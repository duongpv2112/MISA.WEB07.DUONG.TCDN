using Dapper;
using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.Common.Enums;
using MISA.WEB07.DUONGPV.TCDN.Common.Utilities;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Dynamic;

namespace MISA.WEB07.DUONGPV.TCDN.DL
{
    public class ReceiptPaymentDL : BaseDL<ReceiptPayment>, IReceiptPaymentDL
    {
        /// <summary>
        /// Lấy danh sách bản ghi cho phép tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <param name="orderBy">Sắp xếp</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách bản ghi thỏa mãn điều kiện tìm kiếm và phân trang
        /// + Tổng số bản ghi thỏa mãn điều kiện
        /// + Tổng số trang
        /// + Trang hiện tại
        /// + Số bản ghi trang hiện tại
        /// + Keyword tìm kiếm hiện tại</returns>
        /// Created by: DUONGPV (04/10/2022)
        public override async Task<PagingData<ReceiptPayment>> GetDataFilter(string? keyword = "", int? filter = null, int pageSize = 10, int pageNumber = 1, string? orderBy = "")
        {
            // Khai báo tên stored procedure GET ALL

            var tableName = "";
            switch (filter)
            {
                case null:
                    tableName = "ReceiptPayment";
                    break;
                case 0:
                    tableName = "Receipt";
                    break;
                case 1:
                    tableName = "Payment";
                    break;
                default:
                    tableName = "ReceiptPayment";
                    break;
            }

            //string getDataFilterStoredProcedureName = $"Func_{tableName}_GetPaging";
            //string getTotalRecordStoredProcedureName = $"Func_{tableName}_TotalRecord";
            //string getTotalMoneyStoredProcedureName = $"Func_{tableName}_TotalMoney";
            string sqlCommand = $"select * from func_{tableName}_getpaging(@v_limit, @v_offset, @v_keyword, @v_sort); " +
                $"select * from func_{tableName}_totalrecord(@v_keyword); " +
                $"select * from func_{tableName}_totalmoney(@v_keyword);";

            var parametersGetPaging = new DynamicParameters();
            parametersGetPaging.Add("@v_offset", (pageNumber - 1) * pageSize);
            parametersGetPaging.Add("@v_limit", pageSize);
            parametersGetPaging.Add("@v_keyword", keyword == null ? "" : keyword);
            parametersGetPaging.Add("@v_sort", orderBy == null ? "" : orderBy);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure
            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResults = await npgSqlConnection.QueryMultipleAsync(sqlCommand, parametersGetPaging);
                //var multipleResults = await npgSqlConnection.QueryMultipleAsync(getDataFilterStoredProcedureName, parametersGetPaging, commandType: CommandType.StoredProcedure);
                //var totalRecord = await npgSqlConnection.QueryFirstAsync<long>(getTotalRecordStoredProcedureName, parametersTotalRecord, commandType: CommandType.StoredProcedure);
                //var totalMoney = await npgSqlConnection.QueryFirstAsync<long>(getTotalMoneyStoredProcedureName, parametersGetPaging, commandType: CommandType.StoredProcedure);
                if (multipleResults != null)
                {
                    var listRecord = multipleResults.Read<dynamic>().ToList();
                    var totalRecord = multipleResults.Read<long>().Single();
                    var totalMoney = multipleResults.Read<long>().Single();
                    //var listRecord = multipleResults.ToList();
                    int totalPage = 0;
                    if ((int)totalRecord % pageSize != 0)
                    {
                        totalPage = (int)totalRecord / pageSize + 1;
                    }
                    else { totalPage = (int)totalRecord / pageSize; }
                    var summaryData = new
                    {
                        TotalCount = totalRecord,
                        TotalMoney = totalMoney
                    };
                    return new PagingData<ReceiptPayment>()
                    {
                        Data = listRecord,
                        TotalCount = totalRecord,
                        TotalPage = totalPage,
                        CurrentPage = pageNumber,
                        CurrentRecord = pageSize,
                        KeyWord = keyword,
                        Filter = filter,
                        SummaryData = summaryData
                    };
                }
                return new PagingData<ReceiptPayment>()
                {
                    Data = new List<dynamic>(),
                    TotalCount = 0,
                    TotalPage = 0,
                    CurrentPage = 0,
                    CurrentRecord = 0,
                    KeyWord = "",
                    Filter = null,
                    SummaryData = new { }
                };
            }
        }

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm</param> 
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi được thêm thành công hay thất bại(true, false)</returns>
        /// Created by: DUONGPV (04/10/2022)
        public async Task<Guid> InsertOneRecord(ReceiptPaymentDTO record, int typeRecord)
        {
            // Khai báo tên stored procedure

            var tableNamePrimary = "";
            var tableNameReference = "";
            switch (typeRecord)
            {
                case (int)TypeVoucher.Receipt:
                    tableNamePrimary = "Receipt";
                    tableNameReference = "ReceiptDetail";
                    break;
                case (int)TypeVoucher.Payment:
                    tableNamePrimary = "Payment";
                    tableNameReference = "PaymentDetail";
                    break;
                default:
                    break;
            }

            string insertPrimaryStoredProcedureName = $"Func_{tableNamePrimary}_Insert";
            string insertReferenceStoredProcedureName = $"Func_{tableNameReference}_Insert";

            // Chuẩn bị tham số đầu vào cho stored procedure
            Guid newGuid = Guid.NewGuid();

            var propertiesReceiptPayment = typeof(ReceiptPayment).GetProperties();
            var parametersReceiptPayment = new DynamicParameters();
            foreach (var property in propertiesReceiptPayment)
            {
                string propertyName = $"@v_{property.Name}";
                var propertyValue = property.GetValue(record.receiptPayment);
                parametersReceiptPayment.Add(propertyName, propertyValue);
            }

            var keyReceiptPaymentProperty = typeof(ReceiptPayment).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parametersReceiptPayment.Add($"@v_{keyReceiptPaymentProperty?.Name}", newGuid);

            bool isInsertReceiptPayment = false;
            bool isInsertReceiptPaymentDetail = false;

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                npgSqlConnection.Open();
                isInsertReceiptPayment = await npgSqlConnection.QueryFirstAsync<bool>(insertPrimaryStoredProcedureName, parametersReceiptPayment, commandType: System.Data.CommandType.StoredProcedure);
                if (record.receiptPaymentDetails?.Count > 0)
                {
                    using (NpgsqlTransaction transaction = npgSqlConnection.BeginTransaction())
                    {
                        try
                        {
                            foreach (var dataItem in record.receiptPaymentDetails)
                            {
                                var propertiesReceiptPaymentDetail = typeof(ReceiptPaymentDetail).GetProperties();
                                var parametersReceiptPaymentDetail = new DynamicParameters();
                                foreach (var property in propertiesReceiptPaymentDetail)
                                {
                                    string propertyName = $"@v_{property.Name}";
                                    var propertyValue = property.GetValue(dataItem);
                                    parametersReceiptPaymentDetail.Add(propertyName, propertyValue);
                                }
                                var keyReceiptPaymentDetailProperty = typeof(ReceiptPaymentDetail).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
                                parametersReceiptPaymentDetail.Add($"@v_{keyReceiptPaymentDetailProperty?.Name}", Guid.NewGuid());

                                var keyRefReceiptPaymentDetailProperty = typeof(ReceiptPaymentDetail).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(ForeignKeyAttribute), true).Count() > 0);
                                parametersReceiptPaymentDetail.Add($"@v_{keyRefReceiptPaymentDetailProperty?.Name}", newGuid);

                                var insertCommand = $"SELECT * FROM Func_{tableNameReference}_Insert(@v_accouting_id, @v_reason, @v_debt_account, @v_credit_account, @v_amount_money, @v_account_object_id, @v_account_object_name, @v_receipt_payment_id, @v_created_date, @v_created_by, @v_modified_date,  @v_modified_by);";

                                isInsertReceiptPaymentDetail = await npgSqlConnection.QueryFirstAsync<bool>(insertReferenceStoredProcedureName, parametersReceiptPaymentDetail, commandType: System.Data.CommandType.StoredProcedure);
                            }
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                        }
                    }
                }
                else isInsertReceiptPaymentDetail = true;
            }
            return isInsertReceiptPayment ? isInsertReceiptPaymentDetail ? newGuid : Guid.Empty : Guid.Empty;
        }

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<dynamic> GetOneRecord(Guid id, int typeRecord)
        {
            // Khai báo tên stored procedure INSERT
            var tableNamePrimary = "";
            var tableNameReference = "";
            switch (typeRecord)
            {
                case 0:
                    tableNamePrimary = "Receipt";
                    tableNameReference = "ReceiptDetail";
                    break;
                case 1:
                    tableNamePrimary = "Payment";
                    tableNameReference = "PaymentDetail";
                    break;
                default:
                    break;
            }
            string getOneReceiptPaymentStoredProcedureName = $"Func_{tableNamePrimary}_GetOne";
            string getOneReceiptPaymentDetailStoredProcedureName = $"Func_{tableNameReference}_GetOne";

            // Chuẩn bị tham số đầu vào của stored procedure
            var parameterReceiptPayments = new DynamicParameters();
            var keyReceiptPaymentProperty = typeof(ReceiptPayment).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parameterReceiptPayments.Add($"@v_{keyReceiptPaymentProperty?.Name}", id);

            var parameterReceiptPaymentDetails = new DynamicParameters();
            var keyReceiptPaymentDetailProperty = typeof(ReceiptPaymentDetail).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(ForeignKeyAttribute), true).Count() > 0);
            parameterReceiptPaymentDetails.Add($"@v_{keyReceiptPaymentDetailProperty?.Name}", id);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var recordReceiptPayment = await npgSqlConnection.QueryFirstOrDefaultAsync<dynamic>(getOneReceiptPaymentStoredProcedureName, parameterReceiptPayments, commandType: System.Data.CommandType.StoredProcedure);
                var recordReceiptPaymentDetail = await npgSqlConnection.QueryAsync<dynamic>(getOneReceiptPaymentDetailStoredProcedureName, parameterReceiptPaymentDetails, commandType: System.Data.CommandType.StoredProcedure);
                dynamic record = new ExpandoObject();
                record.receiptPayment = recordReceiptPayment;
                record.receiptPaymentDetails = recordReceiptPaymentDetail;
                return record;
            }
        }

        /// <summary>
        /// Cập nhật thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<Guid> UpdateOneRecord(Guid id, ReceiptPaymentDTO record, int typeRecord)
        {
            // Khai báo tên stored procedure INSERT
            var tableNamePrimary = "";
            var tableNameReference = "";
            switch (typeRecord)
            {
                case 0:
                    tableNamePrimary = "Receipt";
                    tableNameReference = "ReceiptDetail";
                    break;
                case 1:
                    tableNamePrimary = "Payment";
                    tableNameReference = "PaymentDetail";
                    break;
                default:
                    break;
            }

            string updateReceiptPaymentStoredProcedureName = $"Func_{tableNamePrimary}_Update";
            string insertReceiptPaymentDetailStoredProcedureName = $"Func_{tableNameReference}_Insert";
            string updateReceiptPaymentDetailStoredProcedureName = $"Func_{tableNameReference}_Update";
            string deleteReceiptPaymentDetailStoredProcedureName = $"Func_{tableNameReference}_Delete";

            // Chuẩn bị tham số đầu vào của stored procedure
            var propertiesReceiptPayment = typeof(ReceiptPayment).GetProperties();
            var parametersReceiptPayment = new DynamicParameters();
            foreach (var property in propertiesReceiptPayment)
            {
                string propertyName = $"@v_{property.Name}";
                var propertyValue = property.GetValue(record.receiptPayment);
                parametersReceiptPayment.Add(propertyName, propertyValue);
            }

            var keyReceiptPaymentProperty = typeof(ReceiptPayment).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parametersReceiptPayment.Add($"@v_{keyReceiptPaymentProperty?.Name}", id);

            bool isUpdateReceiptPayment = false;
            bool isUpdateReceiptPaymentDetail = false;

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                npgSqlConnection.Open();

                if (record.receiptPaymentDetails?.Count > 0)
                {
                    isUpdateReceiptPayment = await npgSqlConnection.QueryFirstAsync<bool>(updateReceiptPaymentStoredProcedureName, parametersReceiptPayment, commandType: System.Data.CommandType.StoredProcedure);

                    using (NpgsqlTransaction transaction = npgSqlConnection.BeginTransaction())
                    {
                        try
                        {
                            var propertiesReceiptPaymentDetail = typeof(ReceiptPaymentDetail).GetProperties();
                            var parametersReceiptPaymentDetail = new DynamicParameters();
                            foreach (var dataItem in record.receiptPaymentDetails)
                            {
                                switch (dataItem.state)
                                {
                                    case StateCode.Delete:
                                        var keyDeleteReceiptPaymentDetailProperty = typeof(ReceiptPaymentDetail).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
                                        parametersReceiptPaymentDetail.Add($"@v_{keyDeleteReceiptPaymentDetailProperty?.Name}", dataItem.accounting_id);
                                        isUpdateReceiptPaymentDetail = await npgSqlConnection.QueryFirstAsync<bool>(deleteReceiptPaymentDetailStoredProcedureName, parametersReceiptPaymentDetail, commandType: System.Data.CommandType.StoredProcedure);
                                        break;
                                    case StateCode.Insert:
                                        foreach (var property in propertiesReceiptPaymentDetail)
                                        {
                                            string propertyName = $"@v_{property.Name}";
                                            var propertyValue = property.GetValue(dataItem);
                                            parametersReceiptPaymentDetail.Add(propertyName, propertyValue);
                                        }
                                        var keyInsertReceiptPaymentDetailProperty = typeof(ReceiptPaymentDetail).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
                                        parametersReceiptPaymentDetail.Add($"@v_{keyInsertReceiptPaymentDetailProperty?.Name}", Guid.NewGuid());

                                        var keyInsertRefReceiptPaymentDetailProperty = typeof(ReceiptPaymentDetail).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(ForeignKeyAttribute), true).Count() > 0);
                                        parametersReceiptPaymentDetail.Add($"@v_{keyInsertRefReceiptPaymentDetailProperty?.Name}", id);

                                        isUpdateReceiptPaymentDetail = await npgSqlConnection.QueryFirstAsync<bool>(insertReceiptPaymentDetailStoredProcedureName, parametersReceiptPaymentDetail, commandType: System.Data.CommandType.StoredProcedure);
                                        break;
                                    case StateCode.Update:
                                        foreach (var property in propertiesReceiptPaymentDetail)
                                        {
                                            string propertyName = $"@v_{property.Name}";
                                            var propertyValue = property.GetValue(dataItem);
                                            parametersReceiptPaymentDetail.Add(propertyName, propertyValue);
                                        }

                                        isUpdateReceiptPaymentDetail = await npgSqlConnection.QueryFirstAsync<bool>(updateReceiptPaymentDetailStoredProcedureName, parametersReceiptPaymentDetail, commandType: System.Data.CommandType.StoredProcedure);
                                        break;
                                    case StateCode.NoChange:
                                        isUpdateReceiptPaymentDetail = true;
                                        break;
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                        }
                    }
                }
                else isUpdateReceiptPaymentDetail = false;
            }
            return isUpdateReceiptPayment ? isUpdateReceiptPaymentDetail ? id : Guid.Empty : Guid.Empty;
        }

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> DeleteOneRecord(Guid id, int typeRecord)
        {
            // Khai báo tên stored procedure INSERT
            var tableNamePrimary = "";
            var tableNameReference = "";
            switch (typeRecord)
            {
                case 0:
                    tableNamePrimary = "Receipt";
                    tableNameReference = "ReceiptDetail";
                    break;
                case 1:
                    tableNamePrimary = "Payment";
                    tableNameReference = "PaymentDetail";
                    break;
                default:
                    break;
            }
            string deleteReceiptPaymentStoredProcedureName = $"Func_{tableNamePrimary}_Delete";

            // Chuẩn bị tham số đầu vào của stored procedure
            var parameterReceiptPayments = new DynamicParameters();
            var keyReceiptPaymentProperty = typeof(ReceiptPayment).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parameterReceiptPayments.Add($"@v_{keyReceiptPaymentProperty?.Name}", id);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                bool status = await npgSqlConnection.QueryFirstOrDefaultAsync<bool>(deleteReceiptPaymentStoredProcedureName, parameterReceiptPayments, commandType: System.Data.CommandType.StoredProcedure);
                return status;
            }
        }

        /// <summary>
        /// Kiểm tra mã code có phải của bản ghi này không
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="accountObjectCode">Mã code của bản ghi cần kiểm tra</param>
        /// <returns>True hoặc False</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> CheckExitsRecord(Guid id, string? receiptPaymentNumber)
        {
            // Khai báo tên stored procedure GET ONE
            string getOneRPStoredProcedureName = $"Func_ReceiptPayment_GetOne";

            // Chuẩn bị tham số đầu vào của stored procedure
            var parameters = new DynamicParameters();
            var keyProperty = typeof(ReceiptPayment).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parameters.Add($"@v_{keyProperty?.Name}", id);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var record = await npgSqlConnection.QueryFirstOrDefaultAsync<ReceiptPayment>(getOneRPStoredProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                bool isExits = record.receipt_payment_number == receiptPaymentNumber;
                return isExits;
            }
        }

        /// <summary>
        /// Kiểm tra thông tin SupplierDetail có tồn tại không
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>True hoặc False</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> CheckExitsDetailRecord(Guid id)
        {
            // Khai báo tên stored procedure GET ONE
            string getOneStoredProcedureName = $"Func_AccountObject_GetOne";

            // Chuẩn bị tham số đầu vào của stored procedure
            var parameters = new DynamicParameters();
            var keyProperty = typeof(AccountObject).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parameters.Add($"@v_{keyProperty?.Name}", id);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var record = await npgSqlConnection.QueryFirstOrDefaultAsync<AccountObject>(getOneStoredProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                bool isExits = record != null && record.account_object_id == id;
                return isExits;
            }
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Mã code mới</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<string> GetNewCode(int typeRecord)
        {
            // Khai báo tên stored procedure INSERT
            var tableNamePrimary = "";
            var tableNameReference = "";
            var ruleCode = "";
            switch (typeRecord)
            {
                case 0:
                    tableNamePrimary = "Receipt";
                    tableNameReference = "ReceiptDetail";
                    ruleCode = "PT-";
                    break;
                case 1:
                    tableNamePrimary = "Payment";
                    tableNameReference = "PaymentDetail";
                    ruleCode = "PC-";
                    break;
                default:
                    break;
            }

            string getNewCodeStoredProcedureName = $"Func_{tableNamePrimary}_GetNewCode";

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                long maxCode = await npgSqlConnection.QueryFirstOrDefaultAsync<long>(getNewCodeStoredProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                string newCode = ruleCode + (maxCode + 1).ToString();

                return newCode;
            }
        }

        /// <summary>
        /// Lấy danh sách bản ghi cần export
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="filter">Giá trị muốn lọc</param>
        /// <param name="orderBy">Sắp xếp</param>
        /// <returns>Danh sách bản ghi được export</returns>
        /// Created by: DUONGPV (04/10/2022)
        public override async Task<List<ReceiptPayment>> ExportData(string? keyword = "", int? filter = null, string? orderBy = "")
        {
            // Khai báo tên stored procedure GET ALL

            var tableName = "";
            switch (filter)
            {
                case null:
                    tableName = "ReceiptPayment";
                    break;
                case 0:
                    tableName = "Receipt";
                    break;
                case 1:
                    tableName = "Payment";
                    break;
                default:
                    tableName = "ReceiptPayment";
                    break;
            }

            string exportDataStoredProcedureName = $"Func_{tableName}_Export";

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parametersExportData = new DynamicParameters();
            parametersExportData.Add("@v_keyword", keyword == null ? "%%" : $"%{keyword}%");
            parametersExportData.Add("@v_sort", orderBy == null ? "%%" : $"%{orderBy}%");

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure
            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResults = await npgSqlConnection.QueryAsync<ReceiptPayment>(exportDataStoredProcedureName, parametersExportData, commandType: CommandType.StoredProcedure);
                return multipleResults.ToList();
            }
        }
    }
}

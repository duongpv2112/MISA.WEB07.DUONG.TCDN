using Dapper;
using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace MISA.WEB07.DUONGPV.TCDN.DL
{
    public class AccountObjectDL : BaseDL<AccountObject>, IAccountObjectDL
    {
        /// <summary>
        /// Thêm mới thông tin một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Bản ghi insert thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> InsertOneRecord(SupplierDTO record)
        {
            // Khai báo tên stored procedure INSERT
            string insertStoredProcedureName = $"Func_AccountObject_Insert";
            string insertConstraintStoredProcedureName = $"Func_SupplierConstraint_Insert";

            // Chuẩn bị tham số đầu vào của stored procedure
            Guid newGuid = Guid.NewGuid();

            var propertiesAccountObject = typeof(AccountObject).GetProperties();
            var parametersAccountObject = new DynamicParameters();
            foreach (var property in propertiesAccountObject)
            {
                string propertyName = $"@v_{property.Name}";
                var propertyValue = property.GetValue(record.accountObject);
                parametersAccountObject.Add(propertyName, propertyValue);
            }

            var keyAccountObjectProperty = typeof(AccountObject).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parametersAccountObject.Add($"@v_{keyAccountObjectProperty?.Name}", newGuid);

            bool isInsertAccountObject = false;
            bool isInsertSupplierConstraint = false;

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                npgSqlConnection.Open();
                isInsertAccountObject = await npgSqlConnection.QueryFirstAsync<bool>(insertStoredProcedureName, parametersAccountObject, commandType: System.Data.CommandType.StoredProcedure);
                if (record.supplierConstraints?.Count > 0)
                {
                    using (NpgsqlTransaction transaction = npgSqlConnection.BeginTransaction())
                    {
                        try
                        {
                            foreach (var dataItem in record.supplierConstraints)
                            {
                                var propertiesSupplierConstraint = typeof(SupplierConstraint).GetProperties();
                                var parametersSupplierConstraint = new DynamicParameters();
                                foreach (var property in propertiesSupplierConstraint)
                                {
                                    string propertyName = $"@v_{property.Name}";
                                    var propertyValue = property.GetValue(dataItem);
                                    parametersSupplierConstraint.Add(propertyName, propertyValue);
                                }

                                var keySupplierConstraintProperty = typeof(SupplierConstraint).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
                                parametersSupplierConstraint.Add($"@v_{keySupplierConstraintProperty?.Name}", newGuid);

                                isInsertSupplierConstraint = await npgSqlConnection.QueryFirstAsync<bool>(insertConstraintStoredProcedureName, parametersSupplierConstraint, commandType: System.Data.CommandType.StoredProcedure);
                            }
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                        }
                    }
                }
                else isInsertSupplierConstraint = true;
            }
            return isInsertAccountObject ? isInsertSupplierConstraint ? true : false : false;
        }

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<dynamic> GetOneRecord(Guid id)
        {
            // Khai báo tên stored procedure INSERT
            string insertAccountObjectStoredProcedureName = $"Func_AccountObject_GetOne";
            string insertConstraintStoredProcedureName = $"Func_SupplierConstraint_GetOne";

            // Chuẩn bị tham số đầu vào của stored procedure
            var parameterAccountObjects = new DynamicParameters();
            var keyAccountObjectProperty = typeof(AccountObject).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parameterAccountObjects.Add($"@v_{keyAccountObjectProperty?.Name}", id);

            var parameterSupplierConstraints = new DynamicParameters();
            var keySupplierConstraintProperty = typeof(SupplierConstraint).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parameterSupplierConstraints.Add($"@v_{keySupplierConstraintProperty?.Name}", id);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var recordAccountObject = await npgSqlConnection.QueryFirstOrDefaultAsync<dynamic>(insertAccountObjectStoredProcedureName, parameterAccountObjects, commandType: System.Data.CommandType.StoredProcedure);
                var recordSupplierConstraint = await npgSqlConnection.QueryAsync<dynamic>(insertConstraintStoredProcedureName, parameterSupplierConstraints, commandType: System.Data.CommandType.StoredProcedure);
                dynamic record = new ExpandoObject();
                record.accountObject = recordAccountObject;
                record.supplierConstraints = recordSupplierConstraint;
                return record;
            }
        }

        /// <summary>
        /// Cập nhật thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> UpdateOneRecord(Guid id, SupplierDTO record)
        {
            // Khai báo tên stored procedure INSERT
            string updateStoredProcedureName = $"Func_AccountObject_Update";
            string deleteConstraintStoredProcedureName = $"Func_SupplierConstraint_Delete";
            string insertConstraintStoredProcedureName = $"Func_SupplierConstraint_Insert";

            // Chuẩn bị tham số đầu vào của stored procedure
            var propertiesAccountObject = typeof(AccountObject).GetProperties();
            var parametersAccountObject = new DynamicParameters();
            foreach (var property in propertiesAccountObject)
            {
                string propertyName = $"@v_{property.Name}";
                var propertyValue = property.GetValue(record.accountObject);
                parametersAccountObject.Add(propertyName, propertyValue);
            }

            var keyAccountObjectProperty = typeof(AccountObject).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parametersAccountObject.Add($"@v_{keyAccountObjectProperty?.Name}", id);

            bool isUpdateAccountObject = false;
            bool isUpdateSupplierConstraint = false;

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                npgSqlConnection.Open();
                isUpdateAccountObject = await npgSqlConnection.QueryFirstAsync<bool>(updateStoredProcedureName, parametersAccountObject, commandType: System.Data.CommandType.StoredProcedure);

                bool isDeleteSupplierConstraint = false;
                var keySupplierConstraintProperty = typeof(SupplierConstraint).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
                var parametersSupplierConstraintDelete = new DynamicParameters();
                parametersSupplierConstraintDelete.Add($"@v_{keySupplierConstraintProperty?.Name}", id);

                isDeleteSupplierConstraint = await npgSqlConnection.QueryFirstAsync<bool>(deleteConstraintStoredProcedureName, parametersSupplierConstraintDelete, commandType: System.Data.CommandType.StoredProcedure);

                if (isDeleteSupplierConstraint)
                {
                    if (record.supplierConstraints?.Count > 0)
                    {
                        using (NpgsqlTransaction transaction = npgSqlConnection.BeginTransaction())
                        {
                            try
                            {
                                foreach (var dataItem in record.supplierConstraints)
                                {
                                    var propertiesSupplierConstraint = typeof(SupplierConstraint).GetProperties();
                                    var parametersSupplierConstraint = new DynamicParameters();
                                    foreach (var property in propertiesSupplierConstraint)
                                    {
                                        string propertyName = $"@v_{property.Name}";
                                        var propertyValue = property.GetValue(dataItem);
                                        parametersSupplierConstraint.Add(propertyName, propertyValue);
                                    }
                                    parametersSupplierConstraint.Add($"@v_{keySupplierConstraintProperty?.Name}", id);

                                    isUpdateSupplierConstraint = await npgSqlConnection.QueryFirstAsync<bool>(insertConstraintStoredProcedureName, parametersSupplierConstraint, commandType: System.Data.CommandType.StoredProcedure);
                                }
                                transaction.Commit();
                            }
                            catch
                            {
                                transaction.Rollback();
                            }
                        }
                    }
                    else isUpdateSupplierConstraint = true;
                }
            }
            return isUpdateAccountObject ? isUpdateSupplierConstraint ? true : false : false;
        }

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> DeleteOneRecord(Guid id)
        {
            // Khai báo tên stored procedure INSERT
            string deleteAccountObjectStoredProcedureName = $"Func_AccountObject_Delete";

            // Chuẩn bị tham số đầu vào của stored procedure
            var parameterAccountObjects = new DynamicParameters();
            var keyAccountObjectProperty = typeof(AccountObject).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
            parameterAccountObjects.Add($"@v_{keyAccountObjectProperty?.Name}", id);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                bool status = await npgSqlConnection.QueryFirstOrDefaultAsync<bool>(deleteAccountObjectStoredProcedureName, parameterAccountObjects, commandType: System.Data.CommandType.StoredProcedure);
                return status;
            }
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã code mới</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<string> GetNewCode()
        {
            // Khai báo tên stored procedure INSERT
            string getNewCodeStoredProcedureName = $"Func_AccountObject_GetNewCode";

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure với tham số đầu vào ở trên

            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                long maxCode = await npgSqlConnection.QueryFirstOrDefaultAsync<long>(getNewCodeStoredProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                string newCode = "NCC-" + (maxCode + 1).ToString();

                return newCode;
            }
        }
    }
}

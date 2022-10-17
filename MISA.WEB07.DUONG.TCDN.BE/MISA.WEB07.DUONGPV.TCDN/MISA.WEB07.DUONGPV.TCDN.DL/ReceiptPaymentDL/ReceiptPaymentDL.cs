using Dapper;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.Common.Utilities;
using Npgsql;
using System.Data;

namespace MISA.WEB07.DUONGPV.TCDN.DL
{
    public class ReceiptPaymentDL : BaseDL<ReceiptPayment>, IReceiptPaymentDL
    {
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

            string getDataFilterStoredProcedureName = $"Func_{tableName}_GetPaging";
            string getTotalRecordStoredProcedureName = $"Func_{tableName}_TotalRecord";
            string getTotalMoneyStoredProcedureName = $"Func_{tableName}_TotalMoney";

            var parametersGetPaging = new DynamicParameters();
            parametersGetPaging.Add("@v_offset", (pageNumber - 1) * pageSize);
            parametersGetPaging.Add("@v_limit", pageSize);
            parametersGetPaging.Add("@v_keyword", keyword == null ? "" : keyword);
            parametersGetPaging.Add("@v_sort", orderBy == null ? "" : orderBy);

            // Chuẩn bị tham số đầu vào cho stored procedure



            var parametersTotalRecord = new DynamicParameters();
            parametersTotalRecord.Add("@v_keyword", keyword == null ? "" : keyword);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure
            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResults = await npgSqlConnection.QueryAsync<dynamic>(getDataFilterStoredProcedureName, parametersGetPaging, commandType: CommandType.StoredProcedure);
                var totalRecord = await npgSqlConnection.QueryFirstAsync<long>(getTotalRecordStoredProcedureName, parametersTotalRecord, commandType: CommandType.StoredProcedure);
                var totalMoney = await npgSqlConnection.QueryFirstAsync<long>(getTotalMoneyStoredProcedureName, parametersGetPaging, commandType: CommandType.StoredProcedure);
                if (multipleResults != null)
                {
                    var listRecord = multipleResults.ToList();
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
    }
}

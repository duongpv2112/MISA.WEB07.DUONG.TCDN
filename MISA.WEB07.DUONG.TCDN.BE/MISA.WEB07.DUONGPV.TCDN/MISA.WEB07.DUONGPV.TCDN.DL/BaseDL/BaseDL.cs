using Dapper;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.Common.Utilities;
using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MISA.WEB07.DUONGPV.TCDN.DL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Method

        /// <summary>
        /// Lấy danh sách bản ghi cho phép tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="filter">Giá trị muốn lọc</param>
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
        public virtual async Task<PagingData<T>> GetDataFilter(string? keyword = "", int? filter = null, int pageSize = 10, int pageNumber = 1, string? orderBy = "")
        {
            // Khai báo tên stored procedure GET ALL
            string tableName = EntityUtilities.GetTableName<T>();
            string getDataFilterStoredProcedureName = $"Func_{tableName}_GetPaging";
            string getTotalRecordStoredProcedureName = $"Func_{tableName}_TotalRecord";

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parametersGetPaging = new DynamicParameters();
            parametersGetPaging.Add("@v_offset", (pageNumber - 1) * pageSize);
            parametersGetPaging.Add("@v_limit", pageSize);
            parametersGetPaging.Add("@v_keyword", keyword == null ? "" : keyword);
            parametersGetPaging.Add("@v_sort", orderBy == null ? "" : orderBy);

            var parametersTotalRecord = new DynamicParameters();
            parametersTotalRecord.Add("@v_keyword", keyword == null ? "" : keyword);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure
            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResults = await npgSqlConnection.QueryAsync<dynamic>(getDataFilterStoredProcedureName, parametersGetPaging, commandType: CommandType.StoredProcedure);
                var totalRecord = await npgSqlConnection.QueryFirstAsync<long>(getTotalRecordStoredProcedureName, parametersTotalRecord, commandType: CommandType.StoredProcedure);
                if (multipleResults != null)
                {
                    var listRecord = multipleResults.ToList();
                    int totalPage = 0;
                    if ((int)totalRecord % pageSize != 0)
                    {
                        totalPage = (int)totalRecord / pageSize + 1;
                    }
                    else { totalPage = (int)totalRecord / pageSize; }
                    return new PagingData<T>()
                    {
                        Data = listRecord,
                        TotalCount = totalRecord,
                        TotalPage = totalPage,
                        CurrentPage = pageNumber,
                        CurrentRecord = pageSize,
                        KeyWord = keyword,
                        Filter = filter
                    };
                }
                return new PagingData<T>()
                {
                    Data = new List<dynamic>(),
                    TotalCount = 0,
                    TotalPage = 0,
                    CurrentPage = 0,
                    CurrentRecord = 0,
                    KeyWord = "",
                    Filter = null
                };
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
        public virtual async Task<List<T>> ExportData(string? keyword = "", int? filter = null, string? orderBy = "")
        {
            // Khai báo tên stored procedure GET ALL
            string tableName = EntityUtilities.GetTableName<T>();
            string getDataFilterStoredProcedureName = $"Func_{tableName}_Export";

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parametersGetPaging = new DynamicParameters();
            parametersGetPaging.Add("@v_keyword", keyword == null ? "" : keyword);
            parametersGetPaging.Add("@v_sort", orderBy == null ? "" : orderBy);

            // Thực hiện gọi vào DB để chạy câu lệnh stored procedure
            using (var npgSqlConnection = new NpgsqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResults = await npgSqlConnection.QueryAsync<T>(getDataFilterStoredProcedureName, parametersGetPaging, commandType: CommandType.StoredProcedure);
                return multipleResults.ToList();
            }
        }

        #endregion
    }
}

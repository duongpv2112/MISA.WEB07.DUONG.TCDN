using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Utilities
{
    /// <summary>
    /// Những hàm dùng chung xử lý entity
    /// </summary>
    public static class EntityUtilities
    {
        /// <summary>
        /// Lấy tên bảng của entity
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của entity</typeparam>
        /// <returns>Tên bảng</returns>
        /// Created by: DUONGPV (25/08/2022)
        public static string GetTableName<T>()
        {
            string tableName = typeof(T).Name;
            var tableAttributes = typeof(T).GetTypeInfo().GetCustomAttributes<MISATableAttribute>();
            if (tableAttributes.Count() > 0)
            {
                tableName = tableAttributes.First().Name;
            }
            return tableName;
        }

        /// <summary>
        /// Lấy tên bảng kết nối của entity
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của entity</typeparam>
        /// <returns>Tên bảng</returns>
        /// Created by: DUONGPV (25/08/2022)
        public static string GetTableNameConstraint<T>()
        {
            string tableNameConstraint = typeof(T).Name;
            var tableAttributes = typeof(T).GetTypeInfo().GetCustomAttributes<MISATableAttribute>();
            if (tableAttributes.Count() > 0)
            {
                tableNameConstraint = tableAttributes.First().NameConstraint;
            }
            return tableNameConstraint;
        }
    }
}

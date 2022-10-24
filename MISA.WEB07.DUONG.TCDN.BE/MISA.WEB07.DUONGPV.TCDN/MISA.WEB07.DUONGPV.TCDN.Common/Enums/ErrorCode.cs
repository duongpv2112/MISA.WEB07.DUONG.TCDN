using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Enums
{
    /// <summary>
    /// Mã lỗi nội bộ
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Lỗi do exception chưa xác định được
        /// </summary>
        Exception = 101,

        /// <summary>
        /// Lỗi do dữ liệu đầu vào bị lỗi
        /// </summary>
        InvalidInput = 102,

        /// <summary>
        /// Lỗi do trùng mã
        /// </summary>
        DuplicateCode = 103,

        /// <summary>
        /// Hành động insert, update, delete, ... bị lỗi
        /// </summary>
        ActionField = 104,
    }
}

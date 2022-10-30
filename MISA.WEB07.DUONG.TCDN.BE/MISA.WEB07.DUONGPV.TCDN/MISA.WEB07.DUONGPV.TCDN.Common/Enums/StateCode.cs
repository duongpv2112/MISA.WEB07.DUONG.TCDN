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
    public enum StateCode
    {
        /// <summary>
        /// Trạng thái chưa thay đổi
        /// </summary>
        NoChange = 0,

        /// <summary>
        /// Trạng thái thêm
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Trạng thái sửa
        /// </summary>
        Update = 2,

        /// <summary>
        /// Trạng thái xóa
        /// </summary>
        Delete = 3,
    }
}

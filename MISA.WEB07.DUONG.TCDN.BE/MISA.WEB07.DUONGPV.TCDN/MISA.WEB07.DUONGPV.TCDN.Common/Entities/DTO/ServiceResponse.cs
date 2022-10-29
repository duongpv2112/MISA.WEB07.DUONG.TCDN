using MISA.WEB07.DUONGPV.TCDN.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO
{
    /// <summary>
    /// Thông tin dữ liệu trả về của một service
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// Thông báo thành công. True nếu thành công, False nếu thất
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Mã lỗi nội bộ
        /// </summary>
        public ErrorCode ErrorCode { get; set; }
    }
}

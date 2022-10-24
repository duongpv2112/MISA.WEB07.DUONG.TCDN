using MISA.WEB07.DUONGPV.TCDN.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO
{
    /// <summary>
    /// Thông tin lỗi trả về cho client
    /// </summary>
    public class SuccessResult
    {
        /// <summary>
        /// Định danh của mã thành công
        /// </summary>
        public int Code { get; set; } = 0;

        /// <summary>
        /// Thông báo cho User. Không bắt buộc, tùy theo đặc thù từng dịch vụ và client tích hợp
        /// </summary>
        public string? UserMsg { get; set; }

        /// <summary>
        /// Thông tin chi tiết hơn về vấn đề. Ví dụ: Đường dẫn mô tả về mã lỗi
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Mã để tra cứu thông tin log trên 
        /// </summary>
        public string? TraceId { get; set; }

        public SuccessResult(string? userMsg, object data, string? traceId)
        {
            Code = 0;
            UserMsg = userMsg;
            Data = data;
            TraceId = traceId;
        }
    }
}

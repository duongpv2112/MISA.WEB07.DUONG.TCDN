using MISA.WEB07.DUONGPV.TCDN.Common.Enums;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO
{
    /// <summary>
    /// Thông tin lỗi trả về cho client
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Định danh của mã lỗi nội bộ
        /// </summary>
        public ErrorCode Code { get; set; }

        /// <summary>
        /// Thông báo cho User. Không bắt buộc, tùy theo đặc thù từng dịch vụ và client tích hợp
        /// </summary>
        public string? UserMsg { get; set; }

        /// <summary>
        /// Thông báo cho Dev. Thông báo ngắn gọn để thông báo cho Dev biết vấn đề đang gặp phải
        /// </summary>
        public object? DevMsg { get; set; }

        /// <summary>
        /// Thông tin chi tiết hơn về vấn đề. Ví dụ: Đường dẫn mô tả về mã lỗi
        /// </summary>
        public string? MoreInfo { get; set; }

        /// <summary>
        /// Mã để tra cứu thông tin log trên 
        /// </summary>
        public string? TraceId { get; set; }
        public ErrorResult(ErrorCode errorCode, string? userMsg, object? devMsg, string? moreInfo, string? traceId)
        {
            Code = errorCode;
            UserMsg = userMsg;
            DevMsg = devMsg;
            MoreInfo = moreInfo;
            TraceId = traceId;
        }
    }
}

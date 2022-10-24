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
        public string? DevMsg { get; set; }

        /// <summary>
        /// Dữ liệu hiển thị cùng
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Thông tin chi tiết hơn về vấn đề. Ví dụ: Đường dẫn mô tả về mã lỗi
        /// </summary>
        public string? MoreInfo { get; set; }

        /// <summary>
        /// Mã để tra cứu thông tin log trên 
        /// </summary>
        public string? TraceId { get; set; }
        public ErrorResult(ErrorCode errorCode, string? userMsg, string? devMsg, object data, string? moreInfo, string? traceId)
        {
            Code = errorCode;
            UserMsg = userMsg;
            DevMsg = devMsg;
            Data = data;
            MoreInfo = moreInfo;
            TraceId = traceId;
        }
    }
}

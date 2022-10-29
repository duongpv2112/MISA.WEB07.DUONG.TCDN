using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.Common.Exceptions;
using Npgsql;
using System.Diagnostics;

namespace MISA.WEB07.DUONGPV.TCDN.API.Helpers
{
    /// <summary>
    /// Class static gồm các hàm xử lý lỗi khi gọi API
    /// </summary>
    public static class HandleError
    {
        /// <summary>
        /// Validate 1 entity trả về đối tượng chứa thông tin lỗi
        /// </summary>
        /// <param name="msException">Đối tượng exception custom gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: DUONGPV (04/10/2022)
        public static ErrorResult? ValidateEntity(MISAException msException, HttpContext httpContext)
        {
            Console.WriteLine(msException.Data);
            return new ErrorResult(
                Common.Enums.ErrorCode.InvalidInput,
                Common.Resources.Resource.UserMsg_ValidateFailed,
                msException.ErrorsMessage,
                "https://google.com.vn",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);

        }

        /// <summary>
        /// Validate 1 entity trả về đối tượng chứa thông tin lỗi
        /// </summary>
        /// <param name="message">Message thông báo</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: DUONGPV (04/10/2022)
        public static ErrorResult? ValidateEntity(object? message, HttpContext httpContext)
        {
            Console.WriteLine(message);
            return new ErrorResult(
                Common.Enums.ErrorCode.InvalidInput,
                Common.Resources.Resource.UserMsg_ValidateFailed,
                message,
                "https://google.com.vn",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);

        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp exception
        /// </summary>
        /// <param name="exception">Đối tượng exception gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: DUONGPV (04/10/2022)
        public static ErrorResult? GenerateExceptionResult(Exception exception, HttpContext httpContext)
        {
            Console.WriteLine(exception.Message);
            return new ErrorResult(
                Common.Enums.ErrorCode.Exception,
                Common.Resources.Resource.UserMsg_Exception,
                Common.Resources.Resource.DevMsg_Exception,
                "https://google.com.vn",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp lỗi trùng mã
        /// </summary>
        /// <param name="nameField">Tên trường bị duplicate</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: DUONGPV (04/10/2022)
        public static ErrorResult? GenerateDuplicateCodeErrorResult(object? nameField, HttpContext httpContext)
        {
            Console.WriteLine(Common.Resources.Resource.DevMsg_DuplicateCode);

            var errorResult = new ErrorResult(
                    Common.Enums.ErrorCode.DuplicateCode,
                    String.Format(Common.Resources.Resource.UserMsg_DuplicateCode, nameField),
                    nameField,
                    "https://google.com.vn",
                    Activity.Current?.Id ?? httpContext?.TraceIdentifier);
            return errorResult;
        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp lỗi trùng mã
        /// </summary>
        /// <param name="nameAction">Tên action thực hiện không thành công</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: DUONGPV (04/10/2022)
        public static ErrorResult? AcctionFieldErrorResult(object? nameAction, HttpContext httpContext)
        {
            Console.WriteLine(Common.Resources.Resource.DevMsg_ActionFailed);

            var errorResult = new ErrorResult(
                    Common.Enums.ErrorCode.ActionField,
                    String.Format(Common.Resources.Resource.UserMsg_ActionFailed, nameAction),
                    Common.Resources.Resource.DevMsg_ActionFailed,
                    "https://google.com.vn",
                    Activity.Current?.Id ?? httpContext?.TraceIdentifier);
            return errorResult;
        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp lỗi trùng mã
        /// </summary>
        /// <param name="npgsqlException">Đối tượng exception của DB gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: DUONGPV (25/08/2022)
        public static ErrorResult? GenerateNpgsqlExceptionResult(NpgsqlException npgsqlException, HttpContext httpContext)
        {
            Console.WriteLine(npgsqlException.Message);
            return new ErrorResult(
                Common.Enums.ErrorCode.Exception,
                Common.Resources.Resource.UserMsg_Exception,
                Common.Resources.Resource.DevMsg_Exception,
                "https://google.com.vn",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        }
    }
}

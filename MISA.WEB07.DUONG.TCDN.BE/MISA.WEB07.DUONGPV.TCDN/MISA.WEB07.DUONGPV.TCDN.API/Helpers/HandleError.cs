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
        /// Created by: DUONGPV (25/08/2022)
        public static ErrorResult? ValidateEntity(MISAException msException, HttpContext httpContext)
        {
            Console.WriteLine(msException.Data);
            return new ErrorResult(
                Common.Enums.ErrorCode.InvalidInput,
                Common.Resources.Resource.UserMsg_ValidateFailed,
                Common.Resources.Resource.DevMsg_ValidateFailed,
                msException.Data,
                "https://google.com.vn",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);

        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp exception
        /// </summary>
        /// <param name="exception">Đối tượng exception gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: DUONGPV (25/08/2022)
        public static ErrorResult? GenerateExceptionResult(Exception exception, HttpContext httpContext)
        {
            Console.WriteLine(exception.Message);
            return new ErrorResult(
                Common.Enums.ErrorCode.Exception,
                Common.Resources.Resource.UserMsg_Exception,
                Common.Resources.Resource.DevMsg_Exception,
                "Catched an exception",
                "https://google.com.vn",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp lỗi trùng mã
        /// </summary>
        /// <param name="exception">Đối tượng exception gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        /// Created by: DUONGPV (25/08/2022)
        //public static ErrorResult? GenerateDuplicateCodeErrorResult(NpgsqlException npgsqlException, HttpContext httpContext)
        //{
        //    if (npgsqlException.ErrorCode == NpgsqlEr.DuplicateKeyEntry)
        //    {
        //        var errorResult = new ErrorResult(
        //            Common.Enums.ErrorCode.DuplicateCode,
        //            Common.Resouces.Resouces.ErrorMessageDuplicate,
        //            $"{mySqlException.Message}",
        //            "https://google.com.vn",
        //            Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        //        return errorResult;
        //    }

        //    Console.WriteLine(mySqlException.Message);
        //    return new ErrorResult(
        //        Common.Enums.ErrorCode.Exception,
        //        Common.Resouces.Resouces.ErrorMessageException,
        //        "Catched an exception",
        //        "https://google.com.vn",
        //        Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        //}
    }
}

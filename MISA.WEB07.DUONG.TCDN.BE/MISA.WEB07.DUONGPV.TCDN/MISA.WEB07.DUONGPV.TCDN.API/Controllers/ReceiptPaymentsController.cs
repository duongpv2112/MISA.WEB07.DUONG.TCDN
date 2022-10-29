using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.DUONGPV.TCDN.API.BaseControllers;
using MISA.WEB07.DUONGPV.TCDN.API.Helpers;
using MISA.WEB07.DUONGPV.TCDN.BL;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.Common.Exceptions;
using Npgsql;

namespace MISA.WEB07.DUONGPV.TCDN.API.Controllers
{
    public class ReceiptPaymentsController : BasesController<ReceiptPayment>
    {
        #region Field

        private IReceiptPaymentBL _receiptPaymentBL;

        #endregion

        #region Constructor

        public ReceiptPaymentsController(IReceiptPaymentBL receiptPaymentBL) : base(receiptPaymentBL)
        {
            _receiptPaymentBL = receiptPaymentBL;
        }

        #region Method

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm</param> 
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi được thêm thành công hay thất bại(true, false)</returns>
        /// Created by: DUONGPV (04/10/2022)
        [HttpPost]
        public async Task<IActionResult> InsertOneRecord([FromBody] ReceiptPaymentDTO record, [FromQuery] int typeRecord)
        {
            try
            {
                ServiceResponse serviceResponse = await _receiptPaymentBL.InsertOneRecord(record, typeRecord);

                if (serviceResponse.IsSuccess)
                {
                    if (serviceResponse.ErrorCode == Common.Enums.ErrorCode.ActionField)
                    {
                        return StatusCode(StatusCodes.Status200OK, HandleError.AcctionFieldErrorResult(Common.Resources.Resource.InsertAction, HttpContext));
                    }
                    return StatusCode(StatusCodes.Status201Created, new
                    {
                        Code = 0,
                        Data = serviceResponse.Data,
                        Message = Common.Resources.Resource.InsertRecordSuccess
                    });
                }
                else
                {
                    if (serviceResponse.ErrorCode == Common.Enums.ErrorCode.DuplicateCode)
                    {
                        return StatusCode(StatusCodes.Status200OK, HandleError.GenerateDuplicateCodeErrorResult(serviceResponse.Data, HttpContext));
                    }
                    else if (serviceResponse.ErrorCode == Common.Enums.ErrorCode.InvalidInput)
                    {
                        return StatusCode(StatusCodes.Status200OK, HandleError.ValidateEntity(serviceResponse.Data, HttpContext));
                    }
                    return StatusCode(StatusCodes.Status200OK, HandleError.AcctionFieldErrorResult(Common.Resources.Resource.InsertAction, HttpContext));
                }
            }
            catch (MISAException msException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.ValidateEntity(msException, HttpContext));
            }
            catch (NpgsqlException npgsqlException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateNpgsqlExceptionResult(npgsqlException, HttpContext));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception, HttpContext));
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneRecord(Guid id, [FromQuery] int typeRecord)
        {
            try
            {
                var record = await _receiptPaymentBL.GetOneRecord(id, typeRecord);

                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, record);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, exception.Message);
            }
        }

        /// <summary>
        /// Cập nhật thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneRecord([FromRoute] Guid id, [FromBody] ReceiptPaymentDTO record, [FromQuery] int typeRecord)
        {
            try
            {
                ServiceResponse serviceResponse = await _receiptPaymentBL.UpdateOneRecord(id, record, typeRecord);

                if (serviceResponse.IsSuccess)
                {
                    if (serviceResponse.ErrorCode == Common.Enums.ErrorCode.ActionField)
                    {
                        return StatusCode(StatusCodes.Status200OK, HandleError.AcctionFieldErrorResult(Common.Resources.Resource.UpdateAction, HttpContext));
                    }
                    return StatusCode(StatusCodes.Status201Created, new
                    {
                        Code = 0,
                        Data = serviceResponse.Data,
                        Message = Common.Resources.Resource.UpdateRecordSuccess
                    });
                }
                else
                {
                    if (serviceResponse.ErrorCode == Common.Enums.ErrorCode.DuplicateCode)
                    {
                        return StatusCode(StatusCodes.Status200OK, HandleError.GenerateDuplicateCodeErrorResult(serviceResponse.Data, HttpContext));
                    }
                    else if (serviceResponse.ErrorCode == Common.Enums.ErrorCode.InvalidInput)
                    {
                        return StatusCode(StatusCodes.Status200OK, HandleError.ValidateEntity(serviceResponse.Data, HttpContext));
                    }
                    return StatusCode(StatusCodes.Status200OK, HandleError.AcctionFieldErrorResult(Common.Resources.Resource.UpdateAction, HttpContext));
                }
            }
            catch (MISAException msException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.ValidateEntity(msException, HttpContext));
            }
            catch (NpgsqlException npgsqlException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateNpgsqlExceptionResult(npgsqlException, HttpContext));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception, HttpContext));
            }
        }

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneRecord([FromRoute] Guid id, [FromQuery] int typeRecord)
        {
            try
            {
                bool status = await _receiptPaymentBL.DeleteOneRecord(id, typeRecord);

                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, status);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, exception.Message);
            }
        }

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        [HttpGet("GetNewCode")]
        public async Task<IActionResult> GetNewCode([FromQuery] int typeRecord)
        {
            try
            {
                string newCode = await _receiptPaymentBL.GetNewCode(typeRecord);

                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, newCode);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, exception.Message);
            }
        }

        #endregion

        #endregion
    }
}

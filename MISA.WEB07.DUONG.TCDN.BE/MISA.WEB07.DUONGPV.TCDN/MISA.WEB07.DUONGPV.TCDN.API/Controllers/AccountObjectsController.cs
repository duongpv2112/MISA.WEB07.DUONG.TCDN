using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.DUONGPV.TCDN.API.BaseControllers;
using MISA.WEB07.DUONGPV.TCDN.BL;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.Common.Utilities;
using MISA.WEB07.DUONGPV.TCDN.DL;
using Npgsql;
using System.Data;

namespace MISA.WEB07.DUONGPV.TCDN.API.Controllers
{
    public class AccountObjectsController : BasesController<AccountObject>
    {
        #region Field

        private IAccountObjectBL _accountObjectBL;

        #endregion

        #region Constructor

        #endregion


        public AccountObjectsController(IAccountObjectBL accountObjectBL) : base(accountObjectBL)
        {
            _accountObjectBL = accountObjectBL;
        }

        #region Method

        /// <summary>
        /// Thêm mới thông tin bản ghi
        /// </summary>
        /// <returns>Bản ghi được insert thành công hay thất bại</returns>
        /// Created by: DUONGPV (04/10/2022)
        [HttpPost]
        public async Task<IActionResult> InsertOneRecord([FromBody] SupplierDTO record)
        {
            try
            {
                bool InsertSucces = await _accountObjectBL.InsertOneRecord(record);

                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, InsertSucces);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, exception.Message);
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneRecord(Guid id)
        {
            try
            {
                var record = await _accountObjectBL.GetOneRecord(id);

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
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneRecord([FromRoute] Guid id, [FromBody] SupplierDTO record)
        {
            try
            {
                bool status = await _accountObjectBL.UpdateOneRecord(id, record);

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
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneRecord([FromRoute] Guid id)
        {
            try
            {
                bool status = await _accountObjectBL.DeleteOneRecord(id);

                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, status);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, exception.Message);
            }
        }

        #endregion

    }
}

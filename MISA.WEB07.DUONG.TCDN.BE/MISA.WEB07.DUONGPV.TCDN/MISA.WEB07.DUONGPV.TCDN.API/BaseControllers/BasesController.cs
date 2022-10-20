using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.DUONGPV.TCDN.BL;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MISA.WEB07.DUONGPV.TCDN.API.BaseControllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách bản ghi cho phép tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="filter">Giá trị cần lọc</param> 
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <param name="orderBy">Sắp xếp</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách bản ghi thỏa mãn điều kiện tìm kiếm và phân trang
        /// + Tổng số bản ghi thỏa mãn điều kiện
        /// + Tổng số trang
        /// + Trang hiện tại
        /// + Số bản ghi trang hiện tại
        /// + Keyword tìm kiếm hiện tại</returns>
        /// Created by: DUONGPV (04/10/2022)
        [HttpGet]
        public virtual async Task<IActionResult> GetDataFilter(
            [FromQuery] string? keyword,
            [FromQuery] int? filter,
            [FromQuery] int pageSize,
            [FromQuery] int pageNumber,
            [FromQuery] string? orderBy
            )
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _baseBL.GetDataFilter(keyword, filter, pageSize, pageNumber, orderBy));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "001");
            }
        }

        /// <summary>
        /// Lấy danh sách bản ghi cần export
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="filter">Giá trị muốn lọc</param>
        /// <param name="orderBy">Sắp xếp</param>
        /// <returns>Danh sách bản ghi được export</returns>
        /// Created by: DUONGPV (04/10/2022)
        [HttpPost("ExportData")]
        public virtual async Task<IActionResult> ExportData([FromBody] ExportDataDTO export)
        {
            try
            {
                byte[] byteArr = await _baseBL.ExportData(export);
                string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return new FileContentResult(byteArr, mimeType)
                {
                    FileDownloadName = export.FileNameDownload
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "001");
            }
        }

        #endregion
    }
}

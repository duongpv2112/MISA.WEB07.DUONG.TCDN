using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;

namespace MISA.WEB07.DUONGPV.TCDN.BL
{
    public interface IAccountObjectBL : IBaseBL<AccountObject>
    {
        /// <summary>
        /// Thêm mới thông tin một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Bản ghi insert thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<ServiceResponse> InsertOneRecord(SupplierDTO record);

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<dynamic> GetOneRecord(Guid id);

        /// <summary>
        /// Cập nhật thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<ServiceResponse> UpdateOneRecord(Guid id, SupplierDTO record);

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<bool> DeleteOneRecord(Guid id);

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã code mới</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<string> GetNewCode();
    }
}

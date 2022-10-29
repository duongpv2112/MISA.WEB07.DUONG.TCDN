using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;

namespace MISA.WEB07.DUONGPV.TCDN.DL
{
    public interface IAccountObjectDL : IBaseDL<AccountObject>
    {
        /// <summary>
        /// Thêm mới thông tin một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Bản ghi insert thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<Guid> InsertOneRecord(SupplierDTO record);

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
        public Task<Guid> UpdateOneRecord(Guid id, SupplierDTO record);

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

        /// <summary>
        /// Kiểm tra mã code có phải của bản ghi này không
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="accountObjectCode">Mã code của bản ghi cần kiểm tra</param>
        /// <returns>True hoặc False</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<bool> CheckExitsRecord(Guid id, string? accountObjectCode);

        /// <summary>
        /// Kiểm tra thông tin SupplierDetail có tồn tại không
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>True hoặc False</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<bool> CheckExitsDetailRecord(Guid id);
    }
}

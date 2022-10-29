using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;

namespace MISA.WEB07.DUONGPV.TCDN.DL
{
    public interface IReceiptPaymentDL : IBaseDL<ReceiptPayment>
    {
        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm</param> 
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi được thêm thành công hay thất bại(true, false)</returns>
        /// Created by: DUONGPV (04/10/2022)
        public Task<Guid> InsertOneRecord(ReceiptPaymentDTO record, int typeRecord);

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<dynamic> GetOneRecord(Guid id, int typeRecord);

        /// <summary>
        /// Cập nhật thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<Guid> UpdateOneRecord(Guid id, ReceiptPaymentDTO record, int typeRecord);

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<bool> DeleteOneRecord(Guid id, int typeRecord);

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã code mới</returns>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// Author: DUONGPV (04/10/2022)
        public Task<string> GetNewCode(int typeRecord);

        /// <summary>
        /// Kiểm tra mã code có phải của bản ghi này không
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="receiptPaymentNumber">Mã code của bản ghi cần kiểm tra</param>
        /// <returns>True hoặc False</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<bool> CheckExitsRecord(Guid id, string? receiptPaymentNumber);

        /// <summary>
        /// Kiểm tra thông tin ReceiptPaymentNumberDetail có tồn tại không
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>True hoặc False</returns>
        /// Author: DUONGPV (04/10/2022)
        public Task<bool> CheckExitsDetailRecord(Guid id);
    }
}

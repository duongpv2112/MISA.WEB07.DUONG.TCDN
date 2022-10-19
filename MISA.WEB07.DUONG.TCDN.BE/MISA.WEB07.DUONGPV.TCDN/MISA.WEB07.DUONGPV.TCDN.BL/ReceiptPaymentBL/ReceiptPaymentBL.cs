using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.BL
{
    public class ReceiptPaymentBL : BaseBL<ReceiptPayment>, IReceiptPaymentBL
    {
        #region Field

        private IReceiptPaymentDL _receiptPaymentDL;

        #endregion

        #region Constructor

        public ReceiptPaymentBL(IReceiptPaymentDL
            receiptPaymentDL) : base(receiptPaymentDL)
        {
            _receiptPaymentDL = receiptPaymentDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm</param> 
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi được thêm thành công hay thất bại(true, false)</returns>
        /// Created by: DUONGPV (04/10/2022)
        public async Task<bool> InsertOneRecord(ReceiptPaymentDTO record, int typeRecord)
        {
            return await _receiptPaymentDL.InsertOneRecord(record, typeRecord);
        }

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<dynamic> GetOneRecord(Guid id, int typeRecord)
        {
            return await _receiptPaymentDL.GetOneRecord(id, typeRecord);
        }

        /// <summary>
        /// Cập nhật thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> UpdateOneRecord(Guid id, ReceiptPaymentDTO record, int typeRecord)
        {
            return await _receiptPaymentDL.UpdateOneRecord(id, record, typeRecord);
        }

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> DeleteOneRecord(Guid id, int typeRecord)
        {
            return await _receiptPaymentDL.DeleteOneRecord(id, typeRecord);
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <param name="typeRecord">Loại bản ghi</param>
        /// <returns>Mã code mới</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<string> GetNewCode(int typeRecord)
        {
            return await _receiptPaymentDL.GetNewCode(typeRecord);
        }

        #endregion
    }
}

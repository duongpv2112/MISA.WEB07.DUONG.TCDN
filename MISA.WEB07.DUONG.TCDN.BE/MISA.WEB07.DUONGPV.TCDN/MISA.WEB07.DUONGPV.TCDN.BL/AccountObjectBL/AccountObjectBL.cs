using MISA.WEB07.DUONGPV.TCDN.BL.Utilities;
using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.Common.Exceptions;
using MISA.WEB07.DUONGPV.TCDN.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.BL
{
    public class AccountObjectBL : BaseBL<AccountObject>, IAccountObjectBL
    {
        #region Field

        private IAccountObjectDL _accountObjectDL;

        #endregion

        #region Constructor

        public AccountObjectBL(IAccountObjectDL
            accountObjectDL) : base(accountObjectDL)
        {
            _accountObjectDL = accountObjectDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Thêm mới thông tin một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Bản ghi insert thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> InsertOneRecord(SupplierDTO record)
        {
            return await _accountObjectDL.InsertOneRecord(record);
        }

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<dynamic> GetOneRecord(Guid id)
        {
            return await _accountObjectDL.GetOneRecord(id);
        }

        /// <summary>
        /// Cập nhật thông tin chi tiết một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần lấy</param>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> UpdateOneRecord(Guid id, SupplierDTO record)
        {
            return await _accountObjectDL.UpdateOneRecord(id, record);
        }

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi cần xóa</param>
        /// <returns>Bản ghi xóa thành công hay thất bại (True, False)</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<bool> DeleteOneRecord(Guid id)
        {
            return await _accountObjectDL.DeleteOneRecord(id);
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã code mới</returns>
        /// Author: DUONGPV (04/10/2022)
        public async Task<string> GetNewCode()
        {
            return await _accountObjectDL.GetNewCode();
        }

        #endregion
    }
}

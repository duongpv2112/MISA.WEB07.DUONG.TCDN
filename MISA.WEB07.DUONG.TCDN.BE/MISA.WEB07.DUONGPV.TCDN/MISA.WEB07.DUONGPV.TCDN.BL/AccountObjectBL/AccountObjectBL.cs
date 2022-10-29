using MISA.WEB07.DUONGPV.TCDN.BL.Utilities;
using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.Common.Enums;
using MISA.WEB07.DUONGPV.TCDN.Common.Exceptions;
using MISA.WEB07.DUONGPV.TCDN.DL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
        public async Task<ServiceResponse> InsertOneRecord(SupplierDTO record)
        {
            var isDuplicate = await _accountObjectDL.CheckDuplicateCode(record?.accountObject?.account_object_code);
            if (isDuplicate)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Data = $"{Common.Resources.Resource.VendorCode} <{record?.accountObject?.account_object_code}>",
                    ErrorCode = Common.Enums.ErrorCode.DuplicateCode,
                };
            }
            ValidateEntity<AccountObject>.Validate(record.accountObject);
            if(record.supplierConstraints.Count > 0)
            {
                foreach(var item in record.supplierConstraints)
                {
                    var isExitsDetailRecord = await _accountObjectDL.CheckExitsDetailRecord(item.supplier_group_id);
                    if (!isExitsDetailRecord)
                    {
                        return new ServiceResponse
                        {
                            IsSuccess = false,
                            Data = string.Format(Common.Resources.Resource.NotExitsSupplierGroup, item.supplier_group_id),
                            ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                        };
                    }
                }
            }
            var isInsertSuccess = await _accountObjectDL.InsertOneRecord(record);
            if (isInsertSuccess != Guid.Empty)
            {
                return new ServiceResponse
                {
                    IsSuccess = true,
                    Data = isInsertSuccess,
                };
            }
            else
            {
                return new ServiceResponse
                {
                    IsSuccess = true,
                    Data = Common.Enums.ErrorCode.ActionField,
                    ErrorCode = Common.Enums.ErrorCode.ActionField,
                };
            }
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
        public async Task<ServiceResponse> UpdateOneRecord(Guid id, SupplierDTO record)
        {
            var isExits = await _accountObjectDL.CheckExitsRecord(id, record?.accountObject?.account_object_code);
            var isDuplicate = await _accountObjectDL.CheckDuplicateCode(record?.accountObject?.account_object_code);
            if (!isExits && isDuplicate)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Data = $"{Common.Resources.Resource.VendorCode} <{record?.accountObject?.account_object_code}>",
                    ErrorCode = Common.Enums.ErrorCode.DuplicateCode,
                };
            }
            ValidateEntity<AccountObject>.Validate(record.accountObject);
            if (record.supplierConstraints.Count > 0)
            {
                foreach (var item in record.supplierConstraints)
                {
                    var isExitsDetailRecord = await _accountObjectDL.CheckExitsDetailRecord(item.supplier_group_id);
                    if (!isExitsDetailRecord)
                    {
                        return new ServiceResponse
                        {
                            IsSuccess = false,
                            Data = string.Format(Common.Resources.Resource.NotExitsSupplierGroup, item.supplier_group_id),
                            ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                        };
                    }
                }
            }
            var isUpdateSuccess = await _accountObjectDL.UpdateOneRecord(id, record);
            if (isUpdateSuccess != Guid.Empty)
            {
                return new ServiceResponse
                {
                    IsSuccess = true,
                    Data = isUpdateSuccess,
                };
            }
            else
            {
                return new ServiceResponse
                {
                    IsSuccess = true,
                    Data = Common.Enums.ErrorCode.ActionField,
                    ErrorCode = Common.Enums.ErrorCode.ActionField,
                };
            }
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

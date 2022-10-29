using MISA.WEB07.DUONGPV.TCDN.BL.Utilities;
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
        public async Task<ServiceResponse> InsertOneRecord(ReceiptPaymentDTO record, int typeRecord)
        {
            var isDuplicate = await _receiptPaymentDL.CheckDuplicateCode(record?.receiptPayment?.receipt_payment_number);
            if (isDuplicate)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Data = record?.receiptPayment?.receipt_payment_number,
                    ErrorCode = Common.Enums.ErrorCode.DuplicateCode,
                };
            }
            if(record?.receiptPayment?.account_object_id != null)
            {
                var isExitsAccountObjectRecord = await _receiptPaymentDL.CheckExitsDetailRecord((Guid)record?.receiptPayment?.account_object_id);
                if (!isExitsAccountObjectRecord)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Data = string.Format(Common.Resources.Resource.NotExitsVendor, (Guid)record?.receiptPayment?.account_object_id),
                        ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                    };
                }
            }
            ValidateEntity<ReceiptPayment>.Validate(record.receiptPayment);
            var accountingDate = record.receiptPayment.accounting_date;
            var receiptPaymentDate = record.receiptPayment.receipt_payment_date;
            if (DateTime.Parse(accountingDate) < DateTime.Parse(receiptPaymentDate))
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Data = string.Format(Common.Resources.Resource.ReceiptPaymentDateBiggerAccountingDate, DateTime.Parse(receiptPaymentDate).ToString("dd/MM/yyyy")),
                    ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                };
            }
            if (record.receiptPaymentDetails.Count > 0)
            {
                foreach (var item in record.receiptPaymentDetails)
                {
                    ValidateEntity<ReceiptPaymentDetail>.Validate(item);

                    if(item.account_object_id != null)
                    {
                        var isExitsDetailRecord = await _receiptPaymentDL.CheckExitsDetailRecord((Guid)item.account_object_id);
                        if (!isExitsDetailRecord)
                        {
                            return new ServiceResponse
                            {
                                IsSuccess = false,
                                Data = string.Format(Common.Resources.Resource.NotExitsVendor, item.account_object_id),
                                ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                            };
                        }
                    }
                }
            }
            else
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Data = Common.Resources.Resource.ErrorListReceiptPaymentDetail,
                    ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                };
            }
            var isInsertSuccess = await _receiptPaymentDL.InsertOneRecord(record, typeRecord);
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
        public async Task<ServiceResponse> UpdateOneRecord(Guid id, ReceiptPaymentDTO record, int typeRecord)
        {
            var isExits = await _receiptPaymentDL.CheckExitsRecord(id, record?.receiptPayment?.receipt_payment_number);
            var isDuplicate = await _receiptPaymentDL.CheckDuplicateCode(record?.receiptPayment?.receipt_payment_number);
            if (!isExits && isDuplicate)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Data = record?.receiptPayment?.receipt_payment_number,
                    ErrorCode = Common.Enums.ErrorCode.DuplicateCode,
                };
            }
            if (record?.receiptPayment?.account_object_id != null)
            {
                var isExitsAccountObjectRecord = await _receiptPaymentDL.CheckExitsDetailRecord((Guid)record?.receiptPayment?.account_object_id);
                if (!isExitsAccountObjectRecord)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Data = string.Format(Common.Resources.Resource.NotExitsVendor, (Guid)record?.receiptPayment?.account_object_id),
                        ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                    };
                }
            }
            ValidateEntity<ReceiptPayment>.Validate(record.receiptPayment);
            var accountingDate = record.receiptPayment.accounting_date;
            var receiptPaymentDate = record.receiptPayment.receipt_payment_date;
            if (DateTime.Parse(accountingDate) < DateTime.Parse(receiptPaymentDate))
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Data = string.Format(Common.Resources.Resource.ReceiptPaymentDateBiggerAccountingDate, DateTime.Parse(receiptPaymentDate).ToString("dd/MM/yyyy")),
                    ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                };
            }
            if (record.receiptPaymentDetails.Count > 0)
            {
                foreach (var item in record.receiptPaymentDetails)
                {
                    ValidateEntity<ReceiptPaymentDetail>.Validate(item);

                    if (item.account_object_id != null)
                    {
                        var isExitsDetailRecord = await _receiptPaymentDL.CheckExitsDetailRecord((Guid)item.account_object_id);
                        if (!isExitsDetailRecord)
                        {
                            return new ServiceResponse
                            {
                                IsSuccess = false,
                                Data = string.Format(Common.Resources.Resource.NotExitsVendor, item.account_object_id),
                                ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                            };
                        }
                    }
                }
            }
            else
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Data = Common.Resources.Resource.ErrorListReceiptPaymentDetail,
                    ErrorCode = Common.Enums.ErrorCode.InvalidInput,
                };
            }
            var isInsertSuccess = await _receiptPaymentDL.UpdateOneRecord(id, record, typeRecord);
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

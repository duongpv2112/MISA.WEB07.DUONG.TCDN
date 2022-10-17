using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.DUONGPV.TCDN.API.BaseControllers;
using MISA.WEB07.DUONGPV.TCDN.BL;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;

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

        #endregion

        #endregion
    }
}

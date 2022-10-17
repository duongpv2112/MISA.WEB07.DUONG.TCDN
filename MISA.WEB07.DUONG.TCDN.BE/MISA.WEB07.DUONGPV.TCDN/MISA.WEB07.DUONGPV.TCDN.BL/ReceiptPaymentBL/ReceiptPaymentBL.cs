using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
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

        #endregion
    }
}

using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
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

        #endregion
    }
}

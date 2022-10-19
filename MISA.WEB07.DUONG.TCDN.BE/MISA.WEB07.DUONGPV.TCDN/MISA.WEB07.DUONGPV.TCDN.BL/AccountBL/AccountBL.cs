using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.BL
{
    public class AccountBL : BaseBL<Account>, IAccountBL
    {
        #region Field

        private IAccountDL _accountDL;

        #endregion

        #region Constructor

        public AccountBL(IAccountDL
            accountDL) : base(accountDL)
        {
            _accountDL = accountDL;
        }

        #endregion

        #region Method

        #endregion
    }
}

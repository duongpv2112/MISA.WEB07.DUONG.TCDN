using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.DUONGPV.TCDN.API.BaseControllers;
using MISA.WEB07.DUONGPV.TCDN.BL;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;

namespace MISA.WEB07.DUONGPV.TCDN.API.Controllers
{
    public class AccountsController : BasesController<Account>
    {
        #region Field

        private IAccountBL _accountBL;

        #endregion

        #region Constructor

        public AccountsController(IAccountBL accountBL) : base(accountBL)
        {
            _accountBL = accountBL;
        }

        #region Method

        #endregion

        #endregion
    }
}

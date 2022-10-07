using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.DUONGPV.TCDN.API.BaseControllers;
using MISA.WEB07.DUONGPV.TCDN.BL;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Utilities;
using MISA.WEB07.DUONGPV.TCDN.DL;
using Npgsql;
using System.Data;

namespace MISA.WEB07.DUONGPV.TCDN.API.Controllers
{
    public class AccountObjectsController : BasesController<AccountObject>
    {
        #region Field

        private IAccountObjectBL _accountObjectBL;

        #endregion

        #region Constructor

        public AccountObjectsController(IAccountObjectBL accountObjectBL) : base(accountObjectBL)
        {
            _accountObjectBL = accountObjectBL;
        }

        #region Method

        #endregion

        #endregion
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.DUONGPV.TCDN.API.BaseControllers;
using MISA.WEB07.DUONGPV.TCDN.BL;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;

namespace MISA.WEB07.DUONGPV.TCDN.API.Controllers
{
    public class SupplierGroupsController : BasesController<SupplierGroup>
    {
        #region Field

        private ISupplierGroupBL _supplierGroupBL;

        #endregion

        #region Constructor

        public SupplierGroupsController(ISupplierGroupBL supplierGroupBL) : base(supplierGroupBL)
        {
            _supplierGroupBL = supplierGroupBL;
        }

        #region Method

        #endregion

        #endregion
    }
}

using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.BL
{
    public class SupplierGroupBL : BaseBL<SupplierGroup>, ISupplierGroupBL
    {
        #region Field

        private ISupplierGroupDL _supplierGroupDL;

        #endregion

        #region Constructor

        public SupplierGroupBL(ISupplierGroupDL
            supplierGroupDL) : base(supplierGroupDL)
        {
            _supplierGroupDL = supplierGroupDL;
        }

        #endregion

        #region Method

        #endregion
    }
}

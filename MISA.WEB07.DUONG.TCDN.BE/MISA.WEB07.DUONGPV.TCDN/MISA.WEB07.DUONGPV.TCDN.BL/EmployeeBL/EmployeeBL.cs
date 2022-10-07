using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.BL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {

        #region Field

        private IEmployeeDL _employeeDL;

        #endregion

        #region Constructor

        public EmployeeBL(IEmployeeDL
            employeeDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
        }

        #endregion

        #region Method

        #endregion

    }
}

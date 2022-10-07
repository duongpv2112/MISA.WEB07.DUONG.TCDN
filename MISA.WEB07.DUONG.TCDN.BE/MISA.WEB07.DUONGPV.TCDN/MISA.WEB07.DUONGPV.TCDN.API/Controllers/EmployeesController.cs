using MISA.WEB07.DUONGPV.TCDN.API.BaseControllers;
using MISA.WEB07.DUONGPV.TCDN.BL;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;

namespace MISA.WEB07.DUONGPV.TCDN.API.Controllers
{
    public class EmployeesController : BasesController<Employee>
    {
        #region Field

        private IEmployeeBL _employeeBL;

        #endregion

        #region Constructor

        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }

        #region Method

        #endregion

        #endregion
    }
}

using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Method
        public Task<PagingData<T>> GetDataFilter(string? keyword, int pageSize = 10, int pageNumber = 1, string? orderBy = "")
        {
            return _baseDL.GetDataFilter(keyword, pageSize, pageNumber, orderBy);
        }
        #endregion
    }
}

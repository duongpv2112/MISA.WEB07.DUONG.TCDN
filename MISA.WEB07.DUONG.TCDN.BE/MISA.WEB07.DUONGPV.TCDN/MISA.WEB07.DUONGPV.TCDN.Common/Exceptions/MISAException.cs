using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Exceptions
{
    /// <summary>
    /// Exception trả về danh sách string lỗi hoặc string lỗi
    /// </summary>
    public class MISAException : Exception
    {
        #region Field

        public IDictionary ErrorsMessage;
        public string ErrorMessage;

        #endregion

        #region Constructor

        /// <summary>
        /// Trả về danh sách string lỗi
        /// </summary>
        /// <param name="errors"></param>
        public MISAException(List<string> errors)
        {
            ErrorsMessage = new Dictionary<string, List<string>>();
            ErrorsMessage.Add("error", errors);
        }

        /// <summary>
        /// Trả về string lỗi
        /// </summary>
        /// <param name="errorMessage"></param>
        public MISAException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        #endregion

        #region Method

        public override IDictionary Data => this.ErrorsMessage;
        public override string Message => this.ErrorMessage;

        #endregion


    }
}

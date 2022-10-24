using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Exceptions
{
    public class MISAException : Exception
    {
        public IDictionary ErrorsMessage;
        public string ErrorMessage;
        public MISAException(List<string> errors)
        {
            ErrorsMessage = new Dictionary<string, List<string>>();
            ErrorsMessage.Add("error", errors);
        }
        public MISAException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override IDictionary Data => this.ErrorsMessage;
        public override string Message => this.ErrorMessage;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Attributes
{
    public class MISAKeyAttribute : Attribute
    {
        public string name;

        public MISAKeyAttribute(string name)
        {
            this.name = name;
        }

        public string Name { get { return name; } }

    }
}

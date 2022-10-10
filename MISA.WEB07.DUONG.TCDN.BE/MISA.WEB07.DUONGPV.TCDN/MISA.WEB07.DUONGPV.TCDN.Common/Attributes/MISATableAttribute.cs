using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Attributes
{
    public class MISATableAttribute : Attribute
    {
        public string name;
        public string nameConstraint;

        public MISATableAttribute(string name)
        {
            this.name = name;
        }

        public MISATableAttribute(string name, string nameConstraint)
        {
            this.name = name;
            this.nameConstraint = nameConstraint;
        }

        public string Name { get { return name; } }

        public string NameConstraint { get { return nameConstraint; } }
    }
}

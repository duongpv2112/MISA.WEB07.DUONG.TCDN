using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO
{
    public class SupplierDTO
    {
        /// <summary>
        /// Nhà cung cấp 
        /// </summary>
        public AccountObject? Supplier { get; set; }
        /// <summary>
        /// Mảng nhóm nhà cung cấp 
        /// </summary>
        public List<dynamic> SupplierGroups { get; set; } = new List<dynamic>();
    }
}

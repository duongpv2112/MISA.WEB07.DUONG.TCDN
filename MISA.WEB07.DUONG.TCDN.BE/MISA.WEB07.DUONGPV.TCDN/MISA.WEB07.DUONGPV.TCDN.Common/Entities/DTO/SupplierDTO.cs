using MISA.WEB07.DUONGPV.TCDN.Common.Utilities;
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
        /// Thông tin bản ghi nhà cung cấp
        /// </summary>
        public AccountObject? accountObject { get; set; }
        /// <summary>
        /// Danh sách bản ghi phụ
        /// </summary>
        public List<SupplierConstraint>? supplierConstraints { get; set; } = new List<SupplierConstraint>();
    }
}

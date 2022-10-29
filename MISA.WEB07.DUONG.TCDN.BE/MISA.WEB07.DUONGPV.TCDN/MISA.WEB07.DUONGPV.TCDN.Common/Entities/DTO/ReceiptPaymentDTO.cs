using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO
{
    /// <summary>
    /// Đối tượng Chứng từ DTO
    /// </summary>
    public class ReceiptPaymentDTO
    {
        /// <summary>
        /// Thông tin bản ghi chứng từ
        /// </summary>
        public ReceiptPayment? receiptPayment { get; set; }

        /// <summary>
        /// Danh sách bản ghi chứng từ chi tiết
        /// </summary>
        public List<ReceiptPaymentDetail>? receiptPaymentDetails { get; set; } = new List<ReceiptPaymentDetail>();
    }
}

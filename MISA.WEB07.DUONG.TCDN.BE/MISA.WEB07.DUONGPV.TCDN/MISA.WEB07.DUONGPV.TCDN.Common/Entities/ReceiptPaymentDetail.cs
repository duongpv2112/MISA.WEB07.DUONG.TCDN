using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities
{
    /// <summary>
    /// Thu chi tiền chi tiết
    /// </summary>
    [MISATable("ReceiptPayment")]
    public class ReceiptPaymentDetail
    {
        #region Property
        /// <summary>
        /// ID Hạch toán
        /// </summary>
        [PrimaryKey("accounting_id")]
        public Guid accounting_id { get; set; }

        /// <summary>
        /// Diễn giải
        /// </summary>
        public string? reason { get; set; }

        /// <summary>
        /// Tài khoản nợ
        /// </summary>
        [IsNotNullOrEmpty("Tài khoản nợ không được trống")]
        public string debt_account { get; set; }

        /// <summary>
        /// Tài khoản có
        /// </summary>
        [IsNotNullOrEmpty("Tài khoản có không được trống")]
        public string credit_account { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        public decimal amount_money { get; set; }

        /// <summary>
        /// ID Đối tượng
        /// </summary>
        public Guid? account_object_id { get; set; }

        /// <summary>
        /// Tên đối tượng
        /// </summary>
        public string? account_object_name { get; set; }

        /// <summary>
        /// ID Chứng từ
        /// </summary>
        [IsNotNullOrEmpty("ID chứng từ không tồn tại")]
        [ForeignKey("receipt_payment_id")]
        public Guid? receipt_payment_id { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public string? created_date { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public string? modified_date { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string? modified_by { get; set; }

        #endregion
    }
}

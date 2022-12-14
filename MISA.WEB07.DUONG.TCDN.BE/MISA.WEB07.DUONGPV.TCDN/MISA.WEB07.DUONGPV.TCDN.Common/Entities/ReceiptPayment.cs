    using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using MISA.WEB07.DUONGPV.TCDN.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities
{
    /// <summary>
    /// Thu chi tiền
    /// </summary>
    [MISATable("ReceiptPayment")]
    public class ReceiptPayment
    {
        #region Property

        /// <summary>
        /// ID Chứng từ
        /// </summary>
        [PrimaryKey("receipt_payment_id")]
        public Guid receipt_payment_id { get; set; }

        /// <summary>
        /// Ngày hạch toán
        /// </summary>
        [IsNotNullOrEmpty("Ngày hạch toán không được để trống")]
        public string accounting_date { get; set; }

        /// <summary>
        /// Ngày chứng từ
        /// </summary>
        [IsNotNullOrEmpty("Ngày chứng từ không được để trống")]
        public string receipt_payment_date { get; set; }

        /// <summary>
        /// Số chứng từ
        /// </summary>
        [IsNotNullOrEmpty("Số chứng từ không được để trống")]
        public string? receipt_payment_number { get; set; }

        /// <summary>
        /// ID Đối tượng
        /// </summary>
        [ForeignKey("account_object_id")]
        public Guid? account_object_id { get; set; }

        /// <summary>
        /// Tên đối tượng
        /// </summary>
        public string? account_object_name { get; set; }

        /// <summary>
        /// Người làm chứng từ
        /// </summary>
        public string? account_object_contact_name { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? address { get; set; }

        /// <summary>
        /// ID Nhân viên
        /// </summary>
        public Guid? employee_id { get; set; }

        /// <summary>
        /// Lý do
        /// </summary>
        public string? reason { get; set; }

        /// <summary>
        /// Số lượng file kèm 
        /// </summary>
        [PositiveNumber("Số lượng file kèm không được nhỏ hơn 0")]
        public int adding_number { get; set; }

        /// <summary>
        /// Tổng tiền
        /// </summary>
        [PositiveNumber("Tổng tiền không được nhỏ hơn 0")]
        public decimal total_money { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public string created_date { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public string modified_date { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string? modified_by { get; set; }

        /// <summary>
        /// Tên đối tượng
        /// </summary>
        public string? account_object_code { get; set; }

        #endregion
    }
}

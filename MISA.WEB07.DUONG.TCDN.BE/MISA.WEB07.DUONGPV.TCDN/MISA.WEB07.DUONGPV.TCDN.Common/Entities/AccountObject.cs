using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using MISA.WEB07.DUONGPV.TCDN.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities
{
    /// <summary>
    /// Đối tượng
    /// </summary>
    [MISATable("AccountObject", "SupplierConstraint")]
    public class AccountObject
    {
        #region Property
        /// <summary>
        /// ID Đối tượng
        /// </summary>
        [PrimaryKey("account_object_id")]
        public Guid account_object_id { get; set; }

        /// <summary>
        /// Mã đối tượng
        /// </summary>
        [IsNotNullOrEmpty("Mã đối tượng không được trống")]
        public string account_object_code { get; set; }

        /// <summary>
        /// Tên đối tượng
        /// </summary>
        [IsNotNullOrEmpty("Tên đối tượng không được trống")]
        public string account_object_name { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? address { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        public string? website { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string? tax_code { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [MISAPhone("Số điện thoại di động")]
        public string? phone_number { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        [MISAPhone("Số điện thoại cố định")]
        public string? telephone_number  { get; set; }

        /// <summary>
        /// Số CMND
        /// </summary>
        public string? identity_number { get; set; }

        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        [DateBiggerCurrent("identity_date")]
        public string? identity_date { get; set; }

        /// <summary>
        /// Nơi cấp CMND 
        /// </summary>
        public string? identity_place { get; set; }

        /// <summary>
        /// ID Nhân viên mua hàng
        /// </summary>
        public Guid? employee_id  { get; set; }

        /// <summary>
        /// Loại nhà cung cấp
        /// </summary>
        public TypeSupplier? supplier_type { get; set; }

        /// <summary>
        /// Tên người liên hệ
        /// </summary>
        public string? contact_name { get; set; }

        /// <summary>
        /// Xưng hô người liên hệ
        /// </summary>
        public Vocative? vocative_contact { get; set; }

        /// <summary>
        /// Xưng hô nhà cung cấp
        /// </summary>
        public Vocative? vocative_supplier { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [MISAEmail("email")]
        public string? email { get; set; }

        /// <summary>
        /// Tên người đại diện pháp luật
        /// </summary>
        public string? representative_name { get; set; }

        /// <summary>
        /// Điều khoản thanh toán
        /// </summary>
        public PaymentTerm? payment_term { get; set; }

        /// <summary>
        /// Số ngày được nợ
        /// </summary>
        public int? number_day_owed { get; set; }

        /// <summary>
        /// Số nợ tối đa
        /// </summary>
        public decimal maximum_debt_amount { get; set; }

        /// <summary>
        /// Tài khoản công nợ phải trả
        /// </summary>
        public string? account_payable { get; set; }

        /// <summary>
        /// Đơn vị
        /// </summary>
        public string? department_name { get; set; }

        /// <summary>
        /// Là nhà cung cấp
        /// </summary>
        public bool? is_supplier { get; set; }

        /// <summary>
        /// Là nhân viên
        /// </summary>
        public bool? is_employee { get; set; }

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

        #endregion
    }
}

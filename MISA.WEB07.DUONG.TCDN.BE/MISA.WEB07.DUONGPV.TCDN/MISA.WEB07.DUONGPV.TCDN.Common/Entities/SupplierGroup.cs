using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities
{
    /// <summary>
    /// Nhóm nhà cung cấp
    /// </summary>
    [MISATable("SupplierGroup")]    
    public class SupplierGroup
    {
        #region Property

        /// <summary>
        /// ID Nhóm nhà cung cấp
        /// </summary>
        [PrimaryKey("supplier_group_id")]
        public Guid supplier_group_id { get; set; }

        /// <summary>
        /// Mã nhóm nhà cung cấp
        /// </summary>
        [Required]
        public string supplier_group_code { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required]
        public string supplier_group_name { get; set; }

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

using MISA.WEB07.DUONGPV.TCDN.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities
{
    /// <summary>
    /// Tài khoản
    /// </summary>
    [MISATable("Account")]
    public class Account
    {
        #region Property

        /// <summary>
        /// ID Tài khoản
        /// </summary>
        [PrimaryKey("account_id")]
        public Guid account_id { get; set; }

        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string account_number { get; set; }

        /// <summary>
        /// Tên tài khoản
        /// </summary>
        [Required]
        public string account_name { get; set; }

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

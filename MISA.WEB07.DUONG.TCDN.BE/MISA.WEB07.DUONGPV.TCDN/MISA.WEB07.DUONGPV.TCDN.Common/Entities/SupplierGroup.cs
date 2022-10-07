﻿using MISA.WEB07.DUONGPV.TCDN.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities
{
    /// <summary>
    /// Nhóm nhà cung cấp
    /// </summary>
    [Table("SupplierGroup")]    
    public class SupplierGroup
    {
        #region Property

        /// <summary>
        /// ID Nhóm nhà cung cấp
        /// </summary>
        [Key]
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
        public DateTime created_date { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? created_by { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime modified_date { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string? modified_by { get; set; }

        #endregion
    }
}
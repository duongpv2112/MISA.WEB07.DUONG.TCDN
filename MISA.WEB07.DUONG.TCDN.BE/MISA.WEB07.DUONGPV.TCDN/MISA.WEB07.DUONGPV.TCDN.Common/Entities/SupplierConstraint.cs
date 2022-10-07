﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities
{
    /// <summary>
    /// Chi tiết nhà cung cấp
    /// </summary>
    [Table("SupplierConstraint")]
    public class SupplierConstraint
    {
        #region Property
        /// <summary>
        /// ID Nhà cung cấp
        /// </summary>
        public Guid supplier_id { get; set; }

        /// <summary>
        /// ID Nhóm nhà cung cấp
        /// </summary>
        public Guid supplier_group_id { get; set; }

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
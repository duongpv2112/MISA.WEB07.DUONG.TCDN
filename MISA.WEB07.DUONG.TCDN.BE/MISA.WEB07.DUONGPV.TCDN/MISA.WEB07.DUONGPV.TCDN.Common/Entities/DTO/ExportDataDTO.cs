using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO
{
    /// <summary>
    /// Đối tượng cột
    /// </summary>
    public class Column {
        /// <summary>
        /// Tên của cột
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Mã của cột
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Độ rộng của cột
        /// </summary>
        public int Width { get; set; }
    }

    /// <summary>
    /// Đối tượng ExportData
    /// </summary>
    public class ExportDataDTO
    {
        /// <summary>
        /// Danh sách các cột
        /// </summary>
        public List<Column> Columns { get; set; }

        /// <summary>
        /// Tiêu đề của File
        /// </summary>
        public string ReportTitle { get; set; }

        /// <summary>
        /// Tên file cần export
        /// </summary>
        public string FileNameDownload { get; set; }

        /// <summary>
        /// Từ khóa tìm kiếm
        /// </summary>
        public string? keyword { get; set; }

        /// <summary>
        /// Giá trị cần lọc
        /// </summary>
        public int? filter { get; set; }

        /// <summary>
        /// Giá trị cần sắp xếp
        /// </summary>
        public string? orderBy { get; set; }
    }
}

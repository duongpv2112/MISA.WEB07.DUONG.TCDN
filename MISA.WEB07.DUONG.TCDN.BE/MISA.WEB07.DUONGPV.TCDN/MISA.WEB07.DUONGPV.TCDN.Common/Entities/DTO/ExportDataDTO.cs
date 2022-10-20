using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO
{
    public class Column { 
        public string Caption { get; set; }
        public string Key { get; set; }
        public int Width { get; set; }
    }

    public class ExportDataDTO
    {
        public List<Column> Columns { get; set; }
        public string ReportTitle { get; set; }
        public string FileNameDownload { get; set; }
        public string? keyword { get; set; }
        public int? filter { get; set; }
        public string? orderBy { get; set; }
    }
}

using Aspose.Cells;
using Microsoft.VisualBasic;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities;
using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using MISA.WEB07.DUONGPV.TCDN.DL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách bản ghi cho phép tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <param name="orderBy">Sắp xếp</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách bản ghi thỏa mãn điều kiện tìm kiếm và phân trang
        /// + Tổng số bản ghi thỏa mãn điều kiện
        /// + Tổng số trang
        /// + Trang hiện tại
        /// + Số bản ghi trang hiện tại
        /// + Keyword tìm kiếm hiện tại</returns>
        /// Created by: DUONGPV (04/10/2022)
        public async Task<PagingData<T>> GetDataFilter(string? keyword, int? filter = null, int pageSize = 10, int pageNumber = 1, string? orderBy = "")
        {
            return await _baseDL.GetDataFilter(keyword, filter, pageSize, pageNumber, orderBy);
        }

        /// <summary>
        /// Lấy danh sách bản ghi cần export
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="filter">Giá trị muốn lọc</param>
        /// <param name="orderBy">Sắp xếp</param>
        /// <returns>Danh sách bản ghi được export</returns>
        /// Created by: DUONGPV (04/10/2022)
        public async Task<byte[]> ExportData(ExportDataDTO export)
        {
            using (var workbook = new Workbook())
            {
                var sheet = workbook.Worksheets[0];

                sheet.Name = export.ReportTitle;

                // Thêm style cho 2 dòng đầu
                Cells cells = sheet.Cells;
                cells.Merge(0, 0, 1, export.Columns.Count);
                cells.Merge(1, 0, 1, export.Columns.Count);

                Style styleRowMerge = workbook.CreateStyle();
                styleRowMerge.Font.Size = 16;
                styleRowMerge.Font.Name = "Arial";
                styleRowMerge.Font.IsBold = true;
                styleRowMerge.VerticalAlignment = TextAlignmentType.Center;
                styleRowMerge.HorizontalAlignment = TextAlignmentType.Center;

                sheet.Cells["A1"].SetStyle(styleRowMerge);
                sheet.Cells["A1"].Value = export.ReportTitle;
                sheet.Cells["A2"].SetStyle(styleRowMerge);

                // Thêm style cho các dòng dữ liệu
                Style styleRowData = workbook.CreateStyle();
                styleRowData.Font.Size = 11;
                styleRowData.Font.Name = "Times New Roman";
                styleRowData.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                styleRowData.Borders[BorderType.TopBorder].Color = Color.Black;
                styleRowData.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                styleRowData.Borders[BorderType.BottomBorder].Color = Color.Black;
                styleRowData.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                styleRowData.Borders[BorderType.LeftBorder].Color = Color.Black;
                styleRowData.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                styleRowData.Borders[BorderType.RightBorder].Color = Color.Black;
                styleRowData.Number = 3;


                // Thêm style cho dòng tên cột
                Style styleRowNameColumn = workbook.CreateStyle();
                styleRowNameColumn.Font.Size = 10;
                styleRowNameColumn.Font.Name = "Arial";
                styleRowNameColumn.Font.IsBold = true;
                styleRowNameColumn.VerticalAlignment = TextAlignmentType.Center;
                styleRowNameColumn.HorizontalAlignment = TextAlignmentType.Center;
                styleRowNameColumn.ForegroundColor = Color.LightGray;
                styleRowNameColumn.Pattern = BackgroundType.Solid;
                styleRowNameColumn.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                styleRowNameColumn.Borders[BorderType.TopBorder].Color = Color.Black;
                styleRowNameColumn.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                styleRowNameColumn.Borders[BorderType.BottomBorder].Color = Color.Black;
                styleRowNameColumn.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                styleRowNameColumn.Borders[BorderType.LeftBorder].Color = Color.Black;
                styleRowNameColumn.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                styleRowNameColumn.Borders[BorderType.RightBorder].Color = Color.Black;

                for (int i = 0; i < export.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        sheet.Cells[2, i].SetStyle(styleRowNameColumn);
                        sheet.Cells[2, i].Value = "STT";
                    }
                    else
                    {
                        sheet.Cells[2, i].SetStyle(styleRowNameColumn);
                        sheet.Cells[2, i].Value = export.Columns[i].Caption;
                        var styleCustom = sheet.Cells[2, i].GetStyle();
                        styleCustom.Number = 14;
                        sheet.Cells[2, i].SetStyle(styleCustom);
                    }
                }

                var rowIdx = 3;
                var stt = 1;

                var datas = await _baseDL.ExportData(export.keyword, export.filter, export.orderBy);

                foreach (var data in datas)
                {

                    for (int i = 0; i < export.Columns.Count; i++)
                    {
                        if (i == 0)
                        {
                            sheet.Cells[rowIdx, i].Value = $"'{stt}";
                            sheet.Cells[rowIdx, i].SetStyle(styleRowData);
                        }
                        else
                        {
                            var property = typeof(T).GetProperties().FirstOrDefault(s => s.Name == export.Columns[i].Key);
                            sheet.Cells[rowIdx, i].Value = property?.GetValue(data);
                            sheet.Cells[rowIdx, i].SetStyle(styleRowData);
                        }
                    }

                    rowIdx++;
                    stt++;
                }

                sheet.AutoFitColumns();
                sheet.Cells.SetRowHeight(1, 14);

                using (var stream = new MemoryStream())
                {
                    workbook.Save(stream, SaveFormat.Xlsx);
                    stream.Position = 0;
                    var content = stream.ToArray();
                    return content;
                }
            }
        }

        #endregion
    }
}

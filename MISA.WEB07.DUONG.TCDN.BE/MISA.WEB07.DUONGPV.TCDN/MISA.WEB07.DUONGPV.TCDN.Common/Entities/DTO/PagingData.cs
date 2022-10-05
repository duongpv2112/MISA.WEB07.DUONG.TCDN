namespace MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO
{
    /// <summary>
    /// Dữ liệu trả về khi tìm kiếm và phân trang
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu của đối tượng trong mảng trả về</typeparam>
    public class PagingData<T>
    {
        /// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Số bản ghi trang hiện tại
        /// </summary>
        public int CurrentRecord { get; set; }

        /// <summary>
        /// Keyword search hiện tại
        /// </summary>
        public string? KeyWord { get; set; }

        /// <summary>
        /// Mảng đối tượng thỏa mãn điều kiện tìm kiếm và phân trang 
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();
    }
}

﻿using MISA.WEB07.DUONGPV.TCDN.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB07.DUONGPV.TCDN.DL
{
    public interface IBaseDL<T>
    {
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
        public Task<PagingData<T>> GetDataFilter(string? keyword, int pageSize = 10, int pageNumber = 1, string? orderBy = "");
    }
}
using QuanLyCongTacChinhSach.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyCongTacChinhSach.DataAccess.ViewModel
{
    public class SearchHoSoGocVM:HoSoGoc
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public int TotalRecords { get; set; }
    }
}
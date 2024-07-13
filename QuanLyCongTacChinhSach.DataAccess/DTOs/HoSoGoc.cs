using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongTacChinhSach.DataAccess.DTOs
{
    public class HoSoGoc
    {
        public int Id_ThongTin { get; set; }
        public int Id_User { get; set; }
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string SoHieuQN { get; set; }
        public DateTime NgaySinh { get; set; }
        public int LoaiHoSo { get; set; }
        public int QuyenSo { get; set; }
        public int TrangSo { get; set; }
        public int SoThuTu { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public int Id_CapQuanTTBo { get; set; }
        public int Id_CoQuanTinh { get; set; }
        public int Id_CoQuanHuyen { get; set; }
        public int Id_CoQuanXa { get; set; }
        public int Id_CoQuanCuThe { get; set; }
        public string MaHoSo { get; set; }
        public string ThongTinChiTiet { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongTacChinhSach.DataAccess.DTOs
{
    public class tb_YeuCauXuLy
    {
        public int? Id_YeuCauXuLy { get; set; }
        public int? Id_NguoiYeuCau { get; set; }
        public string NoiDungyeuCau { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string MaQN { get; set; }
        public string CCCD { get; set; }
        public int? Id_HienTai_Tinh { get; set; }
        public int? Id_HienTai_Huyen { get; set; }
        public int? Id_HienTai_Xa { get; set; }
        public string HienTai_ChiTiet { get; set; }
        public string ChiTietYeuCau { get; set; }
        public string LinkHoSo { get; set; }
        public int? Id_TrangThaiXuLy { get; set; }
    }

}

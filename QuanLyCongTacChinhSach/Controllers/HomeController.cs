using QuanLyCongTacChinhSach.DataAccess.DTOs;
using QuanLyCongTacChinhSach.DataAccess.Factory;
using QuanLyCongTacChinhSach.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCongTacChinhSach.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHoSoGocFactory _hoSoGocFactory;

        public HomeController()
        {
            IRepository<HoSoGoc> repository = new Repository<HoSoGoc>();
            _hoSoGocFactory = new HoSoGocFactory(repository);
        }

        public async Task<ActionResult> Index()
        {
            HoSoGoc hoSoGoc = new HoSoGoc() {
                Id_User = 101,
                MaNV = 1001,
                HoTen = "Nguyen Van A",
                SoHieuQN = "SHQN001",
                NgaySinh = new DateTime(1990, 1, 1),
                LoaiHoSo = 1,
                QuyenSo = 2,
                TrangSo = 3,
                SoThuTu = 1,
                BatDau = new DateTime(2020, 1, 1),
                KetThuc = new DateTime(2020, 12, 31),
                Id_CoQuanTTBo = 1,
                Id_CoQuanTinh = 1,
                Id_CoQuanHuyen = 1,
                Id_CoQuanXa = 1,
                Id_CoQuanCuThe = 1,
                MaHoSo = "HS001",
                TTChiTiet = "Chi tiet ve ho so Nguyen Van A"
            };
            bool isSuccess =await _hoSoGocFactory.Repository.Add(hoSoGoc);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
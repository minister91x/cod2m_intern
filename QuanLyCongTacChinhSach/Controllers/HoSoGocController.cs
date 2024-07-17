using Newtonsoft.Json;
using QuanLyCongTacChinhSach.DataAccess.DTOs;
using QuanLyCongTacChinhSach.DataAccess.Factory;
using QuanLyCongTacChinhSach.DataAccess.IRepositories;
using QuanLyCongTacChinhSach.DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services.Description;

namespace QuanLyCongTacChinhSach.Controllers
{
    public class HoSoGocController : Controller
    {
        // GET: HoSoGoc
        private readonly IHoSoGocFactory _hoSoGocFactory;

        public HoSoGocController()
        {
            IRepository<HoSoGoc> repository = new Repository<HoSoGoc>();
            _hoSoGocFactory = new HoSoGocFactory(repository);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert()
        {
            HoSoGoc hoSoGoc = new HoSoGoc();
            var states = new List<SelectListItem>
            {
                new SelectListItem { Text = "Alabama", Value = "1" },
                new SelectListItem { Text = "Alaska", Value = "2" },
                new SelectListItem { Text = "California", Value = "3" },
                new SelectListItem { Text = "Delaware", Value = "4" },
                new SelectListItem { Text = "Tennessee", Value = "5" },
                new SelectListItem { Text = "Texas", Value = "6" },
                new SelectListItem { Text = "Washington", Value = "7" }
            };
            ViewBag.StateList = new SelectList(states, "Value", "Text");

            return View(hoSoGoc);
        }
        [HttpPost]
        public async Task<ActionResult> Insert(HoSoGoc hoSoGoc)
        {
            bool isSuccess = await _hoSoGocFactory.Repository.Add(hoSoGoc);
            return Json(new { IsSuccess = isSuccess, Message = isSuccess ? "Thêm or update hồ sơ gốc thành công" : "Thêm or update hồ sơ không thành công" });
        }
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var result=await _hoSoGocFactory.Repository.GetById(id);
            return Json(data: result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> Search(SearchHoSoGocVM model)
        {
            var result =await _hoSoGocFactory.Repository.Search(model);
            string itemsJson = JsonConvert.SerializeObject(result.Items);

            // Deserialize back to a proper list of objects
            var items = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(itemsJson);

            var jsonData = new
            {
                data = items,
                TotalRecords = result.TotalRecords
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _hoSoGocFactory.Repository.Delete(id);
            return Json(new { IsSuccess = result, Message = result ? "Xóa hồ sơ gốc thành công.!" : "Xóa hồ sơ không thành công.!" });
        }
        [HttpPost]
        public async Task<ActionResult> Update(HoSoGoc hoSoGoc)
        {
            var result = await _hoSoGocFactory.Repository.Update(hoSoGoc);
            return Json(new { IsSuccess = result, Message = result ? "Cập nhật hồ sơ gốc thành công.!" : "Cập nhật hồ sơ không thành công.!" });
        }
    }
}
﻿using QuanLyCongTacChinhSach.DataAccess.DTOs;
using QuanLyCongTacChinhSach.DataAccess.Factory;
using QuanLyCongTacChinhSach.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
            return Json(new { IsSuccess=isSuccess,Message= isSuccess?"Thêm hồ sơ gốc thành":"Thêm hồ sơ không thành công"});
        }
    }
}
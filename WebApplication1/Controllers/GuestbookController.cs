using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class GuestbookController : Controller
    {
        GestbooksDBService guestbooksService = new GestbooksDBService();
        // GET: Guestbook
        public ActionResult Index()
        {
            GestbookVM data = new GestbookVM();
            data.DataList = guestbooksService.GetDataList();
            return View(data);
        }

        public ActionResult Create()
        {
            // 使用部分檢視
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "Name,Content")]Guestbooks data)
        {
            guestbooksService.InsertGustbooks(data);
            return RedirectToAction("Index", "Guestbook");
        }
    }
}
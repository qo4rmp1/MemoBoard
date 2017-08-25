using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class MessageController : Controller
    {
        // 實作Service物件
        messageDBService data = new messageDBService();
        // GET: Message
        public ActionResult Index()
        {
            return View(data.GetData());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string title, string content)
        {
            data.DBCreate(title, content);
            return RedirectToAction("Index");
        }
    }
}
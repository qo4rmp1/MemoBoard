using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class FMessageController : Controller
    {
        FMessageService service = new FMessageService();
        // GET: FMessage
        public ActionResult Index(int Id)
        {
            ViewData["AId"] = Id;
            return PartialView();
        }

        public ActionResult DataList(int AId, int Page = 1)
        {
            FMessageVM data = new FMessageVM();
            data.Paging = new ForPaging(Page);
            data.AId = AId;
            data.DataList = service.GetDataList(data.Paging, data.AId);
            return PartialView(data);
        }

        [Authorize]
        public ActionResult Create(int Id)
        {
            ViewData["AId"] = Id;
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(int Id, [Bind(Include ="Content")]ForumMessage Data)
        {
            Data.Account = User.Identity.Name;
            Data.AId = Id;
            service.Insert(Data);
            return RedirectToAction("Index", new { Id = Id });
        }
    }
}
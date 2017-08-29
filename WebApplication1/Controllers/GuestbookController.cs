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
            return View();
        }

        public ActionResult GetDataList(string Search, int Page = 1)
        {
            GuestbookVM data = new GuestbookVM();

            data.Search = Search;
            data.Paging = new ForPaging(Page);

            data.DataList = guestbooksService.GetDataList(data.Search, data.Paging);
            return PartialView(data);
        }

        [HttpPost]
        public ActionResult GetDataList([Bind(Include = "Search")]GuestbookVM Data)
        {
            return RedirectToAction("GetDataList", new { Search = Data.Search });
        }
        public ActionResult Create()
        {
            // 使用部分檢視
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add([Bind(Include = "Content")]Guestbooks data)
        {
            data.Account = User.Identity.Name;
            guestbooksService.InsertGustbooks(data);
            return RedirectToAction("Index", "Guestbook");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Guestbooks Data = guestbooksService.Find(id);
            return View(Data);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include ="Content")]Guestbooks updateData)
        {
            if (guestbooksService.CheckUpdate(id))
            {
                updateData.Id = id;
                updateData.Account = User.Identity.Name;
                guestbooksService.Update(updateData);
            }
            else
            {
                ModelState.AddModelError("", "有回覆的留言不可編輯");
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Reply(int id)
        {
            Guestbooks Data = guestbooksService.Find(id);
            return View(Data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Reply(int id, [Bind(Include = "Reply")]Guestbooks replyData)
        {
            if (guestbooksService.CheckUpdate(id))
            {
                replyData.Id = id;
                guestbooksService.ReplyGuestbooks(replyData);
            }
            else
            {
                ModelState.AddModelError("", "有回覆的留言不可編輯");
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            guestbooksService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
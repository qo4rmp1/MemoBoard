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
        public ActionResult Index(string Search, int Page = 1)
        {
            GestbookVM data = new GestbookVM();

            data.Search = Search;
            data.Paging = new ForPaging(Page);

            data.DataList = guestbooksService.GetDataList(data.Search, data.Paging);
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

        public ActionResult Edit(int id)
        {
            Guestbooks Data = guestbooksService.Find(id);
            return View(Data);
        }

        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include ="Name,Content")]Guestbooks updateData)
        {
            if (guestbooksService.CheckUpdate(id))
            {
                updateData.Id = id;
                guestbooksService.Update(updateData);
            }
            else
            {
                ModelState.AddModelError("", "有回覆的留言不可編輯");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Reply(int id)
        {
            Guestbooks Data = guestbooksService.Find(id);
            return View(Data);
        }

        [HttpPost]
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

        public ActionResult Delete(int id)
        {
            guestbooksService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
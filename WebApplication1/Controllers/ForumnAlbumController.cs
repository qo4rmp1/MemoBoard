using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ForumAlbumController : Controller
    {
        private IForumAlbumService service;

        public ForumAlbumController(IForumAlbumService Service)
        {
            this.service = Service;
        }
        // GET: ForumnAlbum
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int Page = 1)
        {
            ForumAlbumVM data = new ForumAlbumVM();
            data.Paging = new ForPaging(Page);
            data.FileList = service.GetDataList(data.Paging);
            return PartialView(data);
        }

        public ActionResult Upload()
        {
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Upload([Bind(Include = "upload")]ForumAlbumVM Data)
        {
            if (Data.Upload != null)
            {
                string Url = Path.Combine(Server.MapPath("~/Upload/"), Data.Upload.FileName);
                Data.Upload.SaveAs(Url);
                service.UploadFile(Data.Upload.FileName, Url, Data.Upload.ContentLength, Data.Upload.ContentType, User.Identity.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Show(int Id)
        {
            ForumAlbum data = service.Find(Id);

            if (data != null)
            {
                // 使用UrlHelper產生圖片路徑
                UrlHelper urlHelper = new UrlHelper(Request.RequestContext);
                urlHelper.Content("~/Upload/" + data.FileName);
                Response.ContentType = data.Type;
                //return Content(urlHelper.Content("~/Upload/" + data.FileName));

                return base.File(urlHelper.Content("~/Upload/" + data.FileName), data.Type);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Download(int Id)
        {
            ForumAlbum data = service.Find(Id);

            if (data != null)
            {
                Stream stream = new FileStream(data.Url, FileMode.Open, FileAccess.Read, FileShare.Read);
                return File(stream, data.Type, data.FileName);
            }
            else
            {
                return JavaScript("alert(\"無此檔案\")");
            }
        }

        public ActionResult Carousel()
        {
            ForumAlbumVM data = new ForumAlbumVM();
            data.Paging = new ForPaging(1);
            data.FileList = service.GetDataList(data.Paging);
            return View(data);
        }
    }
}
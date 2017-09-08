using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ForumArticleService service = new ForumArticleService();

        public ActionResult Index()
        {
            //return View();
            throw new NotImplementedException();
        }

        public ActionResult List(string Search, int Page = 1)
        {
            FArticleVM data = new FArticleVM();
            data.Search = Search;
            data.Paging = new ForPaging(Page);
            data.DataList = service.GetDataList(data.Paging, data.Search);
            return PartialView(data);
        }

        public ActionResult Article(int Id)
        {
            ForumArticle data = service.Find(Id);
            // 將觀看人數+1
            service.AddWatch(Id);
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        //public ActionResult Create([Bind(Include = "Title,Content")]ForumArticle Data)
        //{
        //    Data.Account = User.Identity.Name;
        //    service.Insert(Data);
        //    return RedirectToAction("Index");
        //}
        public ActionResult Create(FormCollection form)//[Bind(Include = "Title, Content")]ForumArticle Data
        {
            ForumArticle Data = new ForumArticle();
            if (TryUpdateModel(Data, new string[] { "Title", "Content" }))
            {
                Data.Account = User.Identity.Name;
                service.Insert(Data);
                return RedirectToAction("Index");
            }
            return View(form);
        }

        [Authorize]
        public ActionResult Edit(int Id)
        {
            ForumArticle data = service.Find(Id);
            return PartialView(data);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(int Id, FormCollection Form)
        {
            if (service.CheckUpdate(Id))
            {
                ForumArticle data = service.Find(Id);
                if (TryUpdateModel(data, new string[] { "Content" }))
                {
                    service.Save();
                }
            }

            return RedirectToAction("Index", new { Id = Id });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            service.Delete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult ShowPopularity()
        {
            FArticleVM data = new FArticleVM();
            data.DataList = service.GetPopularityDataList();
            return View(data);
        }
    }
}
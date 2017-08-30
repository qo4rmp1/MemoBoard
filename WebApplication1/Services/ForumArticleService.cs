using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ForumArticleService
    {
        private messageEntities db = new messageEntities();

        public ForumArticle GetDataById(int Id)
        {
            return db.ForumArticle.Find(Id);
        }

        private IQueryable<ForumArticle> GetAllDataList(ForPaging Paging)
        {
            IQueryable<ForumArticle> Data = db.ForumArticle;

            Paging.SetMaxPage(Data.Count());
            Paging.SetRightPage();
            return Data;
        }

        private IQueryable<ForumArticle> GetAllDataList(ForPaging Paging, string Search)
        {
            IQueryable<ForumArticle> Data = db.ForumArticle.Where(p => p.Members.Name.Contains(Search) || p.Title.Contains(Search) || p.Content.Contains(Search));

            Paging.SetMaxPage(Data.Count());
            Paging.SetRightPage();
            return Data;
        }

        public List<ForumArticle> GetDataList(ForPaging Paging, string Search)
        {
            IQueryable<ForumArticle> data;

            if (string.IsNullOrEmpty(Search))
            {
                data = GetAllDataList(Paging);
            }
            else
            {
                data = GetAllDataList(Paging, Search);
            }

            data = data.OrderByDescending(p => p.AId).Skip((Paging.NowPage - 1) * Paging.ItemNo).Take(Paging.ItemNo);

            return data.ToList();
        }

        public void Insert(ForumArticle FArticle)
        {
            FArticle.CreateTime = DateTime.Now;
            db.ForumArticle.Add(FArticle);
            db.SaveChanges();
        }
    }
}
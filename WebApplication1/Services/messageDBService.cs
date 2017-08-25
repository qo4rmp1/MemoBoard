using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class messageDBService
    {
        public messageEntities db = new messageEntities();

        // 取得資料庫中Article資料
        public List<Article> GetData()
        {
            return db.Article.ToList();
        }
        
        public void DBCreate(string title, string content)
        {
            Article article = new Article
            {
                Title = title,
                Content = content,
                Time = DateTime.Now
            };

            db.Article.Add(article);
            db.SaveChanges();
        }
    }
}
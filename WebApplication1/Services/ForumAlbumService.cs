using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ForumAlbumService
    {
        private messageEntities db = new messageEntities();

        public ForumAlbum Find(int Id)
        {
            return db.ForumAlbum.Where(p => p.AlbId == Id).FirstOrDefault();
        }

        public IQueryable<ForumAlbum> GetAllDataList(ForPaging Paging)
        {
            IQueryable<ForumAlbum> Data = db.ForumAlbum;

            Paging.SetMaxPage(Data.Count());
            Paging.SetRightPage();
            return Data;
        }

        public List<ForumAlbum> GetDataList(ForPaging Paging)
        {
            IQueryable<ForumAlbum> Data = GetAllDataList(Paging);
            return Data.OrderByDescending(p => p.AlbId).Skip((Paging.NowPage - 1) * Paging.ItemNo).Take(Paging.ItemNo).ToList();
        }

        public void UploadFile(string FileName, string Url, int Size, string Type, string Account)
        {
            ForumAlbum data = new ForumAlbum()
            {
                FileName = FileName,
                Url = Url,
                Size = Size,
                Type = Type,
                Account = Account,
                CreateTime = DateTime.Now
            };

            db.ForumAlbum.Add(data);
            db.SaveChanges();
        }
    }
}
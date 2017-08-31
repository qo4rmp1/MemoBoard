using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class FMessageService
    {
        private messageEntities db = new messageEntities();

        public IQueryable<ForumMessage> GetAllDataList(ForPaging Paging, int AId)
        {
            IQueryable<ForumMessage> Data = db.ForumMessage.Where(p => p.AId == AId);
            Paging.SetMaxPage(Data.Count());
            Paging.SetRightPage();
            return Data;
        }

        public List<ForumMessage> GetDataList(ForPaging Paging, int AId)
        {
            IQueryable<ForumMessage> Data = GetAllDataList(Paging, AId);
            return Data.OrderByDescending(p => p.AId).Skip((Paging.NowPage - 1) * Paging.ItemNo).Take(Paging.ItemNo).ToList();
        }

        public void Insert(ForumMessage Data)
        {
            Data.CreateTime = DateTime.Now;
            db.ForumMessage.Add(Data);
            db.SaveChanges();
        }
    }
}
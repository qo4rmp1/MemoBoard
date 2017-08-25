using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GestbooksDBService
    {
        public messageEntities db = new messageEntities();

        public List<Guestbooks> GetDataList()
        {
            return db.Guestbooks.ToList();
        }
        public void InsertGustbooks(Guestbooks newData)
        {
            newData.CreateTime = DateTime.Now;
            db.Guestbooks.Add(newData);
            db.SaveChanges();
        }
        public Guestbooks Find(int id)
        {
            return db.Guestbooks.Find(id);
        }
        public void Update(Guestbooks updateData)
        {
            Guestbooks OldData = Find(updateData.Id);

            if (OldData != null)
            {
                OldData.Name = updateData.Name;
                OldData.Content = updateData.Content;
                db.SaveChanges();
            }
        }
        public void ReplyGuestbooks(Guestbooks replyData)
        {
            Guestbooks OldData = Find(replyData.Id);

            if (OldData != null)
            {
                OldData.Reply = replyData.Reply;
                OldData.ReplyTime = DateTime.Now;
                db.SaveChanges();
            }
        }
        public bool CheckUpdate(int id)
        {
            Guestbooks Data = Find(id);

            return (Data != null && string.IsNullOrEmpty(Data.Reply));
        }
    }
}
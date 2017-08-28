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

        public List<Guestbooks> GetDataList(string Search, ForPaging Paging)
        {
            IQueryable<Guestbooks> data;

            if (string.IsNullOrEmpty(Search))
            {
                data = GetDataList(Paging);
            }
            else
            {
                data = GetDataList(Paging, Search);
            }

            return data.OrderByDescending(p => p.Id).Skip((Paging.NowPage - 1) * Paging.ItemNo).Take(Paging.ItemNo).ToList();
        }
        public IQueryable<Guestbooks> GetDataList(ForPaging Paging)
        {
            IQueryable<Guestbooks> data = db.Guestbooks;

            Paging.MaxPage = (int)Math.Ceiling(Convert.ToDouble(data.Count() / Paging.ItemNo));
            Paging.SetRightPage();

            return data;
        }
        public IQueryable<Guestbooks> GetDataList(ForPaging Paging, string Search)
        {
            IQueryable<Guestbooks> data = db.Guestbooks.AsQueryable();

            if (string.IsNullOrEmpty(Search) == false)
            {
                data = db.Guestbooks.Where(p => p.Account.Contains(Search) || p.Content.Contains(Search) || p.Reply.Contains(Search));

                Paging.MaxPage = (int)Math.Ceiling(Convert.ToDouble(data.Count() / Paging.ItemNo));
                Paging.SetRightPage();
            }
            return data;
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
                OldData.Account = updateData.Account;
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

            return (Data != null && Data.ReplyTime == null);
        }
        public void Delete(int id)
        {
            Guestbooks Data = Find(id);

            if (Data != null)
            {
                db.Guestbooks.Remove(Data);
                db.SaveChanges();
            }
        }
    }
}
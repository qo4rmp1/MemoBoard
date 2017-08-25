using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}
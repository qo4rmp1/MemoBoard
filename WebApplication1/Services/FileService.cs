using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class FileService
    {
        messageEntities db = new messageEntities();

        public IQueryable<FileContent> GetAllFileList(ForPaging Paging)
        {
            IQueryable<FileContent> fileList = db.FileContent;

            Paging.SetMaxPage(fileList.Count());
            Paging.SetRightPage();

            return fileList;
        }

        public List<FileContent> GetFileList(ForPaging Paging)
        {
            IQueryable<FileContent> fileList = GetAllFileList(Paging);

            return fileList.OrderByDescending(p => p.Id).Skip((Paging.NowPage - 1) * Paging.ItemNo).Take(Paging.ItemNo).ToList();
        }

        public FileContent GetFileList(int Id)
        {
            return db.FileContent.FirstOrDefault(p => p.Id == Id);
        }

        public void UploadFile(string Name, string Url, int Size, string Type)
        {
            FileContent filecontent = new FileContent()
            {
                Name = Name,
                Url = Url,
                Size = Size,
                Type = Type,
                CreateTime = DateTime.Now
            };

            db.FileContent.Add(filecontent);
            db.SaveChanges();
        }
    }
}
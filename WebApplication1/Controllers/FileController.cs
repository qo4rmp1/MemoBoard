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
    public class FileController : Controller
    {
        FileService fileservice = new FileService();
        // GET: File
        public ActionResult Index(int Page = 1)
        {
            FileVM fileVM = new FileVM();
            fileVM.Paging = new ForPaging(Page);
            fileVM.FileList = fileservice.GetFileList(fileVM.Paging);
            
            return View(fileVM);
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string filename = Path.GetFileName(upload.FileName);
                string url = Path.Combine(Server.MapPath("~/Upload/"), filename);

                upload.SaveAs(url);
                fileservice.UploadFile(filename, url, upload.ContentLength, upload.ContentType);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DownloadFile(int Id)
        {
            FileContent file = fileservice.GetFileList(Id);

            if (file != null)
            {
                Stream stream = new FileStream(file.Url, FileMode.Open, FileAccess.Read, FileShare.Read);
                return File(stream, file.Type, file.Name);
            }
            else
            {
                return JavaScript("alert(\"無此檔案\"");
            }
        }
    }
}
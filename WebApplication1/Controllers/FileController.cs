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

            /*
            //取得目前 HTTP 要求的 HttpRequestBase 物件
            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    // 取得的檔案是stream
                    Stream stream = fileContent.InputStream;                    
                    var fileName = Path.GetFileName(file);
                    var path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }
             */
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
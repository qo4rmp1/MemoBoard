using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Services;

namespace WebApplication1.Models
{
    public class ForumAlbumVM
    {
        [DisplayName("上傳圖片")]
        [FileExtensions(ErrorMessage = "所上傳檔案不是圖片")]
        public HttpPostedFileBase Upload { get; set; }
        // 儲存檔案陣列
        public List<ForumAlbum> FileList { get; set; }
        // 分頁內容
        public ForPaging Paging { get; set; }
    }
}
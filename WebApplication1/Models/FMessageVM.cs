using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Services;

namespace WebApplication1.Models
{
    public class FMessageVM
    {
        // 資料陣列
        public List<ForumMessage> DataList { get; set; }
        // 分頁內容
        public ForPaging Paging { get; set; }
        // 文章編號
        public int AId { get; set; }
    }
}
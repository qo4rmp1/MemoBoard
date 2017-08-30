using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApplication1.Services;

namespace WebApplication1.Models
{
    public class ArticleVM
    {
        [DisplayName("搜尋")]
        public string Search { get; set; }
        public ForPaging Paging { get; set; }
        public List<Article> DataList { get; set; }
    }
}
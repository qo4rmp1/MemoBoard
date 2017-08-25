using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Models
{
    public class GestbookVM
    {
        [DisplayName("搜尋")]
        public string Search { get; set; }
        public ForPaging Paging{ get; set; }
        public List<Guestbooks> DataList { get; set; }
    }
}
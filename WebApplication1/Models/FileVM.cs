using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Services;

namespace WebApplication1.Models
{
    public class FileVM
    {
        public List<FileContent> FileList { get; set; }
        public ForPaging Paging { get; set; }
    }
}
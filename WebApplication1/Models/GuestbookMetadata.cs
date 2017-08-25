using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [MetadataType(typeof(GuestbookMetadata))]
    public partial class Guestbooks
    {
        private class GuestbookMetadata
        {
            public int Id { get; set; }
            [DisplayName("名字")]
            [Required(ErrorMessage ="請輸入名字")]
            public string Name { get; set; }
            [DisplayName("留言")]
            [Required(ErrorMessage = "請輸入留言")]
            public string Content { get; set; }
            public System.DateTime CreateTime { get; set; }
            public string Reply { get; set; }
            public Nullable<System.DateTime> ReplyTime { get; set; }

        }
    }
}
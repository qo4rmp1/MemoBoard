namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(GuestbooksMetaData))]
    public partial class Guestbooks
    {
    }
    
    public partial class GuestbooksMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        [DisplayName("留言")]
        [Required(ErrorMessage = "請輸入留言")]
        public string Content { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Reply { get; set; }
        public Nullable<System.DateTime> ReplyTime { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [DisplayName("名字")]
        [Required(ErrorMessage = "請輸入名字")]
        public string Account { get; set; }
    
        public virtual Members Members { get; set; }
    }
}

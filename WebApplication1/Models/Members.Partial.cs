namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MembersMetaData))]
    public partial class Members
    {
    }
    
    public partial class MembersMetaData
    {
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Account { get; set; }
        
        [StringLength(40, ErrorMessage="欄位長度不得大於 40 個字元")]
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        [Required]
        public string Email { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        //[Required]
        public string AuthCode { get; set; }
        //[Required]
        public bool IsAdmin { get; set; }
    
        public virtual ICollection<Guestbooks> Guestbooks { get; set; }
        public virtual ICollection<ForumAlbum> ForumAlbum { get; set; }
        public virtual ICollection<ForumArticle> ForumArticle { get; set; }
        public virtual ICollection<ForumMessage> ForumMessage { get; set; }
    }
}

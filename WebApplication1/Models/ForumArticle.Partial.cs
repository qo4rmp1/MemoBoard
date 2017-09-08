namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ForumArticleMetaData))]
    public partial class ForumArticle
    {
    }
    
    public partial class ForumArticleMetaData
    {
        [Required]
        [DisplayName("文章編號")]
        public int AId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [DisplayName("標題")]
        public string Title { get; set; }
        [Required]
        [DisplayName("文章內容")]
        public string Content { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        //[Required]
        [DisplayName("作者")]
        public string Account { get; set; }
        [DisplayName("發表時間")]
        public System.DateTime CreateTime { get; set; }
        [DisplayName("觀看人數")]
        public int Watch { get; set; }
    
        public virtual Members Members { get; set; }
        public virtual ICollection<ForumMessage> ForumMessage { get; set; }
    }
}

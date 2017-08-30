namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ArticleMetaData))]
    public partial class Article
    {
    }
    
    public partial class ArticleMetaData
    {
        [Required]
        [DisplayName("文章編號")]
        public int Id { get; set; }
        
        [DisplayName("標題")]
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string Title { get; set; }
        [DisplayName("文章內容")]
        [Required]
        public string Content { get; set; }
        [DisplayName("發表時間")]
        [Required]
        public System.DateTime Time { get; set; }
    }
}

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ForumMessageMetaData))]
    public partial class ForumMessage
    {
    }
    
    public partial class ForumMessageMetaData
    {
        [Required]
        public int MId { get; set; }
        [Required]
        public int AId { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Account { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        [Required]
        public string Content { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
    
        public virtual ForumArticle ForumArticle { get; set; }
        public virtual Members Members { get; set; }
    }
}

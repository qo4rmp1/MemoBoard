namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ForumAlbumMetaData))]
    public partial class ForumAlbum
    {
    }
    
    public partial class ForumAlbumMetaData
    {
        [Required]
        public int AlbId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        [DisplayName("大小(Byte)")]
        public int Size { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        [Required]
        public string Type { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        [Required]
        public string Account { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
    
        public virtual Members Members { get; set; }
    }
}

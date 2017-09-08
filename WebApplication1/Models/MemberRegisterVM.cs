using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MemberRegisterVM
    {
        //public Members newMember { get; set; }

        [StringLength(30, ErrorMessage = "欄位長度不得大於 30 個字元")]
        [Required]
        public string Account { get; set; }

        [StringLength(40, ErrorMessage = "欄位長度不得大於 40 個字元")]
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

        [StringLength(20, ErrorMessage = "欄位長度不得大於 20 個字元")]
        [Required]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "欄位長度不得大於 200 個字元")]
        [Required]
        public string Email { get; set; }

        
        [DisplayName("確認密碼")]
        [Compare("Password", ErrorMessage = "兩次密碼輸入不一致")]
        [Required(ErrorMessage = "請輸入確認密碼")]
        public string PasswordCheck { get; set; }
    }
}
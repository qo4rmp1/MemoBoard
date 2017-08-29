using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ChangePasswordVM
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "密碼輸入不一致")]
        public string NewPasswordCheck { get; set; }
    }
}
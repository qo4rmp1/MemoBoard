using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MemberService
    {
        public messageEntities db = new messageEntities();

        public MemberService()
        {
        }

        public void Register(Members newMember)
        {
            newMember.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(newMember.Password, "SHA1");
            db.Members.Add(newMember);
            db.SaveChanges();
        }

        public bool AccountCheck(string Account)
        {
            Members data = db.Members.Find(Account);
            return (data != null);
        }

        public string EmailValidate(string UserName, string AuthCode)
        {
            string ValidateStr = string.Empty;

            Members Member = db.Members.Find(UserName);

            if (Member != null)
            {
                if (Member.AuthCode.Equals(AuthCode))
                {
                    Member.AuthCode = string.Empty;
                    db.SaveChanges();
                    ValidateStr = "帳號信箱驗證成功";
                }
                else
                {
                    ValidateStr = "驗證碼錯誤，請重新確認";
                }
            }
            else
            {
                ValidateStr = "找不到該會員資料，請重新確認";
            }
            return ValidateStr;
        }

        public string LoginCheck(string UserName, string Password)
        {
            if (UserName == "123" && Password == "123")
            {
                return "";
            }

            return "密碼錯誤";

            //Members Member = db.Members.Find(UserName);

            //if (Member != null)
            //{
            //    if (string.IsNullOrWhiteSpace(Member.AuthCode))
            //    {
            //        if (PasswordCheck(Member, Password))
            //        {
            //            return "";
            //        }
            //        else
            //        {
            //            return "密碼錯誤";
            //        }
            //    }
            //    else
            //    {
            //        return "登入帳號尚未驗證成功";
            //    }
            //}
            //else
            //{
            //    return "查無此使用者";
            //}
        }

        private bool PasswordCheck(Members Member, string Password)
        {
            return Member.Password.Equals(FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1"));
        }

        public string GetRole(string UserName)
        {
            string Role = "User";
            Members Member = db.Members.Find(UserName);

            if (Member != null)
            {
                if (Member.IsAdmin)
                {
                    Role += ",Admin";
                }
            }

            return Role;
        }

        public string ChangePassword(string UserName, string Password, string NewPassword)
        {
            string Msg = string.Empty;
            Members members = db.Members.Find(UserName);
            
            if (PasswordCheck(members, Password))
            {
                members.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPassword, "SHA1");
                db.SaveChanges();
                Msg = "修改密碼成功";
            }
            else
            {
                Msg = "就密碼輸入錯誤";
            }
            return Msg;
        }
    }
}
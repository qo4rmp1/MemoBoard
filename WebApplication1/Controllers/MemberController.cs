using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using System.IO;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class MemberController : Controller
    {
        private MemberService MemberService = new MemberService();
        private MailService MailService = new MailService();

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Guestbook");
            else
                return View();
        }

        [HttpPost]
        public ActionResult Register(MemberRegisterVM RegisterMember)
        {
            if (ModelState.IsValid)
            {
                RegisterMember.newMember.Password = RegisterMember.Password;
                RegisterMember.newMember.AuthCode = new Guid().ToString();
                MemberService.Register(RegisterMember.newMember);UriBuilder ValidateUrl = new UriBuilder(Request.Url)
                {
                    Path = Url.Action("EmailValidate", "Member", new { UserName = RegisterMember.newMember.Account, AuthCode = RegisterMember.newMember.AuthCode })
                };

                string TempMail = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/MemberRegisterEMailTemplate.htm"));
                string MailBody = MailService.GetRegisterMailBody(
                    TempMail,
                    RegisterMember.newMember.Account,
                    ValidateUrl.ToString().Replace("%3F", "?")
                );

                MailService.SendRegisterMail(MailBody, RegisterMember.newMember.Email);
                TempData["RegisterState"] = "註冊成功，請至信箱驗證信件";
                return RedirectToAction("RegisterResult");
            }

            RegisterMember.Password = null;
            RegisterMember.PasswordCheck = null;

            return View(RegisterMember);
        }

        public ActionResult RegisterResult()
        {
            return View();
        }

        public ActionResult AccountCheck(MemberRegisterVM Member)
        {
            return Json(MemberService.AccountCheck(Member.newMember.Account), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmailValidate(string UserName, string AuthCode)
        {
            ViewData["EmailValidate"] = MemberService.EmailValidate(UserName, AuthCode);
            return View();
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Guestbook");
            else
                return View();
        }

        [HttpPost]
        public ActionResult Login(MemberLoginVM LoginMember)
        {
            if (ModelState.IsValid)
            {
                string ValidateStr = MemberService.LoginCheck(LoginMember.UserName, LoginMember.Password);
                if (string.IsNullOrEmpty(ValidateStr))
                {
                    string RoleData = MemberService.GetRole(LoginMember.UserName);

                    FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(
                        1,
                        LoginMember.UserName,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        false,
                        RoleData,
                        FormsAuthentication.FormsCookiePath);
                    string enTicket = FormsAuthentication.Encrypt(Ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));
                    return RedirectToAction("Index", "Guestbook");
                }
                else
                {
                    ModelState.AddModelError("", ValidateStr);
                    LoginMember.Password = null;
                    return View(LoginMember);
                }
            }

            LoginMember.Password = null;
            return View(LoginMember);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
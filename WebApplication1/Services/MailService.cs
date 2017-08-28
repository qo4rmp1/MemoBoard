using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.Services
{
    public class MailService
    {
        private string gmail_account = "d2011033";
        private string gmail_mail = "d2011033@gmail.com";
        private string gmail_password = "dei2011033";

        public string GetRegisterMailBody(string TempString, string UserName, string ValidateUrl)
        {
            TempString = TempString.Replace("{{Name}}", UserName);
            TempString = TempString.Replace("{{AUTH_URL}}", ValidateUrl);

            return TempString;
        }

        public void SendRegisterMail(string MailBody, string ToMail)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential(gmail_account, gmail_password);
            SmtpServer.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gmail_mail);
            mail.To.Add(ToMail);
            mail.Subject = "會員註冊確認信";
            mail.Body = MailBody;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 執行Unity.MVC4初始化
            Bootstrapper.Initialise();
        }

        protected void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal contextUser = Context.User;

            if (contextUser.Identity.AuthenticationType == "Forms")
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                string[] roles = ticket.UserData.Split(new char[] { ',' });
                HttpContext.Current.User = new GenericPrincipal(User.Identity, roles);
                Thread.CurrentPrincipal = HttpContext.Current.User;
            }
        }

        void ErrorLog_Filtering(object sender, Elmah.ExceptionFilterEventArgs e)
        {
            var exception = e.Exception.GetBaseException();

            if (exception is HttpRequestValidationException)
            {
                e.Dismiss();
            }
        }

        void ErrorMail_Filtering(object senderm, Elmah.ExceptionFilterEventArgs e)
        {
            var exception = e.Exception.GetBaseException();
            var httpException = (HttpException)e.Exception;

            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                e.Dismiss();
            }

            if (exception is System.IO.FileNotFoundException ||
                exception is HttpRequestValidationException ||
                exception is HttpException)
            {
                e.Dismiss();
            }
        }

        void ErrorMail_Mailing(object sender, Elmah.ErrorMailEventArgs e)
        {
            var exception = e.Error.Exception;

            if (exception is NotImplementedException)
            {
                e.Mail.Priority = System.Net.Mail.MailPriority.High;
                e.Mail.Subject = "ELMAH - Error 高度警示";
            }
        }
    }
}

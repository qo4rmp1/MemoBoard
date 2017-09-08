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
    }
}

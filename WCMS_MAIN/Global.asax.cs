using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WCMS_MAIN.HelperClass;

namespace WCMS_MAIN
{
    public class MvcApplication : System.Web.HttpApplication
    {

        //protected void Application_BeginRequest()
        //{
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        //    Response.Cache.SetNoStore();
        //}

        protected void Application_Start()
        {
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
            //AreaRegistration.RegisterAllAreas();
           
        }
        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 480;
        }


        //private void Application_AuthenticateRequest(object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.User != null)
        //    {
        //        if (HttpContext.Current.User.Identity.IsAuthenticated)
        //        {
        //            if (HttpContext.Current.User.Identity is FormsIdentity)
        //            {
        //                FormsIdentity id =
        //                    (FormsIdentity)HttpContext.Current.User.Identity;
        //                FormsAuthenticationTicket ticket = id.Ticket;

        //                // Get the stored user-data, in this case, our roles
        //                string userData = ticket.UserData;
        //                string[] roles = userData.Split(',');
        //                // string[] roles = {"User"};
        //                HttpContext.Current.User = new GenericPrincipal(id, roles);
        //            }
        //        }
        //    }
        //}
    }
}

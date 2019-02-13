using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCMS_MAIN.HelperClass
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CheckSessionOutAttribute: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
        if (!controllerName.Contains("account"))
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            var user = session["UserName"]; //Key 2 should be User or UserName
            if (((user == null) && (!session.IsNewSession)) || (session.IsNewSession))
            {
                //send them off to the login page
                var url = new UrlHelper(filterContext.RequestContext);
                var loginUrl = VirtualPathUtility.ToAbsolute("~/Account/LogIn"); //url.Content("..Account/LogIn");
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }
}
    
    
}
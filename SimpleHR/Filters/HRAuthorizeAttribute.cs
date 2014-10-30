using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SimpleHR.Providers;

namespace SimpleHR.Filters
{
    public class HRAuthorizeAttribute : AuthorizeAttribute
    {
        //This should be ninjected, but have not figured out how to make it work with attribute
        protected IRolesCheckProvider RolesCheckProvider = new RolesCheckProvider();

        protected virtual IPrincipal CurrentUser
        {
            get { return HttpContext.Current.User; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool isHR = RolesCheckProvider.IsEmployeeInHR(CurrentUser.Identity.Name);

            if (!isHR)
            {
                var controllerContext = new ControllerContext(filterContext.RequestContext, filterContext.Controller);
                var controller = (string)filterContext.RouteData.Values["controller"];
                var action = (string)filterContext.RouteData.Values["action"];

                var url = new UrlHelper(filterContext.RequestContext);
                var logonUrl = url.Action("Unauthorize", "Credentials", new { reason = "notAuthorized" });
                filterContext.Result = new RedirectResult(logonUrl);
            }
        }        
    }
}
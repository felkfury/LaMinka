using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LaMinka.Security
{
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    base.HandleUnauthorizedRequest(filterContext);
            //}
            //else
            //{
            //    filterContext.Result = new RedirectToRouteResult(
            //                               new RouteValueDictionary
            //                       {
            //                           { "action", "AccessDenied" },
            //                           { "controller", "Account" }
            //                       });
            //}
        }
    }
}

using System;
 using System.Collections.Generic;
using System.Linq;
 using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace WebApplication1.Filter
{
    public class AuthFilterAttribute : ActionFilterAttribute, IAuthenticationFilter, IActionFilter//, IResultFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            WindowsIdentity identity = HttpContext.Current.Request.LogonUserIdentity;
            if (identity != null)
            {

            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var User = filterContext.HttpContext.User;


            if (User == null || !User.Identity.IsAuthenticated)
            {

            }

        }

        //public void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    throw new NotImplementedException();
        //}

    }
    public class ActionFilterAttribute : FilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.OnActionExecuted = " OnActionExecuted of IActionFilter filter called";
        }
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.OnActionExecuting = " OnActionExecuting of IActionFilter filter called";
        }
    }
}
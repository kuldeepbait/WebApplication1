using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Filter
{
    public class ExceptionHandlerFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            Exception exception = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }
    }
}
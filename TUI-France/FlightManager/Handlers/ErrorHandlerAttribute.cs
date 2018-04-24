using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightManager.Handlers
{
    public class ErrorHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new {
                    error = true,
                    message = filterContext.Exception.ToString()
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
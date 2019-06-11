using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksPeople.Controllers
{
    public class HttpClientActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ((AWController)filterContext.Controller).APIConnector = new Models.APIConnect();
        }

        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //}

        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //}

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            ((AWController)filterContext.Controller).APIConnector.Dispose();
        }

    }
}
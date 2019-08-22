using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmissionsOnlineSystem.Filters
{
    /// <summary>
    /// Appends partial view scripts to the html response of an AJAX request
    /// </summary>
    public class RenderAjaxPartialScriptsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var response = filterContext.HttpContext.Response;
                if (response.Filter != null)
                    response.Filter = new RenderAjaxPartialScriptsResponseFilter(response.Filter, filterContext);
            }
        }
    }
}
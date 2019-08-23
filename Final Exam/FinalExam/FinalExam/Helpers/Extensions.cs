using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalExam.Helpers
{
    public static class Extensions
    {
        public static IHtmlString GetArrow(this HtmlHelper helper, string currentSortBy, string sortBy, string sortDir)
        {
            if (currentSortBy == sortBy)
            {
                if (sortDir == "asc")
                    return helper.Raw(@"<span>&uarr;</span>");
                else
                    return helper.Raw(@"<span>&darr;</span>");
            }
            return helper.Raw("");
        }
    }
}
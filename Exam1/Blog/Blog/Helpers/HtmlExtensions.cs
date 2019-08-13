using HtmlAgilityPack;
using System.Web;
using System.Web.Mvc;

namespace Blog.Helpers
{
    public static class HtmlExtensions
    {
        public static IHtmlString StripHtml(this HtmlHelper helper, string content, int limit)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);
            if (limit > 0 && htmlDoc.DocumentNode.InnerText.Length > limit)
                return new HtmlString(htmlDoc.DocumentNode.InnerText.Substring(0, limit)+"...");
            return new HtmlString(content);
        }

        public static IHtmlString AddText(this HtmlHelper helper, string message)
        {
            return new HtmlString(message + " added from helper");
        }
    }
}
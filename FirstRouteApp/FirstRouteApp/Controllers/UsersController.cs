using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstRouteApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ByUserName(string username)
        {
            ViewBag.UserName = username;
            // remove parameter from the method
           // ViewBag.UserName = RouteData.Values["UserName"].ToString();
            return View();
        }
    }
}
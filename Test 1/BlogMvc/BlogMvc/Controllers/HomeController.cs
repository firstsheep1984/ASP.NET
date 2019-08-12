using BlogMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvc.Controllers
{
    [Authorize(Roles = RoleName.CanManage)]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
           
            if (User.IsInRole(RoleName.CanManage))
                return View(db.Posts);
            else
                return View("_ReadOnlyPosts", db.Posts);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
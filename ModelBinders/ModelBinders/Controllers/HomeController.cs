using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinders.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult Paremeter() {
            return View();
        }

        [HttpPost]
        public ActionResult Paremeter(int first)
        {
            return RedirectToAction("Parameter2", new { first = first });
            //return View("Parameter2", first); //Content("first value :" + first);
        }

        [HttpPost]
        public ActionResult Parameter2(int first)
        {
            return View(first);
        }

        public ActionResult Collections()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Collections(IEnumerable<string> strings)
        {
            return Content(string.Join(",", strings));
        }
    }
}
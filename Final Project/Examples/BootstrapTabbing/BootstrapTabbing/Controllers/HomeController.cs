using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapTabbing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _SubmissionTab(string id)
        {
            return PartialView();
        }

        public ActionResult _SearchTab(string id)
        {
            return PartialView();
        }

        public ActionResult _AdditionalTab(string id)
        {
            return PartialView();
        }
    }
}
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controller = new PostsController();
            controller.ControllerContext = new ControllerContext(this.ControllerContext.RequestContext, controller);
            return controller.OnlyPublic();
        }
    }
}
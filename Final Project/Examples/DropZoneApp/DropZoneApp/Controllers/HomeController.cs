using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace DropZoneApp.Controllers
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

        private void RemoveFile() {
            if (Session["filePath"] != null)
            {
                string sFilePath = Session["filePath"].ToString();
                if (System.IO.File.Exists(sFilePath))
                    System.IO.File.Delete(sFilePath);
                Session["filePath"] = "";
            }
        }

        [HttpPost]
        public ActionResult RemoveUpload()
        {
            RemoveFile();
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            RemoveFile();
            try
            {
                var memStream = new MemoryStream();
                file.InputStream.CopyTo(memStream);

                byte[] fileData = memStream.ToArray();
                string filePath = Path.GetTempFileName();

                Session["filePath"] = filePath;
                System.IO.File.WriteAllBytes(filePath, fileData);
            }
            catch (Exception exception)
            {
                return Json(new
                {
                    success = false,
                    response = exception.Message
                });
            }

            return Json(new
            {
                success = true,
                response = "File uploaded."
            });
        }
    }
}
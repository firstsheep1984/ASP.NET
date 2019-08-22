using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Controls;
using Microsoft.AspNet.Identity;
using OnlineAdmission.Models;

namespace OnlineAdmission.Controllers
{
    public class ApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Applications
        [Authorize]
        public ActionResult Index()
        {
            //return View(db.applications.ToList());
            var UsrAppList = new List<Applications>();
            string uname = User.Identity.Name;

            if (User.IsInRole("Admin"))
            {
                //return View(db.applications.ToList());
                return RedirectToAction("SearchPage");
            }
            else
            {
                UsrAppList = db.applications.Where(u => u.Userid == uname).ToList();
                return View(UsrAppList);
            }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult SearchPage(string searchStr)
        {
            return View(db.applications.ToList());

        }

        [Authorize(Roles = "Admin")]
        public PartialViewResult Search(string query)
        {

            var apps = db.applications;
            var subset = apps.Where(app => app.Id.ToString() == query ||
                                        app.Userid.StartsWith(query) ||
                                        app.status.ToString().StartsWith(query) ||
                                        app.FirstName.StartsWith(query) ||
                                        app.LastName.StartsWith(query) ||
                                        app.branch.ToString().StartsWith(query) ||
                                        app.RegistrationDate.StartsWith(query)
                                        );

            ViewBag.Message = "SearchResult";
            return this.PartialView("_SearchResult", subset.ToList());

        }

        // GET: Applications/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Applications applications = db.applications.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }

            applications = db.applications.FirstOrDefault(item => item.Id == id);
            if (applications != null && applications.Photo != null)
            {
                string img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(applications.Photo));
                ViewBag.ImgData = img;
            }

            return View(applications);
        }

        [Authorize]
        public ActionResult Cancel()
        {
            return View();
        }

        // GET: Applications/Create        
        public ActionResult Create()
        {
            return View();
        }



        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,BirhtDate,FirstName,LastName,gender,Address,Email,TelephoneNumber,program,branch,status,Photo")] Applications applications, HttpPostedFileBase file)
        {

            if (!ModelState.IsValid)
            {

                if (applications.status.ToString().ToLower() == "approved" && !User.IsInRole("Admin"))
                {

                    ViewBag.Message = "Only Admin allow to select [Approved!]";
                    return View(applications);

                }

                if (file != null)
                {
                    applications.Photo = new byte[file.ContentLength];
                    file.InputStream.Read(applications.Photo, 0, file.ContentLength);


                    //Save image to filesystem
                    var filename = file.FileName;
                    var filePathOriginal = Server.MapPath("~/Images");
                    //var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    file.SaveAs(savedFileName);
                }

                applications.Userid = User.Identity.Name;

                applications.RegistrationDate = DateTime.Now.ToLocalTime().ToString();

                //Global.ApplicationID = applications.Id;
                db.applications.Add(applications);
                db.SaveChanges();
                Global.ApplicationID = applications.Id;

                return RedirectToAction("Create", "EducationalDetails");
            }

            return View(applications);
        }

        // GET: Applications/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applications applications = db.applications.Find(id);

            if (applications == null)
            {
                return HttpNotFound();
            }

            if (applications.status.ToString().ToLower() == "approved" && !User.IsInRole("Admin")) {

                //User can't edit application if the application already approved by amdin 
                ViewBag.Approved = "The application is approved! Can not be changed!";
                ViewBag.Disabled = "disabled";

                return View(applications);
            }


            return View(applications);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Userid,Photo,FirstName,LastName,BirhtDate,gender,Address,Email,TelephoneNumber,program,branch,RegistrationDate,status")] Applications applications)
        {
            if (applications.status.ToString().ToLower() == "approved" && !User.IsInRole("Admin"))
            {
                ViewBag.Message = "Only Admin allow to select [Approved!]";
                return View(applications);
            }

            if (ModelState.IsValid)
            {            

                db.Entry(applications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applications);
        }

        // GET: Applications/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applications applications = db.applications.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }
            return View(applications);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Applications applications = db.applications.Find(id);
            db.applications.Remove(applications);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}

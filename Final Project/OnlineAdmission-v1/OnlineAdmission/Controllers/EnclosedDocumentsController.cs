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
using OnlineAdmission.Models;

namespace OnlineAdmission.Controllers
{
    public class EnclosedDocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnclosedDocuments
        [Authorize]
        public ActionResult Index()
        {
            var enclosedDocuments = db.enclosedDocuments.Include(e => e.application);
            //return View(enclosedDocuments.ToList());

            var encolseList = new List<EnclosedDocuments>();
            string uname = User.Identity.Name;

            if (User.IsInRole("Admin"))
            {
                return View(db.enclosedDocuments.ToList());
            }
            else
            {
                encolseList = db.enclosedDocuments.Where(u => u.application.Userid == uname).ToList();
                return View(encolseList);
            }



        }

        // GET: EnclosedDocuments/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Check URL from( where the request from?)
            string urlFrom = Request.UrlReferrer.ToString();

            if (urlFrom.ToLower().Contains("educationaldetails"))
            {
                //Reqeust from Applications/Details/Next
                //Fetch EnclosedDocuments.Id based on id
                EnclosedDocuments encloseDoc = db.enclosedDocuments.FirstOrDefault(enc => enc.applicationId == id);
                if (encloseDoc == null)
                {
                    //ViewBag.NoEduFound = "No Detail Information!";           
                    return RedirectToAction("Index", "EnclosedDocuments");

                }
                else
                {

                    //Got EnclosedDocuments.Id
                    int encId = encloseDoc.Id;
                    //Check EnclosedDocuments by encId
                    encloseDoc = db.enclosedDocuments.Find(encId);
                    if (encloseDoc.DocURL != null)
                    {
                        //Get file URL path then put into ViewBag.
                        //Details View will use the ViewBag Value
                        ViewBag.DownLoadURL = encloseDoc.DocURL;

                    }
                    return View(encloseDoc);

                }
            }
            else
            {
                EnclosedDocuments encloseDoc = db.enclosedDocuments.Find(id);
                if (encloseDoc == null)
                {
                    return HttpNotFound();
                }
                return View(encloseDoc);
            }
        }

        // GET: EnclosedDocuments/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.applicationId = new SelectList(db.applications, "Id", "Userid");
            return View();
        }

        // POST: EnclosedDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,qualification,doctype,docname")] EnclosedDocuments enclosedDocuments, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadFile != null && enclosedDocuments != null)
                {

                    //Save image to filesystem
                    var filename = uploadFile.FileName;
                    var filePathOriginal = Server.MapPath("~/Uploads");

                    //var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                    string savedFileName = Path.Combine(filePathOriginal, filename);

                    //Save file to server  ~/uploads/      
                    uploadFile.SaveAs(savedFileName);

                    //Get root URL like http://localhost:12345
                    var rootURL = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

                    //Save file URL path to database
                    string fileFullURL = rootURL + "/Uploads/" + filename;
                    enclosedDocuments.DocURL = fileFullURL;

                }
                enclosedDocuments.applicationId = Global.ApplicationID;
                db.enclosedDocuments.Add(enclosedDocuments);
                db.SaveChanges();
                return RedirectToAction("Index", "Applications");

            }

            ViewBag.applicationId = new SelectList(db.applications, "Id", "Userid", enclosedDocuments.applicationId);
            return View(enclosedDocuments);
        }

        // GET: EnclosedDocuments/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnclosedDocuments enclosedDocuments = db.enclosedDocuments.Find(id);
            if (enclosedDocuments == null)
            {
                return HttpNotFound();
            }
            ViewBag.applicationId = new SelectList(db.applications, "Id", "Userid", enclosedDocuments.applicationId);
            return View(enclosedDocuments);
        }

        // POST: EnclosedDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,applicationId,qualification,doctype,docname,DocURL")] EnclosedDocuments enclosedDocuments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enclosedDocuments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.applicationId = new SelectList(db.applications, "Id", "Userid", enclosedDocuments.applicationId);
            return View(enclosedDocuments);
        }

        // GET: EnclosedDocuments/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnclosedDocuments enclosedDocuments = db.enclosedDocuments.Find(id);
            if (enclosedDocuments == null)
            {
                return HttpNotFound();
            }
            return View(enclosedDocuments);
        }

        // POST: EnclosedDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            EnclosedDocuments enclosedDocuments = db.enclosedDocuments.Find(id);
            db.enclosedDocuments.Remove(enclosedDocuments);
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

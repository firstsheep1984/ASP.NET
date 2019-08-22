using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineAdmission.Models;

namespace OnlineAdmission.Controllers
{
    public class EducationalDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EducationalDetails
        [Authorize]
        public ActionResult Index()
        {
            var educationalDetails = db.educationalDetails.Include(e => e.application);
            //return View(educationalDetails.ToList());
            
            var eduList = new List<EducationalDetails>();
            string uname = User.Identity.Name;

            if (User.IsInRole("Admin"))
            {
                return View(db.educationalDetails.ToList());
            }
            else
            {
                eduList = db.educationalDetails.Where(u => u.application.Userid == uname).ToList();
                return View(eduList);
            }
        }

        // GET: EducationalDetails/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {          

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Check URL from( where the request from?)
            
            string urlFrom = Request.UrlReferrer.ToString();
            
            if (urlFrom.ToLower().Contains("applications"))
            {
                //Reqeust from Applications/Details/Next
                //Fetch EducationalDetails.Id based on id
                EducationalDetails education = db.educationalDetails.FirstOrDefault(edu => edu.applicationId == id);
                if (education == null)
                {
                    //ViewBag.NoEduFound = "No Detail Information!";           
                    return Redirect(urlFrom);

                }
                else
                {
                    //Got EducationalDetails.Id
                    int eduId = education.Id;
                    //Check EducationalDetails by eduId
                    education = db.educationalDetails.Find(eduId);
                    return View(education);
                 

                }

            }
            else
            {
                EducationalDetails educationalDetails = db.educationalDetails.Find(id);
                if (educationalDetails == null)
                {
                    return HttpNotFound();
                }
                return View(educationalDetails);
            }
        }

        // GET: EducationalDetails/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.applicationId = new SelectList(db.applications, "Id", "Userid");
            return View();
        }

        // POST: EducationalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,qualification,yearPassing,DurationFrom,DurationTo,BoardUniversity,Subjects,Percentage")] EducationalDetails educationalDetails)
        {
            if (ModelState.IsValid)
            {

                //applicationId,
                //if (Global.ApplicationID != "")
                //educationalDetails.applicationId = Global.ApplicationID;
                //string uID  = User.Identity.GetUserId();

                educationalDetails.applicationId = Global.ApplicationID;
                db.educationalDetails.Add(educationalDetails);
                db.SaveChanges();
                return RedirectToAction("Create", "EnclosedDocuments");
            }

            ViewBag.applicationId = new SelectList(db.applications, "Id", "Userid", educationalDetails.applicationId);
            return View(educationalDetails);
        }

        // GET: EducationalDetails/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalDetails educationalDetails = db.educationalDetails.Find(id);
            if (educationalDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.applicationId = new SelectList(db.applications, "Id", "Userid", educationalDetails.applicationId);
            return View(educationalDetails);
        }

        // POST: EducationalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,applicationId,qualification,yearPassing,DurationFrom,DurationTo,BoardUniversity,Subjects,Percentage")] EducationalDetails educationalDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationalDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.applicationId = new SelectList(db.applications, "Id", "Userid", educationalDetails.applicationId);
            return View(educationalDetails);
        }

        // GET: EducationalDetails/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalDetails educationalDetails = db.educationalDetails.Find(id);
            if (educationalDetails == null)
            {
                return HttpNotFound();
            }
            return View(educationalDetails);
        }

        // POST: EducationalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationalDetails educationalDetails = db.educationalDetails.Find(id);
            db.educationalDetails.Remove(educationalDetails);
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

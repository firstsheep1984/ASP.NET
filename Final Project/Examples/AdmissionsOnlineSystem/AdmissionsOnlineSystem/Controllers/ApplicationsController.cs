using System.Data;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AdmissionsOnlineSystem.Models;
using AdmissionsOnlineSystem.ViewModels;
using System.Collections.Generic;
using System;

namespace AdmissionsOnlineSystem.Controllers
{
    public class ApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Index()
        {
            //if (User.IsInRole(RoleName.CanManage))
            //{
            var applications = db.Applications.Include(a => a.User);
            return View(applications.ToList());
            //}
            /*else
            {
                string id = User.Identity.GetUserId();
                Application application = db.Applications.Include(a => a.Department).Include(a => a.Program).Where(a => a.ApplicationId == id).FirstOrDefault();
                return View(application);
            }*/
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Search(string query)
        {
            var applicates = db.Applications;
            var subset = applicates.Where(a => a.FirstName.StartsWith(query));        
            return this.PartialView("_Applicates", subset.ToList());
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
                id = User.Identity.GetUserId();

            Application application = db.Applications.Include(a => a.Department).Include(a => a.Program).Where(a => a.ApplicationId == id).FirstOrDefault();
            if (application == null)
            {
                return HttpNotFound();
            }

            string email = db.Users.Where(u => u.Id == id).Select(u => u.Email).FirstOrDefault();

            ApplicationViewModel applicationViewModel = new ApplicationViewModel()
            {
                ApplicationId = application.ApplicationId,
                DepartmentId = (application.Department != null ? application.Department.DepartmentId : 0),
                ProgramId = (application.Program != null ? application.Program.Id : 0),
                Email = email,
                FirstName = application.FirstName,
                LastName = application.LastName,
                TelePhoneNumber = application.TelePhoneNumber
            };

            PopulateDropDownLists(applicationViewModel.DepartmentId, applicationViewModel.ProgramId);

            return View(applicationViewModel);
        }

        public JsonResult GetProgramsByDepartmentId(int id)
        {
            var programs = GetProgramsByDepId(id);
            var result = (from r in programs
                          select new
                          {
                              id = r.Id,
                              name = r.Name
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public List<Program> GetProgramsByDepId(int id)
        {
            List<Program> programs = new List<Program>();
            if (id > 0)
                programs = db.Programs.Where(p => p.DepartmentId == id).ToList();
            else
                programs.Insert(0, new Program { Id = 0, Name = "--Select a program--" });

            return programs;
        }

        private void PopulateDropDownLists(int defaultDepartmentId, int defaultProgramId)
        {
            List<Department> lstDepartment = db.Departments.ToList();
            lstDepartment.Insert(0, new Department { DepartmentId = 0, Name = "--Select Department--" });
            List<Program> lstProgram = new List<Program>();
            ViewBag.DepartmentList = new SelectList(lstDepartment, "DepartmentId", "Name", selectedValue: defaultDepartmentId);
            if (defaultDepartmentId != 0)
                lstProgram = GetProgramsByDepId(defaultDepartmentId);
            else
                lstProgram.Insert(0, new Program { Id = 0, Name = "--Select Program--" });
            ViewBag.ProgramList = new SelectList(lstProgram, "Id", "Name", selectedValue: defaultProgramId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationViewModel applicationVM)
        {
            if (ModelState.IsValid)
            {
                Application application = db.Applications.Find(applicationVM.ApplicationId);
                if (applicationVM.DepartmentId != 0)
                    application.Department = db.Departments.Find(applicationVM.DepartmentId);
                if (applicationVM.ProgramId != 0)
                    application.Program = db.Programs.Find(applicationVM.ProgramId);
                application.FirstName = applicationVM.FirstName;
                application.LastName = applicationVM.LastName;
                application.TelePhoneNumber = applicationVM.TelePhoneNumber;
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                if (application.EducationDetails == null)
                    application.EducationDetails = new List<EducationDetail>();
                return RedirectToAction("EducationDetails", "Applications", new { appId = application.ApplicationId });
            }

            PopulateDropDownLists(applicationVM.DepartmentId, applicationVM.ProgramId);

            return View(applicationVM);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateEducationDetails(string appId)
        {
            Application application = db.Applications.Find(appId);
            EducationDetail educationDetail = new EducationDetail();
            educationDetail.Application = application;
            educationDetail.ApplicationId = application.ApplicationId;
            return View(educationDetail);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateEducationDetails(EducationDetail educationDetail)
        {
            Application application = db.Applications.Find(educationDetail.ApplicationId);
            educationDetail.Application = application;
            if (ModelState.IsValid)
            {
                
                db.EducationDetails.Add(educationDetail);
                db.SaveChanges();
                return RedirectToAction("EducationDetails", "Applications", new { appId = educationDetail.ApplicationId } );
            }

            return View(educationDetail);
        }

        [Authorize]
        public ActionResult EducationDetails(string appId)
        {
            if (appId == null)
                appId = User.Identity.GetUserId();

            Application application = db.Applications.Include(a => a.Department).Include(a => a.Program).Where(a => a.ApplicationId == appId).FirstOrDefault();
            if (application == null)
            {
                return HttpNotFound();
            }

            List<EducationDetail> educationDetails = db.EducationDetails.Include(e => e.Application).Where(e => e.ApplicationId == application.ApplicationId).ToList();

            return View(educationDetails);
        }

        [HttpGet]
        public ActionResult EditEducationDetails(int id)
        {
            EducationDetail educationDetail = db.EducationDetails.Include(e => e.Application).Where(e => e.Id == id).FirstOrDefault();
            return View(educationDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEducationDetails(EducationDetail educationDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationDetail).State = EntityState.Modified;
                db.SaveChanges();
               
                return RedirectToAction("EducationDetails", "Applications", new { appId = educationDetail.ApplicationId });
            }
            return View(educationDetail);
        }

        [HttpGet]
        public ActionResult DeleteEducationDetails(int id)
        {
            EducationDetail educationDetail = db.EducationDetails.Include(e => e.Application).Where(e => e.Id == id).FirstOrDefault();
            return View(educationDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEducationDetails(EducationDetail educationDetail)
        {
            if (ModelState.IsValid)
            {
                string applicationId = educationDetail.ApplicationId;
                db.Entry(educationDetail).State = EntityState.Deleted;
                db.EducationDetails.Remove(educationDetail);
                db.SaveChanges();

                return RedirectToAction("EducationDetails", "Applications", new { appId = applicationId });
            }
            return View(educationDetail);
        }

        [Authorize]
        public ActionResult EnclosedDocuments(string appId)
        {
            if (appId == null)
                appId = User.Identity.GetUserId();

            Application application = db.Applications.Include(a => a.Department).Include(a => a.Program).Where(a => a.ApplicationId == appId).FirstOrDefault();
            if (application == null)
            {
                return HttpNotFound();
            }

            List<EnclosedDocument> enclosedDocuments = db.EnclosedDocuments.Include(e => e.Application).Where(e => e.ApplicationId == application.ApplicationId).ToList();

            return View(enclosedDocuments);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateEnclosedDocuments(string appId)
        {
            Application application = db.Applications.Find(appId);
            EnclosedDocument enclosedDocument = new EnclosedDocument();
            enclosedDocument.Application = application;
            enclosedDocument.ApplicationId = application.ApplicationId;
            return View(enclosedDocument);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateEnclosedDocuments(EnclosedDocument enclosedDocument)
        {
            Application application = db.Applications.Find(enclosedDocument.ApplicationId);
            enclosedDocument.Application = application;
            if (ModelState.IsValid)
            {

                db.EnclosedDocuments.Add(enclosedDocument);
                db.SaveChanges();
                return RedirectToAction("EnclosedDocuments", "Applications", new { appId = enclosedDocument.ApplicationId });
            }

            return View(enclosedDocument);
        }

        public ActionResult Details(string id)
        {
            Application application = db.Applications.Include(p => p.Department).Include(p => p.Program).Where(p=>p.ApplicationId == id).FirstOrDefault();
            return View("_StudentDetailsTab", application);
        }

        public ActionResult _EducationDetailsTab(string id)
        {
            return PartialView();
        }

        public ActionResult _EnclosedDocumentsTab(string id)
        {
            return PartialView();
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

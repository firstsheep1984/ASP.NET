using System.Data;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AdmissionsOnlineSystem.Models;
using AdmissionsOnlineSystem.ViewModels;
using System.Collections.Generic;

namespace AdmissionsOnlineSystem.Controllers
{
    [Authorize]
    public class ApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<ApplicationViewModelForList> GetList()
        {
            var query = from apps in db.Applications.Include(a => a.Department).Include(a => a.Program)
                        select new ApplicationViewModelForList
                        {
                            ApplicationId = apps.ApplicationId,
                            DepartmentName = apps.Department.Name,
                            ProgramName = apps.Program.Name,
                            RegistrationDate = apps.RegistrationDate,
                            Status = apps.StatusString,
                            StudentName = apps.FirstName + " " + apps.LastName
                        };

            return query.ToList();
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Index(ApplicationViewModelForList applicationViewModelForList)
        {
            return View(GetList());
        }

        public ActionResult _PersonalInfo(string id)
        {
            var applicationViewModel = RetrieveApplicationVM(id);
            return PartialView(applicationViewModel);
        }

        public ActionResult _EducationDetails(string id)
        {
            if (id == null)
                id = User.Identity.GetUserId();

            Application application = db.Applications.Include(a => a.EducationDetails).Where(a => a.ApplicationId == id).FirstOrDefault();
            return PartialView(application.EducationDetails);
        }

        private EducationDetailViewModel GetEducationDetailVM(string appId, int? id) {
            if (string.IsNullOrEmpty(appId))
                appId = User.Identity.GetUserId();
            EducationDetailViewModel educationDetailVM = null;
            if (id.HasValue)
            {
                EducationDetail educationDetail = db.EducationDetails.Find(id.Value);
                educationDetailVM = new EducationDetailViewModel()
                {
                    Id = educationDetail.Id,
                    ApplicationId = educationDetail.ApplicationId,
                    BoardUniversity = educationDetail.BoardUniversity,
                    Duration = educationDetail.Duration,
                    Percentage = educationDetail.Percentage,
                    Qualification = educationDetail.Qualification,
                    Subjects = educationDetail.Subjects,
                    Year = educationDetail.Year
                };
            }
            else
                educationDetailVM = new EducationDetailViewModel() { ApplicationId = appId };
            return educationDetailVM;
        }

        [HttpGet]
        public ActionResult _AddEditEducationDetail(int? id)
        {
            var educationDetailVM = GetEducationDetailVM(null, id);
            return PartialView(educationDetailVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _DeleteEducationDetail(EducationDetailViewModel educationDetailVM)
        {
            
            if (ModelState.IsValid)
            {
                var educationDetail = db.EducationDetails.Find(educationDetailVM.Id);
                string applicationId = educationDetail.ApplicationId;
                db.EducationDetails.Remove(educationDetail);
                db.SaveChanges();
                List<EducationDetail> educationDetails = GetAllEducationDetailsByApplicant(applicationId);
                return PartialView("_EducationDetailsList", educationDetails);
            }
            return PartialView(educationDetailVM);
        }

        [HttpGet]
        public ActionResult _DeleteEducationDetail(string appId, int? id)
        {
            var educationDetailVM = GetEducationDetailVM(appId, id);
            return PartialView(educationDetailVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _AddEditEducationDetail(EducationDetailViewModel educationDetailVM)
        {
            if (ModelState.IsValid)
            {
                EducationDetail educationDetail = null;
                if (educationDetailVM.Id.HasValue)
                    educationDetail = db.EducationDetails.Find(educationDetailVM.Id.Value);
                else
                    educationDetail = new EducationDetail();
                educationDetail.ApplicationId = educationDetailVM.ApplicationId;
                educationDetail.BoardUniversity = educationDetailVM.BoardUniversity;
                educationDetail.Duration = educationDetailVM.Duration;
                educationDetail.Qualification = educationDetailVM.Qualification;
                educationDetail.Subjects = educationDetailVM.Subjects;
                educationDetail.Year = educationDetailVM.Year;
                educationDetail.Percentage = educationDetailVM.Percentage;
                if (educationDetail.Id <= 0)
                {
                    db.EducationDetails.Add(educationDetail);
                    educationDetailVM.Id = educationDetail.Id;
                }
                else
                    db.Entry(educationDetail).State = EntityState.Modified;
                db.SaveChanges();
                List<EducationDetail> educationDetails = GetAllEducationDetailsByApplicant(educationDetailVM.ApplicationId);
                return PartialView("_EducationDetailsList", educationDetails);
            }
            return PartialView(educationDetailVM);
        }

        private List<EducationDetail> GetAllEducationDetailsByApplicant(string applicationId) {
            return db.EducationDetails.Where(e => e.ApplicationId == applicationId).ToList();
        }

        public ActionResult _EnclosedDocuments(string id)
        {
            if (id == null)
                id = User.Identity.GetUserId();

            Application application = db.Applications.Include(a => a.EnclosedDocuments).Where(a => a.ApplicationId == id).FirstOrDefault();
            return PartialView(application.EnclosedDocuments);
        }

        private ApplicationViewModel RetrieveApplicationVM(string id)
        {
            if (id == null)
                id = User.Identity.GetUserId();

            Application application = db.Applications.Include(a => a.Department).Include(a => a.Program).Where(a => a.ApplicationId == id).FirstOrDefault();

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
            return applicationViewModel;
        }

        public ActionResult Edit(string id)
        {
            var applicationViewModel = RetrieveApplicationVM(id);
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

        public JsonResult GetDepartments()
        {
            var departments = db.Departments.ToList();
            departments.Insert(0, new Department() { DepartmentId =0, Name = "--All Departments--" });
            var result = (from r in departments
                          select new
                          {
                              id = r.DepartmentId,
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
                return new EmptyResult();
            }

            PopulateDropDownLists(applicationVM.DepartmentId, applicationVM.ProgramId);

            return View(applicationVM);
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

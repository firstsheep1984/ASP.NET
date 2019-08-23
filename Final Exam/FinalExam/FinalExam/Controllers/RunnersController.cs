using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalExam.Infraestructure;
using FinalExam.Models;
using FinalExam.ViewModels;
using PagedList;

namespace FinalExam.Controllers
{
    public class RunnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Runners
        public ViewResult Index(string sortOrder, string sortDir, string currentFilter, string searchString, int? page)
        {
            ViewBag.sortOrder = sortOrder;
            ViewBag.sortDir = sortDir;
            sortOrder = sortOrder + "_" + sortDir;
            // ViewBag.CurrentSort = sortOrder;
            // ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            // ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in db.Runners.Include(r => r.Country).Include(r => r.Event)
                           select new RunnersViewModel()
                           {
                               RunnerId = s.RunnerId,
                               Name = s.FirstName + " " + s.LastName,
                               Email = s.Email,
                               EventName = s.Event.Name,
                               EventStatus = s.Event.IsClosed.HasValue ? (s.Event.IsClosed.Value ? "Closed" : "Open") : "Open",
                               Gender = s.Gender.ToString(),
                               Telephone = s.Telephone


                           };
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;

                default:  // Name ascending 
                    students = students.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        public JsonResult GetStateByCountryId(int id)
        {
            var states = GetStatesByCouId(id);
            var result = (from r in states
                          select new
                          {
                              id = r.Id,
                              name = r.Name
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public List<State> GetStatesByCouId(int id)
        {
            List<State> states = new List<State>();
            if (id > 0)
                states = db.States.Where(p => p.CountryId == id).ToList();
            else
                states.Insert(0, new State { Id = 0, Name = "--Select a state--" });

            return states;
        }

        private void PopulateDropDownLists(int defaultCountryId, int defaultStateId)
        {
            List<Country> lstCountry = db.Countries.ToList();
            lstCountry.Insert(0, new Country { Id = 0, Name = "--Select Country--" });
            List<State> lstState = new List<State>();
            ViewBag.CountryList = new SelectList(lstCountry, "CountryId", "Name", selectedValue: defaultCountryId);
            if (defaultCountryId != 0)
                lstState = GetStatesByCouId(defaultCountryId);
            else
                lstState.Insert(0, new State { Id = 0, Name = "--Select State--" });
            ViewBag.StateList = new SelectList(lstState, "Id", "Name", selectedValue: defaultStateId);
        }

        // GET: Runners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runner runner = db.Runners.Find(id);
            if (runner == null)
            {
                return HttpNotFound();
            }
            return View(runner);
        }

        // GET: Runners/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name");
            ViewBag.StateList = new SelectList(db.States, "Id", "Name");
            Runner runner = new Runner();

            // PopulateDropDownLists(runner.CountryId, runner.State);
            return View();
        }

        // POST: Runners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RunnerId,FirstName,LastName,BirthDate,Gender,Email,Telephone,Address,PostalCode,CountryId,RegistrationDate,ContactPersonName,ContactPersonTelephone,EventId")] Runner runner)
        {
            if (ModelState.IsValid)
            {
                db.Runners.Add(runner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", runner.CountryId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", runner.EventId);
            return View(runner);
        }

        // GET: Runners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runner runner = db.Runners.Find(id);
            if (runner == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", runner.CountryId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", runner.EventId);
            return View(runner);
        }

        // POST: Runners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RunnerId,FirstName,LastName,BirthDate,Gender,Email,Telephone,Address,PostalCode,CountryId,RegistrationDate,ContactPersonName,ContactPersonTelephone,EventId")] Runner runner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(runner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", runner.CountryId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", runner.EventId);
            return View(runner);
        }

        // GET: Runners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runner runner = db.Runners.Find(id);
            if (runner == null)
            {
                return HttpNotFound();
            }
            return View(runner);
        }

        // POST: Runners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Runner runner = db.Runners.Find(id);
            db.Runners.Remove(runner);
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

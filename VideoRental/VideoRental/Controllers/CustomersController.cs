using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoRental.Models;

namespace VideoRental.Controllers
{
    [Authorize(Roles = RoleName.CanManage)]
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.MembershipType);
            if (User.IsInRole(RoleName.CanManage))
                return View(customers.ToList());
            else
                return View("ReadOnlyList", customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [AllowAnonymous]
        public ActionResult Search(string query) {
            var customers = db.Customers.Include(c => c.MembershipType);
            var subset = customers.Where(c => c.Name.StartsWith(query));
            if (User.IsInRole(RoleName.CanManage))
                return this.PartialView("_Customers", subset.ToList());
            else
                return PartialView("_ReadOnlyCustomers", subset.ToList());
            
        }

        
        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsSubscribedToNewsLetter,MembershipTypeId,Birthdate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
               // ModelState.AddModelError("Birthdate", "Something wrong happened");
            }

            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", customer.MembershipTypeId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", customer.MembershipTypeId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsSubscribedToNewsLetter,MembershipTypeId,Birthdate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", customer.MembershipTypeId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

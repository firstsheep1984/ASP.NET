using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VedioRental.Models;

namespace VedioRental.Controllers
{
    [Authorize(Roles = RoleName.CanManage)]
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        [AllowAnonymous]
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.MembershipType);
            if (User.IsInRole(RoleName.CanManage))
                return View(customers.ToList());
            else
                return View("ReadOnlyLIst", customers.ToList());
        }
        [AllowAnonymous]
        public ActionResult Search(string query)
        {
            var customers = db.Customers;//.Include(c => c.MembershipType);
            var result = customers              
                .AsQueryable()
                .Where(customer => customer.Name.ToLower().Contains(query.ToLower()))               
                .ToList();

            return this.PartialView("_CustomerResult", result);
        }
        [AllowAnonymous]
        public ActionResult ContentById(int id)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            var customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Customer not found");
            }

            return this.Content(customer.Id.ToString());
        }

        // GET: Customers/Details/5
        [Authorize(Roles = RoleName.CanManage)]
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

        // GET: Customers/Create
        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // add more
            else
            {
                ModelState.AddModelError("", "Something wrong happened");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        [Authorize(Roles = RoleName.CanManage)]
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
            return View(customer);
        }

        // POST: Customers/Edit/5
        [Authorize(Roles = RoleName.CanManage)]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        [Authorize(Roles = RoleName.CanManage)]
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
        [Authorize(Roles = RoleName.CanManage)]
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

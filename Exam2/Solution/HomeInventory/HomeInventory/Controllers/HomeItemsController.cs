using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeInventory.Helpers;
using HomeInventory.Infraestructure;
using HomeInventory.Models;
using HomeInventory.ViewModels;
using PagedList;

namespace HomeInventory.Controllers
{
    public class HomeItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HomeItems
        public ActionResult Index(string sortOrder, string sortDir, string currentFilter, string searchString, int? page)
        {
            ViewBag.sortOrder = sortOrder;
            ViewBag.sortDir = sortDir;
            sortOrder = sortOrder + "_" + sortDir;

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var homeitems = db.HomeItems.Include(h => h.Location).Include(h => h.PurchaseInfo);
                           
            if (!String.IsNullOrEmpty(searchString))
                homeitems = homeitems.Where(p => p.Description.Contains(searchString));

            switch (sortOrder.ToLower())
            {
                case "description_desc":
                    homeitems = homeitems.OrderByDescending(p => p.Description);
                    break;
                case "location_asc":
                    homeitems = homeitems.OrderBy(h => h.Location.Name);
                    break;
                case "location_desc":
                    homeitems = homeitems.OrderByDescending(p => p.Location.Name);
                    break;
                case "model_asc":
                    homeitems = homeitems.OrderBy(p => p.Model);
                    break;
                case "model_desc":
                    homeitems = homeitems.OrderByDescending(p => p.Model);
                    break;
                case "serialnumber_asc":
                    homeitems = homeitems.OrderBy(p => p.SerialNumber);
                    break;
                case "serialnumber_desc":
                    homeitems = homeitems.OrderByDescending(p => p.SerialNumber);
                    break;
                default:  // Description ascending 
                    homeitems = homeitems.OrderBy(p => p.Description);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            var data = homeitems.ToPagedList(pageNumber, pageSize);
            //if (Request.IsAjaxRequest())
            //    return PartialView("_SearchResult", data);
            //else
            return View(data);
        }

        // GET: HomeItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeItem homeItem = db.HomeItems.Include(h => h.Location).Include(h => h.PurchaseInfo).Where(h => h.HomeItemId == id).FirstOrDefault();
            if (homeItem == null)
            {
                return HttpNotFound();
            }
            return View(homeItem);
        }

        // GET: HomeItems/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View();
        }

        // POST: HomeItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeItemViewModel homeItemVM)
        {
            if (ModelState.IsValid)
            {
                HomeItem homeItem = new HomeItem();
                homeItem.LocationId = homeItemVM.LocationId;
                homeItem.Description = homeItemVM.Description;
                homeItem.Model = homeItemVM.Model;
                homeItem.SerialNumber = homeItemVM.SerialNumber;
                homeItem.Photo = ImageConverter.ByteArrayFromPostedFile(homeItemVM.Photo);
                PurchaseInfo purchaseInfo = new PurchaseInfo();
                purchaseInfo.When = homeItemVM.When;
                purchaseInfo.Where = homeItemVM.Where;
                purchaseInfo.Warranty = homeItemVM.Warranty;
                purchaseInfo.Price = homeItemVM.Price;
                homeItem.PurchaseInfo = purchaseInfo;
                db.HomeItems.Add(homeItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", homeItemVM.LocationId);
            return View(homeItemVM);
        }

       

        // GET: HomeItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeItem homeItem = db.HomeItems.Include(h=>h.Location).Include(h=>h.PurchaseInfo).Where(h=>h.HomeItemId == id).FirstOrDefault();
            if (homeItem == null)
            {
                return HttpNotFound();
            }
            return View(homeItem);
        }

        // POST: HomeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeItem homeItem = db.HomeItems.Find(id);
            db.HomeItems.Remove(homeItem);
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

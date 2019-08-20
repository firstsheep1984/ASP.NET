using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VedioRentalData;
using VideoRental.Models;

namespace VedioRentalImprove.Controllers
{
    public class MoviesController : BaseController
    {
        public MoviesController(IVedioRentalData data):base(data)
        {

        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = Data.Movies.All().Include(m => m.Genre);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = Data.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(Data.Genres.All(), "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,GenreId,DateAdded,ReleaseDate,NumberInStock,NumberAvailable")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                Data.Movies.Add(movie);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(Data.Genres.All(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = Data.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(Data.Genres.All(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,GenreId,DateAdded,ReleaseDate,NumberInStock,NumberAvailable")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(movie).State = EntityState.Modified;
                Data.Movies.Update(movie);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(Data.Genres.All(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = Data.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Data.Movies.Delete(id);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}

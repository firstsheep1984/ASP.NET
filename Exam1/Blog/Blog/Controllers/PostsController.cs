using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Blog.Helpers;
using Blog.Models;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }
        /// <summary>
        /// Posts in the home page
        /// </summary>
        /// <returns></returns>
        public ActionResult OnlyPublic()
        {
            var posts = db.Posts.Where(p => p.PostedOn.HasValue).OrderByDescending(p => p.PostedOn).ToList();
            return View("OnlyPublic", posts);
        }

        /// <summary>
        /// One post with its comments
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Full(int id)
        {
            var post = db.Posts.Include(p => p.Comments).Where(p => p.Id == id).FirstOrDefault();
            return View("FullPost", post);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Include(p => p.Comments).Where(p => p.Id == id).FirstOrDefault();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Title,Content,PostedOn")] CreatePostViewModel createPostViewModel)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.CreatedOn = DateTime.Now;
                post.UpdatedOn = DateTime.Now;
                post.Title = createPostViewModel.Title;
                post.Content = createPostViewModel.Content;
                post.PostedOn = createPostViewModel.PostedOn;
                post.UserFullName = UserHelper.GetUserName(db.Users, User.Identity);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createPostViewModel);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,CreatedOn,UpdatedOn,PostedOn,UserFullName")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.UpdatedOn = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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

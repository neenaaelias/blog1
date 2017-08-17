using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using blog1.Models;
using Microsoft.AspNet.Identity;

namespace blog1.Controllers
{
    [RequireHttps]
    public class CommentsController : UserController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Author).Include(c => c.Post);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = db.Posts.FirstOrDefault(p => p.Slug == slug);
            if (post == null)
            {
                return HttpNotFound();
            }

            //ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName");
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title");
            ViewBag.SlugText = post.Slug;

            return View();
        }


        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostId,AuthorId,Body,Created,Updated,UpdateReason")] Comment comment, string slug)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(slug))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var post = db.Posts.FirstOrDefault(p => p.Slug == slug);
                if (post == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    // look up post so that I can get the ID to set the PostID of the comment
                    comment.PostId = post.Id;

                    var userId = User.Identity.GetUserId();
                    comment.AuthorId = userId;
                   comment.Created = DateTimeOffset.Now;
                    db.Comments.Add(comment);
                    db.SaveChanges();
                    var thisPost = db.Posts.Find(comment.PostId);
                    if (thisPost != null)
                    {
                    return RedirectToAction("Details", "BlogPosts", new { slug = post.Slug });

                    }
                }
            }

            //ViewBag.AuthorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.AuthorId);
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AuthorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.AuthorId);
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostId,AuthorId,Body,Created,Updated,UpdateReason")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Updated = DateTimeOffset.Now;
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Details", "BlogPosts", new { slug = post.Slug });
                var thisPost = db.Posts.Find(comment.PostId);
               return RedirectToAction("Details", "BlogPosts", new { slug = thisPost.Slug });
            }
            //ViewBag.AuthorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.AuthorId);
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id, string slug)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName");
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title");

            Comment comment = db.Comments.Find(id);

            var post = db.Posts.FirstOrDefault(p => p.Id == comment.PostId);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Slug = post.Slug;

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            var thisPost = db.Posts.Find(comment.PostId);
            return RedirectToAction("Details", "BlogPosts", new { slug = thisPost.Slug });
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

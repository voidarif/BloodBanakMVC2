using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodBanakMVC2.Context;

namespace BloodBanakMVC2.Controllers
{
    public class userPostsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: userPosts
        public ActionResult Index()
        {
            return View(db.userPosts.ToList());
        }

        // GET: userPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userPost userPost = db.userPosts.Find(id);
            if (userPost == null)
            {
                return HttpNotFound();
            }
            return View(userPost);
        }

        // GET: userPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Mobile,Division,District,Thana,Unian,Village,Message")] userPost userPost)
        {
            if (ModelState.IsValid)
            {
                db.userPosts.Add(userPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userPost);
        }

        // GET: userPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userPost userPost = db.userPosts.Find(id);
            if (userPost == null)
            {
                return HttpNotFound();
            }
            return View(userPost);
        }

        // POST: userPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Mobile,Division,District,Thana,Unian,Village,Message")] userPost userPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userPost);
        }

        // GET: userPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userPost userPost = db.userPosts.Find(id);
            if (userPost == null)
            {
                return HttpNotFound();
            }
            return View(userPost);
        }

        // POST: userPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userPost userPost = db.userPosts.Find(id);
            db.userPosts.Remove(userPost);
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

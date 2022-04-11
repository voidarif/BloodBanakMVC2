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
    public class RequestForBloodController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: RequestForBlood
        public ActionResult Index()
        {
            var tbl_userPost = db.tbl_userPost.Include(t => t.userRegistration);
            return View(tbl_userPost.ToList());
        }

        // GET: RequestForBlood/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_userPost tbl_userPost = db.tbl_userPost.Find(id);
            if (tbl_userPost == null)
            {
                return HttpNotFound();
            }
            return View(tbl_userPost);
        }

        // GET: RequestForBlood/Create
        public ActionResult Create()
        {
            /*var sessionID = db.userRegistrations.Where(x => x.ID.Equals(Session["ID"].ToString()));
            var sessionName= db.userRegistrations.Where(x => x.FullName.Equals(Session["FullName"].ToString()));*/
            ViewBag.UserID = new SelectList(db.userRegistrations, "ID", "FullName");
            /*ViewBag.UserID = new SelectList(db.userRegistrations, sessionID, sessionName);*/

            return View();
            
        }

        // POST: RequestForBlood/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public ActionResult Create([Bind(Include ="ID,UserID,Message")] tbl_userPost tbl_userPost)*/
        public ActionResult Create([Bind(Include = "ID,UserID,Message")] tbl_userPost tbl_userPost)
        {
            var Se = TempData["UserID"];
            /*tbl_userPost UserID = TempData["UserID"];*/
            /* tbl_userPost UserID = db.tbl_userPost.Where(x => x.UserID.Equals(Se)).FirstOrDefault();*/
            /* tbl_userPost UserID= db.tbl_userPost.Where(x => x.UserID.Equals(Se)).FirstOrDefault();*/
            /*TempData["UserID"] = tbl_userPost.UserID;*/

            if (ModelState.IsValid)
            {
                db.tbl_userPost.Add(tbl_userPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.userRegistrations, "ID", "FullName", tbl_userPost.UserID);
            return View(tbl_userPost);
        }

        // GET: RequestForBlood/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_userPost tbl_userPost = db.tbl_userPost.Find(id);
            if (tbl_userPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.userRegistrations, "ID", "FullName", tbl_userPost.UserID);
            return View(tbl_userPost);
        }

        // POST: RequestForBlood/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Message")] tbl_userPost tbl_userPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_userPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.userRegistrations, "ID", "FullName", tbl_userPost.UserID);
            return View(tbl_userPost);
        }

        // GET: RequestForBlood/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_userPost tbl_userPost = db.tbl_userPost.Find(id);
            if (tbl_userPost == null)
            {
                return HttpNotFound();
            }
            return View(tbl_userPost);
        }

        // POST: RequestForBlood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_userPost tbl_userPost = db.tbl_userPost.Find(id);
            db.tbl_userPost.Remove(tbl_userPost);
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

        public ActionResult ShowBloodRequests()
        {
                var tbl_userPost = db.tbl_userPost.Include(t => t.userRegistration);
                return View(tbl_userPost.ToList());
            
        }
    }
}

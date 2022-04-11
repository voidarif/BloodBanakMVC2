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
    public class tbl_UserPostsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: tbl_UserPosts
        public ActionResult Index()
        {
            return View(db.tbl_UserPosts.ToList());
        }

        // GET: tbl_UserPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserPosts tbl_UserPosts = db.tbl_UserPosts.Find(id);
            if (tbl_UserPosts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserPosts);
        }

        // GET: tbl_UserPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_UserPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Mobile,Division,District,Thana,Unian,Village,BloodGroup,DateTime,Message")] tbl_UserPosts tbl_UserPosts)
        {
            tbl_UserPosts.DateTime = DateTime.Now;
            tbl_UserPosts.Name = Session["FullName"].ToString();
            tbl_UserPosts.Email = Session["Email"].ToString();
            tbl_UserPosts.Mobile = Session["Mobile"].ToString();
            tbl_UserPosts.Division = Session["Division"].ToString();
            tbl_UserPosts.District = Session["District"].ToString();
            tbl_UserPosts.Thana = Session["Thana"].ToString();
            tbl_UserPosts.Unian = Session["Unian"].ToString();
            tbl_UserPosts.Village = Session["Village"].ToString();
            tbl_UserPosts.BloodGroup = Session["BloodGroup"].ToString();


            if (ModelState.IsValid)
            {
                db.tbl_UserPosts.Add(tbl_UserPosts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_UserPosts);
        }

        // GET: tbl_UserPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserPosts tbl_UserPosts = db.tbl_UserPosts.Find(id);
            if (tbl_UserPosts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserPosts);
        }

        // POST: tbl_UserPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Mobile,Division,District,Thana,Unian,Village,BloodGroup,DateTime,Message")] tbl_UserPosts tbl_UserPosts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_UserPosts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_UserPosts);
        }

        // GET: tbl_UserPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserPosts tbl_UserPosts = db.tbl_UserPosts.Find(id);
            if (tbl_UserPosts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserPosts);
        }

        // POST: tbl_UserPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_UserPosts tbl_UserPosts = db.tbl_UserPosts.Find(id);
            db.tbl_UserPosts.Remove(tbl_UserPosts);
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
            return View(db.tbl_UserPosts.ToList());

        }

        public ActionResult RequestDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_UserPosts tbl_UserPosts = db.tbl_UserPosts.Find(id);
            if (tbl_UserPosts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UserPosts);
        }
    }
}

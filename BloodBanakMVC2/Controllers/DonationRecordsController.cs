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
    public class DonationRecordsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: DonationRecords
        public ActionResult Index()
        {
            return View(db.tbl_DonationRecords.ToList());
        }

        // GET: DonationRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationRecords tbl_DonationRecords = db.tbl_DonationRecords.Find(id);
            if (tbl_DonationRecords == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationRecords);
        }

        // GET: DonationRecords/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
            tbl_UserPosts tb = new tbl_UserPosts();
            var ID = db.tbl_UserPosts.Find(id);
            Session["tempAcceptorName"] = ID.Name;
            Session["tempAcceptorBG"] = ID.BloodGroup;
            return View();
        }

       

        // POST: DonationRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DonorName,AcceptorName,BloodGroup,DateTime")] tbl_DonationRecords tbl_DonationRecords)
        {
            tbl_UserPosts tb = new tbl_UserPosts();
            tbl_DonationRecords.DonorName = Session["DonorName"].ToString();
            tbl_DonationRecords.DateTime = DateTime.Now;
            tbl_DonationRecords.AcceptorName = Session["tempAcceptorName"].ToString();
            tbl_DonationRecords.BloodGroup = Session["tempAcceptorBG"].ToString();
            if (ModelState.IsValid)
            {
                db.tbl_DonationRecords.Add(tbl_DonationRecords);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_DonationRecords);
        }

        // GET: DonationRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationRecords tbl_DonationRecords = db.tbl_DonationRecords.Find(id);
            if (tbl_DonationRecords == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationRecords);
        }

        // POST: DonationRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DonorName,AcceptorName,BloodGroup,DateTime")] tbl_DonationRecords tbl_DonationRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_DonationRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_DonationRecords);
        }

        // GET: DonationRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationRecords tbl_DonationRecords = db.tbl_DonationRecords.Find(id);
            if (tbl_DonationRecords == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationRecords);
        }

        // POST: DonationRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_DonationRecords tbl_DonationRecords = db.tbl_DonationRecords.Find(id);
            db.tbl_DonationRecords.Remove(tbl_DonationRecords);
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

        public ActionResult ShowDonationRecords()
        {
            return View(db.tbl_DonationRecords.ToList());
        }
    }
}

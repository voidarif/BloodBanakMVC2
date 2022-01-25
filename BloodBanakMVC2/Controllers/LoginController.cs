using BloodBanakMVC2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBanakMVC2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        BloodBankEntities dbObj = new BloodBankEntities();
        public ActionResult Login()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult CheckUser()
        {
            return View();
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult CheckUser(userRegistration model)
        {
            userRegistration obj = new userRegistration();
            if (ModelState.IsValid)
            {
                using (BloodBankEntities db = new BloodBankEntities())
                {
                    var v = db.userRegistrations.Where(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password)).FirstOrDefault();

                    if (v != null) {
                        Session["ID"] = obj.ID.ToString(); //newline
                       
                        return RedirectToAction("Index", "Home"); 
                    }
                    else
                        {

                          //  Session["log"] = v.Email.ToString();
                            return RedirectToAction("About", "Home");
                        }

                    }
                   
                }
 
            ModelState.Clear();
            return View();
        }

        public ActionResult Index()
        {
            if (Session["log"] != null)
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult user()
        {
            if (Session["log"] != null)
            {
                return View("~/Views/Home/About.cshtml");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
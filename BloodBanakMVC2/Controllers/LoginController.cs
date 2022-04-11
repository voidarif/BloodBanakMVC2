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

       /*public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Autherize()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(userRegistration ur)
        {
            using (BloodBankEntities db=new BloodBankEntities())
            {
                var userDetails = db.userRegistrations.Where(x => x.Email == ur.Email && x.Password == ur.Password).FirstOrDefault();
                if(userDetails==null)
                {
                    ur.LoginError = "Wrong email or password";
                    return View("Index", ur);
                }else
                {
                    Session["ID"] = userDetails.ID;
                    Session["FullName"] = userDetails.FullName;
                    return RedirectToAction("Index", "Home");
                }
            }
        }*/

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CheckUser()
        {
            return View();
        }
        [HttpGet]
        // [ValidateAntiForgeryToken]
        public ActionResult CheckUser(userRegistration model)
        {
            userRegistration obj = new userRegistration();
            if (ModelState.IsValid)
            {
                using (BloodBankEntities db = new BloodBankEntities())
                {
                    var v = db.userRegistrations.Where(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password)).FirstOrDefault();
                    var email = db.userRegistrations.Where(x => x.Email.Equals(model.Email)).FirstOrDefault();
                    var pass= db.userRegistrations.Where(x => x.Password.Equals(model.Password)).FirstOrDefault();
                    /*var adminEmail = db.userRegistrations.Where(x => x.Email.Equals(model.Email)).FirstOrDefault();
                    var adminPass= db.userRegistrations.Where(x => x.Password.Equals("admin")).FirstOrDefault();
                   
                    if (adminEmail.ToString() && adminPass == null)
                    {
                        return RedirectToAction("UserList", "Registration");
                    }*/
                    if (v != null)
                    {
                        Session["ID"] = v.ID; //newline
                        Session["FullName"] = v.FullName;
                        Session["DonorName"] = v.FullName;
                        Session["Email"] = v.Email;
                        Session["Mobile"] = v.Mobile;
                        Session["Division"] = v.Division;
                        Session["District"] = v.District;
                        Session["Thana"] = v.Sub_District;
                        Session["Unian"] = v.Union_council;
                        Session["Village"] = v.Village;
                        Session["BloodGroup"] = v.BloodGroup;

                        // Session["FullName"] = model.FullName.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    if(email !=null && pass==null)
                    {
                        // return RedirectToAction("NotanUser", "NotanUser");
                        return RedirectToAction("LoginFailed", "LoginFailed");
                    }
                    if(email == null && pass == null)
                    {

                        //  Session["log"] = v.Email.ToString();
                        //return RedirectToAction("About", "Home");
                        return RedirectToAction("NotanUser", "NotanUser");
                    }
                   

                }

            }

            ModelState.Clear();
            return View();
        }

        /* public ActionResult Index()
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
         }*/

    }
}
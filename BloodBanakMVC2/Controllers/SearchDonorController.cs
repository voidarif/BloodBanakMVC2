using BloodBanakMVC2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBanakMVC2.Controllers
{
    public class SearchDonorController : Controller
    {
        BloodBankEntities dbObj = new BloodBankEntities();
        // GET: SearchDonor

        [HttpGet]
        public ActionResult SearchDonor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchDonor( userRegistration model)
        {
           // userRegistration obj = new userRegistration();
            if (ModelState.IsValid)
            {
                
                    var v = dbObj.userRegistrations.Where(x => x.Division.Equals(model.Division) && x.District.Equals(model.District)).FirstOrDefault();

                    if (v != null)
                    {
                        //  Session["ID"] = obj.ID.ToString(); //newline
                       // Session["UserName"] = obj.FullName.ToString();
                        return RedirectToAction("DonorSearchList", "DonorSearchList");
                    }
                    else
                    {

                        //  Session["log"] = v.Email.ToString();
                        return RedirectToAction("About", "Home");
                    }
            }

            ModelState.Clear();
            return View();
        }
    }
}
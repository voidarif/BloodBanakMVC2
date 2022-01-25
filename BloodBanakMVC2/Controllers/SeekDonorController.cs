using BloodBanakMVC2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBanakMVC2.Controllers
{
    public class SeekDonorController : Controller
    {
        // GET: SeekDonor
        [HttpPost]
        public ActionResult searchDonor(FormCollection form)
        {
            string div = form["Division"].ToString();
            string dis = form["District"].ToString();
            if (ModelState.IsValid)
            {
                using (BloodBankEntities db = new BloodBankEntities())
                {
                    var v = db.userRegistrations.Where(x => x.Division==div && x.District==dis).FirstOrDefault();

                    if (v != null)
                    {
                        // Session["log"] = v.Email.ToString();
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
            return View("Home", "Index", "Home");
            // return View();
        }
    }
}
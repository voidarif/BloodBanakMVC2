using BloodBanakMVC2.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBanakMVC2.Controllers
{
    public class UserProfileController : Controller
    {
        BloodBankEntities dbObj = new BloodBankEntities();
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserProfile(userRegistration model)
        {
            userRegistration obj = new userRegistration();
            if (ModelState.IsValid)
            {
                /*obj.ID = model.ID;
                if (model.ID == 0)
                {*/
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                //}
            }
            return View();
        }
    }
}
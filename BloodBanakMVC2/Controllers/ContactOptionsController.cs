using BloodBanakMVC2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBanakMVC2.Controllers
{
    public class ContactOptionsController : Controller
    {
        BloodBankEntities dbObj = new BloodBankEntities();
        
        // GET: ContactOptions
        public ActionResult ContactOptions()
        {
            return View();
            
        }

        public ActionResult CallNow(userRegistration model)
        {
            userRegistration obj = new userRegistration();
            var mob = dbObj.userRegistrations.Where(x => x.ID == model.ID).FirstOrDefault();
            return View(mob.ToString());
        }
    }
}
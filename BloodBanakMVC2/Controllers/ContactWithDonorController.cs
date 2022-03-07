using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBanakMVC2.Controllers
{
    public class ContactWithDonorController : Controller
    {
        // GET: ContactWithDonor
        public ActionResult ContactWithDonor()
        {
            return RedirectToAction("ContactOptions", "ContactOptions");
        }
    }
}
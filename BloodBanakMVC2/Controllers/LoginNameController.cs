using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBanakMVC2.Context;

namespace BloodBanakMVC2.Controllers
{
    public class LoginNameController : Controller
    {
        // GET: LoginName
        BloodBankEntities db = new BloodBankEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}
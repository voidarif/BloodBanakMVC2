using BloodBanakMVC2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBanakMVC2.Controllers
{
    public class DonorSearchListController : Controller
    {
        BloodBankEntities db = new BloodBankEntities();
        // GET: DonorSearchList
        /*[HttpGet]*/
        public ActionResult DonorSearchList(string division, string district)
        {
            var res = from s in db.userRegistrations select s;
            if (!string.IsNullOrEmpty(division) || !string.IsNullOrEmpty(district))
            {
                res = res.Where(x => x.Division.Contains(division) && x.District.Contains(district));
            }
                return View(res.ToList());
        }


        /*[HttpPost]
        public ActionResult DonorSearchList( userRegistration Model)
        {
            var res = dbObj.userRegistrations.ToList().Where(x => x.Division.Equals(Model.Division) && x.District.Equals(Model.District)).FirstOrDefault();
           // var res = dbObj.userRegistrations.Where(x => x.Division.Equals(model.Division) && x.District.Equals(model.District)).FirstOrDefault().ToString();

            return View(res);
        }*/

      

       

    }
}
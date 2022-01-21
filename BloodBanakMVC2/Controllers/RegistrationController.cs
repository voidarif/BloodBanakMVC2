using BloodBanakMVC2.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBanakMVC2.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        BloodBankEntities dbObj = new BloodBankEntities();
        public ActionResult Registration(userRegistration obj)
        {
            if (obj != null)

                return View(obj);
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddUser(userRegistration model)
        {
            userRegistration obj = new userRegistration();
            if (ModelState.IsValid)
            {
                obj.ID = model.ID;
                obj.FullName = model.FullName;
                obj.Email = model.Email;
                obj.Password = model.Password;
                obj.Mobile = model.Mobile;
                obj.Division = model.Division;
                obj.District = model.District;
                obj.Criterias = model.Criterias;
            
                if(model.ID==0)
                {
                    dbObj.userRegistrations.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }

                
            }
            ModelState.Clear();
            return View("Registration");
        }

        public ActionResult UserList()
        {
            var res = dbObj.userRegistrations.ToList();

            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.userRegistrations.Where(x => x.ID == id).First();
            dbObj.userRegistrations.Remove(res);
            dbObj.SaveChanges();

            var newList = dbObj.userRegistrations.ToList();
            return View("UserList",newList);
        }
    }
}
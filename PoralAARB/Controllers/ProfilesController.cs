using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using PoralAARB.Models;

namespace PoralAARB.Controllers
{
    [Authorize]

    public class ProfilesController : Controller
    {
        readonly PortalAARBEntities db = new PortalAARBEntities();
        public ActionResult Customer(CustomerProfile obj)
        {
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerProfile model)
        {
            CustomerProfile obj = new CustomerProfile();
            if (ModelState.IsValid)
            {
                obj.Id = model.Id;
                obj.Tin = model.Tin;
                obj.FirstName = model.FirstName;
                obj.MiddleName = model.MiddleName;
                obj.LastName = model.LastName;
                obj.RegisteredDate = model.RegisteredDate;

                if (model.Id > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.CustomerProfiles.Add(obj);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("CustomerList");
        }

        public ActionResult CustomerList()
        {
            var res = db.CustomerProfiles.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = db.CustomerProfiles.Where(x => x.Id == id).First();
            db.CustomerProfiles.Remove(res);
            db.SaveChanges();

            var list = db.CustomerProfiles.ToList();

            return View("CustomerList", list);
        }

    }
}
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

    public class ServiceTimesController : Controller
    {
        readonly PortalAARBEntities db = new PortalAARBEntities();
        public ActionResult ServiceTime(ServiceTime obj)
        {
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddServiceTime(ServiceTime model)
        {
            ServiceTime obj = new ServiceTime();
            if (ModelState.IsValid)
            {
                obj.Id = model.Id;
                obj.ServiceTimeId = model.ServiceTimeId;
                obj.ServiceTimeInMinutes = model.ServiceTimeInMinutes;

                if (model.Id > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.ServiceTimes.Add(obj);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("ServiceTimeList");
        }

        public ActionResult ServiceTimeList()
        {
            var res = db.ServiceTimes.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = db.ServiceTimes.Where(x => x.Id == id).First();
            db.ServiceTimes.Remove(res);
            db.SaveChanges();

            var list = db.ServiceTimes.ToList();

            return View("ServiceTimeList", list);
        }

    }
}
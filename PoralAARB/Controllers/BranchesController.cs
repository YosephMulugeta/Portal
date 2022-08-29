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

    public class BranchesController : Controller
    {
        readonly PortalAARBEntities db = new PortalAARBEntities();
        public ActionResult Branches(Branch obj)
        {
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddBranch(Branch model)
        {
            Branch obj = new Branch();
            if (ModelState.IsValid)
            {
                obj.Id = model.Id;
                obj.BranchId = model.BranchId;
                obj.BranchName = model.BranchName;           

                if (model.Id > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Branches.Add(obj);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("BranchList");
        }

        public ActionResult BranchList()
        {
            var res = db.Branches.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = db.Branches.Where(x => x.Id == id).First();
            db.
                Branches.Remove(res);
            db.SaveChanges();

            var list = db.
                Branches.ToList();

            return View("BranchList", list);
        }

    }
}
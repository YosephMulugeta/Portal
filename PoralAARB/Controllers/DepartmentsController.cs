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

    public class DepartmentsController : Controller
    {
        readonly PortalAARBEntities db = new PortalAARBEntities();
        public ActionResult Departments(Department obj)
        {
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddDepartment(Department model)
        {
            Department obj = new Department();
            if (ModelState.IsValid)
            {
                obj.Id = model.Id;
                obj.DepartmentId = model.DepartmentId;
                obj.DepartmentName = model.DepartmentName;           

                if (model.Id > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Departments.Add(obj);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("DepartmentList");
        }

        public ActionResult DepartmentList()
        {
            var res = db.Departments.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = db.Departments.Where(x => x.Id == id).First();
            db.Departments.Remove(res);
            db.SaveChanges();

            var list = db.Departments.ToList();

            return View("DepartmentList", list);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;
using PoralAARB.Models;

namespace PoralAARB.Controllers
{
    [Authorize]
    public class ApplicationsController : Controller
    {
        readonly PortalAARBEntities db = new PortalAARBEntities();
       
        public ActionResult Application(Application obj)
        {
            List<Department> DeptList = db.Departments.ToList();
            ViewBag.ListOfDepartment = new SelectList(DeptList, "DepartmentId", "DepartmentName");

            List<Branch> BranchList = db.Branches.ToList();
            ViewBag.ListOfBranch = new SelectList(BranchList, "BranchId", "BranchName");

            List<Status> StatusList = db.Status.ToList();
            ViewBag.ListOfStatus = new SelectList(StatusList, "StatusId", "StatusName");

            List<MainService> MainServiceList = db.MainServices.ToList();
            ViewBag.ListOfMainService = new SelectList(MainServiceList, "MainServiceId", "MainServiceName");

            List<CustomerProfile> TinList = db.CustomerProfiles.ToList();
            ViewBag.ListOfTin = new SelectList(TinList, "Tin", "Tin");


            return View(obj);
        }
        public JsonResult GetCustomerList(string searchTerm)
        {
            var CustomerList = db.CustomerProfiles.ToList();

            if (searchTerm != null)
            {
                CustomerList = db.CustomerProfiles.Where(x => x.Tin.Contains(searchTerm)).ToList();
            }

            var modifiedData = CustomerList.Select(x => new
            {
                id = x.Tin,
                text = x.Tin
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Finalize(Application obj)
        {
            List<Department> DeptList = db.Departments.ToList();
            ViewBag.ListOfDepartment = new SelectList(DeptList, "DepartmentId", "DepartmentName");

            List<Branch> BranchList = db.Branches.ToList();
            ViewBag.ListOfBranch = new SelectList(BranchList, "BranchId", "BranchName");

            List<Status> StatusList = db.Status.ToList();
            ViewBag.ListOfStatus = new SelectList(StatusList, "StatusId", "StatusName");

            List<MainService> MainServiceList = db.MainServices.ToList();
            ViewBag.ListOfMainService = new SelectList(MainServiceList, "MainServiceId", "MainServiceName");

            //List<CustomerProfile> TinList = db.CustomerProfiles.ToList();
            //ViewBag.ListOfTin = new SelectList(TinList, "Tin", "Tin");


            return View(obj);
        }

        public ActionResult Edit(Application obj)
        {
            List<Department> DeptList = db.Departments.ToList();
            ViewBag.ListOfDepartment = new SelectList(DeptList, "DepartmentId", "DepartmentName");
            
            List<Branch> BranchList = db.Branches.ToList();
            ViewBag.ListOfBranch = new SelectList(BranchList, "BranchId", "BranchName");

            List<Status> StatusList = db.Status.ToList();
            ViewBag.ListOfStatus = new SelectList(StatusList, "StatusId", "StatusName");

            List<MainService> MainServiceList = db.MainServices.ToList();
            ViewBag.ListOfMainService = new SelectList(MainServiceList, "MainServiceId", "MainServiceName");

            List<CustomerProfile> TinList = db.CustomerProfiles.ToList();
            ViewBag.ListOfTin = new SelectList(TinList, "Tin", "Tin");


            return View(obj);
        }
        [HttpPost]
        public ActionResult AddApplication(Application model)
        {
            Application obj = new Application();
            if (ModelState.IsValid)
            {
                obj.ApplicationNo = model.ApplicationNo;
                obj.BranchId = model.BranchId;
                obj.DepartmentId = model.DepartmentId;
                obj.Tin = model.Tin;
                obj.StatusId = model.StatusId;
                obj.MainServiceId = model.MainServiceId;
                obj.Description = model.Description;
                obj.ApplicationDate = DateTime.Now;
                obj.AppointmentDate = DateTime.Now;

                if (model.ApplicationNo > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Applications.Add(obj);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            return RedirectToAction("ApplicationList");
        }
        public ActionResult ApplicationList()
        {
            var res = db.Applications.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = db.Applications.Where(x => x.ApplicationNo == id).First();
            db.Applications.Remove(res);
            db.SaveChanges();

            var list = db.Applications.ToList();
            return View("ApplicationList", list);
        }
    }
}
        
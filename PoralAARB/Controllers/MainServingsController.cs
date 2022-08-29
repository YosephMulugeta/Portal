using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using PoralAARB.Models;
using PoralAARB.ViewModels;

namespace PoralAARB.Controllers
{
    [Authorize]

    public class MainServingsController : Controller
    {
        readonly PortalAARBEntities db = new PortalAARBEntities();
        [HttpGet]
        public JsonResult LoadRoles()
        {
            var role = db.AspNetRoles
                .Select(m => new { value = m.Id, text = m.Name }).ToList();
            return new JsonResult { Data = role, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult LoadServiceTime()
        {
            var servicetime = db.ServiceTimes
                .Select(m => new { value = m.ServiceTimeId, text = m.ServiceTimeInMinutes }).ToList();
            return new JsonResult { Data = servicetime, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            IPagedList<MainService> MainServiceList = db.MainServices.OrderBy(c => c.No).ToList().ToPagedList(page ?? 1, 200);
            return View(MainServiceList);
        }
        [HttpPost]
        public ActionResult SaveService(string id, string roleid, string servicetimeid, string mainservicename, ServiceRequirement[] reqs)
        {
            // New Entry
            if (string.IsNullOrEmpty(id))
            {
                if (!string.IsNullOrEmpty(mainservicename.Trim()) && !string.IsNullOrEmpty(servicetimeid.Trim()) && !string.IsNullOrEmpty(roleid.Trim()) && reqs != null)
                {
                    var mainserviceid = Guid.NewGuid();
                    MainService mainservice = new MainService
                    {
                        MainServiceName = mainservicename,
                        ServingTimeId = servicetimeid,
                        MainServiceId = mainserviceid,
                        RoleId = roleid,

                    };
                    db.MainServices.Add(mainservice);

                    foreach (var o in reqs)
                    {
                        ServiceRequirement req = new ServiceRequirement
                        {
                            MainServiceId = mainserviceid,
                            ServiceRequirementName = o.ServiceRequirementName,
                            ServiceRequirementId = Guid.NewGuid()
                        };
                        db.ServiceRequirements.Add(req);                        
                    }
                    db.SaveChanges();
                }
            }
            // Edit Services 
            else
            {
                var mainserviceGuid = Guid.Parse(id);
                var mainserviceGuidInDb = db.MainServices.FirstOrDefault(c => c.MainServiceId == mainserviceGuid);
                mainserviceGuidInDb.MainServiceName = mainservicename;
                mainserviceGuidInDb.ServingTimeId = servicetimeid;
                mainserviceGuidInDb.RoleId = roleid;

                foreach (var o in reqs)
                {
                    var dbService = db.ServiceRequirements.FirstOrDefault(odr => odr.ServiceRequirementId == o.ServiceRequirementId);
                    if (dbService != null)
                    {
                        dbService.ServiceRequirementName = o.ServiceRequirementName;
                    }
                    else
                    {
                        ServiceRequirement req = new ServiceRequirement
                        {
                            ServiceRequirementId = Guid.NewGuid(),
                            ServiceRequirementName = o.ServiceRequirementName,
                            MainServiceId = mainserviceGuid
                        };
                        db.ServiceRequirements.Add(req);
                    }
                }
                db.SaveChanges();
            }
            return Json("");
        }
        [HttpGet]
        public ActionResult GetServiceDetails(string mainserviceid)
        {
            var mainserviceGuid = Guid.Parse(mainserviceid);
            var mainservicedetails = db.MainServices.Include("ServiceRequirements").Single(c => c.MainServiceId == mainserviceGuid);

            VmMainService MainService = new VmMainService
            {
                MainServiceId = mainservicedetails.MainServiceId,
                MainServiceName = mainservicedetails.MainServiceName,
                RoleId = mainservicedetails.RoleId, 
                ServiceTimeId = mainservicedetails.ServingTimeId
            };
            
            List<VmServiceRequirement> ReqsList = new List<VmServiceRequirement>();
            foreach (var o in mainservicedetails.ServiceRequirements)
            {
                VmServiceRequirement reqs = new VmServiceRequirement
                {
                    ServiceRequirementId = o.ServiceRequirementId,
                    ServiceRequirementName = o.ServiceRequirementName,
                    MainServiceId = o.MainServiceId
                };
                ReqsList.Add(reqs);
            }

            VmMainAndReqs MainAndReqs = new VmMainAndReqs()
            {
                MainService = MainService,
                ServiceRequirements = ReqsList
            };
            return Json(MainAndReqs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteService(string ServiceRequirementId)
        {
            var ServiceRequirementIdGuid = Guid.Parse(ServiceRequirementId);
            var ServiceRequirement = db.ServiceRequirements.Find(ServiceRequirementIdGuid);
            db.ServiceRequirements.Remove(ServiceRequirement);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteCustomer(string mainserviceid)
        {
            var mainserviceidGuid = Guid.Parse(mainserviceid);
            var mainservice = db.MainServices.FirstOrDefault(c => c.MainServiceId == mainserviceidGuid);
            if (mainservice != null)
            {
                var Services = db.ServiceRequirements.Where(o => o.MainServiceId == mainserviceidGuid).ToList();
                foreach (ServiceRequirement o in Services)
                {
                    db.ServiceRequirements.Remove(o);
                }
                db.MainServices.Remove(mainservice);
                db.SaveChanges();
            }
            else
            {
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
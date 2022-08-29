using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using PagedList.Mvc;
using PoralAARB.Models;
using PoralAARB.ViewModels;

namespace PoralAARB.Controllers
{
    [Authorize]

    public class StatusController : Controller
    {
        readonly PortalAARBEntities db = new PortalAARBEntities();

        public ActionResult StatusList(Status obj)
        {
            //List<Status> BranchList = db.Status.ToList();
            return View();

        }
        public JsonResult GetStatusList()
        {
            List<VmStatus> StuList = db.Status.Where(x => x.IsDeleted == false).Select(x => new VmStatus
            {
                Id = x.Id,
                StatusId = x.StatusId,
                StatusName = x.StatusName,
            }).ToList();

            return Json(StuList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStatusById(int Id)
        {
            Status model = db.Status.Where(x => x.Id == Id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(VmStatus model)
        {
            var result = false;
            try
            {
                if (model.Id > 0)
                {
                    Status Cent = db.Status.SingleOrDefault(x => x.IsDeleted == false && x.Id == model.Id);

                    Cent.StatusId = model.StatusId;
                    Cent.StatusName = model.StatusName;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Status Cent = new Status
                    {
                        StatusId = model.StatusId,
                        StatusName = model.StatusName,
                        IsDeleted = false
                    };
                    db.Status.Add(Cent);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteStatusRecord(int Id)
        {
            bool result = false;
            Status Cent = db.Status.SingleOrDefault(x => x.IsDeleted == false && x.Id == Id);
            if (Cent != null)
            {
                Cent.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
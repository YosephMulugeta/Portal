using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VmApplication    {


        public int ApplicationNo { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string Tin { get; set; }
        public bool IsDeleted { get; set; }
        public System.Guid MainServiceId { get; set; }
        public System.DateTime ApplicationDate { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        public string StatusId { get; set; }
        public string MainServiceName { get; set; }
        public string StatusName { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName { get; set; }
    }
}
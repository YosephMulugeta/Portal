using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VMAppCollection
    {
        public int ApplicationNo { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string Tin { get; set; }
        public bool IsDeleted { get; set; }
        public System.Guid MainServiceId { get; set; }
        public string ServiceTimeId { get; set; }
        public System.DateTime ApplicationDate { get; set; }
        public string FisicalYearId { get; set; }
        public string MonthId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        public VmApplication Application { get; set; }
        public List<VmMainService> MainServices { get; set; }
        public List<VmBranch> Branches { get; set; }
        public List<VmCustomerProfile> CustomerProfiles { get; set; }
        public List<VmDepartment> Departments { get; set; }
        public List<VmServiceTime> ServiceTimes { get; set; }
        public List<VmFisicalYear> FisicalYears { get; set; }
        public List<VmMonth> Months { get; set; }
    }
}
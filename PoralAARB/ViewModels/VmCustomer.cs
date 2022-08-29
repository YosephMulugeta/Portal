using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VmCustomer
    {
        public System.Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public string BranchId { get; set; }
        public string CenterId { get; set; }
        public string FisicalYearId { get; set; }
        public string MonthId { get; set; }
        public System.DateTime ServiceDate { get; set; }
    }
}
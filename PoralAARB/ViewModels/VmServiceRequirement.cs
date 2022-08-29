using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VmServiceRequirement
    {
        public System.Guid ServiceRequirementId { get; set; }
        public string ServiceRequirementName { get; set; }
        public System.Guid MainServiceId { get; set; }
    }
}
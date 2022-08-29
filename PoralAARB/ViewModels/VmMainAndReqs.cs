using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VmMainAndReqs
    {
        public VmMainService MainService { get; set; }
        public List<VmServiceRequirement> ServiceRequirements { get; set; }
    }
}
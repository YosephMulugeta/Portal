using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VmCustomerAndServices
    {
        public VmCustomer Customer { get; set; }
        public List<VmService> Services { get; set; }
    }
}
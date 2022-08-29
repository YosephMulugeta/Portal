using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VmCustomerProfile
    {
        public int Id { get; set; }
        public string Tin { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> RegisteredDate { get; set; }
    }
}
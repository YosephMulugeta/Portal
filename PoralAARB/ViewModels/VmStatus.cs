using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VmStatus
    {
        public int Id { get; set; }
        public string StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
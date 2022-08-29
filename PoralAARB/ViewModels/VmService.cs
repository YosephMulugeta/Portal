using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoralAARB.ViewModels
{
    public class VmService
    {
        public System.Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
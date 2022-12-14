//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PoralAARB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MainService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainService()
        {
            this.Applications = new HashSet<Application>();
            this.ServiceRequirements = new HashSet<ServiceRequirement>();
        }
    
        public System.Guid MainServiceId { get; set; }
        public string MainServiceName { get; set; }
        public string ServingTimeId { get; set; }
        public int No { get; set; }
        public string RoleId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Applications { get; set; }
        public virtual AspNetRole AspNetRole { get; set; }
        public virtual ServiceTime ServiceTime { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceRequirement> ServiceRequirements { get; set; }
    }
}

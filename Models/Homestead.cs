//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMS.Desktop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Homestead
    {
        public Homestead()
        {
            this.Meter = new HashSet<Meter>();
            this.Payment = new HashSet<Payment>();
        }
    
        public int Number { get; set; }
        public string OwnerName { get; set; }
    
        public virtual ICollection<Meter> Meter { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}

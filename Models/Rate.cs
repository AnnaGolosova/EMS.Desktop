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
    
    public partial class Rate
    {
        public Rate()
        {
            this.MeterData = new HashSet<MeterData>();
        }
    
        public int Id { get; set; }
        public int IdService { get; set; }
        public double Value { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Number { get; set; }
        public Nullable<int> Tariff { get; set; }
    
        public virtual Service Service { get; set; }
        public virtual ICollection<MeterData> MeterData { get; set; }
    }
}

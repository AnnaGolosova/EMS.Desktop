//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMS.Desktop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MeterData
    {
        public int Id { get; set; }
        public int IdMeter { get; set; }
        public double Value { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Id_Payment { get; set; }
        public Nullable<int> Id_Rate { get; set; }
    
        public virtual Meter Meter { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Rate Rate { get; set; }
    }
}

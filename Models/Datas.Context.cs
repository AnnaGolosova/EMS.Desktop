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
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

    public partial class EMSEntities : DbContext
    {
        public EMSEntities()
            : base("name=EMSEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Copay> Copay { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Homestead> Homestead { get; set; }
        public DbSet<Meter> Meter { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<MeterData> MeterData { get; set; }
    
        public virtual ObjectResult<Nullable<double>> GetAmound(Nullable<int> month)
        {
            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("GetAmound", monthParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> GetAmount(Nullable<int> month, Nullable<int> year)
        {
            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("GetAmount", monthParameter, yearParameter);
        }
    }
}

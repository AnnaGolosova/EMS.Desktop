using EMS.Desktop.Models;
using System.Data.Entity.Infrastructure;

namespace EMS.Desktop.Services
{
    public static class DbEntitiesExtensions
    {
        public static DbQuery<Homestead> IncludeRelaions(this DbQuery<Homestead> entity)
        {
            return entity
                .Include("Payment")
                .Include("Payment.Homestead")
                .Include("Meter");
        }

        public static DbQuery<Payment> IncludeRelaions(this DbQuery<Payment> entity)
        {
            return entity
                .Include("MeterData")
                .Include("MeterData.Meter")
                .Include("MeterData.Meter.Rate")
                .Include("Homestead")
                .Include("File")
                .Include("Service");
        }

        public static DbQuery<File> IncludeRelaions(this DbQuery<File> entity)
        {
            return entity.Include("Payment");
        }

        public static DbQuery<Rate> IncludeRelaions(this DbQuery<Rate> entity)
        {
            return entity.Include("Service").Include("Meter");
        }

        public static DbQuery<Meter> IncludeRelaions(this DbQuery<Meter> entity)
        {
            return entity.Include("Rate").Include("MeterData").Include("Homestead");
        }

        public static DbQuery<MeterData> IncludeRelaions(this DbQuery<MeterData> entity)
        {
            return entity
                .Include("Payment")
                .Include("Meter")
                .Include("Meter.Rate");
        }

        public static DbQuery<Service> IncludeRelaions(this DbQuery<Service> entity)
        {
            return entity.Include("Payment").Include("Rate");
        }
    }
}

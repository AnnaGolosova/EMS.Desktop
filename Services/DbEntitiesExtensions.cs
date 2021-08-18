using EMS.Desktop.Models;
using System.Data.Entity.Infrastructure;

namespace EMS.Desktop.Services
{
    public static class DbEntitiesExtensions
    {
        public static DbQuery<Homestead> IncludeRelaions(this DbQuery<Homestead> homesteads)
        {
            return homesteads.Include("Payment").Include("Meter");
        }
    }
}

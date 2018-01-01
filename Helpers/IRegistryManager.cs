using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    public interface IRegistryManager
    {
        bool IsFirstAppEntry();
        string GetNewReporst210Path();
        string GetOldReports210Path();
        string GetExcelPath();
        //Up to the need
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    public interface IConfigAppManager
    {
        bool IsFirstAppEntry();
        string GetReporst210Path();
        string SetReports202Path();
        string GetExcelPath();
        //Up to the need
    }
}

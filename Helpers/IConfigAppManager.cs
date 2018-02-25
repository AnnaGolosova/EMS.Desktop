using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    public interface IConfigAppManager
    {
        string GetExcelPath();
        void SetExcelPath(string path);
        string GetReports210Path();
        void SetReports210Path(string path);
        string GetReports202Path();
        void SetReports202Path(string path);
        bool IsFirstAppEntry();
        //Up to the need
    }
}

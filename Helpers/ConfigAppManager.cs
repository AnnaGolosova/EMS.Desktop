using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    class ConfigAppManager : IConfigAppManager
    {
        public string GetExcelPath()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["GetExcelPath"] != null)
                return System.Configuration.ConfigurationManager.AppSettings["GetExcelPath"];
            else
                return null;
        }

        public string GetReports210Path()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["GetReports210Path"] != null)
                return System.Configuration.ConfigurationManager.AppSettings["GetReports210Path"];
            else
                return null;
        }

        public string SetReports202Path()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["SetReports202Path"] != null)
                return System.Configuration.ConfigurationManager.AppSettings["SetReports202Path"];
            else
                return null;
        }

        public bool IsFirstAppEntry()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["SetReports202Path"] == null &&
                System.Configuration.ConfigurationManager.AppSettings["GetReports210Path"] == null &&
                System.Configuration.ConfigurationManager.AppSettings["GetExcelPath"] == null)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    class ConfigManager : IConfigManager
    {
        public string GetExcelPath()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["GetExcelPath"] != null)
                return System.Configuration.ConfigurationManager.AppSettings["GetExcelPath"];
            else 
                return null;
        }

        public string GetNewReporst210Path()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["GetNewReporst210Path"] != null)
                return System.Configuration.ConfigurationManager.AppSettings["GetNewReporst210Path"];
            else
                return null;
        }

        public string SetOldReports202Path()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["SetOldReports202Path"] != null)
                return System.Configuration.ConfigurationManager.AppSettings["SetOldReports202Path"];
            else
                return null;
        }

        public bool IsFirstAppEntry()
        {
            var a = System.Configuration.ConfigurationManager.AppSettings["SetOldReports202Path"];
            if (System.Configuration.ConfigurationManager.AppSettings["SetOldReports202Path"].CompareTo("") == 0 &&
                System.Configuration.ConfigurationManager.AppSettings["GetNewReporst210Path"].CompareTo("") == 0 &&
                System.Configuration.ConfigurationManager.AppSettings["GetExcelPath"].CompareTo("") == 0)
                return true;
            else
                return false;
        }
    }
}

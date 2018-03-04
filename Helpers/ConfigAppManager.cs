using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    static class ConfigAppManager
    {
        public static string GetExcelPath()
        {
            if (ConfigurationManager.AppSettings["ExcelPath"] != null)
                return ConfigurationManager.AppSettings["ExcelPath"];
            else
                return null;
        }

        public static void SetExcelPath(string path)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            config.AppSettings.Settings["ExcelPath"].Value = path;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetReports210Path()
        {
            if (ConfigurationManager.AppSettings["Reports210Path"] != null)
                return ConfigurationManager.AppSettings["Reports210Path"];
            else
                return null;
        }

        public static void SetReports210Path(string path)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            config.AppSettings.Settings["Reports210Path"].Value = path;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetReports202Path()
        {
            if (ConfigurationManager.AppSettings["Reports202Path"] != null)
                return ConfigurationManager.AppSettings["Reports202Path"];
            else
                return null;
        }

        public static void SetReports202Path(string path)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            config.AppSettings.Settings["Reports202Path"].Value = path;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static bool IsFirstAppEntry()
        {
            if (ConfigurationManager.AppSettings["Reports202Path"] == null &&
                ConfigurationManager.AppSettings["Reports210Path"] == null &&
                ConfigurationManager.AppSettings["ExcelPath"] == null)
                return true;
            else
                return false;
        }
    }
}

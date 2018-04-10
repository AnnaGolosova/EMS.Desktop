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
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            if (config.AppSettings.Settings["ExcelPath"].Value != null)
                return config.AppSettings.Settings["ExcelPath"].Value;
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
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            if (config.AppSettings.Settings["Reports210Path"].Value != null)
                return config.AppSettings.Settings["Reports210Path"].Value;
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
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            if (config.AppSettings.Settings["Reports202Path"].Value != null)
                return config.AppSettings.Settings["Reports202Path"].Value;
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
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            if (config.AppSettings.Settings["Reports202Path"].Value == null &&
                config.AppSettings.Settings["Reports210Path"].Value == null &&
                config.AppSettings.Settings["ExcelPath"].Value == null)
                return true;
            else
                return false;
        }

        public static string GetConnectionString()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            return config.AppSettings.Settings["ConnectionString"].Value;
        }

        public static void SetConnectionString(string connectionString)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            config.AppSettings.Settings["ConnectionString"].Value = connectionString;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static int GetNextReportNumber()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            int reportNumber = int.Parse(config.AppSettings.Settings["ReportNumber"].Value) + 1;
            config.AppSettings.Settings["ReportNumber"].Value = reportNumber.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            return reportNumber;
        }

        public static double GetTariff()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            if (config.AppSettings.Settings["Tariff"].Value != null)
                return Double.Parse(config.AppSettings.Settings["Tariff"].Value.ToString());
            else
                return 0;
        }

        public static void SetTariff(string tariff)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            config.AppSettings.Settings["Tariff"].Value = tariff;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("Tariff");
        }
    }
}

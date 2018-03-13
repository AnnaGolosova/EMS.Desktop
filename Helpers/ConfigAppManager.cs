﻿using Microsoft.WindowsAPICodePack.Dialogs;
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
    }
}

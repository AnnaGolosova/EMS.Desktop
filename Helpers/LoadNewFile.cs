﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Desktop;
using EMS.Desktop.Services;
using System.Windows.Forms;
using EMS.Desktop.Models;

namespace EMS.Desktop.Helpers
{
    class LoadNewFile
    {
        public static void LoadFile(MainForm obj)
        {
            string path = ConfigAppManager.GetReports210Path();
            List<string> Rep210 = FileManager.GetNewFilePathes(path);
            if (FileManager.GetNewFilesCount(path) != 0)
            {
                Action MaxPrBr = () => { obj.MainProgressBar.Maximum = FileManager.GetNewFilesCount(path);};
                obj.Invoke(MaxPrBr);
                foreach (string s in Rep210)
                {
                    try
                    {
                        DBRepository db = new DBRepository();
                        Report210 report = ExcelWriter.Read210(s);
                        FileManager.ChangeFileState(s, FileState.Loaded);
                        int fileId = FileManager.SetFileId(s, db.GetNextFileId());
                        report.FileId = fileId;
                        db.LoadReport210(report);
                        Action MainPrBr = () =>
                        {
                            obj.MainProgressBar.Value++;
                        };
                        obj.Invoke(MainPrBr);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузки файла!");
                    }
                }
                Action ShowComp = () => { obj.LabelProgrBar.Visible = true; };
                obj.Invoke(ShowComp);
            }
        }
    }
}

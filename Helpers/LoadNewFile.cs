using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Desktop;
using EMS.Desktop.Services;
using System.Windows.Forms;
using EMS.Desktop.Models;
using EMS.Desktop.Exceptions;

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
                        if(!db.TryConnection())
                        {
                            throw new DataBaseException("");
                        }
                        Report210 report = ExcelWriter.Read210(s);
                        File file = db.CreateFile(s);
                        report.FileId = file.Id;
                        db.LoadReport210(report);
                        Action MainPrBr = () =>
                        {
                            obj.MainProgressBar.Value++;
                        };
                        obj.Invoke(MainPrBr);
                        FileManager.MoveFile(s, ConfigAppManager.GetReports210Path() + "\\Downloaded");
                        db.SetFileAsDownloaded(file);
                    }
                    catch(DataBaseException ex)
                    {
                        MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                            "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace, "Ошибка при загрузки файла!");
                    }
                }
                Action ShowComp = () => 
                {
                    obj.LabelProgrBar.Text = "Файлы загружены";
                    obj.LabelProgrBar.Visible = true;
                };
                obj.Invoke(ShowComp);
            }
        }
    }
}

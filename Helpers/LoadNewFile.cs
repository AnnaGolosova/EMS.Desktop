using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Desktop;
using EMS.Desktop.Services;
using System.Windows.Forms;

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
                        DBRepository.LoadReport210(ExcelWriter.Read210(s));
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при загрузки файла!");
                    }
                    FileManager.ChangeFileState(path, FileState.Loaded);
                    Action MainPrBr = () =>
                    {
                        obj.MainProgressBar.Value++;
                        obj.MainProgressBar.Value--;
                        obj.MainProgressBar.Value++;
                    };
                    obj.Invoke(MainPrBr);
                }
                Action ShowComp = () => { obj.LabelProgrBar.Visible = true; };
                obj.Invoke(ShowComp);
            }
        }
    }
}

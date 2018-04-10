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
            int packageNumber = DBRepository.GetNextPackageNumber();
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
                        report.PackageNumber = packageNumber;
                        File file = db.CreateFile(s);
                        report.FileId = file.Id;
                        db.LoadReport210(report);
                        Action MainPrBr = () =>
                        {
                            obj.MainProgressBar.Value++;
                        };
                        obj.Invoke(MainPrBr);

                        DateTime date1 = new DateTime();
                        date1 = DateTime.Now;
                        int dateM = date1.Month;
                        string dateMonth = "";
                        string dateYear = date1.Year.ToString();
                        switch (dateM)
                        {
                            case 1:
                                dateMonth = "Январь";
                                break;
                            case 2:
                                dateMonth = "Февраль";
                                break;
                            case 3:
                                dateMonth = "Март";
                                break;
                            case 4:
                                dateMonth = "Апрель";
                                break;
                            case 5:
                                dateMonth = "Май";
                                break;
                            case 6:
                                dateMonth = "Июнь";
                                break;
                            case 7:
                                dateMonth = "Июль";
                                break;
                            case 8:
                                dateMonth = "Август";
                                break;
                            case 9:
                                dateMonth = "Сентябрь";
                                break;
                            case 10:
                                dateMonth = "Октябрь";
                                break;
                            case 11:
                                dateMonth = "Ноябрь";
                                break;
                            case 12:
                                dateMonth = "Декабрь";
                                break;
                            default:
                                break;
                        }
                        FileManager.MoveFile(s, ConfigAppManager.GetReports210Path() + $"\\Downloaded\\{dateMonth}{dateYear}");

                        db.SetFileAsDownloaded(file);
                    }
                    catch(DataBaseException)
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

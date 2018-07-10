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
                        if(!DBRepository.TryConnection())
                        {
                            throw new DataBaseException("");
                        }
                        Report210 report = ExcelWriter.Read210(s);
                        report.PackageNumber = packageNumber;
                        File file = DBRepository.CreateFile(s);
                        report.FileId = file.Id;
                        DBRepository.LoadReport210(report);
                        Action MainPrBr = () =>
                        {
                            obj.MainProgressBar.Value++;
                        };
                        obj.Invoke(MainPrBr);
                        
                        int dateM = report.Datas.First().Date.Month;
                        string dateMonth = "";
                        string dateYear = report.Datas.First().Date.Year.ToString();
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
                        FileManager.MoveFile(s, ConfigAppManager.GetReports210Path() + $"\\Downloaded\\{dateMonth} {dateYear}");

                        DBRepository.SetFileAsDownloaded(file);
                    }
                    catch(DataBaseException)
                    {
                        MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                            "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Ошибка при загрузки файла!");
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

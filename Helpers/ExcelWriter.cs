using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using EMS.Desktop.Models;
using EMS.Desktop.Services;
using OfficeOpenXml;
using System.Windows.Forms;

namespace EMS.Desktop.Helpers
{
    class ExcelWriter
    {
        public static Report210 Read210(string fileName)
        {
            Report210 datas = new Report210();
            Encoding win1251 = Encoding.GetEncoding(1251);
            string[] file210 = System.IO.File.ReadAllLines(fileName, win1251);
            datas.Datas = new List<Report210.ReportData>();
            for (int i = 1; i < file210.Length; i++)
            {
                string[] str = file210[i].Split('^');
                datas.Datas.Add(new Report210.ReportData());
                datas.Datas[i - 1].Id = Convert.ToInt32(str[0]);
                datas.Datas[i - 1].ServiceId = Convert.ToInt32(str[1]);
                datas.Datas[i - 1].HomeSteadNumber = Convert.ToInt32(str[2]);
                datas.Datas[i - 1].OwnerName = str[3];
                datas.Datas[i - 1].Date = new DateTime(Convert.ToInt32(str[5].Split('.')[1]), Convert.ToInt32(str[5].Split('.')[0]), 1);
                datas.Datas[i - 1].Introduced = Convert.ToDouble(str[6].Replace(".", ","));
                datas.Datas[i - 1].Arrer = Convert.ToDouble(str[7].Replace(".", ","));
                datas.Datas[i - 1].Entered = Convert.ToDouble(str[8].Replace(".", ","));
                datas.Datas[i - 1].Code = str[9] + "^" + str[10] + "^" + str[11] + "^" + str[12] + "^" + str[13] + "^" + str[14] + "^" + str[15] + "^" + str[16] + "^" + str[17] + "^" + str[18] + "^" + str[19];
                datas.Datas[i - 1].meterInfo = new List<Report210.ReportData.MeterInfo>();
                if (datas.Datas[i - 1].ServiceId == 2)
                {
                    int countOfMeters = int.Parse(str[10].Split('~')[0]);
                    for (int j = 0; j < countOfMeters; j++)
                        datas.Datas[i - 1].meterInfo.Add(new Report210.ReportData.MeterInfo()
                        {
                            oldValue = Convert.ToInt32(str[10].Split('~')[6 + 5 * j]),
                            newValue = Convert.ToInt32(str[10].Split('~')[8 + 5 * j]),
                            number = j + 1
                        });
                }

            }
            return datas;
        }

        static List<Report202.ReportData.MeterInfo> ConvertTo202(List<Report210.ReportData.MeterInfo> meter)
        {
            List<Report202.ReportData.MeterInfo> mi = new List<Report202.ReportData.MeterInfo>();
            foreach (Report210.ReportData.MeterInfo mt in meter)
                mi.Add(new Report202.ReportData.MeterInfo() { LocalRateId = 2, Value = mt.newValue });
            return mi;
        }

        public static void Write202(Report210 datas, List<Rate> rates, string fileName)
        {
            Report202 rep = new Report202();
            rep.LocalRates = rates;

            rep.Datas = new List<Report202.ReportData>();
            foreach (Report210.ReportData x in datas.Datas)
            {
                rep.Datas.Add(new Report202.ReportData()
                {
                    ServiceId = x.ServiceId,
                    // Нужно разобраться с этим
                    Arrear = x.Arrer,
                    Date = x.Date,
                    HomeSteadNumber = x.HomeSteadNumber,
                    OwnerName = x.OwnerName,
                    Introdused = x.Introduced,
                    Entered = x.Entered
                });
                if (x.meterInfo != null)
                    rep.Datas[rep.Datas.Count - 1].meterInfo = ConvertTo202(x.meterInfo);
            }
            WriteExcel(rep, fileName);
        }

        private static void WriteExcel(Report202 report, string fileName)
        {
            if(report.Datas.Count == 0)
            {
                MessageBox.Show("Отчет по заданным параметрам не имеет записей! Измените параметры и повторите попытку.", "Отчет не содержит записей", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (DBRepository db = new DBRepository())
            {
                using (var excel = new ExcelPackage())
                {
                    var ws = excel.Workbook.Worksheets.Add("WorkSheet1");
                    int i = 2;
                    if (report.Datas[0].ServiceId == 2)
                    {
                        foreach (Rate r in report.LocalRates)
                        {
                            ws.Cells[i, 1].Value = 1;
                            ws.Cells[i, 2].Value = r.Id;
                            r.Service = db.GetService(r.IdService);
                            ws.Cells[i, 3].Value = r.Service.Name;
                            ws.Cells[i++, 8].Value = r.Value;
                        }
                    }
                    foreach (Report202.ReportData x in report.Datas)
                    {
                        ws.Cells[i, 1].Value = "2";
                        ws.Cells[i, 2].Value = x.HomeSteadNumber;
                        ws.Cells[i, 3].Value =  x.OwnerName;
                        ws.Cells[i, 4].Value = "Номер участка " +x.HomeSteadNumber;
                        ws.Cells[i, 5].Value = x.Date.Month.ToString() + "." + x.Date.Year.ToString();
                        ws.Cells[i, 6].Value = x.Arrear;
                        if (x.ServiceId == 2)
                        {
                            string s = x.meterInfo.Count.ToString() + "~";
                            int j = 1;
                            foreach (Report202.ReportData.MeterInfo mi in x.meterInfo)
                            {
                                s += j++ + "~" + mi.LocalRateId + "~~~6~" + mi.Value + "~";
                            }
                            ws.Cells[i++, 7].Value = s;
                            ws.Cells[i++, 8].Value = "^^^^";
                        }
                        else
                        {
                            ws.Cells[i, 8].Value = x.Introdused;
                            ws.Cells[i++, 9].Value = "^^^^";
                        }
                    }
                    try
                    {
                        excel.SaveAs(new FileInfo(ConfigAppManager.GetExcelPath() + "//" + fileName + ".xlsx"));

                    } catch(InvalidOperationException ex)
                    {
                        MessageBox.Show("Файл" + fileName +" существует либо уже используется.", "Ошибка записи файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
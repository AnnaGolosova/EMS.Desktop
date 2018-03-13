using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using EMS.Desktop.Models;
//using OfficeOpenXml;

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
                            //Parse meter's number
                            number = 1
                        });
                }

            }
            return datas;
        }

        static List<Report202.ReportData.MeterInfo> metInfo(List<Report210.ReportData.MeterInfo> meter)
        {
            List<Report202.ReportData.MeterInfo> mi = new List<Report202.ReportData.MeterInfo>();
            foreach (Report210.ReportData.MeterInfo mt in meter)
                mi.Add(new Report202.ReportData.MeterInfo() { LocalRateId = 1, Value = mt.oldValue });
            return mi;
        }

        public static void Write202(Report210 datas)
        {
            Report202 rep = new Report202();
            rep.LocalRates = new List<Rate>()
            {
                new Rate{ Id = 1, IdService = 2, Value = 0.1246 },
                new Rate{ Id = 2, IdService = 2, Value = 0.1458 },
                new Rate{ Id = 3, IdService = 2, Value = 0.1549 }
            };
            rep.Datas = new List<Report202.ReportData>();
            foreach (Report210.ReportData x in datas.Datas)
            {
                rep.Datas.Add(new Report202.ReportData()
                {
                    // Нужно разобраться с этим
                    RateId = x.ServiceId,
                    Arrear = x.Arrer,
                    Date = x.Date,
                    HomeSteadNumber = x.HomeSteadNumber,
                    OwnerName = x.OwnerName,
                    meterInfo = metInfo(x.meterInfo)
                });
            }
        }

        private static void WriteExcel()
        {
            string firstline = "";
            Report210 datas = ExcelWriter.Read210(firstline);
            //using (var excel = new ExcelPackage())
            //{
            //    var ws = excel.Workbook.Worksheets.Add("WorkSheet1");
            //    foreach (Report210.ReportData x in datas.Datas)
            //    {
            //        ws.Cells[x.Id, 1].Value = x.Id;
            //        ws.Cells[x.Id, 2].Value = x.RateId;
            //        ws.Cells[x.Id, 3].Value = x.HomeSteadNumber;
            //        ws.Cells[x.Id, 4].Value = x.OwnerName;
            //        ws.Cells[x.Id, 5].Value = Convert.ToString(x.Date);
            //        ws.Cells[x.Id, 6].Value = x.Introduced;
            //        ws.Cells[x.Id, 7].Value = x.Arrer;
            //        ws.Cells[x.Id, 8].Value = x.Entered;
            //    }
            //    excel.SaveAs(new FileInfo(new ConfigAppManager().GetExcelPath()));
            //}
        }
    }
}
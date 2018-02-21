using System;
using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;

namespace EMS.Desktop.Helpers
{
    class ExcelWriter
    {
        void Read210(Models.Report210 datas, string firstline)
        {
            string[] file210 = File.ReadAllLines(new ConfigAppManager().GetReports210Path());
            firstline = file210[0];
            datas.Datas = new List<Models.Report210.ReportData>();
            for (int i = 1; i < file210.Length; i++)
            {
                datas.Datas.Add(new Models.Report210.ReportData());
                datas.Datas[i - 1].Id = Convert.ToInt32(file210[i].Split('^')[0]);
                datas.Datas[i - 1].RateId = Convert.ToInt32(file210[i].Split('^')[1]);
                datas.Datas[i - 1].HomeSteadNumber = Convert.ToInt32(file210[i].Split('^')[2]);
                datas.Datas[i - 1].OwnerName = file210[i].Split('^')[3];
                datas.Datas[i - 1].Date = new DateTime(Convert.ToInt32(file210[i].Split('^')[5].Split('.')[1]), Convert.ToInt32(file210[i].Split('^')[5].Split('.')[0]), 1);
                datas.Datas[i - 1].Introduced = Convert.ToDouble(file210[i].Split('^')[6].Replace(".", ","));
                datas.Datas[i - 1].Arrer = Convert.ToDouble(file210[i].Split('^')[7].Replace(".", ","));
                datas.Datas[i - 1].Entered = Convert.ToDouble(file210[i].Split('^')[8].Replace(".", ","));
                datas.Datas[i - 1].Code = file210[i].Split('^')[9] + "^" + file210[i].Split('^')[10] + "^" + file210[i].Split('^')[11] + "^" + file210[i].Split('^')[12] + "^" + file210[i].Split('^')[13] + "^" + file210[i].Split('^')[14] + "^" + file210[i].Split('^')[15] + "^" + file210[i].Split('^')[16] + "^" + file210[i].Split('^')[17] + "^" + file210[i].Split('^')[18] + "^" + file210[i].Split('^')[19];
            }
        }

        private static void Main()
        {
            Models.Report210 datas = new Models.Report210();
            string firstline = "";
            new ExcelWriter().Read210(datas, firstline);
            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("WorkSheet1");
                foreach (Models.Report210.ReportData x in datas.Datas)
                {
                    ws.Cells[x.Id, 1].Value = x.Id;
                    ws.Cells[x.Id, 2].Value = x.RateId;
                    ws.Cells[x.Id, 3].Value = x.HomeSteadNumber;
                    ws.Cells[x.Id, 4].Value = x.OwnerName;
                    ws.Cells[x.Id, 5].Value = Convert.ToString(x.Date);
                    ws.Cells[x.Id, 6].Value = x.Introduced;
                    ws.Cells[x.Id, 7].Value = x.Arrer;
                    ws.Cells[x.Id, 8].Value = x.Entered;
                }
                excel.SaveAs(new FileInfo(new ConfigAppManager().GetExcelPath()));
            }
        }
    }
}

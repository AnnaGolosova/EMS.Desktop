using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
//using OfficeOpenXml;

namespace EMS.Desktop.Helpers
{
    class ExcelWriter
    {
        void Read210(Models.Report210 datas, string firstline)
        {
            Encoding win1251 = Encoding.GetEncoding(1251);
            string[] file210 = File.ReadAllLines(new ConfigAppManager().GetReports210Path(), win1251);
            firstline = file210[0];
            datas.Datas = new List<Models.Report210.ReportData>();
            for (int i = 1; i < file210.Length; i++)
            {
                string[] str = file210[i].Split('^');
                datas.Datas.Add(new Models.Report210.ReportData());
                datas.Datas[i - 1].Id = Convert.ToInt32(str[0]);
                datas.Datas[i - 1].RateId = Convert.ToInt32(str[1]);
                datas.Datas[i - 1].HomeSteadNumber = Convert.ToInt32(str[2]);
                datas.Datas[i - 1].OwnerName = str[3];
                datas.Datas[i - 1].Date = new DateTime(Convert.ToInt32(str[5].Split('.')[1]), Convert.ToInt32(str[5].Split('.')[0]), 1);
                datas.Datas[i - 1].Introduced = Convert.ToDouble(str[6].Replace(".", ","));
                datas.Datas[i - 1].Arrer = Convert.ToDouble(str[7].Replace(".", ","));
                datas.Datas[i - 1].Entered = Convert.ToDouble(str[8].Replace(".", ","));
                datas.Datas[i - 1].Code = str[9] + "^" + str[10] + "^" + str[11] + "^" + str[12] + "^" + str[13] + "^" + str[14] + "^" + str[15] + "^" + str[16] + "^" + str[17] + "^" + str[18] + "^" + str[19];
            }
        }

        private static void WriteExcel()
        {
            Models.Report210 datas = new Models.Report210();
            string firstline = "";
            new ExcelWriter().Read210(datas, firstline);
            //using (var excel = new ExcelPackage())
            //{
            //    var ws = excel.Workbook.Worksheets.Add("WorkSheet1");
            //    foreach (Models.Report210.ReportData x in datas.Datas)
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

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Desktop.Models;
using EMS.Desktop.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
                mi.Add(new Report202.ReportData.MeterInfo() { LocalRateId = mt.rateId, Value = mt.newValue });
            return mi;
        }

        private enum NoRateState
        {
            NotAnswered = 0,
            Yes,
            No
        }

        public static void Write202(Report210 datas, List<Rate> rates, string fileName, bool CreateExcel)
        {
            Report202 rep = new Report202();
            rep.LocalRates = rates;
            DBRepository db = new DBRepository();
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
            NoRateState flag = NoRateState.NotAnswered;
            try
            {
                FileStream stream = new FileStream(ConfigAppManager.GetReports202Path() + "//" + fileName + ".202", FileMode.Create);
                StreamWriter writer = new StreamWriter(stream);
                int recordsCount = rep.Datas[0].ServiceId == 2 ? 3 : 0;
                recordsCount += rep.Datas.Count;
                writer.WriteLine("5^32402192^" + ConfigAppManager.GetNextReportNumber() +
                    "^" + DateTime.Now.Year.ToString() +
                    (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) +
                    DateTime.Now.Day.ToString() + "120000^" +
                    recordsCount + "^400225056^661^BY49AKBB30151211600163000000^1^933^PS");
                if (rep.Datas[0].ServiceId == 2)
                {
                    foreach (Rate r in rep.LocalRates)
                    {
                        string rateStr = "1^" + r.Id + "^";
                        r.Service = db.GetService(r.IdService);
                        rateStr += r.Service.Name + "^^^^^" + r.Value + "^";
                        writer.WriteLine(rateStr);
                    }
                }
                foreach (Report202.ReportData x in rep.Datas)
                {
                    string recordStr = "2^" + x.HomeSteadNumber + "^";
                    recordStr += x.OwnerName + "^Номер участка " + x.HomeSteadNumber + "^";
                    recordStr += x.Date.Month.ToString() + "." + x.Date.Year.ToString() + "^" + x.Arrear + "^";
                    if (x.ServiceId == 2)
                    {
                        string s = x.meterInfo.Count.ToString() + "~";
                        int j = 1;
                        foreach (Report202.ReportData.MeterInfo mi in x.meterInfo)
                        {
                            string localId = "";
                            if (mi.LocalRateId == null)
                            {
                                if (flag == NoRateState.Yes)
                                {
                                    localId = "1";
                                }
                                else
                                if (flag == NoRateState.NotAnswered)
                                {
                                    if (MessageBox.Show("Тарифы не установлены для одного или нескольких участков. Продолжить создание отчетов? Нажмите [Да], чтобы заменать неустановленне тарифы на 1",
                                            "Тарифы не установлены", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                    {
                                        flag = NoRateState.Yes;
                                        localId = "1";
                                    }
                                    else
                                    {
                                        flag = NoRateState.No;
                                        writer.Close();
                                        stream.Close();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                localId = db.GetRatePosition(mi.LocalRateId).ToString();
                            }
                            s += j++ + "~" + localId + "~~~6~" + mi.Value + "~";
                        }
                        recordStr += s + "^^^^^^^^";
                    }
                    else
                    {
                        recordStr += "^" + x.Introdused + "^^^^^^^^^";
                    }
                    writer.WriteLine(recordStr);
                }
                writer.Close();
                writer.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Неверное имя файла. Проверьте пути для сохранения файлов в настройках",
                    "Неверное имя файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Файл " + fileName +
                    ".202 не может быть сохранен. Возможно, он уже существует и открыт в другом приложении. Закройте файл и повторите попытку.",
                    "Файл не может быть сохранен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CreateExcel)
                WriteExcel(rep, fileName, flag);
        }

        private static void WriteExcel(Report202 report, string fileName, NoRateState flag)
        {
            if (report.Datas.Count == 0)
            {
                MessageBox.Show("Отчет по заданным параметрам не имеет записей! Измените параметры и повторите попытку.",
                    "Отчет не содержит записей", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        ws.Cells[i, 3].Value = x.OwnerName;
                        ws.Cells[i, 4].Value = "Номер участка " + x.HomeSteadNumber;
                        ws.Cells[i, 5].Value = x.Date.Month.ToString() + "." + x.Date.Year.ToString();
                        ws.Cells[i, 6].Value = x.Arrear;
                        if (x.ServiceId == 2)
                        {
                            string s = x.meterInfo.Count.ToString() + "~";
                            int j = 1;
                            foreach (Report202.ReportData.MeterInfo mi in x.meterInfo)
                            {
                                string localId = "";
                                if (mi.LocalRateId == null)
                                {
                                    if (flag == NoRateState.Yes)
                                    {
                                        localId = "2";
                                    }
                                    else
                                    if (flag == NoRateState.NotAnswered)
                                    {
                                        if (MessageBox.Show("Тарифы не установлены для одного или нескольких участков. Продолжить создание отчетов? Нажмите [Да], чтобы заменать неустановленне тарифы на 2",
                                                "Тарифы не установлены", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                        {
                                            flag = NoRateState.Yes;
                                            localId = "2";
                                        }
                                        else
                                        {
                                            flag = NoRateState.No;
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    localId = db.GetRatePosition(mi.LocalRateId).ToString();
                                }
                                s += j++ + "~" + localId + "~~~6~" + mi.Value + "~";
                            }
                            ws.Cells[i, 7].Value = s;
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

                    } catch (InvalidOperationException ex)
                    {
                        MessageBox.Show("Файл " + fileName +
                            ".xlsx не может быть сохранен. Возможно, он уже существует и открыт в другом приложении. Закройте файл и повторите попытку.",
                            "Файл не может быть сохранен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Неверное имя файла. Проверьте пути для сохранения файлов в настройках",
                            "Неверное имя файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private static void WriteMonthReport(List<Report210.ReportData> datas, int month, string fileName, int id)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                List<string> Months = new List<string>();
                Months.Add("Январь ");
                Months.Add("Февраль ");
                Months.Add("Март ");
                Months.Add("Апрель ");
                Months.Add("Май ");
                Months.Add("Июнь ");
                Months.Add("Июль ");
                Months.Add("Август ");
                Months.Add("Сентябрь ");
                Months.Add("Октябрь ");
                Months.Add("Ноябрь ");
                Months.Add("Декабрь ");
                var ws = excel.Workbook.Worksheets.Add("Отчёт за месяц");

                if (id == 1)
                {
                    ws.Cells[1, 1, 2, 7].Merge = true;
                    ws.Cells[1, 1].Value = "Данные об уплате взносов СТ «Диколовка-1»";
                    ws.Cells[3, 1, 3, 7].Merge = true;
                    ws.Cells[4, 1].Value = "По состоянию на 01." + (month == 12 ? "01" : Convert.ToString(month)) + '.' + DateTime.UtcNow.Year;
                    ws.Cells[4, 1].Value = "№ по порядку";
                    ws.Cells[4, 2].Value = "№ участка";
                    ws.Cells[4, 3].Value = "ФИО";
                    ws.Cells[4, 4].Value = "Внесено денег";
                    ws.Cells[4, 5].Value = "Снято ЕРИПом";
                    ws.Cells[4, 6].Value = "Перечислено в банк";
                    ws.Cells[4, 7].Value = "Дата оплаты";

                    int i = 5;
                    foreach (Report210.ReportData data in datas)
                    {
                        ws.Cells[i, 1].Value = i - 3;
                        ws.Cells[i, 2].Value = data.HomeSteadNumber;
                        ws.Cells[i, 3].Value = data.OwnerName;
                        ws.Cells[i, 4].Value = data.Introduced;
                        ws.Cells[i, 6].Value = data.Entered;
                        ws.Cells[i, 7].Value = data.Code.Substring(0, 4) + '.' + data.Code.Substring(4, 2) + '.' + data.Code.Substring(6, 2);
                        for (int j = 1; j < 8; j++)
                            ws.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        i++;
                    }

                    ws.Cells[5, 5, i - 1, 5].Formula = "D4 - F4";
                    ws.Cells[i, 1, i, 3].Merge = true;
                    ws.Cells[i, 1].Value = "Итого";
                    ws.Cells[i, 4, i, 6].Formula = "SUM(D4:D" + (i - 1) + ')';

                    ws.Cells[4, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    ws.Cells[4, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    ws.Cells[4, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    ws.Cells[i, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    ws.Cells[i, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    ws.Cells[i, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    ws.Cells[4, 1, i, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[4, 1, 4, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    ws.Cells[i, 1, i, 7].Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    ws.Cells[1, 1, 4, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 1, i, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[3, 1, 3, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[i, 1, i, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 1, 2, 7].Style.Font.Bold = true;
                    ws.Cells[1, 1, 2, 7].Style.Font.Italic = true;
                    ws.Cells[3, 1, 3, 7].Style.Font.Bold = true;
                }
                else if (id == 2)
                {
                    ws.Cells[1, 1, 1, 11].Merge = true;
                    ws.Cells[1, 1].Value = "Ведомость";
                    ws.Cells[2, 1, 2, 11].Merge = true;
                    ws.Cells[2, 1].Value = "уплаты за электроэнергию";
                    ws.Cells[3, 1, 3, 11].Merge = true;
                    ws.Cells[3, 1].Value = "за " + Months[month - 1] + datas[0].Date.Year + "г.";
                    ws.Cells[4, 1, 4, 11].Merge = true;
                    ws.Cells[4, 1].Value = "Гос. тариф "; //+ гос. тариф (0,1192)
                    ws.Cells[5, 1, 6, 1].Merge = true;
                    ws.Cells[5, 1].Value = "№ По порядку";
                    ws.Cells[5, 2, 6, 2].Merge = true;
                    ws.Cells[5, 2].Value = "№ Участка";
                    ws.Cells[5, 3, 6, 3].Merge = true;
                    ws.Cells[5, 3].Value = "Дата оплаты";
                    ws.Cells[5, 4, 6, 4].Merge = true;
                    ws.Cells[5, 4].Value = "Внесено денег";
                    ws.Cells[5, 5, 6, 5].Merge = true;
                    ws.Cells[5, 5].Value = "Снято ЕРИПом";
                    ws.Cells[5, 6, 5, 7].Merge = true;
                    ws.Cells[5, 6].Value = "Уплачено по счётчику";
                    ws.Cells[6, 6].Value = "кВт/ч";
                    ws.Cells[6, 7].Value = "Сумма";
                    ws.Cells[5, 8].Value = "Текущие показания";
                    ws.Cells[6, 8].Value = "кВт/ч";
                    ws.Cells[5, 9, 5, 10].Merge = true;
                    ws.Cells[5, 9].Value = "Доплата за потери";
                    ws.Cells[6, 9].Value = "K=";
                    ws.Cells[6, 10].Value = "Сумма";
                    ws.Cells[5, 11, 6, 11].Merge = true;
                    ws.Cells[5, 11].Value = "Доплата по долгам";
                    // ws.Cells[5, 12].Value = 0.1192;

                    int i = 7;
                    foreach (Report210.ReportData data in datas)
                    {
                        ws.Cells[i, 1].Value = i - 6;
                        ws.Cells[i, 2].Value = data.HomeSteadNumber;
                        ws.Cells[i, 3].Value = data.Date;
                        ws.Cells[i, 4].Value = data.Introduced;
                        ws.Cells[i, 6].Value = data.meterInfo[0].oldValue - data.meterInfo[0].newValue;
                        ws.Cells[i, 8].Value = data.meterInfo[0].newValue;
                        // ws.Cells[i, 9].Value = "";
                        // ws.Cells[i, 11].Value = "";
                        ws.Cells[i, 12].Value = data.Entered;
                        for (int j = 1; j < 12; j++)
                            ws.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        i++;
                    }

                    ws.Cells[7, 5, i - 1, 5].Formula = "D7 - L7";
                    ws.Cells[7, 7, i - 1, 7].Formula = "ROUND(F7 * $L$5, 2)";
                    ws.Cells[7, 10, i - 1, 10].Formula = "ROUND(F7 * I7 * $L$5, 2)";
                    ws.Cells[7, 14, i - 1, 14].Formula = "G7 + J7 + K7";
                    ws.Cells[i, 4, i, 5].Formula = "SUM(D7:D" + (i - 1) + ')';
                    ws.Cells[i, 7].Formula = "SUM(G7:G" + (i - 1) + ')';
                    ws.Cells[i, 10, i, 11].Formula = "SUM(J7:J" + (i - 1) + ')';
                    ws.Cells[i, 14].Formula = "SUM(N7:" + (i - 1) + ')';

                    ws.Cells[5, 1, 6, 11].Style.Font.Bold = true;
                    for (i = 1; i < 12; i++)
                    {
                        ws.Cells[5, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        ws.Cells[6, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                    ws.Cells[5, 1, i, 11].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[i, 1, i, 11].Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    ws.Cells[6, 1, 6, 11].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    ws.Cells[1, 1, i - 1, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 1, i - 1, 11].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[7, 12, i - 1, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[7, 12, i - 1, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[7, 14, i, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[7, 14, i, 14].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[7, 14, i - 1, 14].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                }
                else
                {
                    ws.Cells[1, 1, 2, 8].Merge = true;
                    ws.Cells[1, 1].Value = "Сводная ведомость об уплате налога на " + (id == 3 ? "Землю" : "Недвижимость") + " СТ «Диколовка-1»";
                    ws.Cells[3, 1, 3, 8].Merge = true;
                    ws.Cells[3, 1].Value = "По состоянию на 01." + (month == 12 ? "01" : Convert.ToString(month)) + '.' + DateTime.UtcNow.Year;
                    ws.Cells[4, 1, 5, 1].Merge = true;
                    ws.Cells[4, 1].Value = "№ по порядку";
                    ws.Cells[4, 2, 5, 2].Merge = true;
                    ws.Cells[4, 2].Value = "Номер участка";
                    ws.Cells[4, 3, 5, 3].Merge = true;
                    ws.Cells[4, 3].Value = "ФИО";
                    ws.Cells[4, 4, 5, 4].Merge = true;
                    ws.Cells[4, 4].Value = "Сумма к оплате";
                    ws.Cells[4, 5, 4, 8].Merge = true;
                    ws.Cells[4, 5].Value = "Сведения об оплате";
                    ws.Cells[5, 5].Value = "Внесённая сумма";
                    ws.Cells[5, 6].Value = "Снято ЕРИПом";
                    ws.Cells[5, 7].Value = "Перечислено в банк";
                    ws.Cells[5, 8].Value = "Дата оплаты";

                    int i = 6;
                    foreach (Report210.ReportData data in datas)
                    {
                        ws.Cells[i, 1].Value = i - 5;
                        ws.Cells[i, 2].Value = data.HomeSteadNumber;
                        ws.Cells[i, 3].Value = data.OwnerName;
                        ws.Cells[i, 5].Value = data.Introduced;
                        ws.Cells[i, 7].Value = data.Entered;
                        ws.Cells[i, 8].Value = data.Code.Substring(0, 4) + '.' + data.Code.Substring(4, 2) + '.' + data.Code.Substring(6, 2);
                        for (int j = 1; j < 9; j++)
                            ws.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        i++;
                    }

                    ws.Cells[6, 6, i - 1, 6].Formula = "E6 - G6";
                    ws.Cells[i, 1, i, 3].Merge = true;
                    ws.Cells[i, 1].Value = "Итого";
                    ws.Cells[i, 4, i, 7].Formula = "D6 - D" + (i - 1) + ')';

                    for (int j = 1; j < 9; j++)
                    {
                        ws.Cells[4, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        ws.Cells[5, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                    for (int j = 0; j < 3; j++)
                        ws.Cells[i, j + 2, i, 7 - j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    ws.Cells[4, 1, i, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[4, 1, 5, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    ws.Cells[4, 4, i, 4].Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    ws.Cells[i, 1, i, 8].Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    ws.Cells[1, 1, i, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[1, 1, 5, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, 1, 3, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[6, 5, i, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 1, 2, 8].Style.Font.Bold = true;
                    ws.Cells[1, 1, 2, 8].Style.Font.Italic = true;
                    ws.Cells[4, 1, 5, 8].Style.Font.Bold = true;
                }

                try
                {
                    excel.SaveAs(new FileInfo(ConfigAppManager.GetExcelPath() + "//" + fileName + ".xlsx"));

                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Файл " + fileName +
                        ".xlsx не может быть сохранен. Возможно, он уже существует и открыт в другом приложении. Закройте файл и повторите попытку.",
                        "Файл не может быть сохранен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Неверное имя файла. Проверьте пути для сохранения файлов в настройках",
                        "Неверное имя файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public static void convertRepositoryDataToExcel(DBRepository repository, string fileName)
        {
            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("WorkSheet1");

                ws.Cells[2, 1].Value = "Услуга";
                ws.Cells[2, 2].Value = "Номер участка";
                ws.Cells[2, 3].Value = "ФИО";
                ws.Cells[2, 4].Value = "Номер участка";
                ws.Cells[2, 5].Value = "Дата";
                ws.Cells[2, 6].Value = "Задолженность";
                ws.Cells[2, 7].Value = "Значение счётчика";
                ws.Cells[2, 8].Value = "Внесено";
                for (int j = 1; j < 10; j++)
                    ws.Cells[2, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                int i = 3;
                foreach (Payment x in repository.GetPayment().OrderBy(s => s.Homestead.Number))
                {
                    for (int j = 1; j < 10; j++)
                        ws.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    ws.Cells[i, 1].Value = x.Service.Id;
                    ws.Cells[i, 2].Value = x.Homestead.Number;
                    ws.Cells[i, 3].Value = x.Homestead.OwnerName;
                    ws.Cells[i, 4].Value = "Номер участка " + x.Homestead.Number;
                    ws.Cells[i, 5].Value = x.Date.Value.ToShortDateString();
                    ws.Cells[i, 6].Value = x.Arrear;
                    if (x.Service.Id == 2)
                    {
                        for (int j = 0; j < x.MeterData.Count; j++)
                            ws.Cells[i + j, 7].Value = x.MeterData.ElementAt(j).Value;
                        ws.Cells[i++, 8].Value = "^^^^";
                        if (x.MeterData.Count > 1)
                        {
                            for (int j = 1; j < 7; j++)
                                ws.Cells[i, j, i + x.MeterData.Count - 1, j].Merge = true;
                            ws.Cells[i, 8, i + x.MeterData.Count - 1, 8].Merge = true;
                            ws.Cells[i, 9, i + x.MeterData.Count - 1, 9].Merge = true;
                            for (int j0 = 1; j0 < x.MeterData.Count; j0++)
                                for (int j = 1; j < 10; j++)
                                    ws.Cells[j0, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }
                    }
                    else
                    {
                        ws.Cells[i, 8].Value = x.Introduced;
                        ws.Cells[i++, 9].Value = "^^^^";
                    }
                }
                
                ws.Cells[2, 1, 2, 9].Style.Font.Bold = true;
                ws.Cells[2, 1, i - 1, 9].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 1, 2, 9].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

                try
                {
                    excel.SaveAs(new FileInfo(ConfigAppManager.GetExcelPath() + "//" + fileName + ".xlsx"));
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Файл " + fileName +
                        ".xlsx не может быть сохранен. Возможно, он уже существует и открыт в другом приложении. Закройте файл и повторите попытку.",
                        "Файл не может быть сохранен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Неверное имя файла. Проверьте пути для сохранения файлов в настройках",
                        "Неверное имя файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
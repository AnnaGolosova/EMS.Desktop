using System.IO;
using OfficeOpenXml;

namespace EMS.Desktop.Helpers
{
    class ExcelWriter
    {
        private static void main()
        {
            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("WorkSheetName");

                string[] str = File.ReadAllLines("Путь к файлу.210");
                for (int i = 0; i < str.Length; i++)
                    for (int j = 0; j < str[i].Split('^').Length; j++)
                        ws.Cells[i + 1, j + 1].Value = str[i].Split('^')[j];

                excel.SaveAs(new FileInfo("Путь к файлу.xlsx"));
            }
        }
    }
}

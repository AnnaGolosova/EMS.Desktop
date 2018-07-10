using EMS.Desktop.Exceptions;
using EMS.Desktop.Forms;
using EMS.Desktop.Helpers;
using EMS.Desktop.Models;
using EMS.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS.Desktop
{
    public partial class FormReposForERIP : Form
    {
        public object RateEdirForm { get; private set; }

        public FormReposForERIP()
        {
            try
            {
                InitializeComponent();
                CreateExcelCB.Checked = true;
                Service2RB.Checked = true;
                MonthRB.Checked = true;
                int i = 1;
                RateDGV.Rows.Clear();
                foreach (Rate rate in DBRepository.GetLastRates().OrderBy(r => r.Id))
                {
                    RateDGV.Rows.Add(i++, rate.Service.Name, rate.Value, ConfigAppManager.GetTariff(), rate.Value * ConfigAppManager.GetTariff());
                }
                FileNameTB.Focus();
            }
            catch(DataBaseException)
            {
                Hide();
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void MonthRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = true;
            ToDatePicker.Enabled = false;
            FromDatePicker.Enabled = false;
        }

        private void DuringTimeRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = false;
            ToDatePicker.Enabled = true;
            FromDatePicker.Enabled = true;
        }

        private List<Report210.ReportData> BuildData()
        {
            FilterParams param = BuildParams();
            List<Report210.ReportData> list = new List<Report210.ReportData>();
            foreach (int i in param.ServiceId)
            {
                list.AddRange( DBRepository.Convert(DBRepository.GetMonthData(param.ToDate, i)));
            }
            list = DBRepository.FilterParams(list, param, false).OrderBy(d => d.HomeSteadNumber).ToList();
            return list;
        }

        private FilterParams BuildParams()
        {
            FilterParams param = new FilterParams();
            if (MonthRB.Checked)
            {
                param.FromDate = MonthTimePicker.Value.Date.AddDays(MonthTimePicker.Value.Day * (-1) + 1);
                param.ToDate = MonthTimePicker.Value.Date.AddMonths(1).AddDays(MonthTimePicker.Value.Day * (-1));
            }
            if (DuringTimeRB.Checked)
            {
                param.FromDate = FromDatePicker.Value.Date;
                param.ToDate = ToDatePicker.Value.Date;
            }
            if (Service1RB.Checked)
                param.ServiceId.Add(1);
            if (Service2RB.Checked)
                param.ServiceId.Add(2);
            if (Service3RB.Checked)
                param.ServiceId.Add(3);
            if (Service4RB.Checked)
                param.ServiceId.Add(4);
            return param;
        }

        private void CreateReportButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(FileNameTB.Text) || string.IsNullOrWhiteSpace(FileNameTB.Text))
            {
                MessageBox.Show("Введите имя файла!");
                FileNameTB.Focus();
                return;
            }
            
            try
            {
                List<Rate> oldRates = DBRepository.GetLastRates();
                List<Rate> newRates = new List<Rate>();
                int i = 0;
                foreach (Rate r in oldRates)
                {
                    string s = RateDGV[2, i++].Value.ToString().Replace('.', ',');
                    double d;
                    if (!Double.TryParse(s, out d))
                    {
                        MessageBox.Show("Неверное значение " + s + "!");
                        return;
                    }
                    newRates.Add(new Rate() { Date = r.Date, Value = d, Id = r.Id, IdService = r.IdService });
                }
                DBRepository.ChangeRate(newRates);
                
                List<Report210.ReportData> list = BuildData();
                if(list.Count == 0)
                {
                    MessageBox.Show("Отчет по заданным параметрам не имеет записей! Измените параметры и повторите попытку.",
                        "Отчет не содержит записей", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ExcelWriter.Write202(new Report210() { Datas = list }, newRates, FileNameTB.Text, CreateExcelCB.Checked);
                this.Close();
                (Owner as MainForm).LabelProgrBar.Text = "Отчет сохранен успешно!";
                (Owner as MainForm).LabelProgrBar.Visible = true;
            }
            catch(DataBaseException)
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        private void Service2RB_Click(object sender, EventArgs e)
        {
            Service1RB.Checked = false;
            Service2RB.Checked = true;
            Service3RB.Checked = false;
            Service4RB.Checked = false;
            RateGrB.Visible = true;
            RateEdirB.Visible = true;
        }

        private void Service1RB_Click(object sender, EventArgs e)
        {
            Service1RB.Checked = true;
            Service2RB.Checked = false;
            Service3RB.Checked = false;
            Service4RB.Checked = false;
            RateGrB.Visible = false;
            RateEdirB.Visible = false;
        }

        private void Service3RB_Click(object sender, EventArgs e)
        {
            Service1RB.Checked = false;
            Service2RB.Checked = false;
            Service3RB.Checked = true;
            Service4RB.Checked = false;
            RateGrB.Visible = false;
            RateEdirB.Visible = false;
        }

        private void Service4RB_Click(object sender, EventArgs e)
        {
            Service1RB.Checked = false;
            Service2RB.Checked = false;
            Service3RB.Checked = false;
            Service4RB.Checked = true;
            RateGrB.Visible = false;
            RateEdirB.Visible = false;
        }

        private void RateEdirB_Click(object sender, EventArgs e)
        {
            try
            {
                List<Rate> oldRates = DBRepository.GetLastRates();
                List<Rate> newRates = new List<Rate>();
                int i = 0;
                foreach (Rate r in oldRates)
                {
                    string s = RateDGV[2, i++].Value.ToString().Replace('.', ',');
                    double d;
                    if (!Double.TryParse(s, out d))
                    {
                        MessageBox.Show("Неверное значение [" + s + "]!");
                        return;
                    }
                    newRates.Add(new Rate() { Date = r.Date, Value = d, Id = r.Id, IdService = r.IdService });
                }
                DBRepository.ChangeRate(newRates);
                var data = BuildData();
                if (data.Count > 0)
                {
                    try
                    {
                        RateEditForm rateForm = new RateEditForm(BuildData());
                        rateForm.ShowDialog(this);
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show("Один или несколько тарифов указаны неверно. Неверные тарифы были отмечены красным цветом.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Отчет по заданным параметрам не имеет записей! Измените параметры и повторите попытку.",
                        "Отчет не содержит записей", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(DataBaseException)
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void RateDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                double d;
                if (!double.TryParse(e.FormattedValue.ToString().Replace('.', ','), out d))
                {
                    RateDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#ff899e");
                } else
                {
                    RateDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    RateDGV.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value = ConfigAppManager.GetTariff() * double.Parse(e.FormattedValue.ToString().Replace('.',','));
                }
            }
        }
    }
}

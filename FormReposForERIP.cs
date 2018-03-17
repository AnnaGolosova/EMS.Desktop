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
        public FormReposForERIP()
        {
            InitializeComponent();
            CreateExcelCB.Checked = true;
            Service2RB.Checked = true;
            MonthRB.Checked = true;
            MonthTimePicker.Value = new DateTime(2017, 9, 5);
            DBRepository db = new DBRepository();
            foreach(Rate rate in db.GetRate())
            {
                RateDGV.Rows.Add(rate.Id, rate.Service.Name, rate.Value);
            }
            FileNameTB.Focus();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void MonthRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = true;
            QuarterTimePicker.Enabled = false;
            ToDatePicker.Enabled = false;
            FromDatePicker.Enabled = false;
        }

        private void DuringTimeRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = false;
            QuarterTimePicker.Enabled = false;
            ToDatePicker.Enabled = true;
            FromDatePicker.Enabled = true;
        }

        private void QuarterRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = false;
            QuarterTimePicker.Enabled = true;
            ToDatePicker.Enabled = false;
            FromDatePicker.Enabled = false;
        }

        private void CreateReportButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(FileNameTB.Text) || string.IsNullOrWhiteSpace(FileNameTB.Text))
            {
                MessageBox.Show("Введите имя файла!");
                FileNameTB.Focus();
                return;
            }
            FilterParams param = new FilterParams();
            if(MonthRB.Checked)
            {
                param.FromDate = MonthTimePicker.Value.Date.AddDays(MonthTimePicker.Value.Day * (-1) + 1);
                param.ToDate = MonthTimePicker.Value.Date.AddMonths(1).AddDays(MonthTimePicker.Value.Day * (-1));
            }
            if(QuarterRB.Checked)
            {
                throw new NotImplementedException();
            }
            if(DuringTimeRB.Checked)
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

            List<Report210.ReportData> list = new List<Report210.ReportData>();
            using (DBRepository db = new DBRepository())
            {
                List<Rate> oldRates = db.GetRate();
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
                db.ChangeRate(newRates);
                foreach (Payment pay in db.GetPayment())
                {
                    Report210.ReportData rd = new Report210.ReportData();
                    rd.Date = (DateTime)pay.Date;
                    rd.Entered = pay.Entered;
                    rd.Introduced = pay.Introduced;
                    rd.OwnerName = db.GetHomestead(pay.IdHomestead).OwnerName;
                    rd.ServiceId = pay.IdService;
                    rd.HomeSteadNumber = (int)db.GetHomestead(pay.IdHomestead).Number;
                    if(pay.MeterData.Count != 0)
                    {
                        rd.meterInfo = new List<Report210.ReportData.MeterInfo>();
                        foreach(MeterData md in pay.MeterData)
                        {
                            rd.meterInfo.Add(new Report210.ReportData.MeterInfo() {
                                newValue = md.Value, number = md.Meter.MeterNumber
                            });
                        }
                    }
                    list.Add(rd);
                }
                list = db.FilterParams(list, param);
                ExcelWriter.Write202(new Report210() { Datas = list }, newRates, FileNameTB.Text);
                this.Close();
                (Owner as MainForm).LabelProgrBar.Text = "Отчет сохранен успешно!";
                (Owner as MainForm).LabelProgrBar.Visible = true;
            }
        }
        
        private void Service2RB_Click(object sender, EventArgs e)
        {
            Service1RB.Checked = false;
            Service2RB.Checked = true;
            Service3RB.Checked = false;
            Service4RB.Checked = false;
        }

        private void Service1RB_Click(object sender, EventArgs e)
        {
            Service1RB.Checked = true;
            Service2RB.Checked = false;
            Service3RB.Checked = false;
            Service4RB.Checked = false;
        }

        private void Service3RB_Click(object sender, EventArgs e)
        {
            Service1RB.Checked = false;
            Service2RB.Checked = false;
            Service3RB.Checked = true;
            Service4RB.Checked = false;
        }

        private void Service4RB_Click(object sender, EventArgs e)
        {
            Service1RB.Checked = false;
            Service2RB.Checked = false;
            Service3RB.Checked = false;
            Service4RB.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

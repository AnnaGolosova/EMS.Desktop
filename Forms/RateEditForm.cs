using EMS.Desktop.Exceptions;
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

namespace EMS.Desktop.Forms
{
    public partial class RateEditForm : Form
    {
        private List<Report210.ReportData> data;

        public RateEditForm(List<Report210.ReportData> data)
        {
            try
            {
                InitializeComponent();
                this.data = data.OrderBy(d => d.HomeSteadNumber).ToList();
                splitContainer1.SplitterDistance = RateViewDGV.Height;
                RateViewDGV.Dock = DockStyle.Fill;
                RateDGV.CellValidating += RateDGV_CellValidating;
                DBRepository db = new DBRepository();
                int i = 1;
                foreach (Rate rate in db.GetLastRates().OrderBy(r => r.Id))
                {
                    RateViewDGV.Rows.Add(i++, rate.Service.Name, rate.Value);
                }
                foreach (Report210.ReportData record in this.data.OrderBy(r => r.HomeSteadNumber))
                {

                    foreach (Report210.ReportData.MeterInfo meter in record.meterInfo)
                    {
                        if (meter.rateId == null)
                        {
                            RateDGV.Rows.Add(record.HomeSteadNumber, record.OwnerName, meter.number, record.Arrer, "");
                        }
                        else
                        {
                            Rate rate = db.GetRate(null, meter.rateId);
                            int? x = db.GetRatePosition(meter.rateId);
                            RateDGV.Rows.Add(record.HomeSteadNumber, record.OwnerName, meter.number, record.Arrer, rate == null ? "" : x.ToString());
                        }
                    }
                }

                RateDGV.Focus();
                RateDGV.CurrentCell = RateDGV.Rows[0].Cells[3];
            }
            catch (DataBaseException)
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void RateDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if(e.ColumnIndex == 4)
            {
                if (!(new List<string>() { "1", "2", "3", "" }).Any(r => r.CompareTo(e.FormattedValue.ToString().Normalize()) == 0))
                    RateDGV[e.ColumnIndex, e.RowIndex].Style.BackColor = ColorTranslator.FromHtml("#ff899e");
                else RateDGV[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
            if(e.ColumnIndex == 3)
            {
                DBRepository db = new DBRepository();
                int paymentId = db.GetPayment(data[e.RowIndex].Id).Id;
                
                double d;
                if(!double.TryParse(e.FormattedValue.ToString().Replace('.', ','), out d))
                    RateDGV[e.ColumnIndex, e.RowIndex].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff899e");
                else RateDGV[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }

        private void RateEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                int i = 0;
                DBRepository db = new DBRepository();
                foreach (Report210.ReportData record in data.OrderBy(r => r.HomeSteadNumber))
                {
                    foreach (Report210.ReportData.MeterInfo mi in record.meterInfo)
                    {
                        if (!string.IsNullOrEmpty(RateDGV[4, i].Value.ToString()))
                        {
                            int rateId = Int32.Parse(RateDGV[4, i].Value as string);
                            rateId = db.GetLastRates().OrderBy(r => r.Id).First().Id + rateId - 1;
                            if (mi.rateId != rateId)
                                db.ChangeMeterData((int)mi.id, rateId);
                        }
                        if (!string.IsNullOrEmpty(RateDGV[3, i].Value.ToString()))
                        {
                            string s = RateDGV[3, i].Value.ToString().Replace('.', ',');
                            double arrear = Double.Parse(s);
                            db.SetArrear(record.Id, arrear);
                        }
                        i++;
                    }
                }
                DBRepository.db.SaveChanges();
            }
            catch (DataBaseException)
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Один или несколько тарифов указаны неверно. Неверные тарифы были отмечены красным цветом.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

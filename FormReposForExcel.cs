using EMS.Desktop.Helpers;
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
    public partial class FormReposForExcel : Form
    {
        public FormReposForExcel()
        {
            InitializeComponent();
        }

        private void MonthRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = true;
        }

        private void QuarterRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = false;
        }

        private void DuringTimeRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void CreateReportButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty( FileNameTB.Text) || string.IsNullOrWhiteSpace(FileNameTB.Text))
            {
                MessageBox.Show("Введите имя файла!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileNameTB.Focus();
                return;
            }
            int serviceId = 0;
            if (Service1RB.Checked) serviceId = 1;
            if (Service2RB.Checked) serviceId = 2;
            if (Service3RB.Checked) serviceId = 3;
            if (Service4RB.Checked) serviceId = 4;
            ExcelWriter.WriteMonthReport(MonthTimePicker.Value.Month, MonthTimePicker.Value.Year, FileNameTB.Text, serviceId);

            Hide();
        }
    }
}

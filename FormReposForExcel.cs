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
            ToDatePicker.Enabled = false;
            FromDatePicker.Enabled = false;
        }

        private void QuarterRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = false;
            ToDatePicker.Enabled = false;
            FromDatePicker.Enabled = false;
        }

        private void DuringTimeRB_CheckedChanged(object sender, EventArgs e)
        {
            MonthTimePicker.Enabled = false;
            ToDatePicker.Enabled = true;
            FromDatePicker.Enabled = true;
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
            }
            0
        }
    }
}

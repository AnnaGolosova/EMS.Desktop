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
    }
}

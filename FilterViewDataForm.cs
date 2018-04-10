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
    public partial class FilterViewDataForm : Form
    {
        public MainForm obj;
        FilterParams param = new FilterParams();
        bool IsArear = false;

        public FilterViewDataForm(MainForm _obj, FilterParams filter, bool _IsArear)
        {
            InitializeComponent();
            DBRepository repository = new DBRepository();
            string[] listhomestd = repository.GetHomestead().Select(h => h.OwnerName).ToArray();
            int[] listnumber = repository.GetHomestead().Select(h => h.Number.Value).ToArray();
            var values = new AutoCompleteStringCollection();
            values.AddRange(listhomestd);

            comboBoxOwnerName.DataSource = listhomestd.OrderBy(x => x).ToArray();
            comboBoxOwnerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxOwnerName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxOwnerName.Text = null;


            comboBoxNumber.DataSource = listnumber.OrderBy(x => x).ToArray();
            comboBoxNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxNumber.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxNumber.Text = null;

            param = filter;
            IsArear = _IsArear;

            if (param.ServicId != 0)
            {
                if (param.ServicId == 1)
                    radioButton1.Checked = true;
                if (param.ServicId == 2)
                    radioButton2.Checked = true;
                if (param.ServicId == 3)
                    radioButton3.Checked = true;
                if (param.ServicId == 4)
                    radioButton4.Checked = true;
            }
            if (param.HomesteadNumbr != 0)
                comboBoxNumber.Text = param.HomesteadNumbr.ToString();
            if (param.HomesteadOwnerName != null)
                comboBoxOwnerName.Text = param.HomesteadOwnerName;
            if (param.FromDate.Year != 1)
            {
                dateTimePickerAt.Enabled = true;
                dateTimePickerAt.Value = param.FromDate;
                dateTimePickerTo.Enabled = true;
                dateTimePickerTo.Value = param.ToDate;
                labelTo.Enabled = true;
                radioButtonAt.Checked = true;
            }

            obj = _obj;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int index = comboBoxOwnerName.FindString(comboBoxOwnerName.Text);
        }

        private FilterParams BuildParams()
        {
            FilterParams param = new FilterParams();
            DBRepository dbr = new DBRepository();
            List<int> nbr = dbr.GetHomestead().Select(s => (int)s.Number).ToList();
            List<string> homestd = dbr.GetHomestead().Select(s => s.OwnerName).ToList();
            if (!radioButtonAllTime.Checked)
            {
                param.FromDate = dateTimePickerAt.Value.Date;
                param.ToDate = dateTimePickerTo.Value.Date;
            }
            if (radioButton1.Checked)
                param.ServicId = 1;
            if (radioButton2.Checked)
                param.ServicId = 2;
            if (radioButton3.Checked)
                param.ServicId = 3;
            if (radioButton4.Checked)
                param.ServicId = 4;
            if (radioButtonAll.Checked)
                param.ServicId = 0;
            if (comboBoxOwnerName.Text != "")
            {
                if (homestd.Any(s => s == comboBoxOwnerName.Text))
                    param.HomesteadOwnerName = comboBoxOwnerName.Text;
                else
                {
                    MessageBox.Show("Такого человека не существует");
                    comboBoxOwnerName.Focus();
                    return null;
                }
            }
            try
            {
                if (nbr.Any(s => s == int.Parse(comboBoxNumber.Text)))
                    param.HomesteadNumbr = int.Parse(comboBoxNumber.Text);
                else
                {
                    MessageBox.Show("Такого участка не существует");
                    comboBoxNumber.Focus();
                    return null;
                }
            }
            catch { }
            if (IsArear)
                param.IsArear = true;
            else
                param.IsArear = false;
            return param;
        }

        private void comboBoxNumber_TextChanged(object sender, EventArgs e)
        {
            int index = comboBoxNumber.FindString(comboBoxNumber.Text);
        }
        
        private void radioButtonAt_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerAt.Enabled = true;
            dateTimePickerTo.Enabled = true;
            labelTo.Enabled = true;
        }

        private void radioButtonAllTime_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerAt.Enabled = false;
            dateTimePickerTo.Enabled = false;
            labelTo.Enabled = false;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            
            param = BuildParams();
            obj.filterPrm = param;
            obj.LoadDataGridView(param);
            Hide();

            
            /*int serv = radioButtonAll.Checked ? 5 : (radioButton1.Checked ? 1 : (radioButton2.Checked ? 2 : radioButton3.Checked ? 3 : (radioButton4.Checked ? 4 : 0)));
            if(radioButtonAt.Checked)
                obj.LoadDataGridView(comboBoxOwnerName.Text.ToString(), int.Parse(comboBoxNumber.Text), serv, dateTimePickerAt.Value, dateTimePickerTo.Value);
            if(radioButtonDay.Checked)
                obj.LoadDataGridView(comboBoxOwnerName.Text.ToString(), int.Parse(comboBoxNumber.Text), serv, dateTimePickerDay.Value);
           */
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        /*private void comboBoxNumber_Validating(object sender, CancelEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (!(new List<string>() { "1", "2", "3", "" }).Any(r => r.CompareTo(e.FormattedValue.ToString().Normalize()) == 0))
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff899e");
            else dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
        }*/
    }
}

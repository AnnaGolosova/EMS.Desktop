using EMS.Desktop.Models;
using EMS.Desktop.Services;
using System;
using System.Collections;
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

            param = filter;
            IsArear = _IsArear;

            foreach(Homestead h in DBRepository.GetHomestead().OrderBy(hh => hh.Number))
            {
                listBoxOwnerName.Items.Add($"{h.Number}\t{h.OwnerName}");
            }

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

        private FilterParams BuildParams()
        {
            FilterParams param = new FilterParams();
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
            if(listBoxOwnerName.SelectedItems != null)
            {
                ICollection selctd = listBoxOwnerName.SelectedItems;
                ArrayList s = new ArrayList(selctd);
                List<string> selectItems = s.Cast<string>().ToList();
                foreach(string ss in selectItems)
                {
                    param.HomesteadOwnName.Add(ss.Remove(0, ss.IndexOf("\t") + 1));
                }
            }
            param.IsArear = IsArear;
            param.isBadReport = BadPeopleCheckBox.Checked;
            return param;
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
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICollection selctd = listBoxOwnerName.SelectedItems;
            ArrayList s = new ArrayList(selctd);
            List<string> selectItems = s.Cast<string>().ToList();
            listBoxOwnerName.Items.Clear();
            int i = 0;
            foreach (Homestead h in DBRepository.GetHomestead().OrderBy(hh => hh.Number))
            {
                listBoxOwnerName.Items.Add($"{h.Number}\t{h.OwnerName}");
                if (selectItems.Any(ii => ii.Contains(h.OwnerName)))
                    listBoxOwnerName.SetSelected(i, true);
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ICollection selctd = listBoxOwnerName.SelectedItems;
            ArrayList s = new ArrayList(selctd);
            List<string> selectItems = s.Cast<string>().ToList();
            int i = 0;
            listBoxOwnerName.Items.Clear();
            foreach (Homestead h in DBRepository.GetHomestead().OrderBy(hh => hh.OwnerName))
            {
                listBoxOwnerName.Items.Add($"{h.Number}\t{h.OwnerName}");
                if (selectItems.Any(ii => ii.Contains(h.OwnerName)))
                    listBoxOwnerName.SetSelected(i, true);
                i++;
            }
        }

        private void BadPeopleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !BadPeopleCheckBox.Checked;
        }
    }
}

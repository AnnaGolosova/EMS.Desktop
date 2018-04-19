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
            DBRepository repository = new DBRepository();
            List<Payment> listdbr = repository.GetPayment();
            string[] listhomestd = DBRepository.GetHomestead().OrderBy(h => h.OwnerName).Select(h => h.OwnerName).ToArray();
            int[] listnumber = DBRepository.GetHomestead().OrderBy(h => h.Number).Select(h => h.Number).ToArray();
            var values = new AutoCompleteStringCollection();
            values.AddRange(listhomestd);

            /*comboBoxOwnerName.DataSource = listhomestd.OrderBy(x => x).ToArray();
            comboBoxOwnerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxOwnerName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxOwnerName.Text = null;
            buttonApply.Focus();

            comboBoxNumber.DataSource = listnumber.OrderBy(x => x).ToArray();
            comboBoxNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxNumber.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxNumber.Text = null;*/

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
            /*if (param.HomesteadNumbr != 0)
                comboBoxNumber.Text = param.HomesteadNumbr.ToString();
            if (param.HomesteadOwnerName != null)
                comboBoxOwnerName.Text = param.HomesteadOwnerName;*/
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

        /*private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int index = comboBoxOwnerName.FindString(comboBoxOwnerName.Text);
        }*/

        private FilterParams BuildParams()
        {
            FilterParams param = new FilterParams();
            List<int> nbr = DBRepository.GetHomestead().Select(s => (int)s.Number).ToList();
            List<string> homestd = DBRepository.GetHomestead().Select(s => s.OwnerName).ToList();
            //listBoxOwnerName.GetSelected();
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
            /*if (comboBoxOwnerName.Text != "")
            {
                if (homestd.Any(s => s == listBoxOwnerName.SelectedValue.ToString()))

                    //param.HomesteadOwnName.Add();
                else
                {
                    MessageBox.Show("Такого человека не существует");
                    comboBoxOwnerName.Focus();
                    return null;
                }
            }*/
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
            /*try
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
            catch { }*/
            if (IsArear)
                param.IsArear = true;
            else
                param.IsArear = false;
            return param;
        }

        /*private void comboBoxNumber_TextChanged(object sender, EventArgs e)
        {
            int index = comboBoxNumber.FindString(comboBoxNumber.Text);
        }*/
        
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

        private void listBoxOwnerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            int i;
            DBRepository repository = new DBRepository();
            List<Payment> listdbr = repository.GetPayment();
            
            ICollection selctd = listBoxOwnerName.SelectedItems;
            ArrayList s = new ArrayList(selctd);
            List<string> selectItems = s.Cast<string>().ToList();
            listdbr = listdbr.Where(h => selectItems.Any(p => p.CompareTo(h.Homestead.OwnerName) == 0)).ToList();

            for (i = 0; i < listBoxNumber.Items.Count; i++)
            {
                foreach (Payment p in listdbr)
                {
                    if (listBoxNumber.Items[i].ToString() == p.Homestead.Number.ToString())
                    {
                        if (listBoxNumber.GetSelected(i) == false)
                            listBoxNumber.SetSelected(i, true);
                        else
                            listBoxNumber.SetSelected(i, false);
                        //break;
                    }
                }
            }
            */



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
    }
}

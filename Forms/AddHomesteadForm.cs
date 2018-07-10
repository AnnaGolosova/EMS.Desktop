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

namespace EMS.Desktop.Forms
{
    public partial class AddHomesteadForm : Form
    {
        AddHomesteadState state;
        List<Homestead> homesteadList;

        public AddHomesteadForm(AddHomesteadState state)
        {
            InitializeComponent();
            this.state = state;
            if(state == AddHomesteadState.AddOnlyPayments)
            {
                AddHomesteadGB.Visible = false;
                SelectHomesteadGB.Visible = true;
                homesteadList = DBRepository.GetHomestead().OrderBy(h => h.Number).ToList();
                HomesteadNumberCB.Items.AddRange(homesteadList.Select(h => (object)h.Number).ToArray());
                this.Text = "Добавление нового плательщика";
            }
            else
            {
                NumberTB.Focus();
                AddHomesteadGB.Visible = true;
                SelectHomesteadGB.Visible = false;
                this.Text = "Добавление нового участка";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void NumberTB_Leave(object sender, EventArgs e)
        {
            int t = 0;
            if(!string.IsNullOrEmpty(NumberTB.Text) && (!int.TryParse(NumberTB.Text, out t) ||
                    string.IsNullOrWhiteSpace(NumberTB.Text)))
            {
                MessageBox.Show("Неверное значение в поле [Номер участка]. Возможно, значение не может быть преобразовано в число",
                    "Неверное значение в поле [Номер участка]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if(DBRepository.GetHomestead(t) != null)
            {
                MessageBox.Show("Неверное значение в поле [Номер участка]. Возможно, участок с таким номером уже существует", 
                    "Неверное значение в поле [Номер участка]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateB_Click(object sender, EventArgs e)
        {
            int t;
            List<int> serviceList = new List<int>();
            double meterDataValue;
            if (!Double.TryParse(MeterDataValueTB.Text, out meterDataValue))
            {
                MessageBox.Show("Неверное значение счетчика! Возможно, значение не может быть преобразвано в число",
                    "Неверное значение счетчика",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (state == AddHomesteadState.AddOnlyPayments)
            {
                Homestead h;
                try
                {
                    if (!int.TryParse(HomesteadNumberCB.Text, out t))
                    {
                        MessageBox.Show("Значение не может быть преобразовано в число", "Неверный номер участка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    h = DBRepository.GetHomestead(homesteadList.Where(hh => hh.Number == t).First().Number);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Участок с таким номером не найден", "Участок не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(!string.IsNullOrEmpty(ChangeOwnerNameTB.Text) && !string.IsNullOrWhiteSpace(ChangeOwnerNameTB.Text) &&
                    ChangeOwnerNameTB.Text.CompareTo(h.OwnerName) != 0)
                {
                    h.OwnerName = ChangeOwnerNameTB.Text;
                    DBRepository.ChangeOwnerName(h);
                }
                if (Service1CB.Checked) { serviceList.Add(1); }
                if (Service2CB.Checked) { serviceList.Add(2); }
                if (Service3CB.Checked) { serviceList.Add(3); }
                if (Service4CB.Checked) { serviceList.Add(4); }
                DBRepository.AddStartValues(h.Id, serviceList, meterDataValue, h.Meter.First().Id);
                Hide();
                return;
            }
            if (string.IsNullOrEmpty(NumberTB.Text) || !int.TryParse(NumberTB.Text, out t) ||
                    string.IsNullOrWhiteSpace(NumberTB.Text))
            {
                MessageBox.Show("Неверное значение в поле [Номер участка]. Возможно, значение не может быть преобразовано в число",
                    "Неверное значение в поле [Номер участка]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (DBRepository.GetHomestead(t) != null)
            {
                MessageBox.Show("Неверное значение в поле [Номер участка]. Возможно, участок с таким номером уже существует",
                    "Неверное значение в поле [Номер участка]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(string.IsNullOrEmpty(OwnerNameTB.Text) || string.IsNullOrWhiteSpace(OwnerNameTB.Text))
            {
                MessageBox.Show("Неверное значение в поле [Владелец участка]. Значение или не задано, или состоит из пробелов",
                    "Неверное значение в поле [Владелец участка]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Homestead homestead = DBRepository.AddHomestead(t, OwnerNameTB.Text);
            if (Service1CB.Checked) { serviceList.Add(1); }
            if (Service2CB.Checked) { serviceList.Add(2); }
            if (Service3CB.Checked) { serviceList.Add(3); }
            if (Service4CB.Checked) { serviceList.Add(4); }
            DBRepository.AddStartValues(homestead.Id, serviceList, meterDataValue, homestead.Meter.First().Id);
            Hide();
        }

        private void Service2CB_CheckedChanged(object sender, EventArgs e)
        {
            if(Service2CB.Checked)
            {
                MeterDataValueTB.Visible = true;
                label4.Visible = true;
            }
            else
            {
                MeterDataValueTB.Visible = false;
                label4.Visible = false;
            }
        }

        private void MeterDataValueTB_Leave(object sender, EventArgs e)
        {
            double d;
            if(!Double.TryParse(MeterDataValueTB.Text.Replace('.',','), out d))
            {
                MessageBox.Show("Неверное значение счетчика! Возможно, значение не может быть преобразвано в число", 
                    "Неверное значение счетчика",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HomesteadNumberCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Homestead homestead = homesteadList.Where(l => l.Number == int.Parse(HomesteadNumberCB.Text)).First();
            ChangeOwnerNameTB.Text = homestead.OwnerName;

            Service1CB.Enabled = !homestead.Payment.Any(p => p.IdService == 1);
            Service2CB.Enabled = !homestead.Payment.Any(p => p.IdService == 2);
            Service3CB.Enabled = !homestead.Payment.Any(p => p.IdService == 3);
            Service4CB.Enabled = !homestead.Payment.Any(p => p.IdService == 4);
        }
    }
}

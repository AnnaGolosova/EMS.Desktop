using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS.Desktop;

namespace EMS.Desktop.Forms
{
    public partial class CreateExcel : Form
    {
        public CreateExcel()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FileNameTB.Text) || string.IsNullOrWhiteSpace(FileNameTB.Text))
            {
                MessageBox.Show("Введите имя файла!");
                FileNameTB.Focus();
                return;
            }
            else
            {
                Helpers.ExcelWriter.convertRepositoryDataToExcel(new Services.DBRepository(), FileNameTB.Text);
                Hide();
            }
        }
    }
}

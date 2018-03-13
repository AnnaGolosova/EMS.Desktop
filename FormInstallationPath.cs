using EMS.Desktop.Helpers;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS.Desktop
{
    public partial class FormInstallationPath : Form
    {
        public FormInstallationPath()
        {
            InitializeComponent();
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            PathExcelTextBox.Text = config.AppSettings.Settings["ExcelPath"].Value;
            Path202TextBox.Text = config.AppSettings.Settings["Reports202Path"].Value;
            Path210TextBox.Text = config.AppSettings.Settings["Reports210Path"].Value;
        }

        private void OverViewExcelButton_Click(object sender, EventArgs e)
        {
            using (var openDialog = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                CommonFileDialogResult result = openDialog.ShowDialog();

                if (result == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(openDialog.FileName))
                {
                    PathExcelTextBox.Text = openDialog.FileName;
                    ConfigAppManager.SetExcelPath(openDialog.FileName);
                }
            }
        }

        private void OverView202Button_Click(object sender, EventArgs e)
        {
            using (var openDialog = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                CommonFileDialogResult result = openDialog.ShowDialog();

                if (result == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(openDialog.FileName))
                {
                    Path202TextBox.Text = openDialog.FileName;
                    ConfigAppManager.SetReports202Path(openDialog.FileName);
                }
            }
        }

        private void OverView210Button_Click(object sender, EventArgs e)
        {
            using (var openDialog = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                CommonFileDialogResult result = openDialog.ShowDialog();

                if (result == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(openDialog.FileName))
                {
                    Path210TextBox.Text = openDialog.FileName;
                    ConfigAppManager.SetReports210Path(openDialog.FileName);
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}

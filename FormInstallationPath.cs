using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
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
            PathExcelTextBox.Text = System.Configuration.ConfigurationManager.AppSettings["GetExcelPath"];
            Path202TextBox.Text = System.Configuration.ConfigurationManager.AppSettings["SetOldReports202Path"];
            Path210TextBox.Text = System.Configuration.ConfigurationManager.AppSettings["GetNewReporst210Path"];
        }

        private void OverViewExcelButton_Click(object sender, EventArgs e)
        {
            using (var openDialog = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                CommonFileDialogResult result = openDialog.ShowDialog();

                if (result == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(openDialog.FileName))
                {
                    PathExcelTextBox.Text = openDialog.FileName;
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["GetExcelPath"].Value = openDialog.FileName;
                    config.Save();
                    ConfigurationManager.RefreshSection("appSettings");
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
                    ConfigurationManager.AppSettings["SetOldReports202Path"] = openDialog.FileName;
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
                    ConfigurationManager.AppSettings["GetNewReporst210Path"] = openDialog.FileName;
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

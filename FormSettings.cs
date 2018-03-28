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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            PathExcelTextBox.Text = ConfigAppManager.GetExcelPath();
            Path202TextBox.Text = ConfigAppManager.GetReports202Path();
            Path210TextBox.Text = ConfigAppManager.GetReports210Path();
            TariffTB.Text = ConfigAppManager.GetTariff().ToString();

            FillConnectionPart();
        }

        private void FillConnectionPart()
        {
            string connectionString = ConfigAppManager.GetConnectionString();
            char[] serverName = new char[255];
            ConnectionStringTB.Text = connectionString;
            int dcIndex = connectionString.IndexOf("data source") + 12;
            int endIndex = connectionString.IndexOf(";", dcIndex) - dcIndex;
            connectionString.CopyTo(dcIndex, serverName, 0, endIndex);
            ServerNameTB.Text = new string(serverName);
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

        private void OkButton_Click(object sender, EventArgs e)
        {
            ConfigAppManager.SetConnectionString(ConnectionStringTB.Text);

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["EMSEntities"].ConnectionString = ConnectionStringTB.Text;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            Hide();
        }

        private void ConnectionStringTB_Leave(object sender, EventArgs e)
        {
            string connectionString = ConnectionStringTB.Text;
            char[] serverName = new char[255];
            int dcIndex = connectionString.IndexOf("data source") + 12;
            int endIndex = connectionString.IndexOf(";", dcIndex) - dcIndex;
            connectionString.CopyTo(dcIndex, serverName, 0, endIndex);
            ServerNameTB.Text = new string(serverName);

        }

        private void ServerNameTB_Leave(object sender, EventArgs e)
        {
            string connectionString = ConnectionStringTB.Text;
            char[] serverName = new char[255];
            int dcIndex = connectionString.IndexOf("data source") + 12;
            int endIndex = connectionString.IndexOf(";", dcIndex) - dcIndex;
            connectionString.CopyTo(dcIndex, serverName, 0, endIndex);
            string s = new string(serverName.Take(endIndex).ToArray());
            connectionString = connectionString.Replace(s, ServerNameTB.Text);
            ConnectionStringTB.Text = connectionString;
        }

        private void TariffTB_TextChanged(object sender, EventArgs e)
        {
            ConfigAppManager.SetTariff(TariffTB.Text);
        }
    }
}
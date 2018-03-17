using EMS.Desktop.Helpers;
using EMS.Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EMS.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void OnCreate()
        {
            LoadNewFile.LoadFile(this);
        }
        private void MenuAboutProgram_Click(object sender, EventArgs e)
        {
            FormAboutProgram FrAbPr = new FormAboutProgram();
            FrAbPr.ShowDialog();
        }

        private void MenuReposForERIP_Click(object sender, EventArgs e)
        {
            FormReposForERIP RpFrERIP = new FormReposForERIP();
            RpFrERIP.ShowDialog(this);
        }

        private void MenuReposForExcel_Click(object sender, EventArgs e)
        {
            FormReposForExcel RpFrExcel = new FormReposForExcel();
            RpFrExcel.ShowDialog();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings FrSett = new FormSettings();
            FrSett.ShowDialog();
        }

        private void SavePathTSMI_Click(object sender, EventArgs e)
        {
            FormInstallationPath FmInstPath = new FormInstallationPath();
            FmInstPath.ShowDialog();
        }

        private void Load_MainForm(object sender, EventArgs e)
        {
            Thread NewFile = new Thread(OnCreate);
            NewFile.Start();
        }

        private void Closing_MainForm(object sender, FormClosingEventArgs e)
        {
            if (MainProgressBar.Value != MainProgressBar.Maximum)
            {
                if (MessageBox.Show("Процесс загрузки новых файлов .210 ещё не завершён!\nВы действительнно хотите выйти ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                    Environment.Exit(1);
            }
            else
                Environment.Exit(1);
        }
    }
}

using EMS.Desktop.Helpers;
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
            if (new FileManager().GetNewFilesCount(ConfigAppManager.GetReports210Path()) != 0)
            {
                Action MaxPrBr = () => 
                {
                    MainProgressBar.Maximum = 50000;
                };
                Invoke(MaxPrBr);
                for (int i = 0; i <= MainProgressBar.Maximum - 1; i++)
                {
                    Action AddPrgBr = () =>
                    {
                        ExcelWriter Ex = new ExcelWriter();
                        Ex.Read210();
                        MainProgressBar.Value = i + 1;
                        MainProgressBar.Value = i;
                    };
                    Invoke(AddPrgBr);
                }
                Action ShowComp = () => { LabelProgrBar.Visible = true; };
                Invoke(ShowComp);
            }
        }

        private void MenuAboutProgram_Click(object sender, EventArgs e)
        {
            FormAboutProgram FrAbPr = new FormAboutProgram();
            FrAbPr.ShowDialog();
        }

        private void MenuReposForERIP_Click(object sender, EventArgs e)
        {
            FormReposForERIP RpFrERIP = new FormReposForERIP();
            RpFrERIP.ShowDialog();
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

        private void Closed_MainForm(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}

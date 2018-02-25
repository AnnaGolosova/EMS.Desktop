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
            Thread NewFile = new Thread(OnCreate);
            NewFile.Start();
        }

        public void OnCreate()
        {
            if (true)
            {
                Action MaxPrBr = () => { MainProgressBar.Maximum = 110000; };
                Invoke(MaxPrBr);
                for (int i = 0; i <= MainProgressBar.Maximum; i++)
                {
                    Action AddPrgBr = () =>
                    {
                        MainProgressBar.Value = i;
                        LabelProgrBar.Text = i + "/" + MainProgressBar.Maximum;
                    };
                    Invoke(AddPrgBr);
                }
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

        
    }
}

﻿using EMS.Desktop.Helpers;
using EMS.Desktop.Models;
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
            Thread NewFile = new Thread(OnCreate);
            NewFile.Start();
        }

        public void OnCreate()
        {
            
        }

        private void MenuAboutProgram_Click(object sender, EventArgs e)
        {
            //foreach(string file in FileManager.GetNewFilePathes(Application.StartupPath))
            //{
            //    Report210 report = ExcelWriter.Read210(file);
            //    using (DBRepository db = new DBRepository())
            //    {
            //        db.LoadReport210(report);
            //    }
            //}

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

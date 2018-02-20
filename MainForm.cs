﻿using EMS.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            FormSettings FrSett = new FormSettings();
            FrSett.ShowDialog();
        }

        private void MenuAboutProgram_Click(object sender, EventArgs e)
        {
            //FormAboutProgram FrAbPr = new FormAboutProgram();
            //FrAbPr.ShowDialog();
            try
            {
                FileManager m = new FileManager();
                m.DeleteFile("");

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: {0}", ex.ToString());
            }
            catch (Exception er)
            {
                Console.WriteLine("The process failed: {0}", er.ToString());
            }
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
    }
}

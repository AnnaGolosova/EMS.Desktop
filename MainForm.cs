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
            if (FileManager.GetNewFilesCount(ConfigAppManager.GetReports210Path()) != 0)
            {
                Thread NewFile = new Thread(OnCreate);
                NewFile.Start();
            }
        }

        private void Closing_MainForm(object sender, FormClosingEventArgs e)
        {
            if (FileManager.GetNewFilesCount(ConfigAppManager.GetReports210Path()) != 0)
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
            else
                Environment.Exit(1);
        }

        private void MainJournal_Click(object sender, EventArgs e)
        {
            DBRepository dbrepository = new DBRepository();
            if (dbrepository.GetFiles().Count != 0)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Visible = true;

                var column1 = new DataGridViewColumn();
                column1.HeaderText = "Количество платежей";
                column1.Name = "count";
                column1.MinimumWidth = 90;
                column1.CellTemplate = new DataGridViewTextBoxCell();
                column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                var column2 = new DataGridViewColumn();
                column2.HeaderText = "Время обработки";
                column2.Name = "time";
                column2.MinimumWidth = 90;
                column2.CellTemplate = new DataGridViewTextBoxCell();
                column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                var column3 = new DataGridViewColumn();
                column3.HeaderText = "Путь к файлу";
                column3.Name = "path";
                column3.MinimumWidth = 90;
                column3.CellTemplate = new DataGridViewTextBoxCell();

                dataGridView1.Columns.Add(column1);
                dataGridView1.Columns.Add(column2);
                dataGridView1.Columns.Add(column3);

                dataGridView1.AllowUserToAddRows = false;
                DBRepository repository = new DBRepository();
                List<Models.File> listdbr = repository.GetFiles();
                listdbr.OrderBy(s => s.Date);
                foreach (Models.File s in listdbr)
                {
                    dataGridView1.Rows.Add(s.Payment.Count, s.Date.Value.ToShortDateString(), s.Path);
                }
            }
            else
            {
                LabelProgrBar.Text = "Нет файлов для создания журнала";
                LabelProgrBar.Visible = true;
            }
        }
    }
}

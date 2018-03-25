using EMS.Desktop.Helpers;
using EMS.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using EMS.Desktop.Exceptions;
using System.Configuration;

namespace EMS.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["EMSEntities"].ConnectionString = ConfigAppManager.GetConnectionString();
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            DBRepository db = new DBRepository();
            if(!db.TryConnection())
            {
                AmountLabel.Visible = false;
            }
            else
            {
                AmountLabel.Text = "Сумма на р/с : " + db.GetAmount() + " BYN";
            }
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

        private void Load_MainForm(object sender, EventArgs e)
        {
            if (FileManager.GetNewFilesCount(ConfigAppManager.GetReports210Path()) != 0)
            {
                Thread NewFile = new Thread(OnCreate);
                NewFile.Start();
            }
            else
            {
                LabelProgrBar.Visible = true;
                LabelProgrBar.Text = "Новых файлов нет";
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
            try
            {
                LoadingLabel.Visible = true;
                DBRepository dbrepository = new DBRepository();
                if(!dbrepository.TryConnection())
                {
                    throw new DataBaseException("");
                }
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

                    LoadingLabel.Visible = false;
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
                    LoadingLabel.Visible = false;
                    LabelProgrBar.Text = "Нет файлов для создания журнала";
                    LabelProgrBar.Visible = true;
                }
            }
            catch(DataBaseException)
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера", 
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void MenuDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                LoadingLabel.Visible = true;
                DBRepository repository = new DBRepository();
                if (repository.GetFiles().Count != 0)
                {
                    if (!repository.TryConnection())
                    {
                        throw new DataBaseException("");
                    }
                    LoadingLabel.Visible = true;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Visible = true;

                    var column1 = new DataGridViewColumn();
                    column1.HeaderText = "Услуга";
                    column1.Name = "Servise";
                    //column1.MinimumWidth = 20;
                    column1.CellTemplate = new DataGridViewTextBoxCell();
                    column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column2 = new DataGridViewColumn();
                    column2.HeaderText = "Номер участка";
                    column2.Name = "HomeStead";
                    //column2.MinimumWidth = 20;
                    column2.CellTemplate = new DataGridViewTextBoxCell();
                    column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column3 = new DataGridViewColumn();
                    column3.HeaderText = "Ф.И.О.";
                    column3.Name = "OwnerName";
                    //column3.MinimumWidth = 20;
                    column3.CellTemplate = new DataGridViewTextBoxCell();
                    column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column4 = new DataGridViewColumn();
                    column4.HeaderText = "Дата оплаты";
                    column4.Name = "Date";
                    //column4.MinimumWidth = 20;
                    column4.CellTemplate = new DataGridViewTextBoxCell();
                    column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column5 = new DataGridViewColumn();
                    column5.HeaderText = "Внесено";
                    column5.Name = "Introdused";
                    // column5.MinimumWidth = 20;
                    column5.CellTemplate = new DataGridViewTextBoxCell();
                    column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column6 = new DataGridViewColumn();
                    column6.HeaderText = "Задолженность";
                    column6.Name = "Arrear";
                    // column6.MinimumWidth = 20;
                    column6.CellTemplate = new DataGridViewTextBoxCell();
                    column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column7 = new DataGridViewColumn();
                    column7.HeaderText = "Поступило на рассчётный счёт";
                    column7.Name = "Entered";
                    //column7.MinimumWidth = 20;
                    column7.CellTemplate = new DataGridViewTextBoxCell();
                    column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column8 = new DataGridViewColumn();
                    column8.HeaderText = "Значение счётчика";
                    column8.Name = "MeterData";
                    //column8.MinimumWidth = 20;
                    column8.CellTemplate = new DataGridViewTextBoxCell();

                    dataGridView1.Columns.Add(column1);
                    dataGridView1.Columns.Add(column2);
                    dataGridView1.Columns.Add(column3);
                    dataGridView1.Columns.Add(column4);
                    dataGridView1.Columns.Add(column5);
                    dataGridView1.Columns.Add(column6);
                    dataGridView1.Columns.Add(column7);
                    dataGridView1.Columns.Add(column8);
                    LoadingLabel.Visible = false;

                    dataGridView1.AllowUserToAddRows = false;

                    List<Models.Payment> listdbr = repository.GetPayment();
                    listdbr.OrderBy(s => s.Date);
                    int x = 0;
                    foreach (Models.Payment s in listdbr)
                    {
                        if (s.IdService == 2)
                        {
                            dataGridView1.Rows.Add(s.Service.Id, s.Homestead.Number, s.Homestead.OwnerName, s.Date.Value.ToShortDateString(), s.Introduced, "0.0", s.Entered, s.MeterData.ToList()[0].Value);
                            if (s.Homestead.Meter.Count > 1)
                            {
                                int n = s.Homestead.Meter.Count;
                                for (int i = 1; i < n; i++)
                                {
                                    x++;
                                    dataGridView1.Rows.Add("", "", "", "", "", "", "", s.MeterData.ToList()[i].Value);
                                    for (int j = 0; j < 7; j++)
                                    {
                                        dataGridView1.Rows[x].Cells[j].Style.BackColor = Color.Lavender;
                                    }
                                }
                            }
                        }
                        else
                        {
                            dataGridView1.Rows.Add(s.Service.Id, s.Homestead.Number, s.Homestead.OwnerName, s.Date.Value.ToShortDateString(), s.Introduced, "0.0", s.Entered, "");
                            dataGridView1.Rows[x].Cells[7].Style.BackColor = Color.Lavender;
                        }
                        x++;
                    }
                    createExcelButton.Visible = true;
                }
                else
                {
                    LoadingLabel.Visible = false;
                    LabelProgrBar.Text = "Нет файлов для просмотра файлов";
                    LabelProgrBar.Visible = true;
                }
            }
            catch(DataBaseException)
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

       /* bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dataGridView1[column, row];
            DataGridViewCell cell2 = dataGridView1[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }*/

        private void ToolStripDownloadNewFile_Click(object sender, EventArgs e)
        {
            MainProgressBar.Value = 0;
            LabelProgrBar.Visible = false;
            if (FileManager.GetNewFilesCount(ConfigAppManager.GetReports210Path()) != 0)
            {
                Thread NewFile = new Thread(OnCreate);
                NewFile.Start();
            }
            else
            {
                LabelProgrBar.Visible = true;
                LabelProgrBar.Text = "Новых файлов нет";
            }
        }

        private void CLearFileStatesMI_Click(object sender, EventArgs e)
        {
            if(string .IsNullOrEmpty(ConfigAppManager.GetReports210Path()))
            {
                MessageBox.Show("Путь для .210 файлов пуст. Проверьте настройки.", "Путь для .210 файлов пуст", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FileManager.ClearFileStates(ConfigAppManager.GetReports210Path());
            LabelProgrBar.Visible = true;
            LabelProgrBar.Text = "Состояния файлов очищены.";
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            FormSettings FrSett = new FormSettings();
            FrSett.ShowDialog();
        }

        private void createExcelButton_Click(object sender, EventArgs e)
        {

        }
    }
}

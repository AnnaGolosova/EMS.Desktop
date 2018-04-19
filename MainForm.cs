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
using EMS.Desktop.Models;
using EMS.Desktop.Forms;

namespace EMS.Desktop
{
    public partial class MainForm : Form
    {
        private delegate void LoadDelegate();
        private List<Payment> data;
        public FilterParams filterPrm = new FilterParams();

        private void ShowAmount()
        {
            DBRepository db = new DBRepository();
            if (!DBRepository.TryConnection())
            {
                AmountLabel.Visible = false;
            }
            else
            {
                AmountLabel.Text = "Сумма на р/с : " + db.GetAmount() + " BYN";
            }
        }

        public MainForm()
        {
            InitializeComponent();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["EMSEntities"].ConnectionString = ConfigAppManager.GetConnectionString();
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            ShowAmount();
            filterPrm = new FilterParams();
        }

        private void LoadingComplete(IAsyncResult result)
        {
            BeginInvoke(new LoadDelegate(ShowAmount));
            BeginInvoke(new LoadDelegate(ShowArrearDrid));
        }

        void ShowArrearDrid()
        {
            data = DBRepository.GetLastPayment();
            ArrearEditDGV.Rows.Clear();
            foreach (Payment p in data)
            {
                if (p.Service.Id == 2)
                {
                    ArrearEditDGV.Rows.Add(p.Id, p.Service.Id, p.Homestead.Number, p.Homestead.OwnerName,
                        p.Introduced, p.Arrear,
                        p.MeterData.OrderBy(md => md.Meter.MeterNumber).First().NewValue - p.MeterData.OrderBy(md => md.Meter.MeterNumber).First().OldValue,
                        p.MeterData.OrderBy(md => md.Meter.MeterNumber).First().NewValue);
                }
                else
                    ArrearEditDGV.Rows.Add(p.Id, p.Service.Id, p.Homestead.Number, p.Homestead.OwnerName,
                        p.Introduced, p.Arrear);

            }
            ArrearGB.Visible = true;
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
            if (!DBRepository.TryConnection())
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormReposForERIP RpFrERIP = new FormReposForERIP();
            RpFrERIP.ShowDialog(this);
        }

        private void MenuReposForExcel_Click(object sender, EventArgs e)
        {
            if (!DBRepository.TryConnection())
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormReposForExcel RpFrExcel = new FormReposForExcel();
            RpFrExcel.ShowDialog();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings FrSett = new FormSettings();
            FrSett.ShowDialog();
        }

        private void SaveMonthReports()
        {
            if (ConfigAppManager.GetReportDay() < 10)
                if (DateTime.Now.Day == ConfigAppManager.GetReportDay())
                {
                    string[] ServiceName = { "Взносы ", "Электроэнергия ", "Налог на землю ", "Налог на недвижимость " };
                    if (DateTime.Now.Month == 1)
                    {
                        try
                        {
                            ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[0] + DateTime.Now.ToShortDateString(), 1);
                            ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[1] + DateTime.Now.ToShortDateString(), 2);
                            ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[2] + DateTime.Now.ToShortDateString(), 3);
                            ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[3] + DateTime.Now.ToShortDateString(), 4);
                        }
                        catch (ReportIsEmptyException ex)
                        {
                            MessageBox.Show("Отчет по " + DBRepository.GetService(ex.ServiceId).Name + " за текущий месяц не был сформирован, т.к. не имеет записей!", "Формирование ежемесячных отчетов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        for (int j = 1; j < 5; j++)
                        {
                            FilterParams param = new FilterParams();
                            List<Report210.ReportData> list = new List<Report210.ReportData>();
                            param.FromDate = new DateTime(DateTime.Now.Year - 1, 12, 1);
                            param.ToDate = new DateTime(DateTime.Now.Year - 1, 12, 31);
                            param.ServiceId.Add(j);
                            list.AddRange(DBRepository.Convert(DBRepository.GetMonthData(param.ToDate, j)));
                            list = new DBRepository().FilterParams(list, param, false);
                            ExcelWriter.Write202(new Report210() { Datas = list }, new DBRepository().GetLastRates(), ServiceName[j - 1] + DateTime.Now.ToShortDateString(), false);
                        }
                    }
                    else
                    {
                        try
                        {
                            ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[0] + DateTime.Now.ToShortDateString(), 1);
                            ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[1] + DateTime.Now.ToShortDateString(), 2);
                            ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[2] + DateTime.Now.ToShortDateString(), 3);
                            ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[3] + DateTime.Now.ToShortDateString(), 4);
                        }
                        catch (ReportIsEmptyException ex)
                        {
                            MessageBox.Show("Отчет по " + DBRepository.GetService(ex.ServiceId).Name + " за текущий месяц не был сформирован, т.к. не имеет записей!", "Формирование ежемесячных отчетов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        for (int j = 1; j < 5; j++)
                        {
                            FilterParams param = new FilterParams();
                            List<Report210.ReportData> list = new List<Report210.ReportData>();
                            param.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                            param.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));
                            param.ServiceId.Add(j);
                            list.AddRange(DBRepository.Convert(DBRepository.GetMonthData(param.ToDate, j)));
                            list = new DBRepository().FilterParams(list, param, false);
                            ExcelWriter.Write202(new Report210() { Datas = list }, new DBRepository().GetLastRates(), ServiceName[j - 1] + DateTime.Now.ToShortDateString(), false);
                        }
                    }
                }
            else if (DateTime.Now.Day == ConfigAppManager.GetReportDay() || DateTime.Now.Day.Equals(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)))
            {
                string[] ServiceName = { "Взносы ", "Электроэнергия ", "Налог на землю ", "Налог на недвижимость " };
                try
                {
                    ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[0] + DateTime.Now.ToShortDateString(), 1);
                    ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[1] + DateTime.Now.ToShortDateString(), 2);
                    ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[2] + DateTime.Now.ToShortDateString(), 3);
                    ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[3] + DateTime.Now.ToShortDateString(), 4);
                }
                catch (ReportIsEmptyException ex)
                {
                    MessageBox.Show("Отчет по " + DBRepository.GetService(ex.ServiceId).Name + " за текущий месяц не был сформирован, т.к. не имеет записей!", "Формирование ежемесячных отчетов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                for (int j = 1; j < 5; j++)
                {
                    FilterParams param = new FilterParams();
                    List<Report210.ReportData> list = new List<Report210.ReportData>();
                    param.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    param.ToDate = DateTime.Now;
                    param.ServiceId.Add(j);
                    list.AddRange(DBRepository.Convert(DBRepository.GetMonthData(param.ToDate, j)));
                    list = new DBRepository().FilterParams(list, param, false);
                    ExcelWriter.Write202(new Report210() { Datas = list }, new DBRepository().GetLastRates(), ServiceName[j - 1] + DateTime.Now.ToShortDateString(), false);
                }
            }
        }

        private void ShowSaveCompleteMessage()
        {
            LabelProgrBar.Visible = true;
            LabelProgrBar.Text = "Ежемесячные отчеты обработаны";
        }

        private void saveComplete(IAsyncResult res)
        {
            BeginInvoke(new LoadDelegate(ShowSaveCompleteMessage));
        }

        private void Load_MainForm(object sender, EventArgs e)
        {
            if (FileManager.GetNewFilesCount(ConfigAppManager.GetReports210Path()) != 0)
            {
                LoadDelegate loadDelegate = OnCreate;
                IAsyncResult result = loadDelegate.BeginInvoke(new AsyncCallback(LoadingComplete), null);
            }
            else
            {
                LabelProgrBar.Visible = true;
                LabelProgrBar.Text = "Новых файлов нет";
            }
            LoadDelegate saveDelegate = SaveMonthReports;
            IAsyncResult saveResult = saveDelegate.BeginInvoke(new AsyncCallback(saveComplete), null);
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
                ArrearGB.Visible = false;

                DBRepository dbrepository = new DBRepository();
                if(!DBRepository.TryConnection())
                {
                    throw new DataBaseException("");
                }
                if (dbrepository.GetFiles().Count != 0)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Visible = true;
                    createExcelButton.Hide();

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
            if(!DBRepository.TryConnection())
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FilterViewDataForm Flt = new FilterViewDataForm(this, filterPrm, false);
            Flt.Show();
        }

        public void LoadDataGridView(FilterParams param)
        {
            try
            {
                LoadingLabel.Visible = true;
                ArrearGB.Visible = false;
                DBRepository repository = new DBRepository();
                if (repository.GetFiles().Count != 0)
                {
                    if (!DBRepository.TryConnection())
                    {
                        throw new DataBaseException("");
                    }
                    LoadingLabel.Visible = true;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Visible = true;
                    dataGridView1.ScrollBars = ScrollBars.Both;

                    var column1 = new DataGridViewColumn();
                    column1.HeaderText = "Услуга";
                    column1.Name = "Servise";
                    column1.ReadOnly = true;
                    column1.CellTemplate = new DataGridViewTextBoxCell();
                    column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    column1.SortMode = DataGridViewColumnSortMode.Automatic;

                    var column2 = new DataGridViewColumn();
                    column2.HeaderText = "Н/у";
                    column2.Name = "HomeStead";
                    column2.Width = 20;
                    column2.ReadOnly = true;
                    column2.CellTemplate = new DataGridViewTextBoxCell();
                    column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    column2.SortMode = DataGridViewColumnSortMode.Automatic;

                    var column3 = new DataGridViewColumn();
                    column3.HeaderText = "Ф.И.О.";
                    column3.Name = "OwnerName";
                    column3.ReadOnly = true;
                    column3.CellTemplate = new DataGridViewTextBoxCell();
                    column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    column3.SortMode = DataGridViewColumnSortMode.Automatic;

                    var column4 = new DataGridViewColumn();
                    column4.HeaderText = "Дата оплаты";
                    column4.Name = "Date";
                    column4.ReadOnly = true;
                    column4.CellTemplate = new DataGridViewTextBoxCell();
                    column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    column4.SortMode = DataGridViewColumnSortMode.Automatic;

                    var column5 = new DataGridViewColumn();
                    column5.HeaderText = "Задолженность"; 
                    column5.Name = "Arrear";
                    column5.ReadOnly = false;
                    column5.CellTemplate = new DataGridViewTextBoxCell();
                    column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    column5.SortMode = DataGridViewColumnSortMode.Automatic;

                    var column6 = new DataGridViewColumn();
                    column6.HeaderText = "Внесено";
                    column6.Name = "Introdused";
                    column6.ReadOnly = true;
                    column6.CellTemplate = new DataGridViewTextBoxCell();
                    column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    column6.SortMode = DataGridViewColumnSortMode.Automatic;

                    var column7 = new DataGridViewColumn();
                    column7.HeaderText = "Поступило";
                    column7.Name = "Entered";
                    column7.ReadOnly = true;
                    column7.CellTemplate = new DataGridViewTextBoxCell();
                    column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    column7.SortMode = DataGridViewColumnSortMode.Automatic;

                    var column8 = new DataGridViewColumn();
                    column8.HeaderText = "Разность";
                    column8.Name = "Difference";
                    column8.Width = 20;
                    column8.ReadOnly = true;
                    column8.CellTemplate = new DataGridViewTextBoxCell();
                    column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column9 = new DataGridViewColumn();
                    column9.HeaderText = "Кол-во кВТ за месяц";
                    column9.Name = "DifferenceMeter";
                    column9.Width = 20;
                    column9.ReadOnly = true;
                    column9.CellTemplate = new DataGridViewTextBoxCell();
                    column9.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column10 = new DataGridViewColumn();
                    column10.HeaderText = "Значение счётчика";
                    column10.Name = "MeterData";
                    column10.ReadOnly = true;
                    column10.CellTemplate = new DataGridViewTextBoxCell();
                    column10.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column11 = new DataGridViewColumn();
                    column11.HeaderText = "Путь к файлу";
                    column11.Name = "Path";
                    column11.ReadOnly = true;
                    column11.CellTemplate = new DataGridViewTextBoxCell();
                    column11.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    var column12 = new DataGridViewColumn();
                    column12.Name = "Id";
                    column12.ReadOnly = true;
                    column12.CellTemplate = new DataGridViewTextBoxCell();
                    column12.Visible = false;

                    var column14 = new DataGridViewColumn();
                    column14.Name = "IdMeterData";
                    column14.ReadOnly = true;
                    column14.CellTemplate = new DataGridViewTextBoxCell();
                    column14.Visible = false;

                    var column13 = new DataGridViewColumn();
                    column13.HeaderText = "Тариф";
                    column13.Name = "Rate";
                    column13.ReadOnly = false;
                    column13.CellTemplate = new DataGridViewTextBoxCell();
                    column13.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dataGridView1.Columns.Add(column12);
                    dataGridView1.Columns.Add(column1);
                    dataGridView1.Columns.Add(column2);
                    dataGridView1.Columns.Add(column3);
                    dataGridView1.Columns.Add(column4);
                    dataGridView1.Columns.Add(column6);
                    dataGridView1.Columns.Add(column7);
                    dataGridView1.Columns.Add(column8);
                    dataGridView1.Columns.Add(column5);
                    dataGridView1.Columns.Add(column13);
                    dataGridView1.Columns.Add(column9);
                    dataGridView1.Columns.Add(column10);
                    dataGridView1.Columns.Add(column11);
                    dataGridView1.Columns.Add(column14);
                    LoadingLabel.Visible = false;

                    dataGridView1.AllowUserToAddRows = false;

                    List<Payment> listdbr = repository.GetPayment();
                    
                    int x = 0;
                    if (param.HomesteadOwnName.Count != 0)
                    {
                        listdbr.Clear();
                        foreach (string s in param.HomesteadOwnName)
                        {
                            List<Payment> listpay = repository.GetPayment().Where(c => c.Homestead.OwnerName == s).ToList();
                            foreach (Payment p in listpay)
                                listdbr.Add(p);
                        }

                    }
                    if (param.ServicId != 0)
                        listdbr = listdbr.Where(c => c.IdService == param.ServicId).ToList();
                    if(param.HomesteadNumbr != 0)
                        listdbr = listdbr.Where(c => c.Homestead.Number == param.HomesteadNumbr).ToList();
                    
                    if (param.FromDate.Year != 1)
                        listdbr = listdbr.Where(c => c.Date >= param.FromDate && c.Date <= param.ToDate).ToList();
                    if (param.IsArear)
                        listdbr = listdbr.Where(c => c.Arrear > 0.0).ToList();
                    listdbr.OrderBy(s => s.Date);
                    foreach (Payment s in listdbr)
                    {
                        if (s.IdService == 2)
                        {
                            dataGridView1.Rows.Add(s.Id, s.Service.Id, s.Homestead.Number, s.Homestead.OwnerName, s.Date.Value.ToShortDateString(), s.Introduced, s.Entered,
                                (s.Introduced - s.Entered).ToString("F3"), s.Arrear, (int)DBRepository.GetRatePosition(s.MeterData.ToList()[0].Rate.Id), 
                                (s.MeterData.ToList()[0].NewValue - s.MeterData.ToList()[0].OldValue), s.MeterData.ToList()[0].NewValue, s.File.Path, s.MeterData.ToList()[0].Id);
                            if (s.Homestead.Meter.Count > 1)
                            {
                                int n = s.MeterData.Count;
                                for (int i = 1; i < n; i++)
                                {
                                    x++;
                                    dataGridView1.Rows.Add(s.Id, s.Service.Id, s.Homestead.Number, s.Homestead.OwnerName, s.Date.Value.ToShortDateString(), s.Introduced, s.Entered,
                                        (s.Introduced - s.Entered).ToString("F3"), s.Arrear, (int)DBRepository.GetRatePosition(s.MeterData.ToList()[i].Rate.Id),
                                        (s.MeterData.ToList()[i].NewValue - s.MeterData.ToList()[i].OldValue) + " (" + (i + 1) + ") счетчик", s.MeterData.ToList()[i].NewValue, s.File.Path, s.MeterData.ToList()[i].Id);
                                    for (int j = 0; j < 11; j++)
                                    {
                                        dataGridView1.Rows[x].Cells[j].Style.BackColor = Color.Lavender;
                                    }
                                }
                            }
                        }
                        else
                        {
                            dataGridView1.Rows.Add(s.Id, s.Service.Id, s.Homestead.Number, s.Homestead.OwnerName, s.Date.Value.ToShortDateString(), 
                                s.Introduced,  s.Entered, (s.Introduced - s.Entered).ToString("F3"), s.Arrear, "","", "", s.File.Path, "~");
                            /*dataGridView1.Rows[x].Cells[7].Style.BackColor = Color.Lavender;
                            dataGridView1.Rows[x].Cells[8].Style.BackColor = Color.Lavender;
                            dataGridView1.Rows[x].Cells[9].Style.BackColor = Color.Lavender;
                            dataGridView1.Rows[x].Cells[10].Style.BackColor = Color.Lavender;*/
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
                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView1.BackgroundColor = Color.White;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            catch (DataBaseException)
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ToolStripDownloadNewFile_Click(object sender, EventArgs e)
        {
            MainProgressBar.Value = 0;
            LabelProgrBar.Visible = false;
            if (FileManager.GetNewFilesCount(ConfigAppManager.GetReports210Path()) != 0)
            {
                LoadDelegate loadDelegate = OnCreate;
                IAsyncResult result = loadDelegate.BeginInvoke(new AsyncCallback(LoadingComplete), null);
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

        private void DebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBRepository.TryConnection())
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBRepository dbrepository = new DBRepository();
            if (dbrepository.GetFiles().Count != 0)
            {
                FilterViewDataForm Flt = new FilterViewDataForm(this, filterPrm, true);
                Flt.Show();
            }
            else
            {
                LoadingLabel.Visible = false;
                LabelProgrBar.Text = "Нет файлов для создания журнала задолжников";
                LabelProgrBar.Visible = true;
            }
        }

        private void ArrearConfirmB_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Payment p in data)
            {
                if (double.Parse(ArrearEditDGV.Rows[i].Cells[5].Value.ToString().Replace('.', ',')) != 0)
                {
                    DBRepository.ChangeArrear(int.Parse(ArrearEditDGV.Rows[i].Cells[0].Value.ToString()),
                        double.Parse(ArrearEditDGV.Rows[i].Cells[5].Value.ToString().Replace('.', ',')));
                }
                i++;
            }

            ArrearGB.Visible = false;

            if (ConfigAppManager.GetReportDay() < 10)
                if (DateTime.Now.Day == ConfigAppManager.GetReportDay())
                {
                    string[] ServiceName = { "Взносы ", "Электроэнергия ", "Налог на землю ", "Налог на недвижимость " };
                    if (DateTime.Now.Month == 1)
                    {
                        ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[0] + DateTime.Now.ToShortDateString(), 1);
                        ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[1] + DateTime.Now.ToShortDateString(), 2);
                        ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[2] + DateTime.Now.ToShortDateString(), 3);
                        ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[3] + DateTime.Now.ToShortDateString(), 4);
                        for (int j = 1; j < 5; j++)
                        {
                            FilterParams param = new FilterParams();
                            List<Report210.ReportData> list = new List<Report210.ReportData>();
                            param.FromDate = new DateTime(DateTime.Now.Year - 1, 12, 1);
                            param.ToDate = new DateTime(DateTime.Now.Year - 1, 12, 31);
                            param.ServiceId.Add(j);
                            list.AddRange(DBRepository.Convert(DBRepository.GetMonthData(param.ToDate, j)));
                            list = new DBRepository().FilterParams(list, param, false);
                            ExcelWriter.Write202(new Report210() { Datas = list }, new DBRepository().GetLastRates(), ServiceName[j - 1] + DateTime.Now.ToShortDateString(), false);
                        }
                    }
                    else
                    {
                        ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[0] + DateTime.Now.ToShortDateString(), 1);
                        ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[1] + DateTime.Now.ToShortDateString(), 2);
                        ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[2] + DateTime.Now.ToShortDateString(), 3);
                        ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[3] + DateTime.Now.ToShortDateString(), 4);
                        for (int j = 1; j < 5; j++)
                        {
                            FilterParams param = new FilterParams();
                            List<Report210.ReportData> list = new List<Report210.ReportData>();
                            param.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                            param.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));
                            param.ServiceId.Add(j);
                            list.AddRange(DBRepository.Convert(DBRepository.GetMonthData(param.ToDate, j)));
                            list = new DBRepository().FilterParams(list, param, false);
                            ExcelWriter.Write202(new Report210() { Datas = list }, new DBRepository().GetLastRates(), ServiceName[j - 1] + DateTime.Now.ToShortDateString(), false);
                        }
                    }
                }
            else if (DateTime.Now.Day == ConfigAppManager.GetReportDay() || DateTime.Now.Day.Equals(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)))
            {
                string[] ServiceName = { "Взносы ", "Электроэнергия ", "Налог на землю ", "Налог на недвижимость " };
                ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[0] + DateTime.Now.ToShortDateString(), 1);
                ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[1] + DateTime.Now.ToShortDateString(), 2);
                ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[2] + DateTime.Now.ToShortDateString(), 3);
                ExcelWriter.WriteMonthReport(DateTime.Now.Month, ServiceName[3] + DateTime.Now.ToShortDateString(), 4);
                for (int j = 1; j < 5; j++)
                {
                    FilterParams param = new FilterParams();
                    List<Report210.ReportData> list = new List<Report210.ReportData>();
                    param.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    param.ToDate = DateTime.Now;
                    param.ServiceId.Add(j);
                    list.AddRange(DBRepository.Convert(DBRepository.GetMonthData(param.ToDate, j)));
                    list = new DBRepository().FilterParams(list, param, false);
                    ExcelWriter.Write202(new Report210() { Datas = list }, new DBRepository().GetLastRates(), ServiceName[j - 1] + DateTime.Now.ToShortDateString(), false);
                }
            }
        }

        private void ArrearEditDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double d;
            if(e.ColumnIndex == 5)
            {
                if (!double.TryParse(e.FormattedValue.ToString().Replace('.',','), out d))
                    ArrearEditDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#ff899e");
                else ArrearEditDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
        }

        private void createExcelButton_Click(object sender, EventArgs e)
        {
            if (!DBRepository.TryConnection())
            {
                throw new DataBaseException("");
            }
            DBRepository dbrepository = new DBRepository();
            if (dbrepository.GetFiles().Count != 0)
            {
                new Forms.CreateExcel(data).ShowDialog();
            }
        }

        private void добавитьУчастокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBRepository.TryConnection())
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new AddHomesteadForm(AddHomesteadState.AddNewHomestead).Show();
        }

        private void добавитьПлательщикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBRepository.TryConnection())
            {
                MessageBox.Show("Проблемы с базой данных. Проверьте настройки строки подключения, правильно ли указано имя сервера",
                    "Проблемы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new AddHomesteadForm(AddHomesteadState.AddOnlyPayments).Show();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double d;
            if (e.ColumnIndex == 8)
            {
                if (!double.TryParse(e.FormattedValue.ToString().Replace('.', ','), out d))
                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = ColorTranslator.FromHtml("#ff899e");
                else
                {
                    Payment p = DBRepository.GetPayment(int.Parse(dataGridView1[0, e.RowIndex].Value.ToString()));
                    DBRepository.ChangeArrear(p.Id, d);
                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                }
            }
            if (e.ColumnIndex == 9)
            {
                if (!(new List<string>() { "1", "2", "3", "" }).Any(r => r.CompareTo(e.FormattedValue.ToString().Normalize()) == 0))
                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = ColorTranslator.FromHtml("#ff899e");
                else
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                    if(e.FormattedValue.ToString() != "" && dataGridView1[13, e.RowIndex].Value.ToString() != "~")
                    {
                        DBRepository db = new DBRepository();
                        int id = int.Parse(dataGridView1[13, e.RowIndex].Value.ToString());
                        MeterData md = DBRepository.GetMeterData().Where(m => m.Id == id).First();
                        int rateId = Int32.Parse(e.FormattedValue.ToString());
                        rateId = db.GetLastRates().OrderBy(r => r.Id).First().Id + rateId - 1;
                        if (md.IdRate != rateId)
                            db.ChangeMeterData((int)md.Id, rateId);
                    }
                }
            }
        }
        
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if(e.ColumnIndex == 9 && dataGridView1[13, e.RowIndex].Value.ToString() != "~")
            //{
            //    DBRepository db = new DBRepository();
            //    int id = int.Parse(dataGridView1[13, e.RowIndex].Value.ToString());
            //    MeterData md = DBRepository.GetMeterData().Where(m => m.Id == id).First();
            //    dataGridView1[e.ColumnIndex, e.RowIndex].ToolTipText = (md.NewValue - md.OldValue) + " * " + md.Rate.Value + " * " + ConfigAppManager.GetTariff() + " = " + ConfigAppManager.GetTariff() * md.Rate.Value;
            //}
        }
    }
}

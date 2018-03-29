﻿namespace EMS.Desktop
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuFail = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripDownloadNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CLearFileStatesMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRepos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReposForERIP = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReposForExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.MainJournal = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.ArrearGB = new System.Windows.Forms.GroupBox();
            this.ArrearConfirmB = new System.Windows.Forms.Button();
            this.ArrearEditDGV = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomesteadNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Introduced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LabelProgrBar = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.ColorPanel.SuspendLayout();
            this.ArrearGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArrearEditDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFail,
            this.MenuRepos,
            this.MenuDocuments,
            this.MainJournal,
            this.MenuSettings,
            this.MenuAboutProgram});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(1019, 28);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // MenuFail
            // 
            this.MenuFail.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripDownloadNewFile,
            this.CLearFileStatesMI});
            this.MenuFail.Name = "MenuFail";
            this.MenuFail.Size = new System.Drawing.Size(57, 24);
            this.MenuFail.Text = "Файл";
            // 
            // ToolStripDownloadNewFile
            // 
            this.ToolStripDownloadNewFile.Name = "ToolStripDownloadNewFile";
            this.ToolStripDownloadNewFile.Size = new System.Drawing.Size(282, 26);
            this.ToolStripDownloadNewFile.Text = "Загрузка новых файлов";
            this.ToolStripDownloadNewFile.Click += new System.EventHandler(this.ToolStripDownloadNewFile_Click);
            // 
            // CLearFileStatesMI
            // 
            this.CLearFileStatesMI.Enabled = false;
            this.CLearFileStatesMI.Name = "CLearFileStatesMI";
            this.CLearFileStatesMI.Size = new System.Drawing.Size(282, 26);
            this.CLearFileStatesMI.Text = "Сбросить состояния файлов";
            this.CLearFileStatesMI.Click += new System.EventHandler(this.CLearFileStatesMI_Click);
            // 
            // MenuRepos
            // 
            this.MenuRepos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReposForERIP,
            this.MenuReposForExcel});
            this.MenuRepos.Name = "MenuRepos";
            this.MenuRepos.Size = new System.Drawing.Size(71, 24);
            this.MenuRepos.Text = "Отчёты";
            // 
            // MenuReposForERIP
            // 
            this.MenuReposForERIP.Name = "MenuReposForERIP";
            this.MenuReposForERIP.Size = new System.Drawing.Size(161, 26);
            this.MenuReposForERIP.Text = "Отчёт .202";
            this.MenuReposForERIP.Click += new System.EventHandler(this.MenuReposForERIP_Click);
            // 
            // MenuReposForExcel
            // 
            this.MenuReposForExcel.Enabled = false;
            this.MenuReposForExcel.Name = "MenuReposForExcel";
            this.MenuReposForExcel.Size = new System.Drawing.Size(161, 26);
            this.MenuReposForExcel.Text = "Отчёт Excel";
            this.MenuReposForExcel.Click += new System.EventHandler(this.MenuReposForExcel_Click);
            // 
            // MenuDocuments
            // 
            this.MenuDocuments.Name = "MenuDocuments";
            this.MenuDocuments.Size = new System.Drawing.Size(148, 24);
            this.MenuDocuments.Text = "Просмотр данных";
            this.MenuDocuments.Click += new System.EventHandler(this.MenuDocuments_Click);
            // 
            // MainJournal
            // 
            this.MainJournal.Name = "MainJournal";
            this.MainJournal.Size = new System.Drawing.Size(75, 24);
            this.MainJournal.Text = "Журнал";
            this.MainJournal.Click += new System.EventHandler(this.MainJournal_Click);
            // 
            // MenuSettings
            // 
            this.MenuSettings.Name = "MenuSettings";
            this.MenuSettings.Size = new System.Drawing.Size(96, 24);
            this.MenuSettings.Text = "Настройки";
            this.MenuSettings.Click += new System.EventHandler(this.MenuSettings_Click);
            // 
            // MenuAboutProgram
            // 
            this.MenuAboutProgram.Name = "MenuAboutProgram";
            this.MenuAboutProgram.Size = new System.Drawing.Size(116, 24);
            this.MenuAboutProgram.Text = "О программе";
            this.MenuAboutProgram.Click += new System.EventHandler(this.MenuAboutProgram_Click);
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainProgressBar.Location = new System.Drawing.Point(0, 511);
            this.MainProgressBar.Margin = new System.Windows.Forms.Padding(4);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(1019, 28);
            this.MainProgressBar.TabIndex = 1;
            // 
            // ColorPanel
            // 
            this.ColorPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ColorPanel.Controls.Add(this.ArrearGB);
            this.ColorPanel.Controls.Add(this.LoadingLabel);
            this.ColorPanel.Controls.Add(this.dataGridView1);
            this.ColorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorPanel.Location = new System.Drawing.Point(0, 28);
            this.ColorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(1019, 483);
            this.ColorPanel.TabIndex = 2;
            // 
            // ArrearGB
            // 
            this.ArrearGB.Controls.Add(this.ArrearConfirmB);
            this.ArrearGB.Controls.Add(this.ArrearEditDGV);
            this.ArrearGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArrearGB.Location = new System.Drawing.Point(0, 0);
            this.ArrearGB.Name = "ArrearGB";
            this.ArrearGB.Size = new System.Drawing.Size(1019, 483);
            this.ArrearGB.TabIndex = 3;
            this.ArrearGB.TabStop = false;
            this.ArrearGB.Text = "Отредактируйте задолженности";
            this.ArrearGB.Visible = false;
            // 
            // ArrearConfirmB
            // 
            this.ArrearConfirmB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ArrearConfirmB.Location = new System.Drawing.Point(3, 447);
            this.ArrearConfirmB.Name = "ArrearConfirmB";
            this.ArrearConfirmB.Size = new System.Drawing.Size(1013, 33);
            this.ArrearConfirmB.TabIndex = 3;
            this.ArrearConfirmB.Text = "Сохранить";
            this.ArrearConfirmB.UseVisualStyleBackColor = true;
            this.ArrearConfirmB.Click += new System.EventHandler(this.ArrearConfirmB_Click);
            // 
            // ArrearEditDGV
            // 
            this.ArrearEditDGV.AllowUserToAddRows = false;
            this.ArrearEditDGV.AllowUserToDeleteRows = false;
            this.ArrearEditDGV.AllowUserToResizeRows = false;
            this.ArrearEditDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArrearEditDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ServiceId,
            this.HomesteadNumber,
            this.OwnerName,
            this.Introduced,
            this.Arrear,
            this.Difference,
            this.Value});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ArrearEditDGV.DefaultCellStyle = dataGridViewCellStyle8;
            this.ArrearEditDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArrearEditDGV.Location = new System.Drawing.Point(3, 18);
            this.ArrearEditDGV.Name = "ArrearEditDGV";
            this.ArrearEditDGV.RowHeadersVisible = false;
            this.ArrearEditDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.ArrearEditDGV.RowTemplate.Height = 24;
            this.ArrearEditDGV.Size = new System.Drawing.Size(1013, 462);
            this.ArrearEditDGV.TabIndex = 2;
            this.ArrearEditDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ArrearEditDGV_CellValidating);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // ServiceId
            // 
            this.ServiceId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.ServiceId.DefaultCellStyle = dataGridViewCellStyle1;
            this.ServiceId.HeaderText = "Услуга";
            this.ServiceId.Name = "ServiceId";
            this.ServiceId.ReadOnly = true;
            this.ServiceId.Width = 81;
            // 
            // HomesteadNumber
            // 
            this.HomesteadNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.HomesteadNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.HomesteadNumber.HeaderText = "Номер участка";
            this.HomesteadNumber.Name = "HomesteadNumber";
            this.HomesteadNumber.ReadOnly = true;
            this.HomesteadNumber.Width = 125;
            // 
            // OwnerName
            // 
            this.OwnerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.OwnerName.DefaultCellStyle = dataGridViewCellStyle3;
            this.OwnerName.HeaderText = "Владелец";
            this.OwnerName.Name = "OwnerName";
            this.OwnerName.ReadOnly = true;
            this.OwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OwnerName.Width = 79;
            // 
            // Introduced
            // 
            this.Introduced.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.Introduced.DefaultCellStyle = dataGridViewCellStyle4;
            this.Introduced.HeaderText = "Внесено";
            this.Introduced.Name = "Introduced";
            this.Introduced.ReadOnly = true;
            this.Introduced.Width = 93;
            // 
            // Arrear
            // 
            this.Arrear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Arrear.DefaultCellStyle = dataGridViewCellStyle5;
            this.Arrear.HeaderText = "Задолженность";
            this.Arrear.Name = "Arrear";
            // 
            // Difference
            // 
            this.Difference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            this.Difference.DefaultCellStyle = dataGridViewCellStyle6;
            this.Difference.HeaderText = "Количество кВ/ч";
            this.Difference.Name = "Difference";
            this.Difference.ReadOnly = true;
            this.Difference.Width = 135;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            this.Value.DefaultCellStyle = dataGridViewCellStyle7;
            this.Value.HeaderText = "Последнее значение счетчика";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 151;
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadingLabel.Location = new System.Drawing.Point(463, 218);
            this.LoadingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(106, 24);
            this.LoadingLabel.TabIndex = 1;
            this.LoadingLabel.Text = "Загрузка...";
            this.LoadingLabel.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1019, 483);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            // 
            // LabelProgrBar
            // 
            this.LabelProgrBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelProgrBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LabelProgrBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelProgrBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelProgrBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LabelProgrBar.Location = new System.Drawing.Point(0, 511);
            this.LabelProgrBar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelProgrBar.Name = "LabelProgrBar";
            this.LabelProgrBar.Size = new System.Drawing.Size(1019, 28);
            this.LabelProgrBar.TabIndex = 0;
            this.LabelProgrBar.Text = "Файлы загружены";
            this.LabelProgrBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelProgrBar.Visible = false;
            // 
            // AmountLabel
            // 
            this.AmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountLabel.Location = new System.Drawing.Point(786, 7);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(183, 17);
            this.AmountLabel.TabIndex = 3;
            this.AmountLabel.Text = "Сумма на р/с : 100 BYN";
            // 
            // createExcelButton
            // 
            this.createExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createExcelButton.Location = new System.Drawing.Point(679, 415);
            this.createExcelButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.createExcelButton.Name = "createExcelButton";
            this.createExcelButton.Size = new System.Drawing.Size(85, 23);
            this.createExcelButton.TabIndex = 2;
            this.createExcelButton.Text = "Создать Excel";
            this.createExcelButton.UseVisualStyleBackColor = true;
            this.createExcelButton.Visible = false;
            this.createExcelButton.Click += new System.EventHandler(this.createExcelButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 539);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.LabelProgrBar);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.MainProgressBar);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1034, 576);
            this.Name = "MainForm";
            this.Text = "E.M.S.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing_MainForm);
            this.Load += new System.EventHandler(this.Load_MainForm);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ColorPanel.ResumeLayout(false);
            this.ColorPanel.PerformLayout();
            this.ArrearGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArrearEditDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuFail;
        private System.Windows.Forms.ToolStripMenuItem MenuRepos;
        private System.Windows.Forms.ToolStripMenuItem MenuDocuments;
        private System.Windows.Forms.ToolStripMenuItem MainJournal;
        private System.Windows.Forms.ToolStripMenuItem MenuSettings;
        private System.Windows.Forms.ToolStripMenuItem MenuAboutProgram;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.ToolStripMenuItem MenuReposForERIP;
        private System.Windows.Forms.ToolStripMenuItem MenuReposForExcel;
        //private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
       // private System.Windows.Forms.ToolStripMenuItem SavePathTSMI;
        public System.Windows.Forms.Label LabelProgrBar;
        public System.Windows.Forms.ProgressBar MainProgressBar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label LoadingLabel;
        private System.Windows.Forms.ToolStripMenuItem ToolStripDownloadNewFile;
        private System.Windows.Forms.ToolStripMenuItem CLearFileStatesMI;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.DataGridView ArrearEditDGV;
        private System.Windows.Forms.GroupBox ArrearGB;
        private System.Windows.Forms.Button ArrearConfirmB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomesteadNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Introduced;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}


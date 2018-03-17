namespace EMS.Desktop
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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuFail = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRepos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReposForERIP = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReposForExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.MainJournal = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePathTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.LabelProgrBar = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Menu.SuspendLayout();
            this.ColorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFail,
            this.MenuRepos,
            this.MenuDocuments,
            this.MainJournal,
            this.MenuSettings,
            this.MenuAboutProgram});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(643, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // MenuFail
            // 
            this.MenuFail.Name = "MenuFail";
            this.MenuFail.Size = new System.Drawing.Size(48, 20);
            this.MenuFail.Text = "Файл";
            // 
            // MenuRepos
            // 
            this.MenuRepos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReposForERIP,
            this.MenuReposForExcel});
            this.MenuRepos.Name = "MenuRepos";
            this.MenuRepos.Size = new System.Drawing.Size(60, 20);
            this.MenuRepos.Text = "Отчёты";
            // 
            // MenuReposForERIP
            // 
            this.MenuReposForERIP.Name = "MenuReposForERIP";
            this.MenuReposForERIP.Size = new System.Drawing.Size(135, 22);
            this.MenuReposForERIP.Text = "Отчёт ERIP";
            this.MenuReposForERIP.Click += new System.EventHandler(this.MenuReposForERIP_Click);
            // 
            // MenuReposForExcel
            // 
            this.MenuReposForExcel.Name = "MenuReposForExcel";
            this.MenuReposForExcel.Size = new System.Drawing.Size(135, 22);
            this.MenuReposForExcel.Text = "Отчёт Excel";
            this.MenuReposForExcel.Click += new System.EventHandler(this.MenuReposForExcel_Click);
            // 
            // MenuDocuments
            // 
            this.MenuDocuments.Name = "MenuDocuments";
            this.MenuDocuments.Size = new System.Drawing.Size(82, 20);
            this.MenuDocuments.Text = "Документы";
            // 
            // MainJournal
            // 
            this.MainJournal.Name = "MainJournal";
            this.MainJournal.Size = new System.Drawing.Size(63, 20);
            this.MainJournal.Text = "Журнал";
            this.MainJournal.Click += new System.EventHandler(this.MainJournal_Click);
            // 
            // MenuSettings
            // 
            this.MenuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.SavePathTSMI});
            this.MenuSettings.Name = "MenuSettings";
            this.MenuSettings.Size = new System.Drawing.Size(79, 20);
            this.MenuSettings.Text = "Настройки";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.SettingsToolStripMenuItem.Text = "Параметры";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // SavePathTSMI
            // 
            this.SavePathTSMI.Name = "SavePathTSMI";
            this.SavePathTSMI.Size = new System.Drawing.Size(167, 22);
            this.SavePathTSMI.Text = "Путь сохранения";
            this.SavePathTSMI.Click += new System.EventHandler(this.SavePathTSMI_Click);
            // 
            // MenuAboutProgram
            // 
            this.MenuAboutProgram.Name = "MenuAboutProgram";
            this.MenuAboutProgram.Size = new System.Drawing.Size(94, 20);
            this.MenuAboutProgram.Text = "О программе";
            this.MenuAboutProgram.Click += new System.EventHandler(this.MenuAboutProgram_Click);
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainProgressBar.Location = new System.Drawing.Point(0, 380);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(643, 23);
            this.MainProgressBar.TabIndex = 1;
            // 
            // ColorPanel
            // 
            this.ColorPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ColorPanel.Controls.Add(this.dataGridView1);
            this.ColorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorPanel.Location = new System.Drawing.Point(0, 24);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(643, 356);
            this.ColorPanel.TabIndex = 2;
            // 
            // LabelProgrBar
            // 
            this.LabelProgrBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LabelProgrBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelProgrBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelProgrBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LabelProgrBar.Location = new System.Drawing.Point(0, 380);
            this.LabelProgrBar.Name = "LabelProgrBar";
            this.LabelProgrBar.Size = new System.Drawing.Size(643, 23);
            this.LabelProgrBar.TabIndex = 0;
            this.LabelProgrBar.Text = "Файлы загружены";
            this.LabelProgrBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelProgrBar.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(643, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 403);
            this.Controls.Add(this.LabelProgrBar);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.MainProgressBar);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "MainForm";
            this.Text = "E.M.S.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing_MainForm);
            this.Load += new System.EventHandler(this.Load_MainForm);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ColorPanel.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SavePathTSMI;
        public System.Windows.Forms.Label LabelProgrBar;
        public System.Windows.Forms.ProgressBar MainProgressBar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


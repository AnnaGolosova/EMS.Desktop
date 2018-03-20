namespace EMS.Desktop
{
    partial class FormReposForERIP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReposForERIP));
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.RateEdirB = new System.Windows.Forms.Button();
            this.RateGrB = new System.Windows.Forms.GroupBox();
            this.RateDGV = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Service4RB = new System.Windows.Forms.RadioButton();
            this.Service1RB = new System.Windows.Forms.RadioButton();
            this.Service3RB = new System.Windows.Forms.RadioButton();
            this.Service2RB = new System.Windows.Forms.RadioButton();
            this.ToLabel = new System.Windows.Forms.Label();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.QuarterTimePicker = new System.Windows.Forms.DateTimePicker();
            this.MonthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DuringTimeRB = new System.Windows.Forms.RadioButton();
            this.QuarterRB = new System.Windows.Forms.RadioButton();
            this.MonthRB = new System.Windows.Forms.RadioButton();
            this.CreateExcelCB = new System.Windows.Forms.CheckBox();
            this.CreateReportButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.GroupBox.SuspendLayout();
            this.RateGrB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RateDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.RateEdirB);
            this.GroupBox.Controls.Add(this.RateGrB);
            this.GroupBox.Controls.Add(this.groupBox1);
            this.GroupBox.Controls.Add(this.ToLabel);
            this.GroupBox.Controls.Add(this.FromLabel);
            this.GroupBox.Controls.Add(this.ToDatePicker);
            this.GroupBox.Controls.Add(this.FromDatePicker);
            this.GroupBox.Controls.Add(this.QuarterTimePicker);
            this.GroupBox.Controls.Add(this.MonthTimePicker);
            this.GroupBox.Controls.Add(this.DuringTimeRB);
            this.GroupBox.Controls.Add(this.QuarterRB);
            this.GroupBox.Controls.Add(this.MonthRB);
            this.GroupBox.Location = new System.Drawing.Point(10, 28);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(549, 348);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Выбор времени";
            // 
            // RateEdirB
            // 
            this.RateEdirB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RateEdirB.Location = new System.Drawing.Point(5, 317);
            this.RateEdirB.Margin = new System.Windows.Forms.Padding(2);
            this.RateEdirB.Name = "RateEdirB";
            this.RateEdirB.Size = new System.Drawing.Size(124, 25);
            this.RateEdirB.TabIndex = 13;
            this.RateEdirB.Text = "Назначить тарифы";
            this.RateEdirB.UseVisualStyleBackColor = true;
            this.RateEdirB.Click += new System.EventHandler(this.RateEdirB_Click);
            // 
            // RateGrB
            // 
            this.RateGrB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RateGrB.Controls.Add(this.RateDGV);
            this.RateGrB.Location = new System.Drawing.Point(6, 217);
            this.RateGrB.Margin = new System.Windows.Forms.Padding(2);
            this.RateGrB.Name = "RateGrB";
            this.RateGrB.Padding = new System.Windows.Forms.Padding(2);
            this.RateGrB.Size = new System.Drawing.Size(516, 95);
            this.RateGrB.TabIndex = 12;
            this.RateGrB.TabStop = false;
            this.RateGrB.Text = "Редактирование тарифов";
            // 
            // RateDGV
            // 
            this.RateDGV.AllowUserToAddRows = false;
            this.RateDGV.AllowUserToDeleteRows = false;
            this.RateDGV.AllowUserToResizeRows = false;
            this.RateDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RateDGV.ColumnHeadersVisible = false;
            this.RateDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Title,
            this.Value});
            this.RateDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RateDGV.Location = new System.Drawing.Point(2, 15);
            this.RateDGV.Margin = new System.Windows.Forms.Padding(2);
            this.RateDGV.Name = "RateDGV";
            this.RateDGV.RowHeadersVisible = false;
            this.RateDGV.RowTemplate.Height = 24;
            this.RateDGV.Size = new System.Drawing.Size(512, 78);
            this.RateDGV.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 5;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "";
            this.Value.Name = "Value";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Service4RB);
            this.groupBox1.Controls.Add(this.Service1RB);
            this.groupBox1.Controls.Add(this.Service3RB);
            this.groupBox1.Controls.Add(this.Service2RB);
            this.groupBox1.Location = new System.Drawing.Point(6, 125);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(529, 88);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор услуги";
            // 
            // Service4RB
            // 
            this.Service4RB.AutoSize = true;
            this.Service4RB.Location = new System.Drawing.Point(172, 55);
            this.Service4RB.Margin = new System.Windows.Forms.Padding(2);
            this.Service4RB.Name = "Service4RB";
            this.Service4RB.Size = new System.Drawing.Size(149, 17);
            this.Service4RB.TabIndex = 3;
            this.Service4RB.TabStop = true;
            this.Service4RB.Text = "Налог на недвижимость";
            this.Service4RB.UseVisualStyleBackColor = true;
            this.Service4RB.Click += new System.EventHandler(this.Service4RB_Click);
            // 
            // Service1RB
            // 
            this.Service1RB.AutoSize = true;
            this.Service1RB.Location = new System.Drawing.Point(172, 25);
            this.Service1RB.Margin = new System.Windows.Forms.Padding(2);
            this.Service1RB.Name = "Service1RB";
            this.Service1RB.Size = new System.Drawing.Size(64, 17);
            this.Service1RB.TabIndex = 2;
            this.Service1RB.TabStop = true;
            this.Service1RB.Text = "Взносы";
            this.Service1RB.UseVisualStyleBackColor = true;
            this.Service1RB.Click += new System.EventHandler(this.Service1RB_Click);
            // 
            // Service3RB
            // 
            this.Service3RB.AutoSize = true;
            this.Service3RB.Location = new System.Drawing.Point(10, 55);
            this.Service3RB.Margin = new System.Windows.Forms.Padding(2);
            this.Service3RB.Name = "Service3RB";
            this.Service3RB.Size = new System.Drawing.Size(108, 17);
            this.Service3RB.TabIndex = 1;
            this.Service3RB.TabStop = true;
            this.Service3RB.Text = "Налог на землю";
            this.Service3RB.UseVisualStyleBackColor = true;
            this.Service3RB.Click += new System.EventHandler(this.Service3RB_Click);
            // 
            // Service2RB
            // 
            this.Service2RB.AutoSize = true;
            this.Service2RB.Location = new System.Drawing.Point(10, 25);
            this.Service2RB.Margin = new System.Windows.Forms.Padding(2);
            this.Service2RB.Name = "Service2RB";
            this.Service2RB.Size = new System.Drawing.Size(123, 17);
            this.Service2RB.TabIndex = 0;
            this.Service2RB.TabStop = true;
            this.Service2RB.Text = "Электроснабжение";
            this.Service2RB.UseVisualStyleBackColor = true;
            this.Service2RB.Click += new System.EventHandler(this.Service2RB_Click);
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(341, 104);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(21, 13);
            this.ToLabel.TabIndex = 8;
            this.ToLabel.Text = "По";
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(143, 106);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(14, 13);
            this.FromLabel.TabIndex = 7;
            this.FromLabel.Text = "C";
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Enabled = false;
            this.ToDatePicker.Location = new System.Drawing.Point(367, 102);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(169, 20);
            this.ToDatePicker.TabIndex = 6;
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Enabled = false;
            this.FromDatePicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FromDatePicker.Location = new System.Drawing.Point(162, 102);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(169, 20);
            this.FromDatePicker.TabIndex = 5;
            // 
            // QuarterTimePicker
            // 
            this.QuarterTimePicker.Enabled = false;
            this.QuarterTimePicker.Location = new System.Drawing.Point(162, 67);
            this.QuarterTimePicker.Name = "QuarterTimePicker";
            this.QuarterTimePicker.Size = new System.Drawing.Size(169, 20);
            this.QuarterTimePicker.TabIndex = 4;
            // 
            // MonthTimePicker
            // 
            this.MonthTimePicker.Checked = false;
            this.MonthTimePicker.CustomFormat = "MMMM yyyy г.";
            this.MonthTimePicker.Enabled = false;
            this.MonthTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MonthTimePicker.Location = new System.Drawing.Point(162, 28);
            this.MonthTimePicker.Name = "MonthTimePicker";
            this.MonthTimePicker.ShowUpDown = true;
            this.MonthTimePicker.Size = new System.Drawing.Size(169, 20);
            this.MonthTimePicker.TabIndex = 3;
            // 
            // DuringTimeRB
            // 
            this.DuringTimeRB.AutoSize = true;
            this.DuringTimeRB.Location = new System.Drawing.Point(6, 102);
            this.DuringTimeRB.Name = "DuringTimeRB";
            this.DuringTimeRB.Size = new System.Drawing.Size(104, 17);
            this.DuringTimeRB.TabIndex = 2;
            this.DuringTimeRB.Text = "Отчёт за время";
            this.DuringTimeRB.UseVisualStyleBackColor = true;
            this.DuringTimeRB.CheckedChanged += new System.EventHandler(this.DuringTimeRB_CheckedChanged);
            // 
            // QuarterRB
            // 
            this.QuarterRB.AutoSize = true;
            this.QuarterRB.Enabled = false;
            this.QuarterRB.Location = new System.Drawing.Point(6, 67);
            this.QuarterRB.Name = "QuarterRB";
            this.QuarterRB.Size = new System.Drawing.Size(113, 17);
            this.QuarterRB.TabIndex = 1;
            this.QuarterRB.Text = "Отчёт за квартал";
            this.QuarterRB.UseVisualStyleBackColor = true;
            this.QuarterRB.CheckedChanged += new System.EventHandler(this.QuarterRB_CheckedChanged);
            // 
            // MonthRB
            // 
            this.MonthRB.AutoSize = true;
            this.MonthRB.Location = new System.Drawing.Point(6, 31);
            this.MonthRB.Name = "MonthRB";
            this.MonthRB.Size = new System.Drawing.Size(104, 17);
            this.MonthRB.TabIndex = 0;
            this.MonthRB.Text = "Отчёт за месяц";
            this.MonthRB.UseVisualStyleBackColor = true;
            this.MonthRB.CheckedChanged += new System.EventHandler(this.MonthRB_CheckedChanged);
            // 
            // CreateExcelCB
            // 
            this.CreateExcelCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateExcelCB.AutoSize = true;
            this.CreateExcelCB.Location = new System.Drawing.Point(10, 382);
            this.CreateExcelCB.Margin = new System.Windows.Forms.Padding(2);
            this.CreateExcelCB.Name = "CreateExcelCB";
            this.CreateExcelCB.Size = new System.Drawing.Size(168, 17);
            this.CreateExcelCB.TabIndex = 11;
            this.CreateExcelCB.Text = "Создать такой же .xls отчет ";
            this.CreateExcelCB.UseVisualStyleBackColor = true;
            // 
            // CreateReportButton
            // 
            this.CreateReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateReportButton.Location = new System.Drawing.Point(147, 405);
            this.CreateReportButton.Name = "CreateReportButton";
            this.CreateReportButton.Size = new System.Drawing.Size(124, 25);
            this.CreateReportButton.TabIndex = 1;
            this.CreateReportButton.Text = "Сформировать отчёт";
            this.CreateReportButton.UseVisualStyleBackColor = true;
            this.CreateReportButton.Click += new System.EventHandler(this.CreateReportButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.Location = new System.Drawing.Point(10, 405);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(124, 25);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Имя файла";
            // 
            // FileNameTB
            // 
            this.FileNameTB.Location = new System.Drawing.Point(74, 5);
            this.FileNameTB.Margin = new System.Windows.Forms.Padding(2);
            this.FileNameTB.Name = "FileNameTB";
            this.FileNameTB.Size = new System.Drawing.Size(162, 20);
            this.FileNameTB.TabIndex = 13;
            // 
            // FormReposForERIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(571, 440);
            this.Controls.Add(this.FileNameTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateExcelCB);
            this.Controls.Add(this.CreateReportButton);
            this.Controls.Add(this.GroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(754, 820);
            this.MinimumSize = new System.Drawing.Size(18, 45);
            this.Name = "FormReposForERIP";
            this.Text = "Отчёт ERIP";
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.RateGrB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RateDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.RadioButton MonthRB;
        private System.Windows.Forms.RadioButton DuringTimeRB;
        private System.Windows.Forms.RadioButton QuarterRB;
        private System.Windows.Forms.DateTimePicker ToDatePicker;
        private System.Windows.Forms.DateTimePicker FromDatePicker;
        private System.Windows.Forms.DateTimePicker QuarterTimePicker;
        private System.Windows.Forms.DateTimePicker MonthTimePicker;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Button CreateReportButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Service4RB;
        private System.Windows.Forms.RadioButton Service1RB;
        private System.Windows.Forms.RadioButton Service3RB;
        private System.Windows.Forms.RadioButton Service2RB;
        private System.Windows.Forms.CheckBox CreateExcelCB;
        private System.Windows.Forms.GroupBox RateGrB;
        private System.Windows.Forms.DataGridView RateDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button RateEdirB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileNameTB;
    }
}
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
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tariff = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.MonthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DuringTimeRB = new System.Windows.Forms.RadioButton();
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
            this.GroupBox.Controls.Add(this.MonthTimePicker);
            this.GroupBox.Controls.Add(this.DuringTimeRB);
            this.GroupBox.Controls.Add(this.MonthRB);
            this.GroupBox.Location = new System.Drawing.Point(13, 34);
            this.GroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox.Size = new System.Drawing.Size(748, 371);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Выбор времени";
            // 
            // RateEdirB
            // 
            this.RateEdirB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RateEdirB.Location = new System.Drawing.Point(7, 333);
            this.RateEdirB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RateEdirB.Name = "RateEdirB";
            this.RateEdirB.Size = new System.Drawing.Size(165, 31);
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
            this.RateGrB.Location = new System.Drawing.Point(8, 210);
            this.RateGrB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RateGrB.Name = "RateGrB";
            this.RateGrB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RateGrB.Size = new System.Drawing.Size(704, 117);
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
            this.Percent,
            this.Tariff,
            this.Value});
            this.RateDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RateDGV.Location = new System.Drawing.Point(3, 17);
            this.RateDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RateDGV.Name = "RateDGV";
            this.RateDGV.RowHeadersVisible = false;
            this.RateDGV.RowTemplate.Height = 24;
            this.RateDGV.Size = new System.Drawing.Size(698, 98);
            this.RateDGV.TabIndex = 0;
            this.RateDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.RateDGV_CellValidating);
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
            // Percent
            // 
            this.Percent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Percent.HeaderText = "";
            this.Percent.Name = "Percent";
            this.Percent.Width = 5;
            // 
            // Tariff
            // 
            this.Tariff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tariff.HeaderText = "";
            this.Tariff.Name = "Tariff";
            this.Tariff.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Value.HeaderText = "";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Service4RB);
            this.groupBox1.Controls.Add(this.Service1RB);
            this.groupBox1.Controls.Add(this.Service3RB);
            this.groupBox1.Controls.Add(this.Service2RB);
            this.groupBox1.Location = new System.Drawing.Point(8, 92);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(705, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор услуги";
            // 
            // Service4RB
            // 
            this.Service4RB.AutoSize = true;
            this.Service4RB.Location = new System.Drawing.Point(229, 68);
            this.Service4RB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Service4RB.Name = "Service4RB";
            this.Service4RB.Size = new System.Drawing.Size(186, 21);
            this.Service4RB.TabIndex = 3;
            this.Service4RB.TabStop = true;
            this.Service4RB.Text = "Налог на недвижимость";
            this.Service4RB.UseVisualStyleBackColor = true;
            this.Service4RB.Click += new System.EventHandler(this.Service4RB_Click);
            // 
            // Service1RB
            // 
            this.Service1RB.AutoSize = true;
            this.Service1RB.Location = new System.Drawing.Point(229, 31);
            this.Service1RB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Service1RB.Name = "Service1RB";
            this.Service1RB.Size = new System.Drawing.Size(78, 21);
            this.Service1RB.TabIndex = 2;
            this.Service1RB.TabStop = true;
            this.Service1RB.Text = "Взносы";
            this.Service1RB.UseVisualStyleBackColor = true;
            this.Service1RB.Click += new System.EventHandler(this.Service1RB_Click);
            // 
            // Service3RB
            // 
            this.Service3RB.AutoSize = true;
            this.Service3RB.Location = new System.Drawing.Point(13, 68);
            this.Service3RB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Service3RB.Name = "Service3RB";
            this.Service3RB.Size = new System.Drawing.Size(134, 21);
            this.Service3RB.TabIndex = 1;
            this.Service3RB.TabStop = true;
            this.Service3RB.Text = "Налог на землю";
            this.Service3RB.UseVisualStyleBackColor = true;
            this.Service3RB.Click += new System.EventHandler(this.Service3RB_Click);
            // 
            // Service2RB
            // 
            this.Service2RB.AutoSize = true;
            this.Service2RB.Location = new System.Drawing.Point(13, 31);
            this.Service2RB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Service2RB.Name = "Service2RB";
            this.Service2RB.Size = new System.Drawing.Size(156, 21);
            this.Service2RB.TabIndex = 0;
            this.Service2RB.TabStop = true;
            this.Service2RB.Text = "Электроснабжение";
            this.Service2RB.UseVisualStyleBackColor = true;
            this.Service2RB.Click += new System.EventHandler(this.Service2RB_Click);
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(455, 66);
            this.ToLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(26, 17);
            this.ToLabel.TabIndex = 8;
            this.ToLabel.Text = "По";
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(191, 68);
            this.FromLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(17, 17);
            this.FromLabel.TabIndex = 7;
            this.FromLabel.Text = "C";
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Enabled = false;
            this.ToDatePicker.Location = new System.Drawing.Point(489, 64);
            this.ToDatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(224, 22);
            this.ToDatePicker.TabIndex = 6;
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Enabled = false;
            this.FromDatePicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FromDatePicker.Location = new System.Drawing.Point(216, 64);
            this.FromDatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(224, 22);
            this.FromDatePicker.TabIndex = 5;
            // 
            // MonthTimePicker
            // 
            this.MonthTimePicker.Checked = false;
            this.MonthTimePicker.CustomFormat = "MMMM yyyy г.";
            this.MonthTimePicker.Enabled = false;
            this.MonthTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MonthTimePicker.Location = new System.Drawing.Point(216, 34);
            this.MonthTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.MonthTimePicker.Name = "MonthTimePicker";
            this.MonthTimePicker.ShowUpDown = true;
            this.MonthTimePicker.Size = new System.Drawing.Size(224, 22);
            this.MonthTimePicker.TabIndex = 3;
            // 
            // DuringTimeRB
            // 
            this.DuringTimeRB.AutoSize = true;
            this.DuringTimeRB.Location = new System.Drawing.Point(8, 64);
            this.DuringTimeRB.Margin = new System.Windows.Forms.Padding(4);
            this.DuringTimeRB.Name = "DuringTimeRB";
            this.DuringTimeRB.Size = new System.Drawing.Size(133, 21);
            this.DuringTimeRB.TabIndex = 2;
            this.DuringTimeRB.Text = "Отчёт за время";
            this.DuringTimeRB.UseVisualStyleBackColor = true;
            this.DuringTimeRB.CheckedChanged += new System.EventHandler(this.DuringTimeRB_CheckedChanged);
            // 
            // MonthRB
            // 
            this.MonthRB.AutoSize = true;
            this.MonthRB.Location = new System.Drawing.Point(8, 38);
            this.MonthRB.Margin = new System.Windows.Forms.Padding(4);
            this.MonthRB.Name = "MonthRB";
            this.MonthRB.Size = new System.Drawing.Size(133, 21);
            this.MonthRB.TabIndex = 0;
            this.MonthRB.Text = "Отчёт за месяц";
            this.MonthRB.UseVisualStyleBackColor = true;
            this.MonthRB.CheckedChanged += new System.EventHandler(this.MonthRB_CheckedChanged);
            // 
            // CreateExcelCB
            // 
            this.CreateExcelCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateExcelCB.AutoSize = true;
            this.CreateExcelCB.Location = new System.Drawing.Point(13, 413);
            this.CreateExcelCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateExcelCB.Name = "CreateExcelCB";
            this.CreateExcelCB.Size = new System.Drawing.Size(217, 21);
            this.CreateExcelCB.TabIndex = 11;
            this.CreateExcelCB.Text = "Создать такой же .xls отчет ";
            this.CreateExcelCB.UseVisualStyleBackColor = true;
            // 
            // CreateReportButton
            // 
            this.CreateReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateReportButton.Location = new System.Drawing.Point(196, 441);
            this.CreateReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.CreateReportButton.Name = "CreateReportButton";
            this.CreateReportButton.Size = new System.Drawing.Size(165, 31);
            this.CreateReportButton.TabIndex = 1;
            this.CreateReportButton.Text = "Сформировать отчёт";
            this.CreateReportButton.UseVisualStyleBackColor = true;
            this.CreateReportButton.Click += new System.EventHandler(this.CreateReportButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.Location = new System.Drawing.Point(13, 441);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(165, 31);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Имя файла";
            // 
            // FileNameTB
            // 
            this.FileNameTB.Location = new System.Drawing.Point(99, 6);
            this.FileNameTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FileNameTB.Name = "FileNameTB";
            this.FileNameTB.Size = new System.Drawing.Size(215, 22);
            this.FileNameTB.TabIndex = 13;
            // 
            // FormReposForERIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(777, 485);
            this.Controls.Add(this.FileNameTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateExcelCB);
            this.Controls.Add(this.CreateReportButton);
            this.Controls.Add(this.GroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(999, 998);
            this.MinimumSize = new System.Drawing.Size(18, 47);
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
        private System.Windows.Forms.DateTimePicker ToDatePicker;
        private System.Windows.Forms.DateTimePicker FromDatePicker;
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
        private System.Windows.Forms.Button RateEdirB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tariff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}
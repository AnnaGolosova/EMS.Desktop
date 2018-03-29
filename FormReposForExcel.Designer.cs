namespace EMS.Desktop
{
    partial class FormReposForExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReposForExcel));
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.ToLabel = new System.Windows.Forms.Label();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.MonthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DuringTimeRB = new System.Windows.Forms.RadioButton();
            this.MonthRB = new System.Windows.Forms.RadioButton();
            this.CreateReportButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.ToLabel);
            this.GroupBox.Controls.Add(this.FromLabel);
            this.GroupBox.Controls.Add(this.ToDatePicker);
            this.GroupBox.Controls.Add(this.FromDatePicker);
            this.GroupBox.Controls.Add(this.MonthTimePicker);
            this.GroupBox.Controls.Add(this.DuringTimeRB);
            this.GroupBox.Controls.Add(this.MonthRB);
            this.GroupBox.Location = new System.Drawing.Point(16, 53);
            this.GroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox.Size = new System.Drawing.Size(454, 146);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Выбор времени";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(168, 104);
            this.ToLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(26, 17);
            this.ToLabel.TabIndex = 8;
            this.ToLabel.Text = "По";
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(177, 74);
            this.FromLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(17, 17);
            this.FromLabel.TabIndex = 7;
            this.FromLabel.Text = "С";
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Enabled = false;
            this.ToDatePicker.Location = new System.Drawing.Point(202, 101);
            this.ToDatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(224, 22);
            this.ToDatePicker.TabIndex = 6;
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Enabled = false;
            this.FromDatePicker.Location = new System.Drawing.Point(202, 71);
            this.FromDatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(224, 22);
            this.FromDatePicker.TabIndex = 5;
            // 
            // MonthTimePicker
            // 
            this.MonthTimePicker.CustomFormat = "MMMM yyyy г.";
            this.MonthTimePicker.Enabled = false;
            this.MonthTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MonthTimePicker.Location = new System.Drawing.Point(202, 32);
            this.MonthTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MonthTimePicker.Name = "MonthTimePicker";
            this.MonthTimePicker.ShowUpDown = true;
            this.MonthTimePicker.Size = new System.Drawing.Size(224, 22);
            this.MonthTimePicker.TabIndex = 3;
            // 
            // DuringTimeRB
            // 
            this.DuringTimeRB.AutoSize = true;
            this.DuringTimeRB.Location = new System.Drawing.Point(8, 74);
            this.DuringTimeRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.MonthRB.Location = new System.Drawing.Point(8, 32);
            this.MonthRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MonthRB.Name = "MonthRB";
            this.MonthRB.Size = new System.Drawing.Size(133, 21);
            this.MonthRB.TabIndex = 0;
            this.MonthRB.Text = "Отчёт за месяц";
            this.MonthRB.UseVisualStyleBackColor = true;
            this.MonthRB.CheckedChanged += new System.EventHandler(this.MonthRB_CheckedChanged);
            // 
            // CreateReportButton
            // 
            this.CreateReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateReportButton.Location = new System.Drawing.Point(321, 207);
            this.CreateReportButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CreateReportButton.Name = "CreateReportButton";
            this.CreateReportButton.Size = new System.Drawing.Size(149, 25);
            this.CreateReportButton.TabIndex = 1;
            this.CreateReportButton.Text = "Сформировать отчёт";
            this.CreateReportButton.UseVisualStyleBackColor = true;
            this.CreateReportButton.Click += new System.EventHandler(this.CreateReportButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.Location = new System.Drawing.Point(16, 207);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(149, 25);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FileNameTB
            // 
            this.FileNameTB.Location = new System.Drawing.Point(105, 11);
            this.FileNameTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FileNameTB.Name = "FileNameTB";
            this.FileNameTB.Size = new System.Drawing.Size(215, 22);
            this.FileNameTB.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Имя файла";
            // 
            // FormReposForExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 245);
            this.Controls.Add(this.FileNameTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateReportButton);
            this.Controls.Add(this.GroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "FormReposForExcel";
            this.Text = "Отчёт Excel";
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.Button CreateReportButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.RadioButton DuringTimeRB;
        private System.Windows.Forms.RadioButton MonthRB;
        private System.Windows.Forms.DateTimePicker FromDatePicker;
        private System.Windows.Forms.DateTimePicker MonthTimePicker;
        private System.Windows.Forms.DateTimePicker ToDatePicker;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.Label label1;
    }
}
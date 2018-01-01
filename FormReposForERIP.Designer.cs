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
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.MonthRB = new System.Windows.Forms.RadioButton();
            this.QuarterRB = new System.Windows.Forms.RadioButton();
            this.DuringTimeRB = new System.Windows.Forms.RadioButton();
            this.MonthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.QuarterTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.CreateReportButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.ToLabel);
            this.GroupBox.Controls.Add(this.FromLabel);
            this.GroupBox.Controls.Add(this.ToDatePicker);
            this.GroupBox.Controls.Add(this.FromDatePicker);
            this.GroupBox.Controls.Add(this.QuarterTimePicker);
            this.GroupBox.Controls.Add(this.MonthTimePicker);
            this.GroupBox.Controls.Add(this.DuringTimeRB);
            this.GroupBox.Controls.Add(this.QuarterRB);
            this.GroupBox.Controls.Add(this.MonthRB);
            this.GroupBox.Location = new System.Drawing.Point(12, 12);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(652, 188);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Выбор времени";
            // 
            // MonthRB
            // 
            this.MonthRB.AutoSize = true;
            this.MonthRB.Location = new System.Drawing.Point(24, 41);
            this.MonthRB.Name = "MonthRB";
            this.MonthRB.Size = new System.Drawing.Size(104, 17);
            this.MonthRB.TabIndex = 0;
            this.MonthRB.Text = "Отчёт за месяц";
            this.MonthRB.UseVisualStyleBackColor = true;
            this.MonthRB.CheckedChanged += new System.EventHandler(this.MonthRB_CheckedChanged);
            // 
            // QuarterRB
            // 
            this.QuarterRB.AutoSize = true;
            this.QuarterRB.Location = new System.Drawing.Point(24, 89);
            this.QuarterRB.Name = "QuarterRB";
            this.QuarterRB.Size = new System.Drawing.Size(113, 17);
            this.QuarterRB.TabIndex = 1;
            this.QuarterRB.Text = "Отчёт за квартал";
            this.QuarterRB.UseVisualStyleBackColor = true;
            this.QuarterRB.CheckedChanged += new System.EventHandler(this.QuarterRB_CheckedChanged);
            // 
            // DuringTimeRB
            // 
            this.DuringTimeRB.AutoSize = true;
            this.DuringTimeRB.Location = new System.Drawing.Point(24, 138);
            this.DuringTimeRB.Name = "DuringTimeRB";
            this.DuringTimeRB.Size = new System.Drawing.Size(104, 17);
            this.DuringTimeRB.TabIndex = 2;
            this.DuringTimeRB.Text = "Отчёт за время";
            this.DuringTimeRB.UseVisualStyleBackColor = true;
            this.DuringTimeRB.CheckedChanged += new System.EventHandler(this.DuringTimeRB_CheckedChanged);
            // 
            // MonthTimePicker
            // 
            this.MonthTimePicker.CustomFormat = "MMMM yyyy г.";
            this.MonthTimePicker.Enabled = false;
            this.MonthTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MonthTimePicker.Location = new System.Drawing.Point(201, 41);
            this.MonthTimePicker.Name = "MonthTimePicker";
            this.MonthTimePicker.ShowUpDown = true;
            this.MonthTimePicker.Size = new System.Drawing.Size(169, 20);
            this.MonthTimePicker.TabIndex = 3;
            // 
            // QuarterTimePicker
            // 
            this.QuarterTimePicker.Enabled = false;
            this.QuarterTimePicker.Location = new System.Drawing.Point(201, 89);
            this.QuarterTimePicker.Name = "QuarterTimePicker";
            this.QuarterTimePicker.Size = new System.Drawing.Size(169, 20);
            this.QuarterTimePicker.TabIndex = 4;
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Enabled = false;
            this.FromDatePicker.Location = new System.Drawing.Point(201, 138);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(169, 20);
            this.FromDatePicker.TabIndex = 5;
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Enabled = false;
            this.ToDatePicker.Location = new System.Drawing.Point(440, 139);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(169, 20);
            this.ToDatePicker.TabIndex = 6;
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(181, 145);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(14, 13);
            this.FromLabel.TabIndex = 7;
            this.FromLabel.Text = "C";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(413, 146);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(21, 13);
            this.ToLabel.TabIndex = 8;
            this.ToLabel.Text = "По";
            // 
            // CreateReportButton
            // 
            this.CreateReportButton.Location = new System.Drawing.Point(504, 326);
            this.CreateReportButton.Name = "CreateReportButton";
            this.CreateReportButton.Size = new System.Drawing.Size(160, 46);
            this.CreateReportButton.TabIndex = 1;
            this.CreateReportButton.Text = "Сформировать отчёт";
            this.CreateReportButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 326);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(160, 46);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FormReposForERIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 384);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateReportButton);
            this.Controls.Add(this.GroupBox);
            this.MaximumSize = new System.Drawing.Size(692, 423);
            this.MinimumSize = new System.Drawing.Size(692, 423);
            this.Name = "FormReposForERIP";
            this.Text = "Отчёт ERIP";
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.ResumeLayout(false);

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
    }
}
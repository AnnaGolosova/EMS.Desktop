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
            this.MonthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CreateReportButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Service4RB = new System.Windows.Forms.RadioButton();
            this.Service1RB = new System.Windows.Forms.RadioButton();
            this.Service3RB = new System.Windows.Forms.RadioButton();
            this.Service2RB = new System.Windows.Forms.RadioButton();
            this.GroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.MonthTimePicker);
            this.GroupBox.Location = new System.Drawing.Point(16, 53);
            this.GroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox.Size = new System.Drawing.Size(392, 78);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Выбор времени";
            // 
            // MonthTimePicker
            // 
            this.MonthTimePicker.CustomFormat = "MMMM yyyy г.";
            this.MonthTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MonthTimePicker.Location = new System.Drawing.Point(8, 32);
            this.MonthTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.MonthTimePicker.Name = "MonthTimePicker";
            this.MonthTimePicker.ShowUpDown = true;
            this.MonthTimePicker.Size = new System.Drawing.Size(374, 22);
            this.MonthTimePicker.TabIndex = 3;
            // 
            // CreateReportButton
            // 
            this.CreateReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateReportButton.Location = new System.Drawing.Point(259, 254);
            this.CreateReportButton.Margin = new System.Windows.Forms.Padding(4);
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
            this.CancelButton.Location = new System.Drawing.Point(16, 254);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
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
            this.FileNameTB.Size = new System.Drawing.Size(303, 22);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Service4RB);
            this.groupBox1.Controls.Add(this.Service1RB);
            this.groupBox1.Controls.Add(this.Service3RB);
            this.groupBox1.Controls.Add(this.Service2RB);
            this.groupBox1.Location = new System.Drawing.Point(16, 137);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(392, 108);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор услуги";
            // 
            // Service4RB
            // 
            this.Service4RB.AutoSize = true;
            this.Service4RB.Location = new System.Drawing.Point(176, 68);
            this.Service4RB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Service4RB.Name = "Service4RB";
            this.Service4RB.Size = new System.Drawing.Size(186, 21);
            this.Service4RB.TabIndex = 3;
            this.Service4RB.TabStop = true;
            this.Service4RB.Text = "Налог на недвижимость";
            this.Service4RB.UseVisualStyleBackColor = true;
            // 
            // Service1RB
            // 
            this.Service1RB.AutoSize = true;
            this.Service1RB.Location = new System.Drawing.Point(176, 31);
            this.Service1RB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Service1RB.Name = "Service1RB";
            this.Service1RB.Size = new System.Drawing.Size(78, 21);
            this.Service1RB.TabIndex = 2;
            this.Service1RB.TabStop = true;
            this.Service1RB.Text = "Взносы";
            this.Service1RB.UseVisualStyleBackColor = true;
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
            // 
            // FormReposForExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 292);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FileNameTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateReportButton);
            this.Controls.Add(this.GroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "FormReposForExcel";
            this.Text = "Отчёт Excel";
            this.GroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.Button CreateReportButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DateTimePicker MonthTimePicker;
        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Service2RB;
        private System.Windows.Forms.RadioButton Service3RB;
        private System.Windows.Forms.RadioButton Service1RB;
        private System.Windows.Forms.RadioButton Service4RB;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
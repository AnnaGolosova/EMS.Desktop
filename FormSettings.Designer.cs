namespace EMS.Desktop
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.PathesTab = new System.Windows.Forms.TabPage();
            this.TariffTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OverView210Button = new System.Windows.Forms.Button();
            this.Path210TextBox = new System.Windows.Forms.TextBox();
            this.Path210Label = new System.Windows.Forms.Label();
            this.OverView202Button = new System.Windows.Forms.Button();
            this.Path202TextBox = new System.Windows.Forms.TextBox();
            this.Path202Label = new System.Windows.Forms.Label();
            this.OverViewExcelButton = new System.Windows.Forms.Button();
            this.PathExcelTextBox = new System.Windows.Forms.TextBox();
            this.PathExcelLabel = new System.Windows.Forms.Label();
            this.ServerTab = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerNameTB = new System.Windows.Forms.TextBox();
            this.ConnectionStringTB = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.ReportDayPicker = new System.Windows.Forms.DateTimePicker();
            this.ReportDayLabel = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.PathesTab.SuspendLayout();
            this.ServerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.PathesTab);
            this.TabControl.Controls.Add(this.ServerTab);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(425, 319);
            this.TabControl.TabIndex = 0;
            // 
            // PathesTab
            // 
            this.PathesTab.Controls.Add(this.ReportDayLabel);
            this.PathesTab.Controls.Add(this.ReportDayPicker);
            this.PathesTab.Controls.Add(this.TariffTB);
            this.PathesTab.Controls.Add(this.label4);
            this.PathesTab.Controls.Add(this.OverView210Button);
            this.PathesTab.Controls.Add(this.Path210TextBox);
            this.PathesTab.Controls.Add(this.Path210Label);
            this.PathesTab.Controls.Add(this.OverView202Button);
            this.PathesTab.Controls.Add(this.Path202TextBox);
            this.PathesTab.Controls.Add(this.Path202Label);
            this.PathesTab.Controls.Add(this.OverViewExcelButton);
            this.PathesTab.Controls.Add(this.PathExcelTextBox);
            this.PathesTab.Controls.Add(this.PathExcelLabel);
            this.PathesTab.Location = new System.Drawing.Point(4, 22);
            this.PathesTab.Name = "PathesTab";
            this.PathesTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.PathesTab.Size = new System.Drawing.Size(417, 293);
            this.PathesTab.TabIndex = 0;
            this.PathesTab.Text = "Основные";
            this.PathesTab.UseVisualStyleBackColor = true;
            // 
            // TariffTB
            // 
            this.TariffTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TariffTB.Location = new System.Drawing.Point(8, 194);
            this.TariffTB.Name = "TariffTB";
            this.TariffTB.Size = new System.Drawing.Size(315, 20);
            this.TariffTB.TabIndex = 21;
            this.TariffTB.TextChanged += new System.EventHandler(this.TariffTB_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Государственный тариф";
            // 
            // OverView210Button
            // 
            this.OverView210Button.Location = new System.Drawing.Point(330, 137);
            this.OverView210Button.Name = "OverView210Button";
            this.OverView210Button.Size = new System.Drawing.Size(77, 20);
            this.OverView210Button.TabIndex = 19;
            this.OverView210Button.Text = "Обзор";
            this.OverView210Button.UseVisualStyleBackColor = true;
            this.OverView210Button.Click += new System.EventHandler(this.OverView210Button_Click);
            // 
            // Path210TextBox
            // 
            this.Path210TextBox.Location = new System.Drawing.Point(6, 137);
            this.Path210TextBox.Name = "Path210TextBox";
            this.Path210TextBox.ReadOnly = true;
            this.Path210TextBox.Size = new System.Drawing.Size(315, 20);
            this.Path210TextBox.TabIndex = 18;
            // 
            // Path210Label
            // 
            this.Path210Label.AutoSize = true;
            this.Path210Label.Location = new System.Drawing.Point(6, 121);
            this.Path210Label.Name = "Path210Label";
            this.Path210Label.Size = new System.Drawing.Size(110, 13);
            this.Path210Label.TabIndex = 17;
            this.Path210Label.Text = "Путь к файлам .210:";
            // 
            // OverView202Button
            // 
            this.OverView202Button.Location = new System.Drawing.Point(330, 79);
            this.OverView202Button.Name = "OverView202Button";
            this.OverView202Button.Size = new System.Drawing.Size(77, 20);
            this.OverView202Button.TabIndex = 16;
            this.OverView202Button.Text = "Обзор";
            this.OverView202Button.UseVisualStyleBackColor = true;
            this.OverView202Button.Click += new System.EventHandler(this.OverView202Button_Click);
            // 
            // Path202TextBox
            // 
            this.Path202TextBox.Location = new System.Drawing.Point(6, 79);
            this.Path202TextBox.Name = "Path202TextBox";
            this.Path202TextBox.ReadOnly = true;
            this.Path202TextBox.Size = new System.Drawing.Size(315, 20);
            this.Path202TextBox.TabIndex = 15;
            // 
            // Path202Label
            // 
            this.Path202Label.AutoSize = true;
            this.Path202Label.Location = new System.Drawing.Point(6, 63);
            this.Path202Label.Name = "Path202Label";
            this.Path202Label.Size = new System.Drawing.Size(161, 13);
            this.Path202Label.TabIndex = 14;
            this.Path202Label.Text = "Путь сохранения файлов .202:";
            // 
            // OverViewExcelButton
            // 
            this.OverViewExcelButton.Location = new System.Drawing.Point(330, 22);
            this.OverViewExcelButton.Name = "OverViewExcelButton";
            this.OverViewExcelButton.Size = new System.Drawing.Size(77, 20);
            this.OverViewExcelButton.TabIndex = 13;
            this.OverViewExcelButton.Text = "Обзор";
            this.OverViewExcelButton.UseVisualStyleBackColor = true;
            this.OverViewExcelButton.Click += new System.EventHandler(this.OverViewExcelButton_Click);
            // 
            // PathExcelTextBox
            // 
            this.PathExcelTextBox.Location = new System.Drawing.Point(6, 22);
            this.PathExcelTextBox.Name = "PathExcelTextBox";
            this.PathExcelTextBox.ReadOnly = true;
            this.PathExcelTextBox.Size = new System.Drawing.Size(315, 20);
            this.PathExcelTextBox.TabIndex = 12;
            // 
            // PathExcelLabel
            // 
            this.PathExcelLabel.AutoSize = true;
            this.PathExcelLabel.Location = new System.Drawing.Point(6, 6);
            this.PathExcelLabel.Name = "PathExcelLabel";
            this.PathExcelLabel.Size = new System.Drawing.Size(166, 13);
            this.PathExcelLabel.TabIndex = 11;
            this.PathExcelLabel.Text = "Путь сохранения файлов Excel:";
            // 
            // ServerTab
            // 
            this.ServerTab.Controls.Add(this.label3);
            this.ServerTab.Controls.Add(this.ServerNameTB);
            this.ServerTab.Controls.Add(this.ConnectionStringTB);
            this.ServerTab.Controls.Add(this.label2);
            this.ServerTab.Controls.Add(this.label1);
            this.ServerTab.Location = new System.Drawing.Point(4, 22);
            this.ServerTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ServerTab.Name = "ServerTab";
            this.ServerTab.Size = new System.Drawing.Size(417, 293);
            this.ServerTab.TabIndex = 1;
            this.ServerTab.Text = "Настройки сервера";
            this.ServerTab.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 271);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Изменения вступят в силу после перезагрузки приложения";
            // 
            // ServerNameTB
            // 
            this.ServerNameTB.Location = new System.Drawing.Point(14, 124);
            this.ServerNameTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ServerNameTB.Name = "ServerNameTB";
            this.ServerNameTB.Size = new System.Drawing.Size(390, 20);
            this.ServerNameTB.TabIndex = 3;
            this.ServerNameTB.Leave += new System.EventHandler(this.ServerNameTB_Leave);
            // 
            // ConnectionStringTB
            // 
            this.ConnectionStringTB.Location = new System.Drawing.Point(14, 29);
            this.ConnectionStringTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConnectionStringTB.Name = "ConnectionStringTB";
            this.ConnectionStringTB.Size = new System.Drawing.Size(390, 62);
            this.ConnectionStringTB.TabIndex = 2;
            this.ConnectionStringTB.Text = "";
            this.ConnectionStringTB.Leave += new System.EventHandler(this.ConnectionStringTB_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя сервера";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Строка подключения";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(336, 337);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(101, 27);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ReportDayPicker
            // 
            this.ReportDayPicker.CustomFormat = "dd";
            this.ReportDayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ReportDayPicker.Location = new System.Drawing.Point(6, 257);
            this.ReportDayPicker.Name = "ReportDayPicker";
            this.ReportDayPicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ReportDayPicker.ShowUpDown = true;
            this.ReportDayPicker.Size = new System.Drawing.Size(37, 20);
            this.ReportDayPicker.TabIndex = 22;
            this.ReportDayPicker.ValueChanged += new System.EventHandler(this.ReportDayPicker_ValueChanged);
            // 
            // ReportDayLabel
            // 
            this.ReportDayLabel.AutoSize = true;
            this.ReportDayLabel.Location = new System.Drawing.Point(6, 241);
            this.ReportDayLabel.Name = "ReportDayLabel";
            this.ReportDayLabel.Size = new System.Drawing.Size(127, 13);
            this.ReportDayLabel.TabIndex = 23;
            this.ReportDayLabel.Text = "День создания отчётов";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 376);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(353, 414);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.TabControl.ResumeLayout(false);
            this.PathesTab.ResumeLayout(false);
            this.PathesTab.PerformLayout();
            this.ServerTab.ResumeLayout(false);
            this.ServerTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage PathesTab;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button OverView210Button;
        private System.Windows.Forms.TextBox Path210TextBox;
        private System.Windows.Forms.Label Path210Label;
        private System.Windows.Forms.Button OverView202Button;
        private System.Windows.Forms.TextBox Path202TextBox;
        private System.Windows.Forms.Label Path202Label;
        private System.Windows.Forms.Button OverViewExcelButton;
        private System.Windows.Forms.TextBox PathExcelTextBox;
        private System.Windows.Forms.Label PathExcelLabel;
        private System.Windows.Forms.TabPage ServerTab;
        private System.Windows.Forms.TextBox ServerNameTB;
        private System.Windows.Forms.RichTextBox ConnectionStringTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TariffTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ReportDayPicker;
        private System.Windows.Forms.Label ReportDayLabel;
    }
}
namespace EMS.Desktop.Forms
{
    partial class AddHomesteadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddHomesteadForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MeterDataValueTB = new System.Windows.Forms.TextBox();
            this.Service4CB = new System.Windows.Forms.CheckBox();
            this.Service3CB = new System.Windows.Forms.CheckBox();
            this.Service2CB = new System.Windows.Forms.CheckBox();
            this.Service1CB = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CreateB = new System.Windows.Forms.Button();
            this.SelectHomesteadGB = new System.Windows.Forms.GroupBox();
            this.HomesteadNumberCB = new System.Windows.Forms.ComboBox();
            this.ChangeOwnerNameTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddHomesteadGB = new System.Windows.Forms.GroupBox();
            this.OwnerNameTB = new System.Windows.Forms.TextBox();
            this.NumberTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SelectHomesteadGB.SuspendLayout();
            this.AddHomesteadGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(10, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Чтобы добавить участок в генерацию новых .202 отчетов, выберите услугу";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.MeterDataValueTB);
            this.groupBox2.Controls.Add(this.Service4CB);
            this.groupBox2.Controls.Add(this.Service3CB);
            this.groupBox2.Controls.Add(this.Service2CB);
            this.groupBox2.Controls.Add(this.Service1CB);
            this.groupBox2.Location = new System.Drawing.Point(13, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 124);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Связные услуги";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Начальное значение счетчика";
            this.label4.Visible = false;
            // 
            // MeterDataValueTB
            // 
            this.MeterDataValueTB.Location = new System.Drawing.Point(221, 49);
            this.MeterDataValueTB.Name = "MeterDataValueTB";
            this.MeterDataValueTB.Size = new System.Drawing.Size(210, 22);
            this.MeterDataValueTB.TabIndex = 4;
            this.MeterDataValueTB.Text = "0";
            this.MeterDataValueTB.Visible = false;
            this.MeterDataValueTB.Leave += new System.EventHandler(this.MeterDataValueTB_Leave);
            // 
            // Service4CB
            // 
            this.Service4CB.AutoSize = true;
            this.Service4CB.Location = new System.Drawing.Point(12, 101);
            this.Service4CB.Name = "Service4CB";
            this.Service4CB.Size = new System.Drawing.Size(187, 21);
            this.Service4CB.TabIndex = 3;
            this.Service4CB.Text = "Налог на недвижимость";
            this.Service4CB.UseVisualStyleBackColor = true;
            // 
            // Service3CB
            // 
            this.Service3CB.AutoSize = true;
            this.Service3CB.Location = new System.Drawing.Point(12, 73);
            this.Service3CB.Name = "Service3CB";
            this.Service3CB.Size = new System.Drawing.Size(135, 21);
            this.Service3CB.TabIndex = 2;
            this.Service3CB.Text = "Налог на землю";
            this.Service3CB.UseVisualStyleBackColor = true;
            // 
            // Service2CB
            // 
            this.Service2CB.AutoSize = true;
            this.Service2CB.Location = new System.Drawing.Point(12, 49);
            this.Service2CB.Name = "Service2CB";
            this.Service2CB.Size = new System.Drawing.Size(157, 21);
            this.Service2CB.TabIndex = 1;
            this.Service2CB.Text = "Электроснабжение";
            this.Service2CB.UseVisualStyleBackColor = true;
            this.Service2CB.CheckedChanged += new System.EventHandler(this.Service2CB_CheckedChanged);
            // 
            // Service1CB
            // 
            this.Service1CB.AutoSize = true;
            this.Service1CB.Location = new System.Drawing.Point(12, 22);
            this.Service1CB.Name = "Service1CB";
            this.Service1CB.Size = new System.Drawing.Size(79, 21);
            this.Service1CB.TabIndex = 0;
            this.Service1CB.Text = "Взносы";
            this.Service1CB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(13, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateB
            // 
            this.CreateB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateB.Location = new System.Drawing.Point(376, 326);
            this.CreateB.Name = "CreateB";
            this.CreateB.Size = new System.Drawing.Size(108, 32);
            this.CreateB.TabIndex = 4;
            this.CreateB.Text = "Сохранить";
            this.CreateB.UseVisualStyleBackColor = true;
            this.CreateB.Click += new System.EventHandler(this.CreateB_Click);
            // 
            // SelectHomesteadGB
            // 
            this.SelectHomesteadGB.Controls.Add(this.HomesteadNumberCB);
            this.SelectHomesteadGB.Controls.Add(this.ChangeOwnerNameTB);
            this.SelectHomesteadGB.Controls.Add(this.label5);
            this.SelectHomesteadGB.Controls.Add(this.label6);
            this.SelectHomesteadGB.Location = new System.Drawing.Point(14, 12);
            this.SelectHomesteadGB.Name = "SelectHomesteadGB";
            this.SelectHomesteadGB.Size = new System.Drawing.Size(470, 135);
            this.SelectHomesteadGB.TabIndex = 4;
            this.SelectHomesteadGB.TabStop = false;
            this.SelectHomesteadGB.Text = "Данные об участке";
            // 
            // HomesteadNumberCB
            // 
            this.HomesteadNumberCB.FormattingEnabled = true;
            this.HomesteadNumberCB.Location = new System.Drawing.Point(12, 42);
            this.HomesteadNumberCB.Name = "HomesteadNumberCB";
            this.HomesteadNumberCB.Size = new System.Drawing.Size(452, 24);
            this.HomesteadNumberCB.TabIndex = 4;
            this.HomesteadNumberCB.SelectedIndexChanged += new System.EventHandler(this.HomesteadNumberCB_SelectedIndexChanged);
            // 
            // ChangeOwnerNameTB
            // 
            this.ChangeOwnerNameTB.Location = new System.Drawing.Point(12, 100);
            this.ChangeOwnerNameTB.Name = "ChangeOwnerNameTB";
            this.ChangeOwnerNameTB.Size = new System.Drawing.Size(452, 22);
            this.ChangeOwnerNameTB.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(380, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Имя владельца(При изменении новое имя сохраняется)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Введите номер участка";
            // 
            // AddHomesteadGB
            // 
            this.AddHomesteadGB.Controls.Add(this.OwnerNameTB);
            this.AddHomesteadGB.Controls.Add(this.NumberTB);
            this.AddHomesteadGB.Controls.Add(this.label3);
            this.AddHomesteadGB.Controls.Add(this.label2);
            this.AddHomesteadGB.Location = new System.Drawing.Point(14, 12);
            this.AddHomesteadGB.Name = "AddHomesteadGB";
            this.AddHomesteadGB.Size = new System.Drawing.Size(470, 135);
            this.AddHomesteadGB.TabIndex = 5;
            this.AddHomesteadGB.TabStop = false;
            this.AddHomesteadGB.Text = "Данные об участке";
            // 
            // OwnerNameTB
            // 
            this.OwnerNameTB.Location = new System.Drawing.Point(12, 100);
            this.OwnerNameTB.Name = "OwnerNameTB";
            this.OwnerNameTB.Size = new System.Drawing.Size(452, 22);
            this.OwnerNameTB.TabIndex = 3;
            // 
            // NumberTB
            // 
            this.NumberTB.Location = new System.Drawing.Point(12, 42);
            this.NumberTB.Name = "NumberTB";
            this.NumberTB.Size = new System.Drawing.Size(452, 22);
            this.NumberTB.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Введите имя владельца";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Введите номер участка";
            // 
            // AddHomesteadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 370);
            this.Controls.Add(this.AddHomesteadGB);
            this.Controls.Add(this.SelectHomesteadGB);
            this.Controls.Add(this.CreateB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddHomesteadForm";
            this.Text = "Добавление нового участка";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SelectHomesteadGB.ResumeLayout(false);
            this.SelectHomesteadGB.PerformLayout();
            this.AddHomesteadGB.ResumeLayout(false);
            this.AddHomesteadGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Service4CB;
        private System.Windows.Forms.CheckBox Service3CB;
        private System.Windows.Forms.CheckBox Service2CB;
        private System.Windows.Forms.CheckBox Service1CB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CreateB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MeterDataValueTB;
        private System.Windows.Forms.GroupBox SelectHomesteadGB;
        private System.Windows.Forms.TextBox ChangeOwnerNameTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox HomesteadNumberCB;
        private System.Windows.Forms.GroupBox AddHomesteadGB;
        private System.Windows.Forms.TextBox OwnerNameTB;
        private System.Windows.Forms.TextBox NumberTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
namespace EMS.Desktop
{
    partial class FilterViewDataForm
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
            this.ServiceGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxOwnerName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTime = new System.Windows.Forms.GroupBox();
            this.radioButtonAllTime = new System.Windows.Forms.RadioButton();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerAt = new System.Windows.Forms.DateTimePicker();
            this.radioButtonAt = new System.Windows.Forms.RadioButton();
            this.comboBoxNumber = new System.Windows.Forms.ComboBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ServiceGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServiceGroupBox
            // 
            this.ServiceGroupBox.Controls.Add(this.radioButtonAll);
            this.ServiceGroupBox.Controls.Add(this.radioButton4);
            this.ServiceGroupBox.Controls.Add(this.radioButton3);
            this.ServiceGroupBox.Controls.Add(this.radioButton2);
            this.ServiceGroupBox.Controls.Add(this.radioButton1);
            this.ServiceGroupBox.Location = new System.Drawing.Point(16, 108);
            this.ServiceGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServiceGroupBox.Name = "ServiceGroupBox";
            this.ServiceGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServiceGroupBox.Size = new System.Drawing.Size(201, 172);
            this.ServiceGroupBox.TabIndex = 0;
            this.ServiceGroupBox.TabStop = false;
            this.ServiceGroupBox.Text = "Сервис";
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Location = new System.Drawing.Point(8, 144);
            this.radioButtonAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(53, 21);
            this.radioButtonAll.TabIndex = 4;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Все";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(8, 108);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(37, 21);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(8, 80);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(37, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 52);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(37, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 23);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(37, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxNumber);
            this.groupBox2.Controls.Add(this.labelNumber);
            this.groupBox2.Controls.Add(this.comboBoxOwnerName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(225, 108);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(336, 172);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сортировка ФИО";
            // 
            // comboBoxOwnerName
            // 
            this.comboBoxOwnerName.FormattingEnabled = true;
            this.comboBoxOwnerName.Location = new System.Drawing.Point(8, 43);
            this.comboBoxOwnerName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxOwnerName.Name = "comboBoxOwnerName";
            this.comboBoxOwnerName.Size = new System.Drawing.Size(313, 24);
            this.comboBoxOwnerName.TabIndex = 4;
            this.comboBoxOwnerName.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поиск определённого человека";
            // 
            // groupBoxTime
            // 
            this.groupBoxTime.Controls.Add(this.radioButtonAllTime);
            this.groupBoxTime.Controls.Add(this.dateTimePickerTo);
            this.groupBoxTime.Controls.Add(this.labelTo);
            this.groupBoxTime.Controls.Add(this.dateTimePickerAt);
            this.groupBoxTime.Controls.Add(this.radioButtonAt);
            this.groupBoxTime.Location = new System.Drawing.Point(16, 15);
            this.groupBoxTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTime.Name = "groupBoxTime";
            this.groupBoxTime.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTime.Size = new System.Drawing.Size(545, 85);
            this.groupBoxTime.TabIndex = 4;
            this.groupBoxTime.TabStop = false;
            this.groupBoxTime.Text = "По времени";
            // 
            // radioButtonAllTime
            // 
            this.radioButtonAllTime.AutoSize = true;
            this.radioButtonAllTime.Checked = true;
            this.radioButtonAllTime.Location = new System.Drawing.Point(8, 55);
            this.radioButtonAllTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAllTime.Name = "radioButtonAllTime";
            this.radioButtonAllTime.Size = new System.Drawing.Size(116, 21);
            this.radioButtonAllTime.TabIndex = 7;
            this.radioButtonAllTime.TabStop = true;
            this.radioButtonAllTime.Text = "За всё время";
            this.radioButtonAllTime.UseVisualStyleBackColor = true;
            this.radioButtonAllTime.CheckedChanged += new System.EventHandler(this.radioButtonAllTime_CheckedChanged);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Enabled = false;
            this.dateTimePickerTo.Location = new System.Drawing.Point(348, 23);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(188, 22);
            this.dateTimePickerTo.TabIndex = 6;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Enabled = false;
            this.labelTo.Location = new System.Drawing.Point(314, 25);
            this.labelTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(26, 17);
            this.labelTo.TabIndex = 5;
            this.labelTo.Text = "По";
            // 
            // dateTimePickerAt
            // 
            this.dateTimePickerAt.Enabled = false;
            this.dateTimePickerAt.Location = new System.Drawing.Point(103, 23);
            this.dateTimePickerAt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerAt.Name = "dateTimePickerAt";
            this.dateTimePickerAt.Size = new System.Drawing.Size(193, 22);
            this.dateTimePickerAt.TabIndex = 4;
            // 
            // radioButtonAt
            // 
            this.radioButtonAt.AutoSize = true;
            this.radioButtonAt.Location = new System.Drawing.Point(8, 23);
            this.radioButtonAt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAt.Name = "radioButtonAt";
            this.radioButtonAt.Size = new System.Drawing.Size(38, 21);
            this.radioButtonAt.TabIndex = 3;
            this.radioButtonAt.Text = "С";
            this.radioButtonAt.UseVisualStyleBackColor = true;
            this.radioButtonAt.CheckedChanged += new System.EventHandler(this.radioButtonAt_CheckedChanged);
            // 
            // comboBoxNumber
            // 
            this.comboBoxNumber.FormattingEnabled = true;
            this.comboBoxNumber.Location = new System.Drawing.Point(8, 92);
            this.comboBoxNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxNumber.Name = "comboBoxNumber";
            this.comboBoxNumber.Size = new System.Drawing.Size(177, 24);
            this.comboBoxNumber.TabIndex = 1;
            this.comboBoxNumber.TextChanged += new System.EventHandler(this.comboBoxNumber_TextChanged);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(8, 72);
            this.labelNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(107, 17);
            this.labelNumber.TabIndex = 0;
            this.labelNumber.Text = "Номер участка";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(422, 292);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(140, 28);
            this.buttonApply.TabIndex = 6;
            this.buttonApply.Text = "Применить";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(13, 292);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(140, 28);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FilterViewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 329);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBoxTime);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ServiceGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FilterViewDataForm";
            this.Text = "Фильтрация данных";
            this.ServiceGroupBox.ResumeLayout(false);
            this.ServiceGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxTime.ResumeLayout(false);
            this.groupBoxTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ServiceGroupBox;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxOwnerName;
        private System.Windows.Forms.GroupBox groupBoxTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerAt;
        private System.Windows.Forms.RadioButton radioButtonAt;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.ComboBox comboBoxNumber;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.RadioButton radioButtonAllTime;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
    }
}
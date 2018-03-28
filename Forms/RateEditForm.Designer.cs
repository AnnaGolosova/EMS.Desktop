namespace EMS.Desktop.Forms
{
    partial class RateEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateEditForm));
            this.RateDGV = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateViewDGV = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tariff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RateDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateViewDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RateDGV
            // 
            this.RateDGV.AllowUserToAddRows = false;
            this.RateDGV.AllowUserToDeleteRows = false;
            this.RateDGV.AllowUserToResizeRows = false;
            this.RateDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RateDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.OwnerName,
            this.MeterNumber,
            this.Arrear,
            this.Rate});
            this.RateDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RateDGV.Location = new System.Drawing.Point(0, 0);
            this.RateDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RateDGV.Name = "RateDGV";
            this.RateDGV.RowTemplate.Height = 24;
            this.RateDGV.Size = new System.Drawing.Size(859, 271);
            this.RateDGV.TabIndex = 0;
            // 
            // Number
            // 
            this.Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Number.HeaderText = "Номер участка";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 125;
            // 
            // OwnerName
            // 
            this.OwnerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OwnerName.HeaderText = "Имя владельца";
            this.OwnerName.Name = "OwnerName";
            this.OwnerName.ReadOnly = true;
            this.OwnerName.Width = 127;
            // 
            // MeterNumber
            // 
            this.MeterNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MeterNumber.HeaderText = "Номер счетчика";
            this.MeterNumber.Name = "MeterNumber";
            this.MeterNumber.ReadOnly = true;
            this.MeterNumber.Width = 133;
            // 
            // Arrear
            // 
            this.Arrear.HeaderText = "Задолжность";
            this.Arrear.Name = "Arrear";
            // 
            // Rate
            // 
            this.Rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rate.HeaderText = "Номер тарифа";
            this.Rate.Name = "Rate";
            // 
            // RateViewDGV
            // 
            this.RateViewDGV.AllowUserToAddRows = false;
            this.RateViewDGV.AllowUserToDeleteRows = false;
            this.RateViewDGV.AllowUserToResizeRows = false;
            this.RateViewDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RateViewDGV.ColumnHeadersVisible = false;
            this.RateViewDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Title,
            this.Percent,
            this.Tariff,
            this.Value});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RateViewDGV.DefaultCellStyle = dataGridViewCellStyle1;
            this.RateViewDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.RateViewDGV.Location = new System.Drawing.Point(0, 0);
            this.RateViewDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RateViewDGV.Name = "RateViewDGV";
            this.RateViewDGV.RowHeadersVisible = false;
            this.RateViewDGV.RowTemplate.Height = 24;
            this.RateViewDGV.Size = new System.Drawing.Size(859, 96);
            this.RateViewDGV.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.RateViewDGV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RateDGV);
            this.splitContainer1.Size = new System.Drawing.Size(859, 551);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.Frozen = true;
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
            this.Percent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Percent.HeaderText = "";
            this.Percent.Name = "Percent";
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
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // RateEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 551);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RateEditForm";
            this.Text = "Редактор тарифов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RateEditForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.RateDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateViewDGV)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RateDGV;
        private System.Windows.Forms.DataGridView RateViewDGV;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tariff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}
namespace EMS.Desktop.Forms
{
    partial class CreateExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateExcel));
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(198, 60);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(160, 31);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(13, 60);
            this.confirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(160, 31);
            this.confirm.TabIndex = 1;
            this.confirm.Text = "Подтвердить";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // FileNameTB
            // 
            this.FileNameTB.Location = new System.Drawing.Point(13, 30);
            this.FileNameTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FileNameTB.Name = "FileNameTB";
            this.FileNameTB.Size = new System.Drawing.Size(345, 22);
            this.FileNameTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите имя файла";
            // 
            // CreateExcel
            // 
            this.AcceptButton = this.confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(376, 104);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileNameTB);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(394, 148);
            this.Name = "CreateExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.CreateExcel_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.Label label1;
    }
}
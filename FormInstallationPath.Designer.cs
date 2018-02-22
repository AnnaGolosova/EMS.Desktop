namespace EMS.Desktop
{
    partial class FormInstallationPath
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
            this.PathExcelLabel = new System.Windows.Forms.Label();
            this.PathExcelTextBox = new System.Windows.Forms.TextBox();
            this.OverViewExcelButton = new System.Windows.Forms.Button();
            this.Path202Label = new System.Windows.Forms.Label();
            this.Path202TextBox = new System.Windows.Forms.TextBox();
            this.OverView202Button = new System.Windows.Forms.Button();
            this.Path210Label = new System.Windows.Forms.Label();
            this.Path210TextBox = new System.Windows.Forms.TextBox();
            this.OverView210Button = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathExcelLabel
            // 
            this.PathExcelLabel.AutoSize = true;
            this.PathExcelLabel.Location = new System.Drawing.Point(12, 9);
            this.PathExcelLabel.Name = "PathExcelLabel";
            this.PathExcelLabel.Size = new System.Drawing.Size(166, 13);
            this.PathExcelLabel.TabIndex = 0;
            this.PathExcelLabel.Text = "Путь сохранения файлов Excel:";
            // 
            // PathExcelTextBox
            // 
            this.PathExcelTextBox.Location = new System.Drawing.Point(12, 25);
            this.PathExcelTextBox.Name = "PathExcelTextBox";
            this.PathExcelTextBox.ReadOnly = true;
            this.PathExcelTextBox.Size = new System.Drawing.Size(315, 20);
            this.PathExcelTextBox.TabIndex = 1;
            // 
            // OverViewExcelButton
            // 
            this.OverViewExcelButton.Location = new System.Drawing.Point(336, 25);
            this.OverViewExcelButton.Name = "OverViewExcelButton";
            this.OverViewExcelButton.Size = new System.Drawing.Size(77, 20);
            this.OverViewExcelButton.TabIndex = 2;
            this.OverViewExcelButton.Text = "Обзор";
            this.OverViewExcelButton.UseVisualStyleBackColor = true;
            this.OverViewExcelButton.Click += new System.EventHandler(this.OverViewExcelButton_Click);
            // 
            // Path202Label
            // 
            this.Path202Label.AutoSize = true;
            this.Path202Label.Location = new System.Drawing.Point(12, 66);
            this.Path202Label.Name = "Path202Label";
            this.Path202Label.Size = new System.Drawing.Size(161, 13);
            this.Path202Label.TabIndex = 3;
            this.Path202Label.Text = "Путь сохранения файлов .202:";
            // 
            // Path202TextBox
            // 
            this.Path202TextBox.Location = new System.Drawing.Point(12, 82);
            this.Path202TextBox.Name = "Path202TextBox";
            this.Path202TextBox.ReadOnly = true;
            this.Path202TextBox.Size = new System.Drawing.Size(315, 20);
            this.Path202TextBox.TabIndex = 4;
            // 
            // OverView202Button
            // 
            this.OverView202Button.Location = new System.Drawing.Point(336, 82);
            this.OverView202Button.Name = "OverView202Button";
            this.OverView202Button.Size = new System.Drawing.Size(77, 20);
            this.OverView202Button.TabIndex = 5;
            this.OverView202Button.Text = "Обзор";
            this.OverView202Button.UseVisualStyleBackColor = true;
            this.OverView202Button.Click += new System.EventHandler(this.OverView202Button_Click);
            // 
            // Path210Label
            // 
            this.Path210Label.AutoSize = true;
            this.Path210Label.Location = new System.Drawing.Point(12, 124);
            this.Path210Label.Name = "Path210Label";
            this.Path210Label.Size = new System.Drawing.Size(110, 13);
            this.Path210Label.TabIndex = 6;
            this.Path210Label.Text = "Путь к файлам .210:";
            // 
            // Path210TextBox
            // 
            this.Path210TextBox.Location = new System.Drawing.Point(12, 140);
            this.Path210TextBox.Name = "Path210TextBox";
            this.Path210TextBox.ReadOnly = true;
            this.Path210TextBox.Size = new System.Drawing.Size(315, 20);
            this.Path210TextBox.TabIndex = 7;
            // 
            // OverView210Button
            // 
            this.OverView210Button.Location = new System.Drawing.Point(336, 140);
            this.OverView210Button.Name = "OverView210Button";
            this.OverView210Button.Size = new System.Drawing.Size(77, 20);
            this.OverView210Button.TabIndex = 8;
            this.OverView210Button.Text = "Обзор";
            this.OverView210Button.UseVisualStyleBackColor = true;
            this.OverView210Button.Click += new System.EventHandler(this.OverView210Button_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.Location = new System.Drawing.Point(12, 237);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(379, 237);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 10;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // FormInstallationPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 272);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OverView210Button);
            this.Controls.Add(this.Path210TextBox);
            this.Controls.Add(this.Path210Label);
            this.Controls.Add(this.OverView202Button);
            this.Controls.Add(this.Path202TextBox);
            this.Controls.Add(this.Path202Label);
            this.Controls.Add(this.OverViewExcelButton);
            this.Controls.Add(this.PathExcelTextBox);
            this.Controls.Add(this.PathExcelLabel);
            this.MaximumSize = new System.Drawing.Size(482, 311);
            this.MinimumSize = new System.Drawing.Size(482, 311);
            this.Name = "FormInstallationPath";
            this.Text = "FormInstallationPath";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PathExcelLabel;
        private System.Windows.Forms.TextBox PathExcelTextBox;
        private System.Windows.Forms.Button OverViewExcelButton;
        private System.Windows.Forms.Label Path202Label;
        private System.Windows.Forms.TextBox Path202TextBox;
        private System.Windows.Forms.Button OverView202Button;
        private System.Windows.Forms.Label Path210Label;
        private System.Windows.Forms.TextBox Path210TextBox;
        private System.Windows.Forms.Button OverView210Button;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ApplyButton;
    }
}
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.OverView210Button = new System.Windows.Forms.Button();
            this.Path210TextBox = new System.Windows.Forms.TextBox();
            this.Path210Label = new System.Windows.Forms.Label();
            this.OverView202Button = new System.Windows.Forms.Button();
            this.Path202TextBox = new System.Windows.Forms.TextBox();
            this.Path202Label = new System.Windows.Forms.Label();
            this.OverViewExcelButton = new System.Windows.Forms.Button();
            this.PathExcelTextBox = new System.Windows.Forms.TextBox();
            this.PathExcelLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(425, 319);
            this.TabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.OverView210Button);
            this.tabPage1.Controls.Add(this.Path210TextBox);
            this.tabPage1.Controls.Add(this.Path210Label);
            this.tabPage1.Controls.Add(this.OverView202Button);
            this.tabPage1.Controls.Add(this.Path202TextBox);
            this.tabPage1.Controls.Add(this.Path202Label);
            this.tabPage1.Controls.Add(this.OverViewExcelButton);
            this.tabPage1.Controls.Add(this.PathExcelTextBox);
            this.tabPage1.Controls.Add(this.PathExcelLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(417, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Пути сохранения";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 376);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TabControl);
            this.MinimumSize = new System.Drawing.Size(353, 415);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
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
    }
}
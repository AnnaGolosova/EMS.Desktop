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
            this.ServerNameTB = new System.Windows.Forms.TextBox();
            this.ConnectionStringTB = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.TabControl.Location = new System.Drawing.Point(16, 15);
            this.TabControl.Margin = new System.Windows.Forms.Padding(4);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(567, 393);
            this.TabControl.TabIndex = 0;
            // 
            // PathesTab
            // 
            this.PathesTab.Controls.Add(this.OverView210Button);
            this.PathesTab.Controls.Add(this.Path210TextBox);
            this.PathesTab.Controls.Add(this.Path210Label);
            this.PathesTab.Controls.Add(this.OverView202Button);
            this.PathesTab.Controls.Add(this.Path202TextBox);
            this.PathesTab.Controls.Add(this.Path202Label);
            this.PathesTab.Controls.Add(this.OverViewExcelButton);
            this.PathesTab.Controls.Add(this.PathExcelTextBox);
            this.PathesTab.Controls.Add(this.PathExcelLabel);
            this.PathesTab.Location = new System.Drawing.Point(4, 25);
            this.PathesTab.Margin = new System.Windows.Forms.Padding(4);
            this.PathesTab.Name = "PathesTab";
            this.PathesTab.Padding = new System.Windows.Forms.Padding(4);
            this.PathesTab.Size = new System.Drawing.Size(559, 364);
            this.PathesTab.TabIndex = 0;
            this.PathesTab.Text = "Пути сохранения";
            this.PathesTab.UseVisualStyleBackColor = true;
            // 
            // OverView210Button
            // 
            this.OverView210Button.Location = new System.Drawing.Point(440, 169);
            this.OverView210Button.Margin = new System.Windows.Forms.Padding(4);
            this.OverView210Button.Name = "OverView210Button";
            this.OverView210Button.Size = new System.Drawing.Size(103, 25);
            this.OverView210Button.TabIndex = 19;
            this.OverView210Button.Text = "Обзор";
            this.OverView210Button.UseVisualStyleBackColor = true;
            this.OverView210Button.Click += new System.EventHandler(this.OverView210Button_Click);
            // 
            // Path210TextBox
            // 
            this.Path210TextBox.Location = new System.Drawing.Point(8, 169);
            this.Path210TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Path210TextBox.Name = "Path210TextBox";
            this.Path210TextBox.ReadOnly = true;
            this.Path210TextBox.Size = new System.Drawing.Size(419, 22);
            this.Path210TextBox.TabIndex = 18;
            // 
            // Path210Label
            // 
            this.Path210Label.AutoSize = true;
            this.Path210Label.Location = new System.Drawing.Point(8, 149);
            this.Path210Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Path210Label.Name = "Path210Label";
            this.Path210Label.Size = new System.Drawing.Size(142, 17);
            this.Path210Label.TabIndex = 17;
            this.Path210Label.Text = "Путь к файлам .210:";
            // 
            // OverView202Button
            // 
            this.OverView202Button.Location = new System.Drawing.Point(440, 97);
            this.OverView202Button.Margin = new System.Windows.Forms.Padding(4);
            this.OverView202Button.Name = "OverView202Button";
            this.OverView202Button.Size = new System.Drawing.Size(103, 25);
            this.OverView202Button.TabIndex = 16;
            this.OverView202Button.Text = "Обзор";
            this.OverView202Button.UseVisualStyleBackColor = true;
            this.OverView202Button.Click += new System.EventHandler(this.OverView202Button_Click);
            // 
            // Path202TextBox
            // 
            this.Path202TextBox.Location = new System.Drawing.Point(8, 97);
            this.Path202TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Path202TextBox.Name = "Path202TextBox";
            this.Path202TextBox.ReadOnly = true;
            this.Path202TextBox.Size = new System.Drawing.Size(419, 22);
            this.Path202TextBox.TabIndex = 15;
            // 
            // Path202Label
            // 
            this.Path202Label.AutoSize = true;
            this.Path202Label.Location = new System.Drawing.Point(8, 78);
            this.Path202Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Path202Label.Name = "Path202Label";
            this.Path202Label.Size = new System.Drawing.Size(210, 17);
            this.Path202Label.TabIndex = 14;
            this.Path202Label.Text = "Путь сохранения файлов .202:";
            // 
            // OverViewExcelButton
            // 
            this.OverViewExcelButton.Location = new System.Drawing.Point(440, 27);
            this.OverViewExcelButton.Margin = new System.Windows.Forms.Padding(4);
            this.OverViewExcelButton.Name = "OverViewExcelButton";
            this.OverViewExcelButton.Size = new System.Drawing.Size(103, 25);
            this.OverViewExcelButton.TabIndex = 13;
            this.OverViewExcelButton.Text = "Обзор";
            this.OverViewExcelButton.UseVisualStyleBackColor = true;
            this.OverViewExcelButton.Click += new System.EventHandler(this.OverViewExcelButton_Click);
            // 
            // PathExcelTextBox
            // 
            this.PathExcelTextBox.Location = new System.Drawing.Point(8, 27);
            this.PathExcelTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PathExcelTextBox.Name = "PathExcelTextBox";
            this.PathExcelTextBox.ReadOnly = true;
            this.PathExcelTextBox.Size = new System.Drawing.Size(419, 22);
            this.PathExcelTextBox.TabIndex = 12;
            // 
            // PathExcelLabel
            // 
            this.PathExcelLabel.AutoSize = true;
            this.PathExcelLabel.Location = new System.Drawing.Point(8, 7);
            this.PathExcelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PathExcelLabel.Name = "PathExcelLabel";
            this.PathExcelLabel.Size = new System.Drawing.Size(215, 17);
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
            this.ServerTab.Location = new System.Drawing.Point(4, 25);
            this.ServerTab.Name = "ServerTab";
            this.ServerTab.Size = new System.Drawing.Size(559, 364);
            this.ServerTab.TabIndex = 1;
            this.ServerTab.Text = "Настройки сервера";
            this.ServerTab.UseVisualStyleBackColor = true;
            // 
            // ServerNameTB
            // 
            this.ServerNameTB.Location = new System.Drawing.Point(19, 153);
            this.ServerNameTB.Name = "ServerNameTB";
            this.ServerNameTB.Size = new System.Drawing.Size(519, 22);
            this.ServerNameTB.TabIndex = 3;
            this.ServerNameTB.Leave += new System.EventHandler(this.ServerNameTB_Leave);
            // 
            // ConnectionStringTB
            // 
            this.ConnectionStringTB.Location = new System.Drawing.Point(19, 36);
            this.ConnectionStringTB.Name = "ConnectionStringTB";
            this.ConnectionStringTB.Size = new System.Drawing.Size(519, 76);
            this.ConnectionStringTB.TabIndex = 2;
            this.ConnectionStringTB.Text = "";
            this.ConnectionStringTB.Leave += new System.EventHandler(this.ConnectionStringTB_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя сервера";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Строка подключения";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(448, 415);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(135, 33);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Изменения вступят в силу после перезагрузки приложения";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 463);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(465, 500);
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
    }
}
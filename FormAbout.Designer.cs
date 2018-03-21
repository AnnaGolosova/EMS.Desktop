namespace EMS.Desktop
{
    partial class FormAboutProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutProgram));
            this.AuthorsGroupBox = new System.Windows.Forms.GroupBox();
            this.labelEdmail = new System.Windows.Forms.Label();
            this.labelSmax = new System.Windows.Forms.Label();
            this.labelSap = new System.Windows.Forms.Label();
            this.labelDan = new System.Windows.Forms.Label();
            this.labelGol = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AuthorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AuthorsGroupBox
            // 
            this.AuthorsGroupBox.Controls.Add(this.labelEdmail);
            this.AuthorsGroupBox.Controls.Add(this.labelSmax);
            this.AuthorsGroupBox.Controls.Add(this.labelSap);
            this.AuthorsGroupBox.Controls.Add(this.labelDan);
            this.AuthorsGroupBox.Controls.Add(this.labelGol);
            this.AuthorsGroupBox.Location = new System.Drawing.Point(16, 112);
            this.AuthorsGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AuthorsGroupBox.Name = "AuthorsGroupBox";
            this.AuthorsGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AuthorsGroupBox.Size = new System.Drawing.Size(412, 209);
            this.AuthorsGroupBox.TabIndex = 0;
            this.AuthorsGroupBox.TabStop = false;
            this.AuthorsGroupBox.Text = "Авторы";
            // 
            // labelEdmail
            // 
            this.labelEdmail.AutoSize = true;
            this.labelEdmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEdmail.Location = new System.Drawing.Point(8, 176);
            this.labelEdmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEdmail.Name = "labelEdmail";
            this.labelEdmail.Size = new System.Drawing.Size(358, 18);
            this.labelEdmail.TabIndex = 4;
            this.labelEdmail.Text = "Электронный адрес: emsdevelopTeam@gmail.com";
            // 
            // labelSmax
            // 
            this.labelSmax.AutoSize = true;
            this.labelSmax.Location = new System.Drawing.Point(8, 133);
            this.labelSmax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSmax.Name = "labelSmax";
            this.labelSmax.Size = new System.Drawing.Size(109, 17);
            this.labelSmax.TabIndex = 3;
            this.labelSmax.Text = "Смахтин Даник";
            // 
            // labelSap
            // 
            this.labelSap.AutoSize = true;
            this.labelSap.Location = new System.Drawing.Point(8, 103);
            this.labelSap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSap.Name = "labelSap";
            this.labelSap.Size = new System.Drawing.Size(117, 17);
            this.labelSap.TabIndex = 2;
            this.labelSap.Text = "Сапончик Артём";
            // 
            // labelDan
            // 
            this.labelDan.AutoSize = true;
            this.labelDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDan.Location = new System.Drawing.Point(8, 69);
            this.labelDan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDan.Name = "labelDan";
            this.labelDan.Size = new System.Drawing.Size(115, 18);
            this.labelDan.TabIndex = 1;
            this.labelDan.Text = "Данилков Егор";
            // 
            // labelGol
            // 
            this.labelGol.AutoSize = true;
            this.labelGol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGol.Location = new System.Drawing.Point(8, 37);
            this.labelGol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGol.Name = "labelGol";
            this.labelGol.Size = new System.Drawing.Size(114, 18);
            this.labelGol.TabIndex = 0;
            this.labelGol.Text = "Голосова Анна";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(293, 359);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(135, 33);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.AboutProgramOkButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(16, 28);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(71, 25);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "E.M.S.";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "Програмное обеспечение предназначенное для загрузки и обработки файлов ERIP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(313, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 62);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Version 1.0";
            // 
            // FormAboutProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 407);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.AuthorsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAboutProgram";
            this.Text = "О программе";
            this.AuthorsGroupBox.ResumeLayout(false);
            this.AuthorsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AuthorsGroupBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEdmail;
        private System.Windows.Forms.Label labelSmax;
        private System.Windows.Forms.Label labelSap;
        private System.Windows.Forms.Label labelDan;
        private System.Windows.Forms.Label labelGol;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}
using System.Reflection;

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
            this.AuthorsGroupBox.Location = new System.Drawing.Point(12, 91);
            this.AuthorsGroupBox.Name = "AuthorsGroupBox";
            this.AuthorsGroupBox.Size = new System.Drawing.Size(309, 170);
            this.AuthorsGroupBox.TabIndex = 0;
            this.AuthorsGroupBox.TabStop = false;
            this.AuthorsGroupBox.Text = "Авторы";
            // 
            // labelEdmail
            // 
            this.labelEdmail.AutoSize = true;
            this.labelEdmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEdmail.Location = new System.Drawing.Point(6, 143);
            this.labelEdmail.Name = "labelEdmail";
            this.labelEdmail.Size = new System.Drawing.Size(298, 15);
            this.labelEdmail.TabIndex = 4;
            this.labelEdmail.Text = "Электронный адрес: emsdevelopTeam@gmail.com";
            // 
            // labelSmax
            // 
            this.labelSmax.AutoSize = true;
            this.labelSmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSmax.Location = new System.Drawing.Point(6, 108);
            this.labelSmax.Name = "labelSmax";
            this.labelSmax.Size = new System.Drawing.Size(97, 15);
            this.labelSmax.TabIndex = 3;
            this.labelSmax.Text = "Смахтин Даник";
            // 
            // labelSap
            // 
            this.labelSap.AutoSize = true;
            this.labelSap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSap.Location = new System.Drawing.Point(6, 84);
            this.labelSap.Name = "labelSap";
            this.labelSap.Size = new System.Drawing.Size(102, 15);
            this.labelSap.TabIndex = 2;
            this.labelSap.Text = "Сапончик Артём";
            // 
            // labelDan
            // 
            this.labelDan.AutoSize = true;
            this.labelDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDan.Location = new System.Drawing.Point(6, 56);
            this.labelDan.Name = "labelDan";
            this.labelDan.Size = new System.Drawing.Size(94, 15);
            this.labelDan.TabIndex = 1;
            this.labelDan.Text = "Данилков Егор";
            // 
            // labelGol
            // 
            this.labelGol.AutoSize = true;
            this.labelGol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGol.Location = new System.Drawing.Point(6, 30);
            this.labelGol.Name = "labelGol";
            this.labelGol.Size = new System.Drawing.Size(93, 15);
            this.labelGol.TabIndex = 0;
            this.labelGol.Text = "Голосова Анна";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(220, 292);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(101, 27);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.AboutProgramOkButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(12, 23);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(56, 20);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "E.M.S.";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Програмное обеспечение предназначенное для загрузки и обработки файлов ERIP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(252, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 74);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 298);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = $"Version {Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}.{Assembly.GetExecutingAssembly().GetName().Version.Build}";
            // 
            // FormAboutProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 331);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.AuthorsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
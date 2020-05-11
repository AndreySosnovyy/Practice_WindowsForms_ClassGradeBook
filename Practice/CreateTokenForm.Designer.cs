namespace Practice
{
    partial class CreateTokenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTokenForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tokenField = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.copyButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.secretCheckBox = new System.Windows.Forms.CheckBox();
            this.tokenInFileButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(182)))), ((int)(((byte)(182)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 32);
            this.panel1.TabIndex = 11;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(50, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "СОЗДАНИЕ ТОКЕНА";
            // 
            // buttonExit
            // 
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(393, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(32, 32);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "✖";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.buttonExit_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Practice.Properties.Resources.mainPen;
            this.pictureBox1.Location = new System.Drawing.Point(12, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tokenField
            // 
            this.tokenField.Font = new System.Drawing.Font("Bahnschrift Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tokenField.Location = new System.Drawing.Point(226, 287);
            this.tokenField.Name = "tokenField";
            this.tokenField.Size = new System.Drawing.Size(168, 35);
            this.tokenField.TabIndex = 12;
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(36, 287);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(184, 35);
            this.generateButton.TabIndex = 13;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Bahnschrift Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(40, 123);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(129, 33);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ученика";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(34, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 34);
            this.label2.TabIndex = 18;
            this.label2.Text = "Создать токен для:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Bahnschrift Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(40, 174);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(125, 33);
            this.radioButton2.TabIndex = 19;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Учителя";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Bahnschrift Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(36, 225);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(220, 33);
            this.radioButton3.TabIndex = 20;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Администратора";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // copyButton
            // 
            this.copyButton.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyButton.Location = new System.Drawing.Point(127, 338);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(184, 37);
            this.copyButton.TabIndex = 21;
            this.copyButton.Text = "Копировать токен";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.AutoSize = true;
            this.infoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoButton.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoButton.Location = new System.Drawing.Point(79, 528);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(267, 24);
            this.infoButton.TabIndex = 22;
            this.infoButton.Text = "*ИНФОРМАЦИЯ О ТОКЕНАХ";
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secretCheckBox);
            this.groupBox1.Controls.Add(this.tokenInFileButton);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(40, 404);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 99);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Или создать файл с токеном";
            // 
            // secretCheckBox
            // 
            this.secretCheckBox.AutoSize = true;
            this.secretCheckBox.Location = new System.Drawing.Point(186, 47);
            this.secretCheckBox.Name = "secretCheckBox";
            this.secretCheckBox.Size = new System.Drawing.Size(140, 28);
            this.secretCheckBox.TabIndex = 1;
            this.secretCheckBox.Text = "Шифровать";
            this.secretCheckBox.UseVisualStyleBackColor = true;
            // 
            // tokenInFileButton
            // 
            this.tokenInFileButton.Location = new System.Drawing.Point(14, 40);
            this.tokenInFileButton.Name = "tokenInFileButton";
            this.tokenInFileButton.Size = new System.Drawing.Size(166, 40);
            this.tokenInFileButton.TabIndex = 0;
            this.tokenInFileButton.Text = "Создать";
            this.tokenInFileButton.UseVisualStyleBackColor = true;
            this.tokenInFileButton.Click += new System.EventHandler(this.tokenInFileButton_Click);
            // 
            // CreateTokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 576);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.tokenField);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTokenForm";
            this.Text = "CreateTokenForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tokenField;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Label infoButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox secretCheckBox;
        private System.Windows.Forms.Button tokenInFileButton;
    }
}
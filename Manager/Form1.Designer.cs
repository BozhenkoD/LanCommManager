namespace Manager
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbComps = new System.Windows.Forms.ListBox();
            this.cbCard = new System.Windows.Forms.ComboBox();
            this.panelcard = new System.Windows.Forms.Panel();
            this.chbCVV = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBoxFileTypes = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbRar = new System.Windows.Forms.CheckBox();
            this.cbOffice = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbMyIp = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelcard.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBoxFileTypes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbComps);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Клиенты";
            // 
            // lbComps
            // 
            this.lbComps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbComps.FormattingEnabled = true;
            this.lbComps.ItemHeight = 17;
            this.lbComps.Location = new System.Drawing.Point(6, 19);
            this.lbComps.Name = "lbComps";
            this.lbComps.Size = new System.Drawing.Size(283, 225);
            this.lbComps.TabIndex = 0;
            // 
            // cbCard
            // 
            this.cbCard.FormattingEnabled = true;
            this.cbCard.Items.AddRange(new object[] {
            "Visa",
            "Master Card"});
            this.cbCard.Location = new System.Drawing.Point(18, 17);
            this.cbCard.Name = "cbCard";
            this.cbCard.Size = new System.Drawing.Size(160, 21);
            this.cbCard.TabIndex = 9;
            // 
            // panelcard
            // 
            this.panelcard.Controls.Add(this.chbCVV);
            this.panelcard.Controls.Add(this.cbCard);
            this.panelcard.Location = new System.Drawing.Point(6, 19);
            this.panelcard.Name = "panelcard";
            this.panelcard.Size = new System.Drawing.Size(282, 179);
            this.panelcard.TabIndex = 10;
            // 
            // chbCVV
            // 
            this.chbCVV.AutoSize = true;
            this.chbCVV.BackColor = System.Drawing.Color.Black;
            this.chbCVV.ForeColor = System.Drawing.SystemColors.Control;
            this.chbCVV.Location = new System.Drawing.Point(18, 145);
            this.chbCVV.Name = "chbCVV";
            this.chbCVV.Size = new System.Drawing.Size(47, 17);
            this.chbCVV.TabIndex = 10;
            this.chbCVV.Text = "CVV";
            this.chbCVV.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelcard);
            this.groupBox3.Location = new System.Drawing.Point(313, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 203);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск карты";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Location = new System.Drawing.Point(11, 279);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(600, 340);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Процес оброботки";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(5, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(589, 315);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxFileTypes
            // 
            this.groupBoxFileTypes.Controls.Add(this.button1);
            this.groupBoxFileTypes.Controls.Add(this.cbRar);
            this.groupBoxFileTypes.Controls.Add(this.cbOffice);
            this.groupBoxFileTypes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxFileTypes.Location = new System.Drawing.Point(313, 12);
            this.groupBoxFileTypes.Name = "groupBoxFileTypes";
            this.groupBoxFileTypes.Size = new System.Drawing.Size(298, 54);
            this.groupBoxFileTypes.TabIndex = 14;
            this.groupBoxFileTypes.TabStop = false;
            this.groupBoxFileTypes.Text = "Целевые типы файлов:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbRar
            // 
            this.cbRar.AutoSize = true;
            this.cbRar.Location = new System.Drawing.Point(110, 22);
            this.cbRar.Name = "cbRar";
            this.cbRar.Size = new System.Drawing.Size(87, 18);
            this.cbRar.TabIndex = 1;
            this.cbRar.Text = "*.rar | *.zip";
            this.cbRar.UseVisualStyleBackColor = true;
            // 
            // cbOffice
            // 
            this.cbOffice.AutoSize = true;
            this.cbOffice.Location = new System.Drawing.Point(7, 22);
            this.cbOffice.Name = "cbOffice";
            this.cbOffice.Size = new System.Drawing.Size(75, 18);
            this.cbOffice.TabIndex = 0;
            this.cbOffice.Text = "MS Office";
            this.cbOffice.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Start);
            this.groupBox2.Controls.Add(this.tbMyIp);
            this.groupBox2.Location = new System.Drawing.Point(16, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 54);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Мой аддресс";
            // 
            // tbMyIp
            // 
            this.tbMyIp.Location = new System.Drawing.Point(7, 22);
            this.tbMyIp.Name = "tbMyIp";
            this.tbMyIp.Size = new System.Drawing.Size(208, 20);
            this.tbMyIp.TabIndex = 0;
            this.tbMyIp.Text = "127.0.0.1";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(222, 20);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(63, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Запуск";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 624);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxFileTypes);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.panelcard.ResumeLayout(false);
            this.panelcard.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBoxFileTypes.ResumeLayout(false);
            this.groupBoxFileTypes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbCard;
        private System.Windows.Forms.Panel panelcard;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chbCVV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBoxFileTypes;
        private System.Windows.Forms.CheckBox cbRar;
        private System.Windows.Forms.CheckBox cbOffice;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListBox lbComps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox tbMyIp;
    }
}


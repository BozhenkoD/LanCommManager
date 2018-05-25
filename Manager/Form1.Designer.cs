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
            this.lvProccess = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CVV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Office = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Progress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxFileTypes = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbOffice = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Start = new System.Windows.Forms.Button();
            this.tbMyIp = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panelcard.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBoxFileTypes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbComps);
            this.groupBox1.Location = new System.Drawing.Point(10, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 201);
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
            this.lbComps.Size = new System.Drawing.Size(283, 174);
            this.lbComps.TabIndex = 0;
            // 
            // cbCard
            // 
            this.cbCard.DisplayMember = "Visa";
            this.cbCard.FormattingEnabled = true;
            this.cbCard.Items.AddRange(new object[] {
            "Visa",
            "Master Card"});
            this.cbCard.Location = new System.Drawing.Point(18, 17);
            this.cbCard.Name = "cbCard";
            this.cbCard.Size = new System.Drawing.Size(160, 21);
            this.cbCard.TabIndex = 9;
            this.cbCard.ValueMember = "Visa";
            // 
            // panelcard
            // 
            this.panelcard.Controls.Add(this.chbCVV);
            this.panelcard.Controls.Add(this.cbCard);
            this.panelcard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcard.Location = new System.Drawing.Point(3, 16);
            this.panelcard.Name = "panelcard";
            this.panelcard.Size = new System.Drawing.Size(292, 184);
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
            this.groupBox3.Location = new System.Drawing.Point(313, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 203);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск карты";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvProccess);
            this.groupBox4.Location = new System.Drawing.Point(11, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(600, 299);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Процес оброботки";
            // 
            // lvProccess
            // 
            this.lvProccess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.CardType,
            this.CVV,
            this.Office,
            this.Rar,
            this.Path,
            this.Progress});
            this.lvProccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProccess.FullRowSelect = true;
            this.lvProccess.Location = new System.Drawing.Point(3, 16);
            this.lvProccess.Name = "lvProccess";
            this.lvProccess.Size = new System.Drawing.Size(594, 280);
            this.lvProccess.TabIndex = 0;
            this.lvProccess.UseCompatibleStateImageBehavior = false;
            this.lvProccess.View = System.Windows.Forms.View.Details;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 90;
            // 
            // CardType
            // 
            this.CardType.Text = "Тип карты";
            this.CardType.Width = 65;
            // 
            // CVV
            // 
            this.CVV.Text = "CVV";
            // 
            // Office
            // 
            this.Office.Text = "Office";
            // 
            // Rar
            // 
            this.Rar.Text = "Rar";
            // 
            // Path
            // 
            this.Path.Text = "Path";
            this.Path.Width = 160;
            // 
            // Progress
            // 
            this.Progress.Tag = "";
            this.Progress.Text = "Progress";
            this.Progress.Width = 80;
            // 
            // groupBoxFileTypes
            // 
            this.groupBoxFileTypes.Controls.Add(this.button1);
            this.groupBoxFileTypes.Controls.Add(this.cbOffice);
            this.groupBoxFileTypes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxFileTypes.Location = new System.Drawing.Point(311, 51);
            this.groupBoxFileTypes.Name = "groupBoxFileTypes";
            this.groupBoxFileTypes.Size = new System.Drawing.Size(298, 54);
            this.groupBoxFileTypes.TabIndex = 14;
            this.groupBoxFileTypes.TabStop = false;
            this.groupBoxFileTypes.Text = "Целевые типы файлов:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbOffice
            // 
            this.cbOffice.AutoSize = true;
            this.cbOffice.Location = new System.Drawing.Point(23, 22);
            this.cbOffice.Name = "cbOffice";
            this.cbOffice.Size = new System.Drawing.Size(142, 18);
            this.cbOffice.TabIndex = 0;
            this.cbOffice.Text = "MS Office Word, Excel.";
            this.cbOffice.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Start);
            this.groupBox2.Controls.Add(this.tbMyIp);
            this.groupBox2.Location = new System.Drawing.Point(311, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 44);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Мой аддресс";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(220, 16);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(63, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Запуск";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // tbMyIp
            // 
            this.tbMyIp.Location = new System.Drawing.Point(6, 19);
            this.tbMyIp.Name = "tbMyIp";
            this.tbMyIp.Size = new System.Drawing.Size(208, 20);
            this.tbMyIp.TabIndex = 0;
            this.tbMyIp.Text = "127.0.0.1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbDirectory);
            this.groupBox5.Location = new System.Drawing.Point(10, 208);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(295, 106);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Директория";
            // 
            // tbDirectory
            // 
            this.tbDirectory.Location = new System.Drawing.Point(6, 29);
            this.tbDirectory.Multiline = true;
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(283, 71);
            this.tbDirectory.TabIndex = 0;
            this.tbDirectory.Text = "C:\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 624);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxFileTypes);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.panelcard.ResumeLayout(false);
            this.panelcard.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBoxFileTypes.ResumeLayout(false);
            this.groupBoxFileTypes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelcard;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chbCVV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lvProccess;
        private System.Windows.Forms.GroupBox groupBoxFileTypes;
        private System.Windows.Forms.CheckBox cbOffice;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListBox lbComps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox tbMyIp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbDirectory;
        public System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader CardType;
        private System.Windows.Forms.ColumnHeader CVV;
        private System.Windows.Forms.ColumnHeader Office;
        private System.Windows.Forms.ColumnHeader Rar;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.ColumnHeader Progress;
        public System.Windows.Forms.ComboBox cbCard;
    }
}


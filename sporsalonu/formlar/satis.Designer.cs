namespace sporsalonu.formlar
{
    partial class satis
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
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox_sinif = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_baslangic = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.comboBox_sure = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_bitistar = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.button_satisyap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_fiyat = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::sporsalonu.Properties.Resources.kapa;
            this.button2.Location = new System.Drawing.Point(408, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 277;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.pictureBox1.Image = global::sporsalonu.Properties.Resources.ekle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 278;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 48);
            this.label1.TabIndex = 279;
            this.label1.Text = "Satış İşlemi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel19.Location = new System.Drawing.Point(115, 125);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(204, 2);
            this.panel19.TabIndex = 296;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Enabled = false;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.ForeColor = System.Drawing.Color.Silver;
            this.label15.Location = new System.Drawing.Point(115, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 22);
            this.label15.TabIndex = 295;
            this.label15.Text = "Sınıf";
            // 
            // comboBox_sinif
            // 
            this.comboBox_sinif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.comboBox_sinif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_sinif.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_sinif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.comboBox_sinif.FormattingEnabled = true;
            this.comboBox_sinif.Location = new System.Drawing.Point(115, 93);
            this.comboBox_sinif.Name = "comboBox_sinif";
            this.comboBox_sinif.Size = new System.Drawing.Size(204, 32);
            this.comboBox_sinif.TabIndex = 294;
            this.comboBox_sinif.Text = "Sınıf Seçiniz..";
            this.comboBox_sinif.SelectedIndexChanged += new System.EventHandler(this.comboBox_sinif_SelectedIndexChanged);
            // 
            // dateTimePicker_baslangic
            // 
            this.dateTimePicker_baslangic.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.dateTimePicker_baslangic.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.dateTimePicker_baslangic.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.dateTimePicker_baslangic.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.dateTimePicker_baslangic.Checked = false;
            this.dateTimePicker_baslangic.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker_baslangic.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.dateTimePicker_baslangic.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_baslangic.Location = new System.Drawing.Point(115, 175);
            this.dateTimePicker_baslangic.Name = "dateTimePicker_baslangic";
            this.dateTimePicker_baslangic.Size = new System.Drawing.Size(204, 32);
            this.dateTimePicker_baslangic.TabIndex = 299;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(115, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 22);
            this.label14.TabIndex = 298;
            this.label14.Text = "Başlangıç Tarihi";
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel18.Location = new System.Drawing.Point(115, 208);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(204, 2);
            this.panel18.TabIndex = 297;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel20.Location = new System.Drawing.Point(115, 284);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(204, 2);
            this.panel20.TabIndex = 301;
            // 
            // comboBox_sure
            // 
            this.comboBox_sure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.comboBox_sure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_sure.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_sure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.comboBox_sure.FormattingEnabled = true;
            this.comboBox_sure.Items.AddRange(new object[] {
            "1 Ay",
            "2 Ay",
            "3 Ay",
            "4 Ay",
            "5 Ay",
            "6 Ay",
            "7 Ay",
            "8 Ay",
            "9 Ay",
            "10 Ay",
            "11 Ay",
            "1 Yıl",
            "2 Yıl",
            "3 Yıl",
            "4 Yıl"});
            this.comboBox_sure.Location = new System.Drawing.Point(115, 254);
            this.comboBox_sure.Name = "comboBox_sure";
            this.comboBox_sure.Size = new System.Drawing.Size(204, 32);
            this.comboBox_sure.TabIndex = 300;
            this.comboBox_sure.Text = "Süre Seçiniz..";
            this.comboBox_sure.SelectedIndexChanged += new System.EventHandler(this.comboBox_sure_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Enabled = false;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.Location = new System.Drawing.Point(115, 310);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 22);
            this.label13.TabIndex = 303;
            this.label13.Text = "Bitiş Tarihi";
            // 
            // textBox_bitistar
            // 
            this.textBox_bitistar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.textBox_bitistar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_bitistar.Enabled = false;
            this.textBox_bitistar.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_bitistar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_bitistar.Location = new System.Drawing.Point(115, 335);
            this.textBox_bitistar.Name = "textBox_bitistar";
            this.textBox_bitistar.Size = new System.Drawing.Size(204, 30);
            this.textBox_bitistar.TabIndex = 304;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel17.Location = new System.Drawing.Point(115, 366);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(204, 2);
            this.panel17.TabIndex = 302;
            // 
            // button_satisyap
            // 
            this.button_satisyap.FlatAppearance.BorderSize = 3;
            this.button_satisyap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_satisyap.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_satisyap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.button_satisyap.Location = new System.Drawing.Point(115, 459);
            this.button_satisyap.Name = "button_satisyap";
            this.button_satisyap.Size = new System.Drawing.Size(204, 46);
            this.button_satisyap.TabIndex = 305;
            this.button_satisyap.Text = "Satış Yap";
            this.button_satisyap.UseVisualStyleBackColor = true;
            this.button_satisyap.Click += new System.EventHandler(this.button_satisyap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(115, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 22);
            this.label2.TabIndex = 307;
            this.label2.Text = "Süre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(115, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 309;
            this.label3.Text = "Satış Fiyatı";
            // 
            // textBox_fiyat
            // 
            this.textBox_fiyat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.textBox_fiyat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_fiyat.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_fiyat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_fiyat.Location = new System.Drawing.Point(115, 411);
            this.textBox_fiyat.Name = "textBox_fiyat";
            this.textBox_fiyat.Size = new System.Drawing.Size(204, 30);
            this.textBox_fiyat.TabIndex = 310;
            this.textBox_fiyat.Enter += new System.EventHandler(this.textBox_fiyat_Enter);
            this.textBox_fiyat.Leave += new System.EventHandler(this.textBox_fiyat_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel1.Location = new System.Drawing.Point(115, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 2);
            this.panel1.TabIndex = 308;
            // 
            // satis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(456, 527);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_fiyat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_satisyap);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox_bitistar);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.comboBox_sure);
            this.Controls.Add(this.dateTimePicker_baslangic);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.panel19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBox_sinif);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "satis";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.satis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox_sinif;
        private System.Windows.Forms.DateTimePicker dateTimePicker_baslangic;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.ComboBox comboBox_sure;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_bitistar;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button button_satisyap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_fiyat;
        private System.Windows.Forms.Panel panel1;
    }
}
namespace sporsalonu.formlar
{
    partial class kullaniciEkle
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
            this.components = new System.ComponentModel.Container();
            this.label_sonuc = new System.Windows.Forms.Label();
            this.timer_sonuc = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_soyad = new System.Windows.Forms.Label();
            this.textBox_soyad = new System.Windows.Forms.TextBox();
            this.button_ekle = new System.Windows.Forms.Button();
            this.label_ad = new System.Windows.Forms.Label();
            this.textBox_ad = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_sifre = new System.Windows.Forms.Label();
            this.textBox_sifre = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_kullanici = new System.Windows.Forms.TextBox();
            this.label_kullanici = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_sonuc
            // 
            this.label_sonuc.AutoSize = true;
            this.label_sonuc.BackColor = System.Drawing.Color.Transparent;
            this.label_sonuc.Enabled = false;
            this.label_sonuc.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_sonuc.ForeColor = System.Drawing.Color.Silver;
            this.label_sonuc.Location = new System.Drawing.Point(52, 390);
            this.label_sonuc.Name = "label_sonuc";
            this.label_sonuc.Size = new System.Drawing.Size(0, 30);
            this.label_sonuc.TabIndex = 83;
            // 
            // timer_sonuc
            // 
            this.timer_sonuc.Tick += new System.EventHandler(this.timer_sonuc_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 48);
            this.label1.TabIndex = 85;
            this.label1.Text = "Kullanıcı Ekle";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_soyad
            // 
            this.label_soyad.AutoSize = true;
            this.label_soyad.BackColor = System.Drawing.Color.Transparent;
            this.label_soyad.Enabled = false;
            this.label_soyad.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_soyad.ForeColor = System.Drawing.Color.Silver;
            this.label_soyad.Location = new System.Drawing.Point(94, 136);
            this.label_soyad.Name = "label_soyad";
            this.label_soyad.Size = new System.Drawing.Size(68, 22);
            this.label_soyad.TabIndex = 79;
            this.label_soyad.Text = "Soyad";
            // 
            // textBox_soyad
            // 
            this.textBox_soyad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.textBox_soyad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_soyad.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_soyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_soyad.Location = new System.Drawing.Point(98, 161);
            this.textBox_soyad.Name = "textBox_soyad";
            this.textBox_soyad.Size = new System.Drawing.Size(189, 30);
            this.textBox_soyad.TabIndex = 74;
            this.textBox_soyad.Text = "Şahin";
            // 
            // button_ekle
            // 
            this.button_ekle.FlatAppearance.BorderSize = 3;
            this.button_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ekle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_ekle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.button_ekle.Location = new System.Drawing.Point(105, 382);
            this.button_ekle.Name = "button_ekle";
            this.button_ekle.Size = new System.Drawing.Size(182, 46);
            this.button_ekle.TabIndex = 75;
            this.button_ekle.Text = "Ekle";
            this.button_ekle.UseVisualStyleBackColor = true;
            this.button_ekle.Click += new System.EventHandler(this.button_ekle_Click);
            // 
            // label_ad
            // 
            this.label_ad.AutoSize = true;
            this.label_ad.BackColor = System.Drawing.Color.Transparent;
            this.label_ad.Enabled = false;
            this.label_ad.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_ad.ForeColor = System.Drawing.Color.Silver;
            this.label_ad.Location = new System.Drawing.Point(94, 61);
            this.label_ad.Name = "label_ad";
            this.label_ad.Size = new System.Drawing.Size(38, 22);
            this.label_ad.TabIndex = 77;
            this.label_ad.Text = "Ad";
            // 
            // textBox_ad
            // 
            this.textBox_ad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.textBox_ad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ad.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_ad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_ad.Location = new System.Drawing.Point(98, 86);
            this.textBox_ad.Name = "textBox_ad";
            this.textBox_ad.Size = new System.Drawing.Size(189, 30);
            this.textBox_ad.TabIndex = 73;
            this.textBox_ad.Text = "Zeynel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel1.Location = new System.Drawing.Point(98, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 2);
            this.panel1.TabIndex = 78;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel2.Location = new System.Drawing.Point(98, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 2);
            this.panel2.TabIndex = 76;
            // 
            // label_sifre
            // 
            this.label_sifre.AutoSize = true;
            this.label_sifre.BackColor = System.Drawing.Color.Transparent;
            this.label_sifre.Enabled = false;
            this.label_sifre.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_sifre.ForeColor = System.Drawing.Color.Silver;
            this.label_sifre.Location = new System.Drawing.Point(94, 286);
            this.label_sifre.Name = "label_sifre";
            this.label_sifre.Size = new System.Drawing.Size(46, 22);
            this.label_sifre.TabIndex = 91;
            this.label_sifre.Text = "Şifre";
            // 
            // textBox_sifre
            // 
            this.textBox_sifre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.textBox_sifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_sifre.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_sifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_sifre.Location = new System.Drawing.Point(98, 315);
            this.textBox_sifre.Name = "textBox_sifre";
            this.textBox_sifre.Size = new System.Drawing.Size(189, 30);
            this.textBox_sifre.TabIndex = 87;
            this.textBox_sifre.Text = "123";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel4.Location = new System.Drawing.Point(98, 347);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(189, 2);
            this.panel4.TabIndex = 88;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel3.Location = new System.Drawing.Point(98, 270);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 2);
            this.panel3.TabIndex = 90;
            // 
            // textBox_kullanici
            // 
            this.textBox_kullanici.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.textBox_kullanici.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_kullanici.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_kullanici.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_kullanici.Location = new System.Drawing.Point(98, 238);
            this.textBox_kullanici.Name = "textBox_kullanici";
            this.textBox_kullanici.Size = new System.Drawing.Size(189, 30);
            this.textBox_kullanici.TabIndex = 86;
            this.textBox_kullanici.Text = "zynlshn";
            // 
            // label_kullanici
            // 
            this.label_kullanici.AutoSize = true;
            this.label_kullanici.BackColor = System.Drawing.Color.Transparent;
            this.label_kullanici.Enabled = false;
            this.label_kullanici.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_kullanici.ForeColor = System.Drawing.Color.Silver;
            this.label_kullanici.Location = new System.Drawing.Point(94, 213);
            this.label_kullanici.Name = "label_kullanici";
            this.label_kullanici.Size = new System.Drawing.Size(118, 22);
            this.label_kullanici.TabIndex = 89;
            this.label_kullanici.Text = "Kullanıcı Adı";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::sporsalonu.Properties.Resources.kapa;
            this.button2.Location = new System.Drawing.Point(346, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 80;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.pictureBox1.Image = global::sporsalonu.Properties.Resources.ekle;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 84;
            this.pictureBox1.TabStop = false;
            // 
            // kullaniciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(393, 465);
            this.Controls.Add(this.label_sifre);
            this.Controls.Add(this.textBox_sifre);
            this.Controls.Add(this.label_kullanici);
            this.Controls.Add(this.textBox_kullanici);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label_sonuc);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_soyad);
            this.Controls.Add(this.textBox_soyad);
            this.Controls.Add(this.button_ekle);
            this.Controls.Add(this.label_ad);
            this.Controls.Add(this.textBox_ad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kullaniciEkle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.kullaniciEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sonuc;
        private System.Windows.Forms.Timer timer_sonuc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_soyad;
        private System.Windows.Forms.TextBox textBox_soyad;
        private System.Windows.Forms.Button button_ekle;
        private System.Windows.Forms.Label label_ad;
        private System.Windows.Forms.TextBox textBox_ad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_sifre;
        private System.Windows.Forms.TextBox textBox_sifre;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_kullanici;
        private System.Windows.Forms.Label label_kullanici;
    }
}
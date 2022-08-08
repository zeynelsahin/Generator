namespace sporsalonu.formlar
{
    partial class olcuturuEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(olcuturuEkle));
            this.label_sonuc = new System.Windows.Forms.Label();
            this.timer_sonuc = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_olcuadi = new System.Windows.Forms.TextBox();
            this.label_olcuadi = new System.Windows.Forms.Label();
            this.button_ekle = new System.Windows.Forms.Button();
            this.textBox_birimi = new System.Windows.Forms.TextBox();
            this.label_birimi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_aktif = new System.Windows.Forms.Button();
            this.button_pasif = new System.Windows.Forms.Button();
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
            this.label_sonuc.Location = new System.Drawing.Point(62, 337);
            this.label_sonuc.Name = "label_sonuc";
            this.label_sonuc.Size = new System.Drawing.Size(0, 30);
            this.label_sonuc.TabIndex = 71;
            // 
            // timer_sonuc
            // 
            this.timer_sonuc.Tick += new System.EventHandler(this.timer_sonuc_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel2.Location = new System.Drawing.Point(111, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 2);
            this.panel2.TabIndex = 64;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel1.Location = new System.Drawing.Point(111, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 2);
            this.panel1.TabIndex = 67;
            // 
            // textBox_olcuadi
            // 
            this.textBox_olcuadi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.textBox_olcuadi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_olcuadi.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_olcuadi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_olcuadi.Location = new System.Drawing.Point(111, 88);
            this.textBox_olcuadi.Name = "textBox_olcuadi";
            this.textBox_olcuadi.Size = new System.Drawing.Size(189, 30);
            this.textBox_olcuadi.TabIndex = 2;
            this.textBox_olcuadi.TextChanged += new System.EventHandler(this.textBox_olcuadi_TextChanged);
            // 
            // label_olcuadi
            // 
            this.label_olcuadi.AutoSize = true;
            this.label_olcuadi.BackColor = System.Drawing.Color.Transparent;
            this.label_olcuadi.Enabled = false;
            this.label_olcuadi.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_olcuadi.ForeColor = System.Drawing.Color.Silver;
            this.label_olcuadi.Location = new System.Drawing.Point(111, 63);
            this.label_olcuadi.Name = "label_olcuadi";
            this.label_olcuadi.Size = new System.Drawing.Size(90, 22);
            this.label_olcuadi.TabIndex = 65;
            this.label_olcuadi.Text = "Ölçü Adı";
            // 
            // button_ekle
            // 
            this.button_ekle.FlatAppearance.BorderSize = 3;
            this.button_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ekle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_ekle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.button_ekle.Location = new System.Drawing.Point(111, 304);
            this.button_ekle.Name = "button_ekle";
            this.button_ekle.Size = new System.Drawing.Size(189, 46);
            this.button_ekle.TabIndex = 4;
            this.button_ekle.Text = "Ekle";
            this.button_ekle.UseVisualStyleBackColor = true;
            this.button_ekle.Click += new System.EventHandler(this.button_ekle_Click);
            // 
            // textBox_birimi
            // 
            this.textBox_birimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.textBox_birimi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_birimi.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_birimi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_birimi.Location = new System.Drawing.Point(111, 173);
            this.textBox_birimi.Name = "textBox_birimi";
            this.textBox_birimi.Size = new System.Drawing.Size(189, 30);
            this.textBox_birimi.TabIndex = 3;
            this.textBox_birimi.TextChanged += new System.EventHandler(this.textBox_birimi_TextChanged_1);
            // 
            // label_birimi
            // 
            this.label_birimi.AutoSize = true;
            this.label_birimi.BackColor = System.Drawing.Color.Transparent;
            this.label_birimi.Enabled = false;
            this.label_birimi.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_birimi.ForeColor = System.Drawing.Color.Silver;
            this.label_birimi.Location = new System.Drawing.Point(111, 148);
            this.label_birimi.Name = "label_birimi";
            this.label_birimi.Size = new System.Drawing.Size(86, 22);
            this.label_birimi.TabIndex = 68;
            this.label_birimi.Text = "Birim Adı";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 48);
            this.label1.TabIndex = 72;
            this.label1.Text = "Ölçü Türü Ekle";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_aktif
            // 
            this.button_aktif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.button_aktif.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button_aktif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_aktif.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_aktif.ForeColor = System.Drawing.Color.White;
            this.button_aktif.Location = new System.Drawing.Point(151, 242);
            this.button_aktif.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_aktif.Name = "button_aktif";
            this.button_aktif.Size = new System.Drawing.Size(58, 31);
            this.button_aktif.TabIndex = 69;
            this.button_aktif.TabStop = false;
            this.button_aktif.Text = "Aktif";
            this.button_aktif.UseVisualStyleBackColor = false;
            this.button_aktif.Click += new System.EventHandler(this.button_aktif_Click);
            // 
            // button_pasif
            // 
            this.button_pasif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(170)))), ((int)(((byte)(157)))));
            this.button_pasif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pasif.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_pasif.Location = new System.Drawing.Point(207, 242);
            this.button_pasif.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_pasif.Name = "button_pasif";
            this.button_pasif.Size = new System.Drawing.Size(58, 31);
            this.button_pasif.TabIndex = 70;
            this.button_pasif.TabStop = false;
            this.button_pasif.Text = "Pasif";
            this.button_pasif.UseVisualStyleBackColor = false;
            this.button_pasif.Click += new System.EventHandler(this.button_pasif_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(193)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::sporsalonu.Properties.Resources.kapa;
            this.button2.Location = new System.Drawing.Point(364, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 69;
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
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // olcuturuEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(412, 376);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_sonuc);
            this.Controls.Add(this.button_pasif);
            this.Controls.Add(this.button_aktif);
            this.Controls.Add(this.label_birimi);
            this.Controls.Add(this.textBox_birimi);
            this.Controls.Add(this.button_ekle);
            this.Controls.Add(this.label_olcuadi);
            this.Controls.Add(this.textBox_olcuadi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "olcuturuEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "olcuturu_Ekle";
            this.Load += new System.EventHandler(this.olcuturu_Ekle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_sonuc;
        private System.Windows.Forms.Timer timer_sonuc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_olcuadi;
        private System.Windows.Forms.Label label_olcuadi;
        private System.Windows.Forms.Button button_ekle;
        private System.Windows.Forms.TextBox textBox_birimi;
        private System.Windows.Forms.Label label_birimi;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_aktif;
        private System.Windows.Forms.Button button_pasif;
    }
}
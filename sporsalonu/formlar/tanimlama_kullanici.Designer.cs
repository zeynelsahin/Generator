namespace sporsalonu.formlar
{
    partial class tanimlama_kullanici
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_sunum = new System.Windows.Forms.Panel();
            this.label_adet = new System.Windows.Forms.Label();
            this.veriListesi = new System.Windows.Forms.DataGridView();
            this.label_copadet = new System.Windows.Forms.Label();
            this.label_ara = new System.Windows.Forms.Label();
            this.textBox_ara = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel_ust = new System.Windows.Forms.Panel();
            this.button_copkutusu = new System.Windows.Forms.Button();
            this.button_sil = new System.Windows.Forms.Button();
            this.button_ekle = new System.Windows.Forms.Button();
            this.button_güncelle = new System.Windows.Forms.Button();
            this.button_yenile = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel_sunum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.veriListesi)).BeginInit();
            this.panel_ust.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_sunum
            // 
            this.panel_sunum.Controls.Add(this.label_adet);
            this.panel_sunum.Controls.Add(this.veriListesi);
            this.panel_sunum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sunum.ForeColor = System.Drawing.Color.Black;
            this.panel_sunum.Location = new System.Drawing.Point(0, 118);
            this.panel_sunum.Name = "panel_sunum";
            this.panel_sunum.Size = new System.Drawing.Size(1056, 603);
            this.panel_sunum.TabIndex = 25;
            this.panel_sunum.SizeChanged += new System.EventHandler(this.panel_sunum_SizeChanged);
            // 
            // label_adet
            // 
            this.label_adet.AutoSize = true;
            this.label_adet.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_adet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.label_adet.Location = new System.Drawing.Point(46, 367);
            this.label_adet.Name = "label_adet";
            this.label_adet.Size = new System.Drawing.Size(109, 30);
            this.label_adet.TabIndex = 81;
            this.label_adet.Text = "Toplam ";
            // 
            // veriListesi
            // 
            this.veriListesi.AllowUserToAddRows = false;
            this.veriListesi.AllowUserToDeleteRows = false;
            this.veriListesi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.veriListesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.veriListesi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.veriListesi.BackgroundColor = System.Drawing.Color.White;
            this.veriListesi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.veriListesi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F);
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.veriListesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.veriListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.veriListesi.DefaultCellStyle = dataGridViewCellStyle2;
            this.veriListesi.Location = new System.Drawing.Point(51, 1);
            this.veriListesi.Name = "veriListesi";
            this.veriListesi.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.veriListesi.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.veriListesi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.veriListesi.Size = new System.Drawing.Size(957, 348);
            this.veriListesi.TabIndex = 1;
            this.veriListesi.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.veriListesi_DataBindingComplete);
            // 
            // label_copadet
            // 
            this.label_copadet.AutoSize = true;
            this.label_copadet.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_copadet.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_copadet.Location = new System.Drawing.Point(1056, 0);
            this.label_copadet.Name = "label_copadet";
            this.label_copadet.Size = new System.Drawing.Size(0, 24);
            this.label_copadet.TabIndex = 73;
            // 
            // label_ara
            // 
            this.label_ara.AutoSize = true;
            this.label_ara.BackColor = System.Drawing.Color.Transparent;
            this.label_ara.Enabled = false;
            this.label_ara.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_ara.ForeColor = System.Drawing.Color.Silver;
            this.label_ara.Location = new System.Drawing.Point(52, 81);
            this.label_ara.Name = "label_ara";
            this.label_ara.Size = new System.Drawing.Size(81, 30);
            this.label_ara.TabIndex = 69;
            this.label_ara.Text = "Ara....";
            // 
            // textBox_ara
            // 
            this.textBox_ara.BackColor = System.Drawing.Color.White;
            this.textBox_ara.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ara.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_ara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.textBox_ara.Location = new System.Drawing.Point(51, 80);
            this.textBox_ara.Name = "textBox_ara";
            this.textBox_ara.Size = new System.Drawing.Size(204, 30);
            this.textBox_ara.TabIndex = 68;
            this.textBox_ara.TextChanged += new System.EventHandler(this.textBox_ara_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel4.Location = new System.Drawing.Point(51, 112);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(204, 2);
            this.panel4.TabIndex = 70;
            // 
            // panel_ust
            // 
            this.panel_ust.Controls.Add(this.label_copadet);
            this.panel_ust.Controls.Add(this.label_ara);
            this.panel_ust.Controls.Add(this.textBox_ara);
            this.panel_ust.Controls.Add(this.panel4);
            this.panel_ust.Controls.Add(this.button_copkutusu);
            this.panel_ust.Controls.Add(this.button_sil);
            this.panel_ust.Controls.Add(this.button_ekle);
            this.panel_ust.Controls.Add(this.button_güncelle);
            this.panel_ust.Controls.Add(this.button_yenile);
            this.panel_ust.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ust.Location = new System.Drawing.Point(0, 0);
            this.panel_ust.Name = "panel_ust";
            this.panel_ust.Size = new System.Drawing.Size(1056, 118);
            this.panel_ust.TabIndex = 24;
            this.panel_ust.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_ust_Paint);
            // 
            // button_copkutusu
            // 
            this.button_copkutusu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_copkutusu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_copkutusu.FlatAppearance.BorderSize = 0;
            this.button_copkutusu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_copkutusu.Image = global::sporsalonu.Properties.Resources.cop_kutusu;
            this.button_copkutusu.Location = new System.Drawing.Point(960, 12);
            this.button_copkutusu.Name = "button_copkutusu";
            this.button_copkutusu.Size = new System.Drawing.Size(48, 48);
            this.button_copkutusu.TabIndex = 7;
            this.button_copkutusu.TabStop = false;
            this.button_copkutusu.UseVisualStyleBackColor = true;
            this.button_copkutusu.Click += new System.EventHandler(this.button_copkutusu_Click);
            // 
            // button_sil
            // 
            this.button_sil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_sil.FlatAppearance.BorderSize = 0;
            this.button_sil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sil.Image = global::sporsalonu.Properties.Resources.sil_32px;
            this.button_sil.Location = new System.Drawing.Point(373, 81);
            this.button_sil.Name = "button_sil";
            this.button_sil.Size = new System.Drawing.Size(32, 32);
            this.button_sil.TabIndex = 6;
            this.button_sil.TabStop = false;
            this.button_sil.UseVisualStyleBackColor = true;
            this.button_sil.Click += new System.EventHandler(this.button_sil_Click);
            // 
            // button_ekle
            // 
            this.button_ekle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ekle.FlatAppearance.BorderSize = 0;
            this.button_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ekle.Image = global::sporsalonu.Properties.Resources.ekle_32px;
            this.button_ekle.Location = new System.Drawing.Point(325, 81);
            this.button_ekle.Name = "button_ekle";
            this.button_ekle.Size = new System.Drawing.Size(32, 32);
            this.button_ekle.TabIndex = 5;
            this.button_ekle.TabStop = false;
            this.button_ekle.UseVisualStyleBackColor = true;
            this.button_ekle.Click += new System.EventHandler(this.button_ekle_Click);
            // 
            // button_güncelle
            // 
            this.button_güncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_güncelle.FlatAppearance.BorderSize = 0;
            this.button_güncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_güncelle.Image = global::sporsalonu.Properties.Resources.guncelle;
            this.button_güncelle.Location = new System.Drawing.Point(421, 81);
            this.button_güncelle.Name = "button_güncelle";
            this.button_güncelle.Size = new System.Drawing.Size(32, 32);
            this.button_güncelle.TabIndex = 4;
            this.button_güncelle.TabStop = false;
            this.button_güncelle.UseVisualStyleBackColor = true;
            this.button_güncelle.Click += new System.EventHandler(this.button_güncelle_Click);
            // 
            // button_yenile
            // 
            this.button_yenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_yenile.FlatAppearance.BorderSize = 0;
            this.button_yenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_yenile.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_yenile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.button_yenile.Image = global::sporsalonu.Properties.Resources.yenile_32px;
            this.button_yenile.Location = new System.Drawing.Point(277, 81);
            this.button_yenile.Name = "button_yenile";
            this.button_yenile.Size = new System.Drawing.Size(32, 32);
            this.button_yenile.TabIndex = 0;
            this.button_yenile.TabStop = false;
            this.button_yenile.UseVisualStyleBackColor = true;
            this.button_yenile.Click += new System.EventHandler(this.button_yenile_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::sporsalonu.Properties.Resources.düzenle;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 183;
            // 
            // tanimlama_kullanici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1056, 721);
            this.Controls.Add(this.panel_sunum);
            this.Controls.Add(this.panel_ust);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "tanimlama_kullanici";
            this.Text = "tanimlama_kullanici";
            this.Load += new System.EventHandler(this.tanimlama_kullanici_Load);
            this.Resize += new System.EventHandler(this.tanimlama_kullanici_Resize);
            this.panel_sunum.ResumeLayout(false);
            this.panel_sunum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.veriListesi)).EndInit();
            this.panel_ust.ResumeLayout(false);
            this.panel_ust.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_sunum;
        private System.Windows.Forms.Label label_adet;
        private System.Windows.Forms.DataGridView veriListesi;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Label label_copadet;
        private System.Windows.Forms.Label label_ara;
        private System.Windows.Forms.TextBox textBox_ara;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button_copkutusu;
        private System.Windows.Forms.Button button_sil;
        private System.Windows.Forms.Button button_ekle;
        private System.Windows.Forms.Button button_güncelle;
        private System.Windows.Forms.Button button_yenile;
        private System.Windows.Forms.Panel panel_ust;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}
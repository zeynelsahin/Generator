
namespace Generator.UI.WF
{
    partial class FormObjectResultAdd
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelPresentation = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.LblSonuc = new System.Windows.Forms.Label();
            this.DgwObject = new System.Windows.Forms.DataGridView();
            this.LblAdet = new System.Windows.Forms.Label();
            this.label_copadet = new System.Windows.Forms.Label();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.PanelThird = new System.Windows.Forms.Panel();
            this.PanelSecond = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.PanelFirst = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.PanelPresentation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwObject)).BeginInit();
            this.PanelTop.SuspendLayout();
            this.PanelSecond.SuspendLayout();
            this.PanelFirst.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelPresentation
            // 
            this.PanelPresentation.Controls.Add(this.label25);
            this.PanelPresentation.Controls.Add(this.button2);
            this.PanelPresentation.Controls.Add(this.LblSonuc);
            this.PanelPresentation.Controls.Add(this.DgwObject);
            this.PanelPresentation.Controls.Add(this.LblAdet);
            this.PanelPresentation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPresentation.ForeColor = System.Drawing.Color.Black;
            this.PanelPresentation.Location = new System.Drawing.Point(0, 248);
            this.PanelPresentation.Name = "PanelPresentation";
            this.PanelPresentation.Size = new System.Drawing.Size(1493, 552);
            this.PanelPresentation.TabIndex = 27;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Enabled = false;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label25.ForeColor = System.Drawing.Color.Silver;
            this.label25.Location = new System.Drawing.Point(1196, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(106, 23);
            this.label25.TabIndex = 326;
            this.label25.Text = "Result Ekle\r\n";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::Generator.UI.WF.Properties.Resources.ekle_32px;
            this.button2.Location = new System.Drawing.Point(1162, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 325;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LblSonuc
            // 
            this.LblSonuc.BackColor = System.Drawing.Color.White;
            this.LblSonuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblSonuc.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSonuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.LblSonuc.Location = new System.Drawing.Point(0, 0);
            this.LblSonuc.Name = "LblSonuc";
            this.LblSonuc.Size = new System.Drawing.Size(1493, 40);
            this.LblSonuc.TabIndex = 307;
            this.LblSonuc.Text = "Sonuç";
            this.LblSonuc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DgwObject
            // 
            this.DgwObject.AllowUserToAddRows = false;
            this.DgwObject.AllowUserToDeleteRows = false;
            this.DgwObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgwObject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgwObject.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgwObject.BackgroundColor = System.Drawing.Color.White;
            this.DgwObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgwObject.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgwObject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgwObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgwObject.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgwObject.Location = new System.Drawing.Point(12, 90);
            this.DgwObject.Name = "DgwObject";
            this.DgwObject.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgwObject.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgwObject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgwObject.Size = new System.Drawing.Size(1469, 350);
            this.DgwObject.TabIndex = 1;
            // 
            // LblAdet
            // 
            this.LblAdet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblAdet.AutoSize = true;
            this.LblAdet.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAdet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.LblAdet.Location = new System.Drawing.Point(12, 337);
            this.LblAdet.Name = "LblAdet";
            this.LblAdet.Size = new System.Drawing.Size(109, 30);
            this.LblAdet.TabIndex = 81;
            this.LblAdet.Text = "Toplam ";
            // 
            // label_copadet
            // 
            this.label_copadet.AutoSize = true;
            this.label_copadet.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_copadet.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_copadet.Location = new System.Drawing.Point(1493, 40);
            this.label_copadet.Name = "label_copadet";
            this.label_copadet.Size = new System.Drawing.Size(0, 24);
            this.label_copadet.TabIndex = 73;
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.PanelThird);
            this.PanelTop.Controls.Add(this.PanelSecond);
            this.PanelTop.Controls.Add(this.PanelFirst);
            this.PanelTop.Controls.Add(this.label_copadet);
            this.PanelTop.Controls.Add(this.label19);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(1493, 248);
            this.PanelTop.TabIndex = 26;
            // 
            // PanelThird
            // 
            this.PanelThird.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelThird.Location = new System.Drawing.Point(993, 40);
            this.PanelThird.Margin = new System.Windows.Forms.Padding(0);
            this.PanelThird.Name = "PanelThird";
            this.PanelThird.Size = new System.Drawing.Size(499, 208);
            this.PanelThird.TabIndex = 308;
            // 
            // PanelSecond
            // 
            this.PanelSecond.Controls.Add(this.panel27);
            this.PanelSecond.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSecond.Location = new System.Drawing.Point(499, 40);
            this.PanelSecond.Margin = new System.Windows.Forms.Padding(0);
            this.PanelSecond.Name = "PanelSecond";
            this.PanelSecond.Size = new System.Drawing.Size(494, 208);
            this.PanelSecond.TabIndex = 307;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel27.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel27.Location = new System.Drawing.Point(484, 0);
            this.panel27.Margin = new System.Windows.Forms.Padding(0);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(10, 208);
            this.panel27.TabIndex = 301;
            // 
            // PanelFirst
            // 
            this.PanelFirst.Controls.Add(this.panel19);
            this.PanelFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelFirst.Location = new System.Drawing.Point(0, 40);
            this.PanelFirst.Margin = new System.Windows.Forms.Padding(0);
            this.PanelFirst.Name = "PanelFirst";
            this.PanelFirst.Size = new System.Drawing.Size(499, 208);
            this.PanelFirst.TabIndex = 211;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel19.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel19.Location = new System.Drawing.Point(489, 0);
            this.panel19.Margin = new System.Windows.Forms.Padding(0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(10, 208);
            this.panel19.TabIndex = 301;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(1493, 40);
            this.label19.TabIndex = 306;
            this.label19.Text = "Object Ekle";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 183;
            // 
            // FormObjectResultAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1493, 800);
            this.Controls.Add(this.PanelPresentation);
            this.Controls.Add(this.PanelTop);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormObjectResultAdd";
            this.ShowIcon = false;
            this.Text = "Nesne Ekle";
            this.Load += new System.EventHandler(this.FormObjectResultAdd_Load);
            this.SizeChanged += new System.EventHandler(this.FormObjectResultAdd_SizeChanged);
            this.PanelPresentation.ResumeLayout(false);
            this.PanelPresentation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwObject)).EndInit();
            this.PanelTop.ResumeLayout(false);
            this.PanelTop.PerformLayout();
            this.PanelSecond.ResumeLayout(false);
            this.PanelFirst.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel PanelPresentation;
        private System.Windows.Forms.Label LblAdet;
        private System.Windows.Forms.DataGridView DgwObject;
        private System.Windows.Forms.Label label_copadet;
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Panel PanelFirst;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel PanelSecond;
        private System.Windows.Forms.TextBox Tbx;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Panel PanelThird;
        private System.Windows.Forms.Label LblSonuc;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button button2;
    }
}
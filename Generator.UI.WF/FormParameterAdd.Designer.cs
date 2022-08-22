
namespace Generator.UI.WF
{
    partial class FormParameterAdd
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
            this.PanelPresentation = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnParameterFind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnParameterAdd = new System.Windows.Forms.Button();
            this.LblSonuc = new System.Windows.Forms.Label();
            this.DgwObject = new System.Windows.Forms.DataGridView();
            this.LblAdet = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.PanelThird = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.PanelSecond = new System.Windows.Forms.Panel();
            this.PanelFirst = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelPresentation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwObject)).BeginInit();
            this.PanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelPresentation
            // 
            this.PanelPresentation.Controls.Add(this.label1);
            this.PanelPresentation.Controls.Add(this.BtnParameterFind);
            this.PanelPresentation.Controls.Add(this.label3);
            this.PanelPresentation.Controls.Add(this.BtnParameterAdd);
            this.PanelPresentation.Controls.Add(this.LblSonuc);
            this.PanelPresentation.Controls.Add(this.DgwObject);
            this.PanelPresentation.Controls.Add(this.LblAdet);
            this.PanelPresentation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPresentation.ForeColor = System.Drawing.Color.Black;
            this.PanelPresentation.Location = new System.Drawing.Point(0, 248);
            this.PanelPresentation.Name = "PanelPresentation";
            this.PanelPresentation.Size = new System.Drawing.Size(1499, 552);
            this.PanelPresentation.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(984, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 334;
            this.label1.Text = "Parametreleri Bul";
            // 
            // BtnParameterFind
            // 
            this.BtnParameterFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnParameterFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnParameterFind.FlatAppearance.BorderSize = 0;
            this.BtnParameterFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParameterFind.Image = global::Generator.UI.WF.Properties.Resources.arama;
            this.BtnParameterFind.Location = new System.Drawing.Point(946, 8);
            this.BtnParameterFind.Name = "BtnParameterFind";
            this.BtnParameterFind.Size = new System.Drawing.Size(32, 32);
            this.BtnParameterFind.TabIndex = 333;
            this.BtnParameterFind.UseVisualStyleBackColor = true;
            this.BtnParameterFind.Click += new System.EventHandler(this.BtnParameterFind_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(1195, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 23);
            this.label3.TabIndex = 332;
            this.label3.Text = "Parametreleri Veritabanına Ekle\r\n";
            // 
            // BtnParameterAdd
            // 
            this.BtnParameterAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnParameterAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnParameterAdd.FlatAppearance.BorderSize = 0;
            this.BtnParameterAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParameterAdd.Image = global::Generator.UI.WF.Properties.Resources.ekle_32px;
            this.BtnParameterAdd.Location = new System.Drawing.Point(1157, 6);
            this.BtnParameterAdd.Name = "BtnParameterAdd";
            this.BtnParameterAdd.Size = new System.Drawing.Size(32, 32);
            this.BtnParameterAdd.TabIndex = 331;
            this.BtnParameterAdd.UseVisualStyleBackColor = true;
            this.BtnParameterAdd.Click += new System.EventHandler(this.BtnParameterAdd_Click);
            // 
            // LblSonuc
            // 
            this.LblSonuc.BackColor = System.Drawing.Color.White;
            this.LblSonuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblSonuc.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSonuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.LblSonuc.Location = new System.Drawing.Point(0, 0);
            this.LblSonuc.Name = "LblSonuc";
            this.LblSonuc.Size = new System.Drawing.Size(1499, 40);
            this.LblSonuc.TabIndex = 307;
            this.LblSonuc.Text = "Sonuc";
            this.LblSonuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.DgwObject.Location = new System.Drawing.Point(12, 64);
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
            this.DgwObject.Size = new System.Drawing.Size(1475, 100);
            this.DgwObject.TabIndex = 1;
            // 
            // LblAdet
            // 
            this.LblAdet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblAdet.AutoSize = true;
            this.LblAdet.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAdet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.LblAdet.Location = new System.Drawing.Point(3, 180);
            this.LblAdet.Name = "LblAdet";
            this.LblAdet.Size = new System.Drawing.Size(109, 30);
            this.LblAdet.TabIndex = 81;
            this.LblAdet.Text = "Toplam ";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 183;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // PanelThird
            // 
            this.PanelThird.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelThird.Location = new System.Drawing.Point(998, 40);
            this.PanelThird.Margin = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.PanelThird.Name = "PanelThird";
            this.PanelThird.Size = new System.Drawing.Size(499, 196);
            this.PanelThird.TabIndex = 308;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(1499, 40);
            this.label19.TabIndex = 306;
            this.label19.Text = "Parametre Ekle";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.PanelThird);
            this.PanelTop.Controls.Add(this.PanelSecond);
            this.PanelTop.Controls.Add(this.PanelFirst);
            this.PanelTop.Controls.Add(this.label19);
            this.PanelTop.Controls.Add(this.panel1);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(1499, 248);
            this.PanelTop.TabIndex = 30;
            // 
            // PanelSecond
            // 
            this.PanelSecond.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSecond.Location = new System.Drawing.Point(499, 40);
            this.PanelSecond.Margin = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.PanelSecond.Name = "PanelSecond";
            this.PanelSecond.Size = new System.Drawing.Size(499, 196);
            this.PanelSecond.TabIndex = 307;
            // 
            // PanelFirst
            // 
            this.PanelFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelFirst.Location = new System.Drawing.Point(0, 40);
            this.PanelFirst.Margin = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.PanelFirst.Name = "PanelFirst";
            this.PanelFirst.Size = new System.Drawing.Size(499, 196);
            this.PanelFirst.TabIndex = 309;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 236);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1499, 12);
            this.panel1.TabIndex = 310;
            // 
            // FormParameterAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1499, 800);
            this.Controls.Add(this.PanelPresentation);
            this.Controls.Add(this.PanelTop);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormParameterAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paramere Ekle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.FormParameterAdd_SizeChanged);
            this.PanelPresentation.ResumeLayout(false);
            this.PanelPresentation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwObject)).EndInit();
            this.PanelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelPresentation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnParameterFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnParameterAdd;
        private System.Windows.Forms.Label LblSonuc;
        private System.Windows.Forms.DataGridView DgwObject;
        private System.Windows.Forms.Label LblAdet;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel PanelThird;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Panel PanelSecond;
        private System.Windows.Forms.Panel PanelFirst;
        private System.Windows.Forms.Panel panel1;
    }
}
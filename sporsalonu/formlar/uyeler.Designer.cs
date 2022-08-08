namespace sporsalonu.formlar
{
    partial class uyeler
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
            this.panel_sunum = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_sunum
            // 
            this.panel_sunum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sunum.ForeColor = System.Drawing.Color.Black;
            this.panel_sunum.Location = new System.Drawing.Point(0, 0);
            this.panel_sunum.Name = "panel_sunum";
            this.panel_sunum.Size = new System.Drawing.Size(1040, 682);
            this.panel_sunum.TabIndex = 28;
            this.panel_sunum.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel_sunum_ControlAdded);
            this.panel_sunum.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panel_sunum_ControlRemoved);
            // 
            // uyeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 682);
            this.Controls.Add(this.panel_sunum);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(109)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "uyeler";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.uyeler_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_sunum;
    }
}
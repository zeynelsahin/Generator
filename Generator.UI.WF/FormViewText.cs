using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Generator.UI.WF
{
    public partial class FormViewText : Form
    {
        public FormViewText()
        {
            InitializeComponent();
        }

        public string TextValue { get; set; }

        private void FormViewText_Load(object sender, EventArgs e)
        {
            Text.Text = TextValue;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Generator.UI.WF
{
    public partial class FormHomePage : Form
    {
        public FormHomePage()
        {
            InitializeComponent();
        }

        private void BtnUxGenerate_Click(object sender, EventArgs e)
        {
            var formUxGenerator = new FormUxGenerator();
            formUxGenerator.Show();
        }
    }
}
using System;
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
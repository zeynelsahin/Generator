using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Generator.Business.Concrete;
using Generator.Business.Constants;
using Generator.DataAccess.Concrete;
using Generator.Entities;

namespace Generator.UI.WF
{
    public partial class FormLogin : Form
    {
        private List<Profile> _profiles;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (_profiles == null)
            {
                LblMessage.Text = Messages.ProfileNotFound;
                return;
            }

            var profile = _profiles.FirstOrDefault(profile =>
                profile.UserName == TbxUserName.Text && profile.Password == TbxPassword.Text);

            if (profile != null)
            {
                Hide();
                var formHomeScreen = new FormObjectAddUpdate(profile);
                formHomeScreen.Show();
            }
            else
            {
                LblMessage.Text = Messages.UserNotFound;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // profiles.json profiller çekliyor
            try
            {
                var jsonString = File.ReadAllText(@"../../../profiles.json");
                _profiles = JsonSerializer.Deserialize<List<Profile>>(jsonString);
                LblMessage.Text = "";
            }
            catch
            {
                _profiles = null;
            }
        }

        private void TbxUserName_TextChanged(object sender, EventArgs e)
        {
            if (TbxUserName.Text != "")
                LblUserName.Hide();
            else
                LblUserName.Show();
        }

        private void TbxPassword_TextChanged(object sender, EventArgs e)
        {
            if (TbxPassword.Text != "")
                LblPassword.Hide();
            else
                LblPassword.Show();
        }
    }
}
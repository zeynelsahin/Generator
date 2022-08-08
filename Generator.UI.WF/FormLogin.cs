using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.Business.Constants;
using Generator.DataAccess.Concrete;
using Generator.Entities;
using Newtonsoft.Json;

namespace Generator.UI.WF
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private List<Profile> _profiles;
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (_profiles == null)
            {
                LblMessage.Text = Messages.ProfileNotFound;
                return;
            }

            var profile = _profiles.FirstOrDefault(profile =>
                profile.UserName == TbxUserName.Text && profile.Password == TbxPassword.Text);

            if (profile!=null)
            {
                this.Hide();
                FormObjectAddUpdate formHomeScreen = new FormObjectAddUpdate(profile);
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
                string jsonString = File.ReadAllText(@"../../../profiles.json");
                _profiles = JsonConvert.DeserializeObject<List<Profile>>(jsonString);
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
            {
                LblUserName.Hide();
            }
            else
            {
                LblUserName.Show();
            }
        }

        private void TbxPassword_TextChanged(object sender, EventArgs e)
        {
            if (TbxPassword.Text != "")
            {
                LblPassword.Hide();
            }
            else
            {
                LblPassword.Show();
            }
        }
    }
}

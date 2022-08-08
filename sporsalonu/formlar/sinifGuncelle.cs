using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class sinifGuncelle : Form
    {
        public sinifGuncelle()
        {
            InitializeComponent();
        }
        sqlSinif sqlSinif = new sqlSinif();
        private void listBox_veriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "";

                komut = "select ad ,kapasite,fiyat,durum  from siniflar where  sinif_id= ('" + listBox_veriler.SelectedItem + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac()); ;
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    textBox_id.Text = listBox_veriler.SelectedItem.ToString();
                    textBox_ad.Text = dr["ad"].ToString();
                    textBox_kapasite.Text = dr["kapasite"].ToString();
                    textBox_fiyat.Text = dr["fiyat"].ToString();
                    if (dr["durum"].ToString() == "False")
                    {
                        aktifbuttongizle();
                        pasifbuttongöster();
                    }
                    else
                    {
                        pasifbuttonfgizle();
                        aktifbuttongöster();
                    }
                }
                sqlSinif.Close();
            }
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "update siniflar set  ad=@p1, kapasite=@p2 ,durum=@p3,fiyat=@p4 where  sinif_id= ('" + textBox_id.Text + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac());
                kmt.Parameters.AddWithValue("@p1", textBox_ad.Text);
                kmt.Parameters.AddWithValue("@p2", textBox_kapasite.Text);
                if (button_aktif.Enabled == true)
                {
                    kmt.Parameters.AddWithValue("@p3", "True");
                }
                else
                {
                    kmt.Parameters.AddWithValue("@p3", "False");
                }
                kmt.Parameters.AddWithValue("@p4", textBox_fiyat.Text);

                kmt.ExecuteNonQuery();
                sqlSinif.Close();
                MessageBox.Show("Kayıt Güncellendi");
            }
        }
        private void aktifbuttongizle()
        {
            button_aktif.BackColor = Color.Transparent;
            button_aktif.Text = "";
            button_aktif.Enabled = false;
        }

        private void pasifbuttongöster()
        {
            button_pasif.Enabled = true;
            button_pasif.BackColor = Color.FromArgb(108, 170, 157);
            button_pasif.Text = "Pasif";
        }

        private void pasifbuttonfgizle()
        {
            button_pasif.Enabled = false;
            button_pasif.BackColor = Color.Transparent;
            button_pasif.Text = "";
        }
        private void button_pasif_Click(object sender, EventArgs e)
        {
            pasifbuttonfgizle();
            aktifbuttongöster();
        }

        private void aktifbuttongöster()
        {
            button_aktif.BackColor = Color.FromArgb(35, 128, 109);
            button_aktif.Text = "Aktif";
            button_aktif.Enabled = true;
        }

        private void sinifGuncell_Load(object sender, EventArgs e)
        {
            foreach (var item in sqlSinif.secilenlerListe)
            {
                listBox_veriler.Items.Add(item);
            }

            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "";

                komut = "select ad ,kapasite,fiyat,durum  from siniflar where  sinif_id= ('" + listBox_veriler.Items[0] + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac()); ;
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    textBox_id.Text = listBox_veriler.Items[0].ToString();
                    textBox_ad.Text = dr["ad"].ToString();
                    textBox_kapasite.Text = dr["kapasite"].ToString();
                    textBox_fiyat.Text = dr["fiyat"].ToString();

                    if (dr["durum"].ToString() == "False")
                    {
                        aktifbuttongizle();
                        pasifbuttongöster();
                    }
                    else
                    {
                        pasifbuttonfgizle();
                        aktifbuttongöster();
                    }
                }
                sqlSinif.Close();
            }
        }

        private void button_aktif_Click(object sender, EventArgs e)
        {
            aktifbuttongizle();
            pasifbuttongöster();
        }

        private void button_pasif_Click_1(object sender, EventArgs e)
        {
            pasifbuttonfgizle();
            aktifbuttongöster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

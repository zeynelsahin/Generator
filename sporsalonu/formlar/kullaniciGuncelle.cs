using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class kullaniciGuncelle : Form
    {
        public kullaniciGuncelle()
        {
            InitializeComponent();
        }
        sqlSinif sqlSinif = new sqlSinif();
        private void listBox_veriler_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "";

                komut = "select kullanici_id , kullanici_ad, sifre , ad,soyad from kullanicilar where  kullanici_id= ('" + listBox_veriler.SelectedItem + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac()); ;
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    textBox_id.Text = listBox_veriler.SelectedItem.ToString();
                    textBox_kullanici.Text = dr["kullanici_ad"].ToString();
                    textBox_sifre.Text = dr["sifre"].ToString();
                    textBox_soyad.Text = dr["soyad"].ToString();
                    textBox_ad.Text = dr["ad"].ToString();

                }
                sqlSinif.Close();
            }
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "update kullanicilar set  kullanici_ad=@p1, sifre=@p2 ,ad=@p3,soyad=@p4  where  kullanici_id= ('" + textBox_id.Text + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac());
                kmt.Parameters.AddWithValue("@p1", textBox_kullanici.Text);
                kmt.Parameters.AddWithValue("@p2", textBox_sifre.Text);
                kmt.Parameters.AddWithValue("@p3", textBox_ad.Text);
                kmt.Parameters.AddWithValue("@p4", textBox_soyad.Text);
                kmt.ExecuteNonQuery();
                sqlSinif.Close();
                MessageBox.Show("Kayıt Güncellendi");
            }
        }

        private void kullaniciGuncell_Load(object sender, EventArgs e)
        {

            foreach (var item in sqlSinif.secilenlerListe)
            {
                listBox_veriler.Items.Add(item);
            }

            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "";

                komut = "select kullanici_id , kullanici_ad, sifre , ad,soyad from kullanicilar where  kullanici_id= ('" + listBox_veriler.Items[0] + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac()); ;
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    textBox_id.Text = listBox_veriler.Items[0].ToString();
                    textBox_kullanici.Text = dr["kullanici_ad"].ToString();
                    textBox_sifre.Text = dr["sifre"].ToString();
                    textBox_soyad.Text = dr["soyad"].ToString();
                    textBox_ad.Text = dr["ad"].ToString();
                }
                sqlSinif.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

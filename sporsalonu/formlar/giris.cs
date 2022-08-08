using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        sqlSinif sqlSinif = new sqlSinif();
        private void button2_Click(object sender, EventArgs e)
        {
            string kmt = "select *from kullanicilar where kullanici_ad=@p1 and sifre=@p2 ";
            SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            komut.Parameters.AddWithValue("@p1", textBox_kullanici.Text);
            komut.Parameters.AddWithValue("@p2", textBox_sifre.Text);
            SqlDataReader da = komut.ExecuteReader();
            if (da.Read())
            {
                this.Hide();
                anaSayfa anaSayfa = new anaSayfa();
                anaSayfa.kullaniciId = Convert.ToInt32(da["kullanici_id"]);
                anaSayfa.Show();
            }
            else
            {
                label_hata.Show();
            }
            sqlSinif.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_kullanici.Text != "")
            {
                label_kullanici.Hide();
            }
            else
            {
                label_kullanici.Show();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_kullanici.Text != "")
            {
                label_sifre.Hide();
            }
            else
            {
                label_sifre.Show();
            }
        }
    }
}

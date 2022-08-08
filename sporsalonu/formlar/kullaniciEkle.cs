using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class kullaniciEkle : Form
    {
        public kullaniciEkle()
        {
            InitializeComponent();
        }
        sqlSinif sqlSinif = new sqlSinif();
        private void button_ekle_Click(object sender, EventArgs e)
        {
            if (textBox_ad.Text != "" || textBox_ad.Text != null && textBox_soyad.Text != "" || textBox_soyad.Text != null && textBox_sifre.Text != "" || textBox_sifre.Text != null && textBox_kullanici.Text != "" || textBox_kullanici.Text != null)
            {
                string kmt = "insert into kullanicilar (kullanici_ad,sifre,ad,soyad) values(@p1,@p2,@p3,@p4) ";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", textBox_kullanici.Text);
                komut.Parameters.AddWithValue("@p2", textBox_sifre.Text);
                komut.Parameters.AddWithValue("@p3", textBox_ad.Text);
                komut.Parameters.AddWithValue("@p4", textBox_soyad.Text);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
                timer_sonuc.Start();
                timer_sonuc.Interval = 10;
                textBox_soyad.Text = "";
                textBox_ad.Text = "";
                textBox_kullanici.Text = "";
                textBox_sifre.Text = "";
            }
            textBox_ad.Focus();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int sayac = 0;

        private void timer_sonuc_Tick(object sender, EventArgs e)
        {
            if (sayac == 20)
            {
                label_sonuc.Text = "";
                timer_sonuc.Stop();
                sayac = 0;
            }
            else
            {
                sayac++;
                label_sonuc.Text = "Kayıt İşlemi Gerçekleşti";
            }
        }

        private void kullaniciEkle_Load(object sender, EventArgs e)
        {
            label_ad.Visible = false;
            label_kullanici.Visible = false;
            label_sifre.Visible = false;
            label_soyad.Visible = false;
        }
    }
}

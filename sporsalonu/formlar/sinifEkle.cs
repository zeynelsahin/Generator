using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class sinifEkle : Form
    {
        public sinifEkle()
        {
            InitializeComponent();
        }
        sqlSinif sqlSinif = new sqlSinif();
        private void button_ekle_Click(object sender, EventArgs e)
        {
            if (textBox_ad.Text != "" || textBox_ad.Text != null && textBox_kapasite.Text != "" || textBox_kapasite.Text != null && textBox_fiyat.Text != "" || textBox_fiyat.Text != null)
            {
                string kmt = "insert into siniflar (ad,kapasite,durum,fiyat) values(@p1,@p2,@p3,@p4) ";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", textBox_ad.Text);
                komut.Parameters.AddWithValue("@p2", textBox_kapasite.Text);
                if (button_aktif.Enabled == true)
                {
                    komut.Parameters.AddWithValue("@p3", 1);
                }
                else
                {
                    komut.Parameters.AddWithValue("@p3", 0);
                }
                komut.Parameters.AddWithValue("@p4", textBox_fiyat.Text); ;
                komut.ExecuteNonQuery();
                sqlSinif.Close();

                textBox_ad.Text = "";
                textBox_kapasite.Text = "";
                textBox_fiyat.Text = "";
            }
            textBox_ad.Focus();
        }
        private void aktifbuttongöster()
        {
            button_aktif.BackColor = Color.FromArgb(35, 128, 109);
            button_aktif.Text = "Aktif";
            button_aktif.Enabled = true;
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

        private void sinifEkle_Load(object sender, EventArgs e)
        {
            pasifbuttonfgizle();
            label_ad.Visible = false;
            label_fiyat.Visible = false;
            label_kapasite.Visible = false;
        }

        private void button_aktif_Click(object sender, EventArgs e)
        {
            aktifbuttongizle();
            pasifbuttongöster();
        }

        private void button_pasif_Click(object sender, EventArgs e)
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
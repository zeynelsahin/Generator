using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class uyeEkle : Form
    {
        public uyeEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        sqlSinif sqlSinif = new sqlSinif();

        private void button_ekle_Click(object sender, EventArgs e)
        {

            string kmt = "insert into uyeler (tcno,ad,soyad,cinsiyet,dogumtarihi,adres,il,ilce,telefon,telefon2,eposta,kangrubu) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)";
            SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            komut.Parameters.AddWithValue("@p1", maskedTextBox_tcno.Text);
            komut.Parameters.AddWithValue("@p2", textBox_ad.Text);
            komut.Parameters.AddWithValue("@p3", textBox_soyad.Text);
            if (radioButton_erkek.Checked)
            {
                komut.Parameters.AddWithValue("@p4", "Erkek");
            }
            else
            {
                komut.Parameters.AddWithValue("@p4", "Kadın");

            }
            komut.Parameters.AddWithValue("@p5", maskedTextBox_dogumta.Text);
            komut.Parameters.AddWithValue("@p6", textBox_adres.Text);
            komut.Parameters.AddWithValue("@p7", textBox_il.Text);
            komut.Parameters.AddWithValue("@p8", textBox_ilce.Text);
            komut.Parameters.AddWithValue("@p9", maskedTextBox1_telefon.Text);
            komut.Parameters.AddWithValue("@p10", maskedTextBox_telefon2.Text);
            komut.Parameters.AddWithValue("@p11", textBox4_eposta.Text);
            komut.Parameters.AddWithValue("@p12", comboBox_kangrub.Text);

            komut.ExecuteNonQuery();
            sqlSinif.Close();
            MessageBox.Show("Üye Eklendi");
            textBox_ad.Focus();
        }
    }
}

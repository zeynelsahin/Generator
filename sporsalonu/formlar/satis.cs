using sporsalonu.siniflar;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class satis : Form
    {
        public satis()
        {
            InitializeComponent();
        }
        public int uyeId { get; set; }
        sqlSinif sqlSinif = new sqlSinif();
        private void button_satisyap_Click(object sender, EventArgs e)
        {
            if (durumBos == true)
            {
                DateTime baslangic = dateTimePicker_baslangic.Value;
                DateTime bitis = Convert.ToDateTime(textBox_bitistar.Text);
                string kmt = "insert into satislar(baslanic_tarihi,bitis_tarihi,satis_fiyati,uye_id,sinif_id) values (@p1,@p2,@p3,@p4,@p5)";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", baslangic.ToString("yyyy.MM.dd"));
                komut.Parameters.AddWithValue("@p2", bitis.ToString("yyyy.MM.dd"));
                komut.Parameters.AddWithValue("@p3", textBox_fiyat.Text);
                komut.Parameters.AddWithValue("@p4", uyeId);
                komut.Parameters.AddWithValue("@p5", comboBox_sinif.SelectedValue);
                komut.ExecuteNonQuery();
                MessageBox.Show("Satış işlemi başarıyla gerçekleştirildi.");
                //int secili = comboBox_sinif.SelectedIndex;
                //comboBox_sinif.SelectedIndex++;
                //comboBox_sinif.SelectedIndex = secili;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz sınıf doludur.");
            }

        }
        private void satis_Load(object sender, EventArgs e)
        {
            string kmt = "select * from siniflar";
            SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_sinif.DataSource = dt;
            comboBox_sinif.ValueMember = "sinif_id";
            comboBox_sinif.DisplayMember = "ad";
            comboBox_sinif.Text = "Sınıf Seçiniz";
        }
        int fi;
        private void comboBox_sure_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kmt = "select fiyat siniflar where sinif_id=@p1";
            SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            //komut.Parameters.AddWithValue("@p1",)
            DateTime baslangic = DateTime.Parse(dateTimePicker_baslangic.Text);
            if (comboBox_sure.SelectedIndex < 12)
            {
                baslangic = baslangic.AddDays((comboBox_sure.SelectedIndex + 1) * 30);
                textBox_fiyat.Text = (fi * (comboBox_sure.SelectedIndex + 1)).ToString();
            }
            else
            {
                baslangic = baslangic.AddDays((comboBox_sure.SelectedIndex - 10) * 30 * 12);
                textBox_fiyat.Text = (fi * ((comboBox_sure.SelectedIndex - 10) * 12)).ToString();
            }
            textBox_bitistar.Text = baslangic.ToShortDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int sayac = 0;
        bool durumBos = true;
        private void comboBox_sinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sayac > 2)
            {
                //Seçilen sınıfın kapasitesi
                string kmt1 = "select kapasite from siniflar where sinif_id=@p1";
                SqlCommand komut1 = new SqlCommand(kmt1, sqlSinif.Baglanti_ac());
                komut1.Parameters.AddWithValue("@p1", comboBox_sinif.SelectedValue);
                string kapasite = komut1.ExecuteScalar().ToString();
                //Seçilen sınıfın toplam üye sayısı
                string kmt2 = "select count(*) from satislar where sinif_id=@p1 and durum=1";
                SqlCommand komut2 = new SqlCommand(kmt2, sqlSinif.Baglanti_ac());
                komut2.Parameters.AddWithValue("@p1", comboBox_sinif.SelectedValue);
                string toplamUye = komut2.ExecuteScalar().ToString();
                if (Convert.ToInt32(toplamUye) <= Convert.ToInt32(kapasite))
                {
                    string kmt = "select fiyat from siniflar where sinif_id=@p1";
                    SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                    komut.Parameters.AddWithValue("@p1", comboBox_sinif.SelectedValue);
                    string deger = komut.ExecuteScalar().ToString();
                    fi = Convert.ToInt32(deger);
                    textBox_fiyat.Text = fi.ToString();
                    durumBos = true;
                }
                else
                {
                    MessageBox.Show("Sınıf kapasitesi doludur.");
                    durumBos = false;
                }
            }
            else
            {
                sayac++;
            }

        }
        private void textBox_fiyat_Leave(object sender, EventArgs e)
        {
            if (textBox_fiyat.Text == "" || textBox_fiyat.Text == null)
            {

            }
            else
            {
                fi = Convert.ToInt32(textBox_fiyat.Text);
            }

        }
        private void textBox_fiyat_Enter(object sender, EventArgs e)
        {
            comboBox_sure.SelectedIndex = 0;
        }



    }
}

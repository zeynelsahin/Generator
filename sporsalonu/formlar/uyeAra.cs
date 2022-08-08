using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class uyeAra : Form
    {
        public uyeAra()
        {
            InitializeComponent();
        }
        sqlSinif sqlSinif = new sqlSinif();
        string komut = "select uye_id,tcno,ad,soyad,cinsiyet,telefon,eposta from uyeler where silme_durumu=0";
        string copkutuAdet = "select count(*) from uyeler where silme_durumu=1";

        void VerilerVeAdet()
        {
            sqlSinif.veriListele(komut, veriListesi, label_adet);
            sqlSinif.copkutuAdet(copkutuAdet, label_copadet);
        }
        public string aranacakAd { get; set; }
        private void uyeAra_Load(object sender, EventArgs e)
        {
            textBox_ara.Focus();
            int id;
            comboBox_sinif.SelectedIndex = 0;
            sqlSinif.siniflar.Clear();
            string kmt = "select * from siniflar where silme_durumu=0";
            SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox_sinif.Items.Add(dr["ad"]);
                id = Convert.ToInt32(dr["sinif_id"]);
                sqlSinif.siniflar.Add(id);
            }
            sqlSinif.Close();
            if (aranacakAd == "")
            {
                VerilerVeAdet();
            }
            else
            {
                textBox_ara.Text = aranacakAd;
                arama();
            }

        }
        public void arama()
        {

            string komut = "select uye_id,tcno,ad,soyad,cinsiyet,telefon,eposta from uyeler where silme_durumu=0";
            if (comboBox_sinif.SelectedIndex == 0)
            {
                komut += "and ad Like '%" + textBox_ara.Text + "%'";
            }
            else
            {
                komut = "select uyeler.uye_id,tcno,ad,soyad,cinsiyet,telefon,eposta from uyeler inner join satislar on satislar.uye_id=uyeler.uye_id where satislar.sinif_id= '" + sqlSinif.siniflar[comboBox_sinif.SelectedIndex - 1] + "' and uyeler.ad like '%" + textBox_ara.Text + "%'";
            }
            sqlSinif.veriListele(komut, veriListesi, label_adet);
            sqlSinif.copkutuAdet(copkutuAdet, label_copadet);

        }
        private void button_copkutusu_Click(object sender, EventArgs e)
        {

            copKutusu copKutusu = new copKutusu();
            copKutusu.gelenForm = 4;
            copKutusu.ShowDialog();
            arama();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            uyeEkle uyeEkle = new uyeEkle();
            uyeEkle.ShowDialog();
            VerilerVeAdet();
        }

        private void button_yenile_Click(object sender, EventArgs e)
        {
            VerilerVeAdet();
            comboBox_sinif.SelectedIndex = 0;
            textBox_ara.Text = "";
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenler(veriListesi);//DataGridView deki seçilenler
            foreach (var item in sqlSinif.secilenlerListe)
            {
                int id = Convert.ToInt32(item);
                string kmt = "update uyeler set silme_durumu=1 where uye_id=@p1";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", id);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
                //tekrardan listeyi yenelemek yerine secilenler listeden siliniyor
            }
            sqlSinif.secilenleriListedenSil(veriListesi, label_adet);
            sqlSinif.copkutuAdet(copkutuAdet, label_copadet);
        }

        private void veriListesi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void uyeAra_Resize(object sender, EventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void textBox_ara_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ara.Text != "")
            {
                label_ara.Visible = false;

            }
            else
            {
                label_ara.Visible = true;
            }
            arama();
        }

        private void comboBox_sinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void veriListesi_DoubleClick(object sender, EventArgs e)
        {
            sqlSinif.secilenler(veriListesi);
            this.Close();
        }

        private void veriListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

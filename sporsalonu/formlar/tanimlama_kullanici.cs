using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class tanimlama_kullanici : Form
    {
        public tanimlama_kullanici()
        {
            InitializeComponent();
        }
        sqlSinif sqlSinif = new sqlSinif();

        string komut = "select kullanici_id as İd, kullanici_ad as '" + "Kullanıcı Adı" + "', sifre as Şifre, ad as Ad,soyad as Soyad from kullanicilar where silme_durumu=0";
        string copkutuAdet = "select count(*) from kullanicilar where silme_durumu=1";

        void VerilerVeAdet()
        {
            sqlSinif.veriListele(komut, veriListesi, label_adet);
            sqlSinif.copkutuAdet(copkutuAdet, label_copadet);
        }
        private void veriListesi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            kullaniciEkle kullaniciEkle = new kullaniciEkle();
            kullaniciEkle.ShowDialog();
            sqlSinif.veriListele(komut, veriListesi, label_adet);
        }

        private void button_yenile_Click(object sender, EventArgs e)
        {
            VerilerVeAdet();
        }

        private void button_copkutusu_Click(object sender, EventArgs e)
        {
            copKutusu copKutusu = new copKutusu();
            copKutusu.gelenForm = 2;
            copKutusu.ShowDialog();
            VerilerVeAdet();
        }

        private void tanimlama_kullanici_Load(object sender, EventArgs e)
        {
            VerilerVeAdet();
            textBox_ara.Focus();
        }

        private void textBox_ara_TextChanged(object sender, EventArgs e)
        {
            string komut = "select kullanici_id as İd, kullanici_ad as '" + "Kullanıcı Adı" + "', sifre as Şifre, ad as Ad,soyad as Soyad from kullanicilar where silme_durumu=0";
            if (textBox_ara.Text != "")
            {
                label_ara.Visible = false;

            }
            else
            {
                label_ara.Visible = true;
            }
            komut += "and kullanici_ad Like '%" + textBox_ara.Text + "%'";
            sqlSinif.veriListele(komut, veriListesi, label_adet);
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenler(veriListesi);//DataGridView deki seçilenler
            foreach (var item in sqlSinif.secilenlerListe)
            {
                int id = Convert.ToInt32(item);
                string kmt = "update kullanicilar set silme_durumu=1 where kullanici_id=@p1";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", id);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
                //tekrardan listeyi yenelemek yerine secilenler listeden siliniyor
            }
            sqlSinif.secilenleriListedenSil(veriListesi, label_adet);
            sqlSinif.copkutuAdet(copkutuAdet, label_copadet);
        }

        private void button_güncelle_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenler(veriListesi);
            sinifGuncelle kullaniciGuncelle = new sinifGuncelle();
            kullaniciGuncelle.ShowDialog();
            VerilerVeAdet();
        }

        private void tanimlama_kullanici_Resize(object sender, EventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);

        }

        private void panel_sunum_SizeChanged(object sender, EventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void panel_ust_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

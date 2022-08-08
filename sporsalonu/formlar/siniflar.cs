using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class siniflar : Form
    {
        public siniflar()
        {
            InitializeComponent();
        }
        string komut = "select sinif_id as İd, ad as '" + "Ad" + "', kapasite as Kapasite,fiyat as Fiyat, durum '" + "Aktif/Pasif" + "' from siniflar where silme_durumu=0";
        string copkutuAdet = "select count(*) from siniflar where silme_durumu=1";
        sqlSinif sqlSinif = new sqlSinif();
        void VerilerVeAdet()
        {
            sqlSinif.veriListele(komut, veriListesi, label_adet);
            sqlSinif.copkutuAdet(copkutuAdet, label_copadet);
        }
        private void siniflar_Load(object sender, EventArgs e)
        {
            VerilerVeAdet();
        }

        private void veriListesi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            sinifEkle sinifEkle = new sinifEkle();
            sinifEkle.ShowDialog();
            VerilerVeAdet();
        }

        private void button_yenile_Click(object sender, EventArgs e)
        {
            VerilerVeAdet();
        }

        private void button_copkutusu_Click(object sender, EventArgs e)
        {
            copKutusu copKutusu = new copKutusu();
            copKutusu.gelenForm = 3;
            copKutusu.ShowDialog();
            VerilerVeAdet();
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenler(veriListesi);//DataGridView deki seçilenler
            foreach (var item in sqlSinif.secilenlerListe)
            {
                int id = Convert.ToInt32(item);
                string kmt = "update siniflar set silme_durumu=1 where sinif_id=@p1";
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
            sinifGuncelle sinifGuncelle = new sinifGuncelle();
            sinifGuncelle.ShowDialog();
            VerilerVeAdet();
        }


    }
}

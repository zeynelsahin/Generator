using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class tanimlama_olcu_tur : Form
    {
        public tanimlama_olcu_tur()
        {
            InitializeComponent();
        }
        string komut = "select olcutur_id as İd,ad as Ad ,birim as Birim ,durum as'" + "Aktif/Pasif" + "' from olcu_turleri where durum=1 and silme_durumu=0";
        string komut1 = "select olcutur_id as İd,ad as Ad ,birim as Birim ,durum as '" + "Aktif/Pasif" + "' from olcu_turleri where silme_durumu=0";
        string copkutuAdet = "select count(*) from olcu_turleri where silme_durumu=1";
        sqlSinif sqlSinif = new sqlSinif();
        private void tanımlama_olcu_tur_Load(object sender, EventArgs e)
        {
            VerilerVeAdet();
            textBox_ara.Focus();

        }
        void VerilerVeAdet()
        {
            if (checkBox_aktif.Checked == true)
            {
                sqlSinif.veriListeleRenkli(komut, veriListesi, label_adet, 3);
            }
            else
            {
                sqlSinif.veriListeleRenkli(komut1, veriListesi, label_adet, 3);
            }
            sqlSinif.copkutuAdet(copkutuAdet, label_copadet);

        }
        private void checkBox_aktif_CheckedChanged(object sender, EventArgs e)
        {
            VerilerVeAdet();
            string ad = textBox_ara.Text;
            textBox_ara.Text = "";
            textBox_ara.Text = ad;
        }

        private void veriListesi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            olcuturuEkle frm = new olcuturuEkle();
            frm.ShowDialog();
            VerilerVeAdet();
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenler(veriListesi);//DataGridView deki seçilenler
            foreach (var item in sqlSinif.secilenlerListe)
            {
                int id = Convert.ToInt32(item);
                string kmt = "update olcu_turleri set silme_durumu=1 where olcutur_id=@p1";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", id);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
                //tekrardan listeyi yenelemek yerine secilenler listeden siliniyor
            }
            VerilerVeAdet();
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

            if (checkBox_aktif.Checked == true)
            {
                komut += "and ad Like '%" + textBox_ara.Text + "%'";
                sqlSinif.veriListeleRenkli(komut, veriListesi, label_adet, 3);
            }
            else
            {
                komut1 += "and ad Like '%" + textBox_ara.Text + "%'";
                sqlSinif.veriListeleRenkli(komut1, veriListesi, label_adet, 3);
            }
        }

        private void button_yenile_Click(object sender, EventArgs e)
        {
            VerilerVeAdet();
        }

        private void button_copkutusu_Click(object sender, EventArgs e)
        {
            copKutusu copKutusu = new copKutusu();
            copKutusu.gelenForm = 1;
            copKutusu.ShowDialog();
            VerilerVeAdet();
        }

        private void panel_sunum_SizeChanged(object sender, EventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void button_güncelle_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenler(veriListesi);
            olcuTurGuncelle olcuTurGuncelle = new olcuTurGuncelle();
            olcuTurGuncelle.ShowDialog();
            VerilerVeAdet();
        }

        private void tanimlama_olcu_tur_Resize(object sender, EventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }
    }
}

using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class copKutusu : Form
    {
        public copKutusu()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        sqlSinif sqlSinif = new sqlSinif();
        string kmt;

        string komut;
        public byte gelenForm { get; set; }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        void veriListele()
        {
            switch (gelenForm)
            {
                case 1: komut = "select olcutur_id as İd,ad as Ad ,birim as Birim ,durum as '" + "Aktif/Pasif" + "' from olcu_turleri where silme_durumu=1"; break;
                case 2: komut = "select kullanici_id as İd, kullanici_ad as '" + "Kullanıcı Adı" + "', sifre as Şifre, ad as Ad,soyad as Soyad from kullanicilar where silme_durumu = 1"; break;
                case 3: komut = "select sinif_id as İd, ad as '" + "Ad" + "', kapasite as Kapasite,fiyat as Fiyat, durum '" + "Aktif/Pasif" + "' from siniflar where silme_durumu=1"; break;
                case 4: komut = "select uye_id as İd,tcno as '" + "T.C No" + "',ad as Ad,soyad as Soyad,cinsiyet as Cinsiyet from uyeler where silme_durumu=1"; break;
            }
            sqlSinif.veriListele(komut, veriListesi, label_adet);
        }
        private void cop_kutusu_Load(object sender, EventArgs e)
        {
            veriListele();
        }


        private bool formboyut = true;

        private void button3_Click(object sender, EventArgs e)
        {
            if (formboyut == true)
            {
                this.WindowState = FormWindowState.Maximized;
                formboyut = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                formboyut = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_üst_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            formboyut = true;
        }

        private void button_geriyukle_Click(object sender, EventArgs e)
        {

            sqlSinif.secilenler(veriListesi);
            foreach (var item in sqlSinif.secilenlerListe)
            {
                int id = Convert.ToInt32(item);
                switch (gelenForm)
                {
                    case 1: kmt = "update olcu_turleri set silme_durumu=0 where olcutur_id=@p1"; break;
                    case 2: kmt = "update kullanicilar set silme_durumu=0 where kullanici_id=@p1"; break;
                    case 3: kmt = "update siniflar set silme_durumu=0 where sinif_id=@p1"; break;
                    case 4: kmt = "update uyeler set silme_durumu=0 where uye_id=@p1"; break;

                }
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", id);
                komut.ExecuteNonQuery();
            }
            sqlSinif.secilenleriListedenSil(veriListesi, label_adet);

            sqlSinif.Close();
        }

        private void button_yenile_Click(object sender, EventArgs e)
        {
            veriListele();
        }

        private void veriListesi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            silinecekler silinecekler = new silinecekler();
            sqlSinif.secilenler(veriListesi);
            switch (gelenForm)
            {
                case 1: silinecekler.gelenForm = 1; break;
                case 2: silinecekler.gelenForm = 2; break;
                case 3: silinecekler.gelenForm = 3; break;
                case 4: silinecekler.gelenForm = 4; break;
            }
            silinecekler.ShowDialog();
            veriListele();
        }

        private void cop_kutusu_SizeChanged(object sender, EventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
        }

        private void button_hepsiniSil_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenlerListe.Clear();
            int id;
            switch (gelenForm)
            {
                case 1: komut = "select olcutur_id from olcu_turleri where silme_durumu=1"; break;
                case 2: komut = "select kullanici_id  from kullanicilar where silme_durumu = 1"; break;
                case 3: komut = "select sinif_id  from siniflar where silme_durumu=1"; break;
                case 4: komut = "select uye_id from uyeler where silme_durumu=1"; break;
            }
            SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac());
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt32(dr[0]);
                sqlSinif.secilenlerListe.Add(id);
            }
            sqlSinif.Close();
            silinecekler silinecekler = new silinecekler();
            switch (gelenForm)
            {
                case 1: silinecekler.gelenForm = 1; break;
                case 2: silinecekler.gelenForm = 2; break;
                case 3: silinecekler.gelenForm = 3; break;
                case 4: silinecekler.gelenForm = 4; break;
            }
            silinecekler.ShowDialog();
            veriListele();
        }

        private void button_hepsiniGeri_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenlerListe.Clear();
            int id;
            switch (gelenForm)
            {
                case 1: komut = "select olcutur_id from olcu_turleri where silme_durumu=1"; break;
                case 2: komut = "select kullanici_id  from kullanicilar where silme_durumu = 1"; break;
                case 3: komut = "select sinif_id  from siniflar where silme_durumu=1"; break;
                case 4: komut = "select uye_id from uyeler where silme_durumu=1"; break;
            }
            SqlCommand kmt1 = new SqlCommand(komut, sqlSinif.Baglanti_ac());
            SqlDataReader dr = kmt1.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt32(dr[0]);
                sqlSinif.secilenlerListe.Add(id);
            }
            sqlSinif.Close();

            switch (gelenForm)
            {

                case 1: kmt = "update olcu_turleri set silme_durumu=0 where olcutur_id=@p1"; break;
                case 2: kmt = "update kullanicilar set silme_durumu=0 where kullanici_id=@p1"; break;
                case 3: kmt = "update siniflar set silme_durumu=0 where sinif_id=@p1"; break;
                case 4: kmt = "update uyeler set silme_durumu=0 where uye_id=@p1"; break;
            }

            foreach (int item in sqlSinif.secilenlerListe)
            {
                SqlCommand komut2 = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                int id2 = Convert.ToInt32(item);
                komut2.Parameters.AddWithValue("@p1", id2);
                komut2.ExecuteNonQuery();

            }

            veriListele();
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
        }
    }
}

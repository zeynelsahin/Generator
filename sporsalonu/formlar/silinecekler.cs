using sporsalonu.siniflar;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class silinecekler : Form
    {
        public silinecekler()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        sqlSinif sqlSinif = new sqlSinif();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public byte gelenForm { get; set; }
        private void silinecekler_Load(object sender, EventArgs e)
        {
            string komut = "";
            DataTable dt = new DataTable();
            foreach (var item in sqlSinif.secilenlerListe)
            {

                switch (gelenForm)
                {
                    case 1: komut = "select olcutur_id as İd,ad as Ad ,birim as Birim ,durum as '" + "Aktif/Pasif" + "' from olcu_turleri where silme_durumu=1 and olcutur_id = ('" + item + "')  "; break;
                    case 2: komut = "select kullanici_id as İd, kullanici_ad as '" + "Kullanıcı Adı" + "', sifre as Şifre, ad as Ad,soyad as Soyad from kullanicilar where silme_durumu=1 and kullanici_id= ('" + item + "')  "; break;
                    case 3: komut = "select sinif_id as İd, ad as '" + "Ad" + "', kapasite as Kapasite,fiyat as Fiyat, durum '" + "Aktif/Pasif" + "' from siniflar where silme_durumu=1 and sinif_id=('" + item + "')"; break;
                    case 4: komut = "select uye_id as İd,tcno as '" + "T.C No" + "',ad as Ad,soyad as Soyad,cinsiyet as Cinsiyet from uyeler where silme_durumu=1 and uye_id=('" + item + "')"; break;

                }

                SqlDataAdapter da = new SqlDataAdapter(komut, sqlSinif.Baglanti_ac());
                da.Fill(dt);
            }
            veriListesi.DataSource = dt;
            sqlSinif.Close();
            sqlSinif.veriAdeti(veriListesi, label_adet);
            sqlSinif.veriAdeti(veriListesi, label_adet);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_tamam_Click(object sender, EventArgs e)
        {
            string komut = "";
            switch (gelenForm)
            {
                case 1: komut = "delete from olcu_turleri where olcutur_id=@p1"; break;
                case 2: komut = "delete from kullanicilar where kullanici_id=@p1"; break;
                case 3: komut = "delete from siniflar where sinif_id=@p1"; break;
                case 4: komut = "delete from uyeler where uye_id=@p1"; break;
            }
            try
            {
                sqlSinif.veriSilTumu(komut, veriListesi);
                label_adet.Text = "Hiç kayıt bulunamadı.";
            }
            catch (Exception)
            {
                MessageBox.Show("Kayda ait veriler bulunmakta.");
            }

        }
        private bool formboyut = true;
        private void button_buyut_Click(object sender, EventArgs e)
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

        private void button_kucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_geriyukle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in veriListesi.SelectedRows)//gelen verileri Listeden siler
            {
                if (veriListesi.Rows.Count != 0)
                {
                    int deger = (Convert.ToInt32(item.Cells[0].Value));
                    sqlSinif.secilenlerListe.Remove(deger);
                }
            }
            sqlSinif.secilenleriListedenSil(veriListesi, label_adet);
        }

        private void veriListesi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
            button_tamam.Top = label_adet.Top - 8;
        }

        private void silinecekler_SizeChanged(object sender, EventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, panel_sunum.Height - 50, label_adet);
            button_tamam.Top = label_adet.Top - 8;
        }
    }
}

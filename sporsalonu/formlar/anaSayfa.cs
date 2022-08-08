using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class anaSayfa : Form
    {
        public anaSayfa()
        {
            InitializeComponent();
        }
        public int uyeId { get; set; }
        public int kullaniciId { get; set; }

        private void Panelsifirla()
        {
            if (panel_isletme.Height != 0)
            {
                panel_isletme.Height = 0;
            }

            if (panel_tanımlamalar.Height != 0)
            {
                panel_tanımlamalar.Height = 0;
            }
            if (panel_uyelikislem.Height != 0)
            {
                panel_uyelikislem.Height = 0;
            }
        }
        private void Panelhide()
        {
            panel_tanımlamalar.Visible = false;
            panel_uyelikislem.Visible = false;
            panel_isletme.Visible = false;
            panel_cekmece.Visible = false;
        }
        private void Panelshow()
        {
            panel_tanımlamalar.Visible = true;
            panel_uyelikislem.Visible = true;
            panel_isletme.Visible = true;
            panel_cekmece.Visible = true;
        }
        private void Panelgoster(Panel panel)
        {

            int sayac = 0;
            int panelyuksekligi = 0;
            if (panel.Height == 0)
            {
                Panelsifirla();
                foreach (Button item in panel.Controls)//paneldeki butonların yüksekliği alınıyor
                {
                    if (item is Button)
                    {
                        sayac++;
                    }
                    panelyuksekligi = sayac * 42;
                    panel.Height = panelyuksekligi;
                }
            }
            else
            {
                panel.Height = 0;
            }
        }
        private void Slider(Control buton)
        {
            panel_slider.Top = buton.Top;
        }
        private void Panelesunumekle(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel_sunum.Controls.Clear();
            panel_sunum.Controls.Add(c);
        }
        private void Ayar_kucukmenu()
        {
            //butonların isimleri küçük menüye hazırlanıyor
            button_tanımlamalar.Text = null;
            button_sınıflar.Text = null;
            button_uyelikislemleri.Text = null;
            //butunların resimleri küçük menüye hazırlanıyor
            button_tanımlamalar.ImageAlign = ContentAlignment.MiddleCenter;
            button_sınıflar.ImageAlign = ContentAlignment.MiddleCenter;
            button_uyelikislemleri.ImageAlign = ContentAlignment.MiddleCenter;
        }
        private void Ayar_buyukmenu()
        {
            //butonların isimleri büyük menü tipine hazırlanıyor
            button_tanımlamalar.Text = "   Tanımlamalar";
            button_sınıflar.Text = "   Sınıflar";
            button_uyelikislemleri.Text = "   Üyelik İşlemleri";
            //butonların iresimleri sola hizalanıyyor
            button_tanımlamalar.ImageAlign = ContentAlignment.MiddleLeft;
            button_sınıflar.ImageAlign = ContentAlignment.MiddleLeft;
            button_uyelikislemleri.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void menukodlar(bool deger)
        {
            if (deger == true)//
            {
                panel_logo.Height = 50;
                pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom;
                Slidertop = panel_slider.Top - 84;
                panel_slider.Top = Slidertop;
                Ayar_kucukmenu();
                Panelhide();
                panel_cekmece.Visible = true;
                button_menualt.Visible = true;
                button_menu.Visible = false;
                panel_solarka.Width = 60;
                label_ara.Hide();
                textBox_ara.Visible = false;
                label_ara.Visible = false;
            }
            else
            {
                panel_logo.Height = 176;
                pictureBox_logo.SizeMode = PictureBoxSizeMode.CenterImage;
                panel_slider.Top = Slidertop + 84;
                Panelshow();
                Ayar_buyukmenu();
                button_menualt.Visible = false;
                button_menu.Visible = true;
                panel_cekmece.Visible = false;
                panel_solarka.Width = 224;
                textBox_ara.Visible = true;
                label_ara.Visible = true;
                textBox_ara.Focus();
            }

        }

        public void Acilacakform(Form frm)
        {
            panel_sunum.Controls.Clear();
            frm.TopLevel = false;
            panel_sunum.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.BringToFront();
        }

        private void button_menualt_Click(object sender, EventArgs e)
        {
            menukodlar(false);
        }

        private void button_menu_Click(object sender, EventArgs e)
        {
            menukodlar(true);
        }

        public int Slidertop { get; set; }

        private void anaSayfa_Load(object sender, EventArgs e)
        {
            //string kmt = "select ad +' '+soyad  from kullanicilar where kullanici_id=@p1";
            //SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            //komut.Parameters.AddWithValue("@p1", kullaniciId);
            //string adSoyad = komut.ExecuteScalar().ToString();
            button_oturum.Text = "adSoyad";
            panel_cekmece.Hide();
            Slider(button_tanımlamalar);
            textBox_ara.Focus();

            uyeler uyeler = new uyeler();
            uyeler.aranacakAd = textBox_ara.Text;
            uyeler.kullaniciId = kullaniciId;
            Acilacakform(uyeler);

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
        private void Kucukmenu_goster(Panel p, string deger)
        {
            p.Visible = true;
            int a;
            if (deger == "işletme")
            {
                a = 138;

                p.Location = new Point(0, a + 42);
            }
            else if (deger == "tanımlamalar")
            {
                a = 180;

                p.Location = new Point(0, a + 42);
            }
            else if (deger == "üyelikişlemleri")
            {
                a = 348;

                p.Location = new Point(0, a + 42);
            }
            else if (deger == "raporlar")
            {
                a = 390;

                p.Location = new Point(3, a + 42);
            }
        }

        private void button_tanımlamalar_Click(object sender, EventArgs e)
        {
            Panelgoster(panel_tanımlamalar);
            Slider(button_tanımlamalar);
            Slidertop = button_tanımlamalar.Top;
        }

        private void button_uyelikislemleri_Click(object sender, EventArgs e)
        {
            Panelgoster(panel_uyelikislem);
            Slidertop = button_uyelikislemleri.Top;
            Slider(button_uyelikislemleri);
        }

        private void button_sınıflar_Click(object sender, EventArgs e)
        {
            Panelsifirla();
            Slidertop = button_sınıflar.Top;
            Slider(button_sınıflar);
            siniflar siniflar = new siniflar();
            Acilacakform(siniflar);
        }

        private void anaSayfa_ResizeBegin(object sender, EventArgs e)
        {
            panel_sunum.Hide();
        }

        private void anaSayfa_ResizeEnd(object sender, EventArgs e)
        {
            panel_sunum.Show();
        }

        private void button_olcuturu_Click(object sender, EventArgs e)
        {
            tanimlama_olcu_tur frm = new tanimlama_olcu_tur();
            Acilacakform(frm);
        }

        private void button_kullanici_Click(object sender, EventArgs e)
        {
            tanimlama_kullanici tanimlama_Kullanici = new tanimlama_kullanici();
            Acilacakform(tanimlama_Kullanici);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            uyeEkle uyeEkle = new uyeEkle();
            uyeEkle.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            uyeler uyeler = new uyeler();
            uyeler.kullaniciId = kullaniciId;
            Acilacakform(uyeler);
        }
        sqlSinif sqlSinif = new sqlSinif();
        private void button_ara_Click(object sender, EventArgs e)
        {
            if (textBox_ara.Text != "")
            {
                uyeler uyeler = new uyeler();
                uyeler.aranacakAd = textBox_ara.Text;
                uyeler.kullaniciId = kullaniciId;
                Acilacakform(uyeler);
            }

        }
        bool durum = true;
        private void button2_Click(object sender, EventArgs e)
        {
            if (durum == true)
            {
                panel_kullanici.Height = 130;
                durum = false;
            }
            else
            {
                panel_kullanici.Height = 50;
                durum = true;
            }
        }

        private void button_oturumKapat_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris giris = new giris();
            giris.Show();
        }

        private void button_kullaniciBilgi_Click(object sender, EventArgs e)
        {
            durum = true;
            panel_kullanici.Height = 50;
            sqlSinif.secilenlerListe.Clear();
            sqlSinif.secilenlerListe.Add(kullaniciId);
            kullaniciGuncelle kullaniciGuncelle = new kullaniciGuncelle();
            kullaniciGuncelle.ShowDialog();
        }

        private void anaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void textBox_ara_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                button_ara.PerformClick();
            }
        }
    }
}

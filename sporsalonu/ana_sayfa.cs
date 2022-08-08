using sporsalonu.formlar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace sporsalonu
{
    public partial class ana_sayfa : Form
    {
        public ana_sayfa()
        {
            InitializeComponent();
            this.BackColor = Color.Red;

        }

        private void Panelsifirla()
        {
            if (panel_isletme.Height != 0)
            {
                panel_isletme.Height = 0;
            }
            if (panel_rapor.Height != 0)
            {
                panel_rapor.Height = 0;
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
            panel_rapor.Visible = false;
            panel_tanımlamalar.Visible = false;
            panel_uyelikislem.Visible = false;
            panel_isletme.Visible = false;
            panel_cekmece.Visible = false;
        }
        private void Panelshow()
        {
            panel_rapor.Visible = true;
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
            button_anasayfa.Text = null;
            button_isletme.Text = null;
            button_tanımlamalar.Text = null;
            button_kampanya.Text = null;
            button_sınıflar.Text = null;
            button_uyeliksecenekleri.Text = null;
            button_uyelikislemleri.Text = null;
            button_raporlar.Text = null;
            //butunların resimleri küçük menüye hazırlanıyor
            button_anasayfa.ImageAlign = ContentAlignment.MiddleCenter;
            button_isletme.ImageAlign = ContentAlignment.MiddleCenter;
            button_tanımlamalar.ImageAlign = ContentAlignment.MiddleCenter;
            button_kampanya.ImageAlign = ContentAlignment.MiddleCenter;
            button_sınıflar.ImageAlign = ContentAlignment.MiddleCenter;
            button_uyeliksecenekleri.ImageAlign = ContentAlignment.MiddleCenter;
            button_uyelikislemleri.ImageAlign = ContentAlignment.MiddleCenter;
            button_raporlar.ImageAlign = ContentAlignment.MiddleCenter;
        }
        private void Ayar_buyukmenu()
        {
            //butonların isimleri büyük menü tipine hazırlanıyor
            button_anasayfa.Text = "   Anasayfa";
            button_isletme.Text = "   İşletme";
            button_tanımlamalar.Text = "   Tanımlamalar";
            button_kampanya.Text = "   Kampanyalar";
            button_sınıflar.Text = "   Sınıflar";
            button_uyeliksecenekleri.Text = "   ÜyelikSeçenekleri";
            button_uyelikislemleri.Text = "   Üyelik İşlemleri";
            button_raporlar.Text = "   Raporlar";
            //butonların iresimleri sola hizalanıyyor
            button_anasayfa.ImageAlign = ContentAlignment.MiddleLeft;
            button_isletme.ImageAlign = ContentAlignment.MiddleLeft;
            button_tanımlamalar.ImageAlign = ContentAlignment.MiddleLeft;
            button_kampanya.ImageAlign = ContentAlignment.MiddleLeft;
            button_sınıflar.ImageAlign = ContentAlignment.MiddleLeft;
            button_uyeliksecenekleri.ImageAlign = ContentAlignment.MiddleLeft;
            button_raporlar.ImageAlign = ContentAlignment.MiddleLeft;
            button_uyelikislemleri.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void menukodlar(bool deger)
        {
            if (deger == true)//
            {
                panel_logo.Height = 79;
                pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom;
                Slidertop = panel_slider.Top - 55;
                panel_slider.Top = Slidertop;
                //Ayar_kucukmenu();
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
                panel_slider.Top = Slidertop + 55;
                Panelshow();
                //Ayar_buyukmenu();
                button_menualt.Visible = false;
                button_menu.Visible = true;
                panel_cekmece.Visible = false;
                panel_solarka.Width = 224;
                textBox_ara.Visible = true;
                label_ara.Visible = true;
                textBox_ara.Focus();
            }

        }
        private void button_menualt_Click(object sender, EventArgs e)
        {
            panel_sunum.Hide();
            menukodlar(false);
            panel_sunum.Show();
        }
        private void button_menu_Click(object sender, EventArgs e)
        {
            panel_sunum.Hide();
            menukodlar(true);
            panel_sunum.Show();
        }

        private bool formboyut = true;

        public int Slidertop { get; set; }

        private void ana_sayfa_Load(object sender, EventArgs e)
        {
            panel_cekmece.Hide();
            Slidertop = button_anasayfa.Top;
            Slider(button_anasayfa);
            textBox_ara.Focus();
            Kucukmenu_gizle();
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
        private void Kucukmenu_gizle()
        {
            isletme.Visible = false;
            tanımlamlar.Visible = false;

        }
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
        private void isletme_MouseLeave(object sender, EventArgs e)
        {
            Kucukmenu_gizle();
        }

        private void tanımlamlar_MouseLeave(object sender, EventArgs e)
        {
            Kucukmenu_gizle();
        }

        private void button_isletme_MouseEnter_1(object sender, EventArgs e)
        {
            if (button_menu.Visible != true)
            {
                Kucukmenu_goster(isletme, "işletme");
            }
        }

        private void button_tanımlamalar_MouseEnter_1(object sender, EventArgs e)
        {
            if (button_menu.Visible != true)
            {
                Kucukmenu_goster(tanımlamlar, "tanımlamalar");
            }
        }

        private void button_isletme_Click(object sender, EventArgs e)
        {
            Panelgoster(panel_isletme);
            Slidertop = button_isletme.Top;
            Slider(button_isletme);
        }

        private void button_tanımlamalar_Click(object sender, EventArgs e)
        {
            Panelgoster(panel_tanımlamalar);
            Slider(button_tanımlamalar);
            Slidertop = button_tanımlamalar.Top;
        }

        private void button_raporlar_Click(object sender, EventArgs e)
        {
            Panelgoster(panel_rapor);
            Slidertop = button_raporlar.Top;
            Slider(button_raporlar);
        }

        private void button_anasayfa_Click(object sender, EventArgs e)
        {
            Slidertop = button_anasayfa.Top;
            Slider(button_anasayfa);
            Panelsifirla();

        }

        private void button_uyelikislemleri_Click(object sender, EventArgs e)
        {
            Panelgoster(panel_uyelikislem);
            Slidertop = button_uyelikislemleri.Top;
            Slider(button_uyelikislemleri);

        }

        private void button_kampanya_Click(object sender, EventArgs e)
        {
            Slidertop = button_kampanya.Top;
            Slider(button_kampanya);
            Panelsifirla();
        }

        private void button_sınıflar_Click(object sender, EventArgs e)
        {
            Slidertop = button_sınıflar.Top;
            Slider(button_sınıflar);
            Panelsifirla();
        }

        private void button_uyeliksecenekleri_Click(object sender, EventArgs e)
        {
            Slidertop = button_uyeliksecenekleri.Top;
            Slider(button_uyeliksecenekleri);
            Panelsifirla();
        }

        void Acilacakform(Form frm)
        {
            panel_sunum.Controls.Clear();
            frm.TopLevel = false;
            panel_sunum.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.BringToFront();
        }
        private void button_olcuturu_Click(object sender, EventArgs e)
        {
            tanimlama_olcu_tur frm = new tanimlama_olcu_tur();
            Acilacakform(frm);
        }

        private void button_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void panel_üst_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void ana_sayfa_ResizeBegin(object sender, EventArgs e)
        {
            panel_sunum.Hide();
        }

        private void ana_sayfa_ResizeEnd(object sender, EventArgs e)
        {
            panel_sunum.Show();
        }

        private void panel_sunum_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



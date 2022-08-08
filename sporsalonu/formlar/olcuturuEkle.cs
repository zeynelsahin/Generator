using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace sporsalonu.formlar
{
    public partial class olcuturuEkle : Form
    {
        public olcuturuEkle()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        sqlSinif sqlSinif = new sqlSinif();

        private void olcuturu_Ekle_Load(object sender, EventArgs e)
        {
            pasifbuttonfgizle();
        }

        private void textBox_olcuadi_TextChanged(object sender, EventArgs e)
        {
            if (textBox_olcuadi.Text != "")
            {
                label_olcuadi.Visible = false;
            }
            else
            {
                label_olcuadi.Visible = true;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            timer_sonuc.Stop();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_aktif_Click(object sender, EventArgs e)
        {
            aktifbuttongizle();
            pasifbuttongöster();
        }

        private void aktifbuttongizle()
        {
            button_aktif.BackColor = Color.Transparent;
            button_aktif.Text = "";
            button_aktif.Enabled = false;
        }

        private void pasifbuttongöster()
        {
            button_pasif.Enabled = true;
            button_pasif.BackColor = Color.FromArgb(108, 170, 157);
            button_pasif.Text = "Pasif";
        }

        private void pasifbuttonfgizle()
        {
            button_pasif.Enabled = false;
            button_pasif.BackColor = Color.Transparent;
            button_pasif.Text = "";
        }
        private void button_pasif_Click(object sender, EventArgs e)
        {
            pasifbuttonfgizle();
            aktifbuttongöster();
        }

        private void aktifbuttongöster()
        {
            button_aktif.BackColor = Color.FromArgb(35, 128, 109);
            button_aktif.Text = "Aktif";
            button_aktif.Enabled = true;
        }

        private void textBox_birimi_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox_birimi.Text != "")
            {
                label_birimi.Visible = false;
            }
            else
            {
                label_birimi.Visible = true;
            }
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            if (textBox_birimi.Text != "" || textBox_birimi.Text != null && textBox_olcuadi.Text != "" || textBox_olcuadi.Text != null)
            {
                string kmt = "insert into olcu_turleri (ad,birim,durum,silme_durumu) values(@p1,@p2,@p3,@p4) ";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", textBox_olcuadi.Text);
                komut.Parameters.AddWithValue("@p2", textBox_birimi.Text);
                if (button_aktif.Enabled == true)
                {
                    komut.Parameters.AddWithValue("@p3", 1);
                }
                else
                {
                    komut.Parameters.AddWithValue("@p3", 0);
                }

                komut.Parameters.AddWithValue("@p4", false);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
                timer_sonuc.Start();
                timer_sonuc.Interval = 10;
                textBox_birimi.Text = "";
                textBox_olcuadi.Text = "";
            }
            textBox_olcuadi.Focus();
        }

        private int sayac = 0;

        private void timer_sonuc_Tick(object sender, EventArgs e)
        {
            if (sayac == 20)
            {
                label_sonuc.Text = "";
                timer_sonuc.Stop();
                sayac = 0;
            }
            else
            {
                sayac++;
                label_sonuc.Text = "Kayıt İşlemi Gerçekleşti";
            }
        }
    }
}

using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class olcuTurGuncelle : Form
    {
        public olcuTurGuncelle()
        {
            InitializeComponent();
        }
        sqlSinif sqlSinif = new sqlSinif();
        private void olcuTurGuncelle_Load(object sender, EventArgs e)
        {
            foreach (var item in sqlSinif.secilenlerListe)
            {
                listBox_veriler.Items.Add(item);
            }

            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "";

                komut = "select olcutur_id , ad,birim,durum  from olcu_turleri where  olcutur_id= ('" + listBox_veriler.Items[0] + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac()); ;
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    textBox_id.Text = listBox_veriler.Items[0].ToString();
                    textBox_olcu.Text = dr["ad"].ToString();
                    textBox_birim.Text = dr["birim"].ToString();
                    if (dr["durum"].ToString() == "False")
                    {
                        aktifbuttongizle();
                        pasifbuttongöster();
                    }
                    else
                    {
                        pasifbuttonfgizle();
                        aktifbuttongöster();
                    }
                }
                sqlSinif.Close();
            }
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

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "update olcu_turleri set  ad=@p1, birim=@p2 ,durum=@p3 where  olcutur_id= ('" + textBox_id.Text + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac());
                kmt.Parameters.AddWithValue("@p1", textBox_olcu.Text);
                kmt.Parameters.AddWithValue("@p2", textBox_birim.Text);
                if (button_aktif.Enabled == true)
                {
                    kmt.Parameters.AddWithValue("@p3", "True");
                }
                else
                {
                    kmt.Parameters.AddWithValue("@p3", "False");
                }
                kmt.ExecuteNonQuery();
                sqlSinif.Close();
                MessageBox.Show("Kayıt Güncellendi");
            }
        }

        private void button_aktif_Click(object sender, EventArgs e)
        {
            aktifbuttongizle();
            pasifbuttongöster();
        }

        private void button_pasif_Click_1(object sender, EventArgs e)
        {

            pasifbuttonfgizle();
            aktifbuttongöster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox_veriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_veriler.Items.Count > 0)
            {
                string komut = "";

                komut = "select olcutur_id , ad,birim,durum  from olcu_turleri where  olcutur_id= ('" + listBox_veriler.SelectedItem + "') ";
                SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac()); ;
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    textBox_id.Text = listBox_veriler.SelectedItem.ToString();
                    textBox_olcu.Text = dr["ad"].ToString();
                    textBox_birim.Text = dr["birim"].ToString();
                    if (dr["durum"].ToString() == "False")
                    {
                        aktifbuttongizle();
                        pasifbuttongöster();
                    }
                    else
                    {
                        pasifbuttonfgizle();
                        aktifbuttongöster();
                    }
                }
                sqlSinif.Close();
            }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_birim_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_ad_Click(object sender, EventArgs e)
        {

        }

        private void textBox_olcu_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

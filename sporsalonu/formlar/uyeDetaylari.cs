using sporsalonu.siniflar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class uyeDetaylari : Form
    {
        public uyeDetaylari()
        {
            InitializeComponent();
        }

        sqlSinif sqlSinif = new sqlSinif();
        string kmt;
        private void uyeDetaylari_Load(object sender, EventArgs e)
        {
            //Profil
            int uyeId = sqlSinif.secilenlerListe[0];
            string komut = "select *from  uyeler where uye_id= ('" + uyeId + "') ";
            SqlCommand kmt = new SqlCommand(komut, sqlSinif.Baglanti_ac()); ;
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                textBox_id.Text = uyeId.ToString();
                maskedTextBox_tcno.Text = dr["tcno"].ToString();
                textBox_ad.Text = dr["ad"].ToString();
                textBox_soyad.Text = dr["soyad"].ToString();
                maskedTextBox_dogumta.Text = dr["dogumtarihi"].ToString();
                textBox_adres.Text = dr["adres"].ToString();
                textBox_il.Text = dr["il"].ToString();
                textBox_ilce.Text = dr["ilce"].ToString();
                maskedTextBox1_telefon.Text = dr["telefon"].ToString();
                maskedTextBox_telefon2.Text = dr["telefon2"].ToString();
                textBox4_eposta.Text = dr["eposta"].ToString();
                int a = comboBox_kangrub.FindStringExact(dr["kangrubu"].ToString());
                comboBox_kangrub.SelectedIndex = a;
                if (dr["cinsiyet"].ToString() == "Erkek")
                {
                    radioButton_erkek.Checked = true;
                }
                else
                {
                    radioButton_kadın.Checked = true;
                }
            }
            sqlSinif.Close();

            //Vücut Ölçüleri
            sqlSinif.secilenlerListe.Clear();
            int olcutur_id;
            string kmt1 = "select * from olcu_turleri where durum=1 and silme_durumu=0";
            SqlCommand komut1 = new SqlCommand(kmt1, sqlSinif.Baglanti_ac());

            dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                comboBox_tur.Items.Add(dr["ad"].ToString());
                comboBox_turAra.Items.Add(dr["ad"].ToString());
                olcutur_id = Convert.ToInt32(dr["olcutur_id"]);
                sqlSinif.secilenlerListe.Add(olcutur_id);
            }
            sqlSinif.Close();
            verilerVucut();
            comboBox_turAra.SelectedIndex = 0;

            //Satışlar

            verilerSatis();

            //Tahislatlar
            verilerTahsilat();
        }
        void verilerVucut()
        {
            kmt = "select vucutolcu_id as İd,olcu_turleri.ad as '" + "Ölçü Ad" + "',tarih as Tarih,vucut_olculeri.deger as Değer from vucut_olculeri join olcu_turleri on olcu_turleri.olcutur_id=vucut_olculeri.olcutur_id where vucut_olculeri.uye_id='" + textBox_id.Text + "'";
            sqlSinif.veriListele(kmt, veriListesi, label_adet);
        }
        void verilerTahsilat()
        {
            if (checkBox_tahislat.Checked)
            {
                kmt = "select tahsilatlar.tahsilat_id,tahsilatlar.tutar,tahsilatlar.tarih,tahsilatlar.saat,kullanicilar.ad+' '+kullanicilar.soyad as '" + "Ödemeyi Alan" + "', tahsilatlar.durum as Durum from tahsilatlar inner join kullanicilar  on kullanicilar.kullanici_id=tahsilatlar.kullanici_id where tahsilatlar.durum=1 and tahsilatlar.uye_id='" + textBox_id.Text + "'";
            }
            else
            {
                kmt = "select tahsilatlar.tahsilat_id,tahsilatlar.tutar,tahsilatlar.tarih,tahsilatlar.saat,kullanicilar.ad+' '+kullanicilar.soyad as'" + "Ödemeyi Alan" + "' ,tahsilatlar.durum as Durum  from tahsilatlar inner join kullanicilar  on kullanicilar.kullanici_id=tahsilatlar.kullanici_id where tahsilatlar.uye_id='" + textBox_id.Text + "'";
            }
            sqlSinif.veriListeleRenkli(kmt, veriListesiTahsilat, label_adetTahsilat, 5);
        }
        void verilerSatis()
        {
            if (checkBox_iptal.Checked)
            {
                kmt = "select satislar.satis_id '" + "Satış İd" + "',siniflar.ad as Sınıf,satislar.baslanic_tarihi as '" + "Başlangıç Tarihi" + "',satislar.bitis_tarihi '" + "Bitiş Tarihi" + "',satislar.satis_fiyati as '" + "Satış Fiyatı" + "', satislar.durum as Durum from satislar join siniflar on satislar.sinif_id=siniflar.sinif_id where satislar.durum=1 and satislar.uye_id='" + textBox_id.Text + "'";
            }
            else
            {
                kmt = "select satislar.satis_id '" + "Satış İd" + "',siniflar.ad as Sınıf,satislar.baslanic_tarihi as '" + "Başlangıç Tarihi" + "',satislar.bitis_tarihi '" + "Bitiş Tarihi" + "',satislar.satis_fiyati as '" + "Satış Fiyatı" + "', satislar.durum as Durum from satislar join siniflar on satislar.sinif_id=siniflar.sinif_id where satislar.uye_id='" + textBox_id.Text + "' ";
            }
            sqlSinif.veriListeleRenkli(kmt, veriListesiSatis, label_adetSatis, 5);
        }

        void AramaVucut()
        {
            if (comboBox_turAra.SelectedIndex != -1)
            {
                if (comboBox_turAra.SelectedIndex == 0)
                {
                    verilerVucut();
                }
                else
                {
                    int deger = sqlSinif.secilenlerListe[comboBox_turAra.SelectedIndex - 1];
                    string kmt = "select vucutolcu_id as İd,olcu_turleri.ad as '" + "Ölçü Ad" + "',vucut_olculeri.tarih as Tarih,vucut_olculeri.deger as Değer from vucut_olculeri join olcu_turleri on olcu_turleri.olcutur_id=vucut_olculeri.olcutur_id where vucut_olculeri.uye_id='" + textBox_id.Text + "' and vucut_olculeri.olcutur_id='" + deger + "' ";
                    sqlSinif.veriListele(kmt, veriListesi, label_adet);
                }

            }
        }
        private void button_duzelt_Click(object sender, EventArgs e)
        {
            //Profil
            string kmt = "update uyeler set tcno=@p1,ad=@p2,soyad=@p3,cinsiyet=@p4,dogumtarihi=@p5,adres=@p6,il=@p7,ilce=@p8,telefon=@p9,telefon2=@p10,eposta=@p11,kangrubu=@p12 where uye_id='" + textBox_id.Text + "' ";
            SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            komut.Parameters.AddWithValue("@p1", maskedTextBox_tcno.Text);
            komut.Parameters.AddWithValue("@p2", textBox_ad.Text);
            komut.Parameters.AddWithValue("@p3", textBox_soyad.Text);
            if (radioButton_erkek.Checked)
            {
                komut.Parameters.AddWithValue("@p4", "Erkek");
            }
            else
            {
                komut.Parameters.AddWithValue("@p4", "Kadın");

            }
            komut.Parameters.AddWithValue("@p5", maskedTextBox_dogumta.Text);
            komut.Parameters.AddWithValue("@p6", textBox_adres.Text);
            komut.Parameters.AddWithValue("@p7", textBox_il.Text);
            komut.Parameters.AddWithValue("@p8", textBox_ilce.Text);
            komut.Parameters.AddWithValue("@p9", maskedTextBox1_telefon.Text);
            komut.Parameters.AddWithValue("@p10", maskedTextBox_telefon2.Text);
            komut.Parameters.AddWithValue("@p11", textBox4_eposta.Text);
            komut.Parameters.AddWithValue("@p12", comboBox_kangrub.Text);
            komut.ExecuteNonQuery();
            sqlSinif.Close();
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            //Profil
            string kmt = "Delete from uyeler where uye_id=@p1";
            SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            komut.Parameters.AddWithValue("@p1", textBox_id.Text);
            komut.ExecuteNonQuery();
            this.Close();
        }

        private void comboBox_tur_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deger = sqlSinif.secilenlerListe[comboBox_tur.SelectedIndex];
            if (comboBox_tur.SelectedIndex != -1)
            {
                string kmt = "Select birim,olcutur_id from olcu_turleri where olcutur_id=@p1";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", deger);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    textBox_birim.Text = dr["birim"].ToString();
                }
                sqlSinif.Close();
            }
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            int deger = sqlSinif.secilenlerListe[comboBox_tur.SelectedIndex];
            if (comboBox_tur.SelectedIndex != -1)
            {
                string kmt = "insert into vucut_olculeri (tarih,deger,olcutur_id,uye_id) values (@p1,@p2,@p3,@p4)";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", DateTime.Now.ToString("yyyy.MM.dd"));
                komut.Parameters.AddWithValue("@p2", textBox_deger.Text);
                komut.Parameters.AddWithValue("@p3", deger);
                komut.Parameters.AddWithValue("@p4", textBox_id.Text);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
                AramaVucut();
            }
        }

        private void button_yenile_Click(object sender, EventArgs e)
        {
            AramaVucut();
        }

        private void veriListesi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, tabPage_vucut.Height - 220, label_adet);
        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesi, tabPage_vucut.Height - 220, label_adet);
            sqlSinif.veriListesiBoyutu(veriListesiSatis, panel_ust.Height - 170, label_adetSatis);
            sqlSinif.veriListesiBoyutu(veriListesiTahsilat, tabPage_tahsilat.Height - 180, label_adetTahsilat);
        }

        private void button_Vsil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in veriListesi.SelectedRows)
            {
                int id = Convert.ToInt32(item.Cells[0].Value);
                string kmt = "delete from vucut_olculeri where  vucutolcu_id=@p1";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", id);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
            }
            sqlSinif.secilenleriListedenSil(veriListesi, label_adet);
        }



        private void comboBox_turAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            AramaVucut();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            //DateTime.Now.ToString("yyyy.MM.dd"));
        }

        private void button_satis_Click(object sender, EventArgs e)
        {
            satis satis = new satis();
            satis.uyeId = Convert.ToInt32(textBox_id.Text);
            satis.ShowDialog();
            verilerSatis();
        }

        private void checkBox_iptal_CheckedChanged(object sender, EventArgs e)
        {
            verilerSatis();
        }

        private void button_yenileSatis_Click(object sender, EventArgs e)
        {
            verilerSatis();
        }

        private void button_silSatis_Click(object sender, EventArgs e)
        {

            sqlSinif.secilenler(veriListesiSatis);//DataGridView deki seçilenler
            foreach (int item in sqlSinif.secilenlerListe)
            {
                int id = Convert.ToInt32(item);
                string kmt = "update satislar set durum=0 where satis_id=@p1";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", item);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
                //tekrardan listeyi yenelemek yerine secilenler listeden siliniyor
            }
            verilerSatis();
        }

        private void veriListesiSatis_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesiSatis, panel_ust.Height - 170, label_adetSatis);
            int toplamSatis = 0;
            if (veriListesiSatis.RowCount != 0)
            {
                for (int i = 0; i < veriListesiSatis.RowCount; i++)
                {
                    if (Convert.ToBoolean(veriListesiSatis.Rows[i].Cells[5].Value) == true)
                    {
                        toplamSatis += Convert.ToInt32(veriListesiSatis.Rows[i].Cells[4].Value);
                    }
                }
                label_satisTutar.Text = toplamSatis.ToString();

            }
            else
            {
                label_satisTutar.Text = 0.ToString();
            }
            label_bakiye.Text = (Convert.ToInt32(label_tahsilatTutar.Text) - toplamSatis).ToString();
        }


        public int kullaniciId { get; set; }
        private void button_odemeAl_Click(object sender, EventArgs e)
        {
            anaSayfa anaSayfa = new anaSayfa();
            string kmt = "insert into tahsilatlar(tarih,saat,tutar,uye_id,kullanici_id) values (@p1,@p2,@p3,@p4,@p5)";
            SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
            komut.Parameters.AddWithValue("@p1", DateTime.Now.ToString("yyyy.MM.dd"));
            komut.Parameters.AddWithValue("@p2", DateTime.Now.ToLongTimeString());
            komut.Parameters.AddWithValue("@p3", textBox_tutar.Text);
            komut.Parameters.AddWithValue("@p4", textBox_id.Text);
            komut.Parameters.AddWithValue("@p5", kullaniciId);
            komut.ExecuteNonQuery();
            sqlSinif.Close();
            verilerTahsilat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerTahsilat();
        }

        private void veriListesiTahsilat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            sqlSinif.veriListesiBoyutu(veriListesiTahsilat, tabPage_tahsilat.Height - 180, label_adetTahsilat);
            int toplamTahsilat = 0;
            if (veriListesiTahsilat.RowCount != 0)
            {
                for (int i = 0; i < veriListesiTahsilat.RowCount; i++)
                {
                    if (Convert.ToBoolean(veriListesiTahsilat.Rows[i].Cells[5].Value) == true)
                    {
                        toplamTahsilat += Convert.ToInt32(veriListesiTahsilat.Rows[i].Cells[1].Value);
                    }
                }
                label_tahsilatTutar.Text = toplamTahsilat.ToString();
            }
            else
            {
                label_tahsilatTutar.Text = 0.ToString();
            }
            label_bakiye.Text = (toplamTahsilat - Convert.ToInt32(label_satisTutar.Text)).ToString();
        }

        private void button_silTahsilat_Click(object sender, EventArgs e)
        {
            sqlSinif.secilenler(veriListesiTahsilat);//DataGridView deki seçilenler
            foreach (int item in sqlSinif.secilenlerListe)
            {

                int id = Convert.ToInt32(item);
                string kmt = "update tahsilatlar set durum=0 where tahsilat_id=@p1";
                SqlCommand komut = new SqlCommand(kmt, sqlSinif.Baglanti_ac());
                komut.Parameters.AddWithValue("@p1", item);
                komut.ExecuteNonQuery();
                sqlSinif.Close();
                //tekrardan listeyi yenelemek yerine secilenler listeden silinmek istensede pasif olanları tekrardan listeden sildiğin için liste yenilenmek zorunda kalınıyor
            }
            verilerTahsilat();
        }

        private void checkBox_tahislat_CheckedChanged(object sender, EventArgs e)
        {
            verilerTahsilat();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

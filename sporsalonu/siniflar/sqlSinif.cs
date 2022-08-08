using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace sporsalonu.siniflar
{
    class sqlSinif
    {
        public SqlConnection bag = new SqlConnection(@"Data Source=Zeynel;Initial Catalog=SporMerkezi;Integrated Security=True");
        public SqlConnection Baglanti_ac()//baglantıyı açar
        {
            if (bag.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    bag.Open();
                }
                catch
                {
                    MessageBox.Show("Bağlantı Kurulamadı", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            return bag;
        }
        public void Close()
        {
            bag.Close();
        }
        public void veriListele(string komut, DataGridView veriListesi, Label label)//veri listeler
        {
            SqlDataAdapter da = new SqlDataAdapter(komut, Baglanti_ac());
            DataTable dt = new DataTable();
            da.Fill(dt);
            veriListesi.DataSource = dt;
            //datagridview deki verilerin adeti
            veriAdeti(veriListesi, label);
        }
        public void veriListeleRenkli(string komut, DataGridView veriListesi, Label label, int sutun)//veri listeler
        {
            SqlDataAdapter da = new SqlDataAdapter(komut, Baglanti_ac()); 
            DataTable dt = new DataTable();
            da.Fill(dt);
            veriListesi.DataSource = dt;
            //datagridview deki verilerin adeti
            veriAdeti(veriListesi, label);
            for (int i = 0; i < veriListesi.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Convert.ToBoolean(veriListesi.Rows[i].Cells[sutun].Value) == false)
                {
                    renk.BackColor = Color.FromArgb(255, 85, 85);
                    renk.ForeColor = Color.White;
                }

                veriListesi.Rows[i].DefaultCellStyle = renk;
            }
        }

        public void veriAdeti(DataGridView veriListesi, Label label)//datagridview deki verilerin adeti
        {
            if (veriListesi.Rows.Count > 0)
            {
                label.Text = veriListesi.Rows.Count.ToString() + " adet kayıt listelendi.";
            }
            else
            {
                label.Text = "Hiç kayıt bulunamadı.";

            }
        }

        public static List<int> secilenlerListe = new List<int>();
        public static List<int> siniflar = new List<int>();

        public void secilenler(DataGridView veriListesi)//datagridview deki seçilenlerin listeye aktarır
        {
            secilenlerListe.Clear();
            foreach (DataGridViewRow item in veriListesi.SelectedRows)
            {
                if (veriListesi.Rows.Count != 0)
                {
                    secilenlerListe.Add(Convert.ToInt32(item.Cells[0].Value));
                }
            }
            secilenlerListe.Reverse();
        }

        public void secilenleriListedenSil(DataGridView veriListesi, Label label)//datagridview deki seçili indexleri kaldırır ve datagridviewdeki verilirin adedini yazar. Bu verilerin yenilenmek yereine kullanılıyor
        {
            foreach (DataGridViewRow item in veriListesi.SelectedRows)
            {
                veriListesi.Rows.RemoveAt(item.Index);
            }
            //datagridview deki verilerin adeti
            veriAdeti(veriListesi, label);
        }

        public void veriSilTumu(string komut, DataGridView veriListesi)//verileri siler her tablo için geçerli
        {
            if (veriListesi.Rows.Count != 0)
            {
                foreach (var id in secilenlerListe)
                {
                    SqlCommand kmt = new SqlCommand(komut, Baglanti_ac());
                    kmt.Parameters.AddWithValue("@p1", id);
                    kmt.ExecuteNonQuery();
                }
                Close();
                while (veriListesi.Rows.Count > 0)//tüm verileri siler
                    veriListesi.Rows.RemoveAt(0);
            }
        }

        public void veriListesiBoyutu(DataGridView veriListesi, int deger1, Label label)//datagridview in boyutunu ayarlar
        {
            int height = 41;
            foreach (DataGridViewRow dr in veriListesi.Rows)
            {
                height += dr.Height;
            }
            if (height > deger1)
            {
                veriListesi.Height = deger1;
            }
            else
            {
                veriListesi.Height = height;
            }
            label.Top = veriListesi.Bottom + 10;
        }
        public void copkutuAdet(string komut, Label label)
        {
            SqlCommand kmt = new SqlCommand(komut, Baglanti_ac());
            label.Text = kmt.ExecuteScalar().ToString();
            Close();
        }

    }
}

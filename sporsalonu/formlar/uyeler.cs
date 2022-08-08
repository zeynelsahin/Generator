using System;
using System.Windows.Forms;

namespace sporsalonu.formlar
{
    public partial class uyeler : Form
    {
        public uyeler()
        {
            InitializeComponent();
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
        public string aranacakAd { get; set; }
        public int kullaniciId { get; set; }
        private void uyeler_Load(object sender, EventArgs e)
        {
            uyeAra uyeAra = new uyeAra();
            uyeAra.aranacakAd = aranacakAd;
            Acilacakform(uyeAra);
        }
        private bool deger = true;
        private void panel_sunum_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (deger == true)
            {
                uyeDetaylari uyeDetaylari = new uyeDetaylari();
                uyeDetaylari.kullaniciId = kullaniciId;
                Acilacakform(uyeDetaylari);

                deger = false;
            }
            else
            {
                uyeAra uyeAra = new uyeAra();
                Acilacakform(uyeAra);
                deger = true;
            }
        }

        private void panel_sunum_ControlAdded(object sender, ControlEventArgs e)
        {

        }
    }
}

using sporsalonu.formlar;
using System;
using System.Windows.Forms;

namespace sporsalonu
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new anaSayfa());
        }
    }
}

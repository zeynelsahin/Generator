using System;
using System.Windows.Forms;

namespace Generator.UI.WF
{
    public static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormObjectAddUpdate());
            //Application.Run(new FormUxGenerator())
            //Application.Run(new FormParameterAndResultAdd());
            //Application.Run(new FormResultAdd());
        }
    }
}
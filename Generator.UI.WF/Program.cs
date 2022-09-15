using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Generator.Business.Abstract;
using Generator.Business.Concrete;
using Generator.DataAccess.Abstract;
using Generator.DataAccess.Concrete;
using Generator.Entities;
using Module = Autofac.Module;

namespace Generator.UI.WF
{
    public static class Program
    {
        //public static IContainer IoCContainer { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            //Application.Run(new FormUxGenerator());
            //Application.Run(new FormParameterAdd());
            //Application.Run(new FormResultAdd());
        }
    }
}
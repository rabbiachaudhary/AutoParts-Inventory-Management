using System;
using System.Windows.Forms;
using FinalProjectG27.Views;

namespace FinalProjectG27
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainDashBoard());
        }
    }
}

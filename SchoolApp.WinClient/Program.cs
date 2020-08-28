using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SchoolApp.WinClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var spfrm = new Views.SystemForms.SplashScreenForm();
            var result = spfrm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            Application.Run(new Form1());
        }
    }
}

using SchoolApp.RepositoryAbstracts;
using SchoolApp.WinClient.ExtentionMethod;
using SchoolApp.WinClient.Views.SystemForms;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Cultures.InitializePersianCulture();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new StructureMap.Container(new IoC.TypeRegistery());
            var spfrm = container.GetInstance<Views.SystemForms.SplashScreenForm>();
            var result = spfrm.ShowDialog();
            if (result != DialogResult.OK)return;

            //var userrepo = container.GetInstance<IstudentsRepository>();
            //if(userrepo.Count() == 0)
            //{
            //    userrepo.Add(new Entities.students
            //    {
                    
            //    })
            //}
            var logForm = container.GetInstance<FrmLogin>();
            var resultLog = logForm.ShowDialog();
            if (resultLog != DialogResult.OK)return;
            Application.Run(new MainForm());
        }
    }
}

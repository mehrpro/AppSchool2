using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using SchoolApp.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolApp.WinClient.Views.SystemForms
{
    public partial class SplashScreenForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IDbTools dbTools;
        public SplashScreenForm(IDbTools dbTools)
        {
            this.dbTools = dbTools;
            InitializeComponent();
        }
        private async void SplashScreenForm_Load(object sender, EventArgs e)
        {

            StatusLabel.Text = $@"در حال بررسی ارتباط با سرور...";
            if (!await dbTools.CheckDBConnection())
            {
                var container = new StructureMap.Container(new IoC.TypeRegistery());
                var connectionSettingForm = container.GetInstance<DbConnectionSettingForm>();
                var result = connectionSettingForm.ShowDialog();
                if (result != DialogResult.OK) DialogResult = DialogResult.Cancel;
            }
            dbTools.RefreshConnectionString();
            StatusLabel.Text = $@"در حال بررسی بانک اطلاعاتی...";
            if (!await dbTools.CheckDatabaseExists())
            {
                StatusLabel.Text = $@"در حال ایجاد بانک اطلاعاتی...";
                if (!await dbTools.CreateDatabase(Properties.Resources.schooldb))
                {
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            }
            DialogResult = DialogResult.OK;
        }


    }
}

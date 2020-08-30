using DevExpress.Data.Utils;
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
    public partial class DbConnectionSettingForm : DevExpress.XtraEditors.XtraForm
    {
        private IDbTools dbTools;
        public DbConnectionSettingForm(IDbTools dbTools)
        {
            this.dbTools = dbTools;
            InitializeComponent();
        }

        private void DbConnectionSettingForm_Load(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            txtDataSource.EditValue = connectionStringBuilder.Server;
            //connectionStringBuilder.IntegratedSecurity = chkUserID.Checked;
            chkUserID.Checked = !connectionStringBuilder.IntegratedSecurity;
            if (!connectionStringBuilder.IntegratedSecurity)
            {
                txtUserID.EditValue = connectionStringBuilder.UserID;
                txtPassword.EditValue = connectionStringBuilder.Password;
            }
            txtDatabaseName.EditValue = connectionStringBuilder.Database;
        }

        private void chkUserID_CheckedChanged(object sender, EventArgs e)
        {
            txtUserID.Enabled = txtPassword.Enabled = chkUserID.Checked;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            WinClient.Helper.ConfigurationTools.UpdateConnectionStrings(
                "mySQL", txtDataSource.Text, txtDatabaseName.Text, !chkUserID.Checked, txtUserID.Text, txtPassword.Text);
            var useridCheck = chkUserID.Checked;
            dbTools.RefreshConnectionString();
            btnClose.Enabled = btnSave.Enabled = txtDatabaseName.Enabled = txtDataSource.Enabled = txtPassword.Enabled = txtUserID.Enabled = chkUserID.Enabled = false;
            var connected = await dbTools.CheckDBConnection();
            if (connected)
                btnClose.Enabled = btnSave.Enabled = txtDatabaseName.Enabled = txtDataSource.Enabled = txtPassword.Enabled = txtUserID.Enabled = chkUserID.Enabled = false;
            if (!connected)
                XtraMessageBox.Show(Properties.Resources.NotComplatedConnection, Text);
            else
            {
                XtraMessageBox.Show(Properties.Resources.ComplateConnectionString, Text);

                DialogResult = DialogResult.OK;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

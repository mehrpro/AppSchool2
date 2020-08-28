using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
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
        public DbConnectionSettingForm()
        {
            InitializeComponent();
        }

        private void DbConnectionSettingForm_Load(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            txtDataSource.EditValue = connectionStringBuilder.Server;
            connectionStringBuilder.IntegratedSecurity = !chkUserID.Checked;
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
            var useridCheck = chkUserID.Checked;

            btnClose.Enabled = btnSave.Enabled = txtDatabaseName.Enabled = txtDataSource.Enabled = txtPassword.Enabled = txtUserID.Enabled = chkUserID.Enabled = false;

            var conncetionStringBuilder = new MySqlConnectionStringBuilder();
            conncetionStringBuilder.Server = txtDataSource.Text;
            conncetionStringBuilder.IntegratedSecurity = !chkUserID.Checked;
            if (chkUserID.Checked)
            {
                conncetionStringBuilder.UserID = txtUserID.Text.Trim();
                conncetionStringBuilder.Password = txtPassword.Text.Trim();
            }
            conncetionStringBuilder.Database = "information_schema";
            try
            {
                using(var connection = new MySqlConnection(conncetionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                }
                XtraMessageBox.Show(Properties.Resources.ComplateConnectionString, Text);
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionString =(ConnectionStringsSection) config.GetSection("connectionStrings");
                conncetionStringBuilder.Database = txtDatabaseName.Text.Trim();
                connectionString.ConnectionStrings["mySQL"].ConnectionString = conncetionStringBuilder.ConnectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {

                XtraMessageBox.Show(Properties.Resources.NotComplatedConnection, Text);

            }
            finally
            {
                btnClose.Enabled = btnSave.Enabled = txtDatabaseName.Enabled = txtDataSource.Enabled = txtPassword.Enabled = txtUserID.Enabled = chkUserID.Enabled = true;
            }
        }
    }
}

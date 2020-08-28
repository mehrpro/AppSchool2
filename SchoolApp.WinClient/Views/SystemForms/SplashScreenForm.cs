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
        IDbTools dbTools;
        public SplashScreenForm()
        {
            //this.dbTools = dbTools;
            InitializeComponent();
        }
        private async Task<bool> CreateDatabase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            var tempDbName = connectionStringBuilder.Database;
            connectionStringBuilder.Database = "information_schema";
            try
            {
                using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = $"create database{tempDbName}";
                    connection.ChangeDatabase(tempDbName);

                    var result = await cmd.ExecuteNonQueryAsync();
                    var createdatabaseCommand = connection.CreateCommand();
                    createdatabaseCommand.CommandText = Properties.Resources.schooldb;
                    await createdatabaseCommand.ExecuteNonQueryAsync();
                    return true;
                }
                
            }
            catch (Exception)
            {
                XtraMessageBox.Show(Properties.Resources.ErrorForCLR, Text);
                DialogResult = DialogResult.Cancel;
            }
            return false;
        }
        private async  Task<bool>  CheckSQLConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            connectionStringBuilder.Database = "information_schema";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                }
                return true;
            }
            catch (Exception)
            {
                var connectionSettingForm = new Views.SystemForms.DbConnectionSettingForm();
                var result = connectionSettingForm.ShowDialog();
                return result == DialogResult.OK;                
            }
        }
        private async Task<bool> CheckDatabaseExists()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            var tempDbName = connectionStringBuilder.Database;
            connectionStringBuilder.Database = "information_schema";
            try
            {
                using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = $"select count(*) from information_schema.schemata where schema_name = @dbname";
                    cmd.Parameters.Add(new MySqlParameter("dbname", tempDbName));
                    var result = (int)await cmd.ExecuteScalarAsync();
                    return result > 0;
                }
                return true;
            }
            catch (Exception)
            {
                XtraMessageBox.Show(Properties.Resources.ErrorForCLR, Text);
                DialogResult =  DialogResult.Cancel;
            }
            return false;
        }
        private async void SplashScreenForm_Load(object sender, EventArgs e)
        {
           
            StatusLabel.Text = $@"در حال بررسی ارتباط با سرور...";
            var serverIsConnected = await CheckSQLConnection();
            if (!serverIsConnected)
                DialogResult = DialogResult.Cancel;
            if (!await CheckDatabaseExists())
                CreateDatabase();

            //if (!await dbTools.CheckDBConnection())
            //{
            //    var connectionSettingForm = new DbConnectionSettingForm();
            //    var result = connectionSettingForm.ShowDialog();
            //    if (result != DialogResult.OK) DialogResult = DialogResult.Cancel;
            //}
            //StatusLabel.Text = $@"در حال بررسی بانک اطلاعاتی...";
            //if (!await dbTools.CheckDatabaseExists())
            //{
            //    StatusLabel.Text = $@"در حال ایجاد بانک اطلاعاتی...";
            //    if (!await dbTools.CreateDatabase(Properties.Resources.schooldb))
            //    {
            //        DialogResult = DialogResult.Cancel;
            //        return;
            //    }
            //}
            //DialogResult = DialogResult.OK;
        }
    }
}

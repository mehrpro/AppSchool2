using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.WinClient.Helper
{
    public class ConfigurationTools
    {
        public static void UpdateConnectionStrings(string connectionName, string server, string dataBase, bool integrationSecurity, string userId, string password)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionString = (ConnectionStringsSection)config.GetSection("connectionStrings");
            var conncetionStringBuilder = new MySqlConnectionStringBuilder();
            conncetionStringBuilder.Server = server;
            conncetionStringBuilder.IntegratedSecurity = !integrationSecurity;
            if (!integrationSecurity)
            {
                conncetionStringBuilder.UserID = userId;
                conncetionStringBuilder.Password = password;
            }
            conncetionStringBuilder.Database = dataBase;
            connectionString.ConnectionStrings[connectionName].ConnectionString = conncetionStringBuilder.ConnectionString;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}

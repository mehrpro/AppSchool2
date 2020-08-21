using SchoolApp.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SchoolApp.Repositoreis
{
    public class SqlDbTools : IDbTools
    {
        private MySqlConnectionStringBuilder connectionStringBuilder;
        private string tempDbName;
        public async Task<bool> CheckDatabaseExists()
        {
            return true;
        }

        public async Task<bool> CheckDBConnection()
        {
            return true;

        }

        public async Task<bool> CreateDatabase(string dbScript)
        {
            return true;

        }

        public void RefreshConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            connectionStringBuilder.init
        }
    }
}

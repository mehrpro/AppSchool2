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
        public SqlDbTools()
        {
            RefreshConnectionString();
        }
        public async Task<bool> CheckDatabaseExists()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    var command = connection.CreateCommand();
                    command.CommandText = "select count(*) from information_schema.schemata where schema_name = @dbname";
                    command.Parameters.Add(new MySqlParameter("dbname", tempDbName));
                    var result = (int)await command.ExecuteScalarAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CheckDBConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> CreateDatabase(string dbScript)
        {
            return true;

        }

        public void RefreshConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            connectionStringBuilder.Database = "sys";
        }
    }
}

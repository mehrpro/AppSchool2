using SchoolApp.RepositoryAbstracts;
using System;
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
                    command.CommandText = $"select count(*) from information_schema.schemata where schema_name = '{tempDbName}'";
                    //command.Parameters.Add(new MySqlParameter("dbname", tempDbName));
                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToBoolean(result);
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
            //connectionStringBuilder.Database = "information_schema";
            try
            {
                using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = $"create database {tempDbName}";
                    await cmd.ExecuteNonQueryAsync();
                    connection.ChangeDatabase(tempDbName);
                    var createdatabaseCommand = connection.CreateCommand();
                    createdatabaseCommand.CommandText = dbScript.Replace("schooldb",tempDbName.ToString());
                    await createdatabaseCommand.ExecuteNonQueryAsync();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
         

        }

        public void RefreshConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            tempDbName = connectionStringBuilder.Database;
            connectionStringBuilder.Database = "information_schema";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace SchoolApp.DataLayer
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    {
        protected readonly string schema;
        protected readonly string tableName;
        private readonly string connectionString;
        List<PropertyModel> _propertyModels = new List<PropertyModel>();

        public GenericRepository()
        {
            var entityType = typeof(TEntity);
            var tableAttribute = entityType.GetCustomAttributes(typeof(TableAttribute), false).OfType<TableAttribute>()
                .FirstOrDefault();
            if (tableAttribute != null)
            {
                schema = tableAttribute.Schema;
                tableName = tableAttribute.Table;
            }
            else
            {
                schema = "dbo";
                tableName = entityType.Name;
            }
            foreach (var propertyInfo in entityType.GetProperties())
            {
                _propertyModels.Add(new PropertyModel()
                {
                    PropertyName = propertyInfo.Name,
                    ColumnName = propertyInfo.Name,
                    IsComputed = propertyInfo.GetCustomAttributes(typeof(ComputedColumnAttribute), false).Any(),
                    IsPrimeryKey = propertyInfo.GetCustomAttributes(typeof(PrimeryKeyAttribute), false).Any(),
                    IsIdentity = propertyInfo.GetCustomAttributes(typeof(IdentityAttribute), false).Any(),
                    Propertyinfo = propertyInfo
                });
            }

        }

        public GenericRepository(string _connectionString) : this()
        {
            if (_connectionString.StartsWith("name="))
            {
                this.connectionString = ConfigurationManager.ConnectionStrings[_connectionString.Substring(5)].ConnectionString;
            }
            else
            {
                this.connectionString = _connectionString;
            }

        }

        public int Add(TEntity entity)
        {
            StringBuilder insertStatment =
                new StringBuilder("INSERT INTO " + schema + "." + tableName + " ({columns}) VALUES ({values})");
            List<string> columnName = new List<string>();
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>();
            List<string> sqlParameterName = new List<string>();
            var parameterCounter = 1;
            foreach (var property in _propertyModels)
            {
                if (property.IsComputed || property.IsPrimeryKey || property.IsIdentity)
                    continue;
                columnName.Add(property.ColumnName);
                var parameterName = "Column" + parameterCounter++;
                sqlParameterName.Add(parameterName);
                var parameterValue = property.Propertyinfo.GetValue(entity);
                sqlParameters.Add(new MySqlParameter(parameterName, parameterValue ?? DBNull.Value));
            }
            insertStatment.Replace("{columns}", string.Join(",", columnName.Select(col => col)));
            insertStatment.Replace("{values}", string.Join(",", sqlParameters.Select(para => "@" + para)));
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cammand = connection.CreateCommand();
                cammand.CommandText = insertStatment.ToString();
                foreach (var parameter in sqlParameters)
                {
                    cammand.Parameters.Add(parameter);
                }

                return cammand.ExecuteNonQuery();
            }
        }

        public int Remove(TEntity entity)
        {
            var primeryKey = _propertyModels.Where(property => property.IsPrimeryKey);


            StringBuilder deleteStatment = new StringBuilder("Delete FROM " + schema + "." + tableName);
            List<string> wherePart = new List<string>();
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>();
            var parameterCounter = 1;
            foreach (var property in primeryKey)
            {

                var parameterName = "Column" + parameterCounter++;
                wherePart.Add(property.ColumnName + "@" + parameterName);
                var parameterValue = property.Propertyinfo.GetValue(entity);
                sqlParameters.Add(new MySqlParameter(parameterName, parameterValue));
            }

            deleteStatment.Append(" WHERE " + string.Join(" AND ", wherePart));
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cammand = connection.CreateCommand();
                cammand.CommandText = deleteStatment.ToString();
                foreach (var parameter in sqlParameters)
                {
                    cammand.Parameters.Add(parameter);
                }

                return cammand.ExecuteNonQuery();
            }

        }

        public TEntity Find(params object[] keys)
        {
            var primeryKey = _propertyModels.Where(property => property.IsPrimeryKey);
            var queryStatment = new StringBuilder("Select  TOP(1) * FROM " + schema + "." + tableName);
            List<string> wherePart = new List<string>();
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>();
            var parameterCounter = 1;
            foreach (var property in primeryKey)
            {
                var parameterName = "Column" + parameterCounter;
                wherePart.Add(property.ColumnName + "@" + parameterName);
                var parameterValue = keys[parameterCounter++ - 1];
                sqlParameters.Add(new MySqlParameter(parameterName, parameterValue));
            }
            queryStatment.Append(" WHERE " + string.Join(" AND ", wherePart));
            return RunQuery(queryStatment.ToString(), sqlParameters.ToArray()).FirstOrDefault();
        }

        public List<TEntity> All()
        {
            var queryStatment = new StringBuilder("Select  * FROM " + schema + "." + tableName);
            return RunQuery(queryStatment.ToString());
        }

        public int Update(TEntity entity)
        {
            var queryUpdate = new StringBuilder("UPDATE "+schema+"."+tableName);
            var nonComputedColumn = _propertyModels.Where(p => !p.IsComputed);
            var primeryKey = _propertyModels.Where(property => property.IsPrimeryKey);
            List<string> updateStatment = new List<string>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var valuseCounter = 1;
            foreach (var model in nonComputedColumn)
            {
                updateStatment.Add(model.ColumnName+"= @valuse"+valuseCounter);
                parameters.Add(new MySqlParameter("valuse"+valuseCounter++,model.Propertyinfo.GetValue(entity)));

            }

            queryUpdate.Append(" SET " + string.Join(",", updateStatment));
            List<string> wherePart = new List<string>();
            var keyCounter = 1;
            foreach (var property in primeryKey)
            {

                var parameterName = "Column" + keyCounter++;
                wherePart.Add(property.ColumnName + "@" + parameterName);
                var parameterValue = property.Propertyinfo.GetValue(entity);
                parameters.Add(new MySqlParameter(parameterName, parameterValue));
            }
            queryUpdate.Append(" WHERE " + string.Join(" AND ", wherePart));
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cammand = connection.CreateCommand();
                cammand.CommandText = queryUpdate.ToString();
                foreach (var parameter in parameters)
                {
                    cammand.Parameters.Add(parameter);
                }

                return cammand.ExecuteNonQuery();
            }
        }

        protected List<TEntity> RunQuery(string query, params MySqlParameter[] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cammand = connection.CreateCommand();
                cammand.CommandText = query.ToString();
                foreach (var parameter in parameters)
                {
                    cammand.Parameters.Add(parameter);
                }

                var reader = cammand.ExecuteReader();
                List<TEntity> entities = new List<TEntity>();
                while (reader.Read())
                {
                    TEntity entity = Activator.CreateInstance<TEntity>();
                    foreach (var model in _propertyModels)
                    {
                        var value = reader[model.ColumnName];
                        if(value is DBNull)
                            model.Propertyinfo.SetValue(entity,null);
                        else
                             model.Propertyinfo.SetValue(entity, value);
                    }

                    entities.Add(entity);
                }

                return entities;
            }

        }
    }
}
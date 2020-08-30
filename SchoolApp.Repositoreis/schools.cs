using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SchoolApp.Entities;
using SchoolApp.DataLayer;
using SchoolApp.RepositoryAbstracts;
namespace SchoolApp.Repositories
{
	public class schoolsRepository : GenericRepository<schools>,IschoolsRepository
	{
		public schoolsRepository(): base("name=mySQL") { }
		public List<schools> GetByID(byte value)
		{
			return RunQuery("SELECT * FROM schooldb.schools WHERE ID = @Value",new MySqlParameter("Value",value));
		}
		public List<schools> GetBySchoolName(string value)
		{
			return RunQuery("SELECT * FROM schooldb.schools WHERE SchoolName LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<schools> GetBySchoolAddress(string value)
		{
			return RunQuery("SELECT * FROM schooldb.schools WHERE SchoolAddress LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<schools> GetBySchoolTel(string value)
		{
			return RunQuery("SELECT * FROM schooldb.schools WHERE SchoolTel LIKE @Value",new MySqlParameter("Value",value));
		}
	}
}

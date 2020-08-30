using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SchoolApp.Entities;
using SchoolApp.DataLayer;
using SchoolApp.RepositoryAbstracts;
namespace SchoolApp.Repositories
{
	public class ClassroomsRepository : GenericRepository<classrooms>, IclassroomsRepository
	{
		public ClassroomsRepository(): base("name=mySQL") { }
		public List<classrooms> GetByClassID(byte value)
		{
			return RunQuery("SELECT * FROM schooldb.classrooms WHERE ClassID = @Value",new MySqlParameter("Value",value));
		}
		public List<classrooms> GetByClassName(string value)
		{
			return RunQuery("SELECT * FROM schooldb.classrooms WHERE ClassName LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<classrooms> GetByClassLevel(byte value)
		{
			return RunQuery("SELECT * FROM schooldb.classrooms WHERE ClassLevel = @Value",new MySqlParameter("Value",value));
		}
		public List<classrooms> GetByClassRegisterDate(DateTime value)
		{
			return RunQuery("SELECT * FROM schooldb.classrooms WHERE ClassRegisterDate = @Value",new MySqlParameter("Value",value));
		}
		public List<classrooms> GetByClassRoomEnable(byte value)
		{
			return RunQuery("SELECT * FROM schooldb.classrooms WHERE ClassRoomEnable = @Value",new MySqlParameter("Value",value));
		}
	}
}

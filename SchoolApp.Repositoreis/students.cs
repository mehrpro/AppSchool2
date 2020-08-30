using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SchoolApp.Entities;
using SchoolApp.DataLayer;
using SchoolApp.RepositoryAbstracts;
namespace SchoolApp.Repositories
{
	public class studentsRepository : GenericRepository<students>, IstudentsRepository
	{
		public studentsRepository() : base("name=mySQL") { }
		public List<students> GetByID(int value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE ID = @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByFName(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE FName LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByLName(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE LName LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByFullName(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE FullName LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByStudentCode(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE StudentCode LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByStudentNatinalCode(int value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE StudentNatinalCode = @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByFatherName(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE FatherName LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByMotherName(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE MotherName LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByHomePhone(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE HomePhone LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByFatherPhone(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE FatherPhone LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByMotherPhone(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE MotherPhone LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetBySMS(string value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE SMS LIKE @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByBrithDate(DateTime? value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE BrithDate = @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByRegDate(DateTime value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE RegDate = @Value",new MySqlParameter("Value",value));
		}
		public List<students> GetByenabled(byte value)
		{
			return RunQuery("SELECT * FROM schooldb.students WHERE enabled = @Value",new MySqlParameter("Value",value));
		}
	}
}

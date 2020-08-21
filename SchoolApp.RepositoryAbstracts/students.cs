using System;
using System.Collections.Generic;
using SchoolApp.Entities;
using SchoolApp.DataLayer;
namespace SchoolApp.RepositoryAbstracts
{
	public interface IstudentsRepository : IRepository<students>
	{
		List<SchoolApp.Entities.students> GetByID(int value);
		List<SchoolApp.Entities.students> GetByFName(string value);
		List<SchoolApp.Entities.students> GetByLName(string value);
		List<SchoolApp.Entities.students> GetByFullName(string value);
		List<SchoolApp.Entities.students> GetByStudentCode(string value);
		List<SchoolApp.Entities.students> GetByStudentNatinalCode(int value);
		List<SchoolApp.Entities.students> GetByFatherName(string value);
		List<SchoolApp.Entities.students> GetByMotherName(string value);
		List<SchoolApp.Entities.students> GetByHomePhone(string value);
		List<SchoolApp.Entities.students> GetByFatherPhone(string value);
		List<SchoolApp.Entities.students> GetByMotherPhone(string value);
		List<SchoolApp.Entities.students> GetBySMS(string value);
		List<SchoolApp.Entities.students> GetByBrithDate(object value);
		List<SchoolApp.Entities.students> GetByRegDate(DateTime value);
		List<SchoolApp.Entities.students> GetByenabled(bool value);
	}
}

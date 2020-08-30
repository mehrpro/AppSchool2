using System;
using System.Collections.Generic;
using SchoolApp.Entities;
using SchoolApp.DataLayer;
namespace SchoolApp.RepositoryAbstracts
{
	public interface IschoolsRepository : IRepository<schools>
	{
		List<SchoolApp.Entities.schools> GetByID(byte value);
		List<SchoolApp.Entities.schools> GetBySchoolName(string value);
		List<SchoolApp.Entities.schools> GetBySchoolAddress(string value);
		List<SchoolApp.Entities.schools> GetBySchoolTel(string value);
	}
}

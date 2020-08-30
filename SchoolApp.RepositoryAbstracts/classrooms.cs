using System;
using System.Collections.Generic;
using SchoolApp.Entities;
using SchoolApp.DataLayer;
namespace SchoolApp.RepositoryAbstracts
{
	public interface IclassroomsRepository : IRepository<classrooms>
	{
		List<SchoolApp.Entities.classrooms> GetByClassID(byte value);
		List<SchoolApp.Entities.classrooms> GetByClassName(string value);
		List<SchoolApp.Entities.classrooms> GetByClassLevel(byte value);
		List<SchoolApp.Entities.classrooms> GetByClassRegisterDate(DateTime value);
		List<SchoolApp.Entities.classrooms> GetByClassRoomEnable(byte value);
	}
}

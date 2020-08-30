using System;
using System.ComponentModel;
using SchoolApp.DataLayer;
namespace SchoolApp.Entities
{
	[Table("schooldb","classrooms")]
	public class classrooms
	{
		[PrimeryKey]
		[DisplayName("شناسه")]
		 public byte	ClassID	{get;set;}
		[DisplayName("نام کلاس")]
		 public string	ClassName	{get;set;}
		[DisplayName("مقطع تحصیلی")]
		 public byte	ClassLevel	{get;set;}
		[DisplayName("تاریخ ثبت")]
		 public DateTime	ClassRegisterDate	{get;set;}
		[DisplayName("فعال بودن کلاس")]
		 public byte	ClassRoomEnable	{get;set;}
	}
}

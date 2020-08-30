using System;
using System.ComponentModel;
using SchoolApp.DataLayer;
namespace SchoolApp.Entities
{
	[Table("schooldb","schools")]
	public class schools
	{
		[PrimeryKey]
		[Identity]
		[DisplayName("شناسه")]
		 public byte	ID	{get;set;}
		[DisplayName("نام مدرسه")]
		 public string	SchoolName	{get;set;}
		[DisplayName("آدرس مدرسه")]
		 public string	SchoolAddress	{get;set;}
		[DisplayName("تلفن مدرسه")]
		 public string	SchoolTel	{get;set;}
	}
}

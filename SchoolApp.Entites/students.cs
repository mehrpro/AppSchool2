using System;
using System.ComponentModel;
using SchoolApp.DataLayer;
namespace SchoolApp.Entities
{
	[Table("schooldb","students")]
	public class students
	{
		[PrimeryKey]
		[Identity]
		[DisplayName("شناسه")]
		 public int	ID	{get;set;}
		[DisplayName("نام")]
		 public string	FName	{get;set;}
		[DisplayName("فامیلی")]
		 public string	LName	{get;set;}
		[ComputedColumn]
		[DisplayName("نام کامل")]
		 public string	FullName	{get;set;}
		[DisplayName("کد دانش آموزشی")]
		 public string	StudentCode	{get;set;}
		[DisplayName("کد ملی")]
		 public int	StudentNatinalCode	{get;set;}
		[DisplayName("نام پدر")]
		 public string	FatherName	{get;set;}
		[DisplayName("نام مادر")]
		 public string	MotherName	{get;set;}
		[DisplayName("تلفن منزل")]
		 public string	HomePhone	{get;set;}
		[DisplayName("موبایل پدر")]
		 public string	FatherPhone	{get;set;}
		[DisplayName("موبایل مادر")]
		 public string	MotherPhone	{get;set;}
		[DisplayName("پیامک")]
		 public string	SMS	{get;set;}
		[DisplayName("تاریخ تولد")]
		 public DateTime?	BrithDate	{get;set;}
		[DisplayName("تاریخ ثبت")]
		 public DateTime 	RegDate	{get;set;}
		[DisplayName("وضعیت")]
		 public byte	enabled	{get;set;}
	}
}

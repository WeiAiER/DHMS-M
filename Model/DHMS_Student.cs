using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Student:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Student
	{
		public DHMS_Student()
		{}
		#region Model
		private int _student_id;
		private string _student_sno;
		private string _student_name;
		private string _student_sex;
		private DateTime _student_birthday;
		private string _student_num;
		private string _department_id;
		private string _class_id;
		/// <summary>
		/// 学生ID
		/// </summary>
		public int Student_ID
		{
			set{ _student_id=value;}
			get{return _student_id;}
		}
		/// <summary>
		/// 学生学号
		/// </summary>
		public string Student_Sno
		{
			set{ _student_sno=value;}
			get{return _student_sno;}
		}
		/// <summary>
		/// 学生名称
		/// </summary>
		public string Student_Name
		{
			set{ _student_name=value;}
			get{return _student_name;}
		}
		/// <summary>
		/// 学生性别
		/// </summary>
		public string Student_Sex
		{
			set{ _student_sex=value;}
			get{return _student_sex;}
		}
		/// <summary>
		/// 学生出生日期
		/// </summary>
		public DateTime Student_Birthday
		{
			set{ _student_birthday=value;}
			get{return _student_birthday;}
		}
		/// <summary>
		/// 学生电话
		/// </summary>
		public string Student_Num
		{
			set{ _student_num=value;}
			get{return _student_num;}
		}
		/// <summary>
		/// 系部名称
		/// </summary>
		public string Department_ID
		{
			set{ _department_id=value;}
			get{return _department_id;}
		}
		/// <summary>
		/// 班级名称
		/// </summary>
		public string Class_ID
		{
			set{ _class_id=value;}
			get{return _class_id;}
		}
		#endregion Model

	}
}


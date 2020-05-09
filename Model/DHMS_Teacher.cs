using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Teacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Teacher
	{
		public DHMS_Teacher()
		{}
		#region Model
		private int _teacher_id;
		private string _teacher_tno;
		private string _teacher_name;
		private string _teacher_sex;
		private DateTime _teacher_birthday;
		private string _teacher_num;
		private string _department_id;
		/// <summary>
		/// 教师ID
		/// </summary>
		public int Teacher_ID
		{
			set{ _teacher_id=value;}
			get{return _teacher_id;}
		}
		/// <summary>
		/// 教师教工号
		/// </summary>
		public string Teacher_Tno
		{
			set{ _teacher_tno=value;}
			get{return _teacher_tno;}
		}
		/// <summary>
		/// 教师名称
		/// </summary>
		public string Teacher_Name
		{
			set{ _teacher_name=value;}
			get{return _teacher_name;}
		}
		/// <summary>
		/// 教师性别
		/// </summary>
		public string Teacher_Sex
		{
			set{ _teacher_sex=value;}
			get{return _teacher_sex;}
		}
		/// <summary>
		/// 教师出生日期
		/// </summary>
		public DateTime Teacher_Birthday
		{
			set{ _teacher_birthday=value;}
			get{return _teacher_birthday;}
		}
		/// <summary>
		/// 教师电话
		/// </summary>
		public string Teacher_Num
		{
			set{ _teacher_num=value;}
			get{return _teacher_num;}
		}
		/// <summary>
		/// 系部名称
		/// </summary>
		public string Department_ID
		{
			set{ _department_id=value;}
			get{return _department_id;}
		}
		#endregion Model

	}
}


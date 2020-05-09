using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Class:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Class
	{
		public DHMS_Class()
		{}
		#region Model
		private string _class_id;
		private string _class_name;
		private string _department_id;
		private string _teacher_tno;
		/// <summary>
		/// 班级ID
		/// </summary>
		public string Class_ID
		{
			set{ _class_id=value;}
			get{return _class_id;}
		}
		/// <summary>
		/// 班级名称
		/// </summary>
		public string Class_Name
		{
			set{ _class_name=value;}
			get{return _class_name;}
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
		/// 班主任
		/// </summary>
		public string Teacher_Tno
		{
			set{ _teacher_tno=value;}
			get{return _teacher_tno;}
		}
		#endregion Model

	}
}


using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Department
	{
		public DHMS_Department()
		{}
		#region Model
		private string _department_id;
		private string _department_name;
		private string _teacher_tno;
		/// <summary>
		/// 系部ID
		/// </summary>
		public string Department_ID
		{
			set{ _department_id=value;}
			get{return _department_id;}
		}
		/// <summary>
		/// 系部名称
		/// </summary>
		public string Department_Name
		{
			set{ _department_name=value;}
			get{return _department_name;}
		}
		/// <summary>
		/// 系部负责人
		/// </summary>
		public string Teacher_Tno
		{
			set{ _teacher_tno=value;}
			get{return _teacher_tno;}
		}
		#endregion Model

	}
}


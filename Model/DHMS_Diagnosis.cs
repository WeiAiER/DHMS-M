using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Diagnosis:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Diagnosis
	{
		public DHMS_Diagnosis()
		{}
		#region Model
		private int _diagnosis_id;
		private string _diagnosis_number;
		private string _diagnosis_name;
		/// <summary>
		/// 诊断ID
		/// </summary>
		public int Diagnosis_ID
		{
			set{ _diagnosis_id=value;}
			get{return _diagnosis_id;}
		}
		/// <summary>
		/// 诊断编号
		/// </summary>
		public string Diagnosis_Number
		{
			set{ _diagnosis_number=value;}
			get{return _diagnosis_number;}
		}
		/// <summary>
		/// 诊断名称
		/// </summary>
		public string Diagnosis_Name
		{
			set{ _diagnosis_name=value;}
			get{return _diagnosis_name;}
		}
		#endregion Model

	}
}


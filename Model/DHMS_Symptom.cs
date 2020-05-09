using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Symptom:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Symptom
	{
		public DHMS_Symptom()
		{}
		#region Model
		private int _symptom_id;
		private string _symptom_number;
		private string _symptom_name;
		/// <summary>
		/// 
		/// </summary>
		public int Symptom_ID
		{
			set{ _symptom_id=value;}
			get{return _symptom_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Symptom_Number
		{
			set{ _symptom_number=value;}
			get{return _symptom_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Symptom_Name
		{
			set{ _symptom_name=value;}
			get{return _symptom_name;}
		}
		#endregion Model

	}
}


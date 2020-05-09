using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Epidemic:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Epidemic
	{
		public DHMS_Epidemic()
		{}
		#region Model
		private int _epidemic_id;
		private string _epidemic_number;
		private string _epidemic_name;
		/// <summary>
		/// 流行病学ID
		/// </summary>
		public int Epidemic_ID
		{
			set{ _epidemic_id=value;}
			get{return _epidemic_id;}
		}
		/// <summary>
		/// 流行病学编号
		/// </summary>
		public string Epidemic_Number
		{
			set{ _epidemic_number=value;}
			get{return _epidemic_number;}
		}
		/// <summary>
		/// 流行病学名称
		/// </summary>
		public string Epidemic_Name
		{
			set{ _epidemic_name=value;}
			get{return _epidemic_name;}
		}
		#endregion Model

	}
}


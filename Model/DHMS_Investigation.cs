using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Investigation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Investigation
	{
		public DHMS_Investigation()
		{}
		#region Model
		private string _investigation_id;
		private int? _investigation_order;
		private string _investigation_problem;
		private string _investigation_option;
		private string _investigation_type;
		/// <summary>
		/// 疫情调查ID
		/// </summary>
		public string Investigation_ID
		{
			set{ _investigation_id=value;}
			get{return _investigation_id;}
		}
		/// <summary>
		/// 疫情调查排序
		/// </summary>
		public int? Investigation_Order
		{
			set{ _investigation_order=value;}
			get{return _investigation_order;}
		}
		/// <summary>
		/// 疫情调查问题
		/// </summary>
		public string Investigation_Problem
		{
			set{ _investigation_problem=value;}
			get{return _investigation_problem;}
		}
		/// <summary>
		/// 疫情调查父ID
		/// </summary>
		public string Investigation_Option
		{
			set{ _investigation_option=value;}
			get{return _investigation_option;}
		}
		/// <summary>
		/// 疫情调查日期
		/// </summary>
		public string Investigation_Type
		{
			set{ _investigation_type=value;}
			get{return _investigation_type;}
		}
		#endregion Model

	}
}


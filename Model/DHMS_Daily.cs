using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Daily:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Daily
	{
		public DHMS_Daily()
		{}
		#region Model
		private string _daily_id;
		private string _teacher_tno;
		private string _investigation_id;
		private string _daily_reply;
		private DateTime? _daily_datetime;
		/// <summary>
		/// 疫情日报ID
		/// </summary>
		public string Daily_ID
		{
			set{ _daily_id=value;}
			get{return _daily_id;}
		}
		/// <summary>
		/// 教工号
		/// </summary>
		public string Teacher_Tno
		{
			set{ _teacher_tno=value;}
			get{return _teacher_tno;}
		}
		/// <summary>
		/// 问题ID
		/// </summary>
		public string Investigation_ID
		{
			set{ _investigation_id=value;}
			get{return _investigation_id;}
		}
		/// <summary>
		/// 问题回答
		/// </summary>
		public string Daily_Reply
		{
			set{ _daily_reply=value;}
			get{return _daily_reply;}
		}
		/// <summary>
		/// 疫情日报日期
		/// </summary>
		public DateTime? Daily_DateTime
		{
			set{ _daily_datetime=value;}
			get{return _daily_datetime;}
		}
		#endregion Model

	}
}


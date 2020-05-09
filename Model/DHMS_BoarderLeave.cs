using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_BoarderLeave:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_BoarderLeave
	{
		public DHMS_BoarderLeave()
		{}
		#region Model
		private string _boarderleave_id;
		private DateTime _boarderleave_date;
		private string _boarderleave_reason;
		private string _boarderleave_auditor;
		private string _boarderleave_state;
		/// <summary>
		/// 住宿生请假ID
		/// </summary>
		public string BoarderLeave_ID
		{
			set{ _boarderleave_id=value;}
			get{return _boarderleave_id;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime BoarderLeave_Date
		{
			set{ _boarderleave_date=value;}
			get{return _boarderleave_date;}
		}
		/// <summary>
		/// 请假原因
		/// </summary>
		public string BoarderLeave_Reason
		{
			set{ _boarderleave_reason=value;}
			get{return _boarderleave_reason;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public string BoarderLeave_Auditor
		{
			set{ _boarderleave_auditor=value;}
			get{return _boarderleave_auditor;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string BoarderLeave_State
		{
			set{ _boarderleave_state=value;}
			get{return _boarderleave_state;}
		}
		#endregion Model

	}
}


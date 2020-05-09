using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_BoarderManage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_BoarderManage
	{
		public DHMS_BoarderManage()
		{}
		#region Model
		private string _boardermanage_id;
		private DateTime _boardermanage_date;
		private string _student_sno;
		private DateTime _boardermanage_rtime;
		private string _boardermanage_feedback;
		private DateTime _boardermanage_ntime;
		/// <summary>
		/// 住宿生管理ID
		/// </summary>
		public string BoarderManage_ID
		{
			set{ _boardermanage_id=value;}
			get{return _boardermanage_id;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime BoarderManage_Date
		{
			set{ _boardermanage_date=value;}
			get{return _boardermanage_date;}
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
		/// 回宿舍时间
		/// </summary>
		public DateTime BoarderManage_RTime
		{
			set{ _boardermanage_rtime=value;}
			get{return _boardermanage_rtime;}
		}
		/// <summary>
		/// 晚检反馈
		/// </summary>
		public string BoarderManage_Feedback
		{
			set{ _boardermanage_feedback=value;}
			get{return _boardermanage_feedback;}
		}
		/// <summary>
		/// 晚检时间
		/// </summary>
		public DateTime BoarderManage_NTime
		{
			set{ _boardermanage_ntime=value;}
			get{return _boardermanage_ntime;}
		}
		#endregion Model

	}
}


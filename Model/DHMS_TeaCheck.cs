using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_TeaCheck:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_TeaCheck
	{
		public DHMS_TeaCheck()
		{}
		#region Model
		private string _teacheck_id;
		private string _teacher_tno;
		private string _teacheck_term;
		private DateTime _teacheck_date;
		private string _teacheck_stage;
		private string _teacheck_remarks;
		/// <summary>
		/// 教工晨午检ID
		/// </summary>
		public string TeaCheck_ID
		{
			set{ _teacheck_id=value;}
			get{return _teacheck_id;}
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
		/// 学期
		/// </summary>
		public string TeaCheck_Term
		{
			set{ _teacheck_term=value;}
			get{return _teacheck_term;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime TeaCheck_Date
		{
			set{ _teacheck_date=value;}
			get{return _teacheck_date;}
		}
		/// <summary>
		/// 阶段
		/// </summary>
		public string TeaCheck_Stage
		{
			set{ _teacheck_stage=value;}
			get{return _teacheck_stage;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string TeaCheck_Remarks
		{
			set{ _teacheck_remarks=value;}
			get{return _teacheck_remarks;}
		}
		#endregion Model

	}
}


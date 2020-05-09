using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_StuCheck:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_StuCheck
	{
		public DHMS_StuCheck()
		{}
		#region Model
		private string _stucheck_id;
		private string _student_sno;
		private string _stucheck_term;
		private DateTime _stucheck_date;
		private string _stucheck_stage;
		private string _stucheck_remarks;
		/// <summary>
		/// 学生晨午检ID
		/// </summary>
		public string StuCheck_ID
		{
			set{ _stucheck_id=value;}
			get{return _stucheck_id;}
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
		/// 学期
		/// </summary>
		public string StuCheck_Term
		{
			set{ _stucheck_term=value;}
			get{return _stucheck_term;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime StuCheck_Date
		{
			set{ _stucheck_date=value;}
			get{return _stucheck_date;}
		}
		/// <summary>
		/// 阶段
		/// </summary>
		public string StuCheck_Stage
		{
			set{ _stucheck_stage=value;}
			get{return _stucheck_stage;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string StuCheck_Remarks
		{
			set{ _stucheck_remarks=value;}
			get{return _stucheck_remarks;}
		}
		#endregion Model

	}
}


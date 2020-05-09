using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Boarder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Boarder
	{
		public DHMS_Boarder()
		{}
		#region Model
		private string _boarder_id;
		private string _student_sno;
		private string _boarder_hostelnum;
		/// <summary>
		/// 住宿生信息ID
		/// </summary>
		public string Boarder_ID
		{
			set{ _boarder_id=value;}
			get{return _boarder_id;}
		}
		/// <summary>
		/// 学生ID
		/// </summary>
		public string Student_Sno
		{
			set{ _student_sno=value;}
			get{return _student_sno;}
		}
		/// <summary>
		/// 宿舍号
		/// </summary>
		public string Boarder_HostelNum
		{
			set{ _boarder_hostelnum=value;}
			get{return _boarder_hostelnum;}
		}
		#endregion Model

	}
}


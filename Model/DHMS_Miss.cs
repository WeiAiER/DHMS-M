using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Miss:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Miss
	{
		public DHMS_Miss()
		{}
		#region Model
		private string _miss_id;
		private string _student_sno;
		private string _miss_fever;
		private string _symptom_number;
		private string _diagnosis_number;
		private string _miss_mstate;
		private string _miss_mhospital;
		private int _miss_days;
		private int _miss_classhour;
		private string _miss_type;
		private string _epidemic_number;
		private string _teacher_tno;
		private DateTime _miss_rdatetime;
		/// <summary>
		/// 缺课ID
		/// </summary>
		public string Miss_ID
		{
			set{ _miss_id=value;}
			get{return _miss_id;}
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
		/// 是否发烧
		/// </summary>
		public string Miss_Fever
		{
			set{ _miss_fever=value;}
			get{return _miss_fever;}
		}
		/// <summary>
		/// 症状编号
		/// </summary>
		public string Symptom_Number
		{
			set{ _symptom_number=value;}
			get{return _symptom_number;}
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
		/// 就诊状态
		/// </summary>
		public string Miss_MState
		{
			set{ _miss_mstate=value;}
			get{return _miss_mstate;}
		}
		/// <summary>
		/// 就诊医院
		/// </summary>
		public string Miss_MHospital
		{
			set{ _miss_mhospital=value;}
			get{return _miss_mhospital;}
		}
		/// <summary>
		/// 缺课天数
		/// </summary>
		public int Miss_Days
		{
			set{ _miss_days=value;}
			get{return _miss_days;}
		}
		/// <summary>
		/// 缺课课时
		/// </summary>
		public int Miss_ClassHour
		{
			set{ _miss_classhour=value;}
			get{return _miss_classhour;}
		}
		/// <summary>
		/// 缺课类型
		/// </summary>
		public string Miss_Type
		{
			set{ _miss_type=value;}
			get{return _miss_type;}
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
		/// 报告人
		/// </summary>
		public string Teacher_Tno
		{
			set{ _teacher_tno=value;}
			get{return _teacher_tno;}
		}
		/// <summary>
		/// 报告日期
		/// </summary>
		public DateTime Miss_RDateTime
		{
			set{ _miss_rdatetime=value;}
			get{return _miss_rdatetime;}
		}
		#endregion Model

	}
}


using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Receive:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Receive
	{
		public DHMS_Receive()
		{}
		#region Model
		private string _receive_id;
		private string _material_id;
		private string _teacher_tno;
		private int _receive_number;
		private DateTime _receive_datetime;
		/// <summary>
		/// 物资领用ID
		/// </summary>
		public string Receive_ID
		{
			set{ _receive_id=value;}
			get{return _receive_id;}
		}
		/// <summary>
		/// 物资ID
		/// </summary>
		public string Material_ID
		{
			set{ _material_id=value;}
			get{return _material_id;}
		}
		/// <summary>
		/// 领用人
		/// </summary>
		public string Teacher_Tno
		{
			set{ _teacher_tno=value;}
			get{return _teacher_tno;}
		}
		/// <summary>
		/// 领用数量
		/// </summary>
		public int Receive_Number
		{
			set{ _receive_number=value;}
			get{return _receive_number;}
		}
		/// <summary>
		/// 领用日期
		/// </summary>
		public DateTime Receive_DateTime
		{
			set{ _receive_datetime=value;}
			get{return _receive_datetime;}
		}
		#endregion Model

	}
}


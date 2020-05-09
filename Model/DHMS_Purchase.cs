using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Purchase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Purchase
	{
		public DHMS_Purchase()
		{}
		#region Model
		private string _purchase_id;
		private string _material_id;
		private int _purchase_number;
		private DateTime _purchase_datetime;
		private string _teacher_tno;
		/// <summary>
		/// 物资采购ID
		/// </summary>
		public string Purchase_ID
		{
			set{ _purchase_id=value;}
			get{return _purchase_id;}
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
		/// 采购数量
		/// </summary>
		public int Purchase_Number
		{
			set{ _purchase_number=value;}
			get{return _purchase_number;}
		}
		/// <summary>
		/// 采购日期
		/// </summary>
		public DateTime Purchase_DateTime
		{
			set{ _purchase_datetime=value;}
			get{return _purchase_datetime;}
		}
		/// <summary>
		/// 采购人
		/// </summary>
		public string Teacher_Tno
		{
			set{ _teacher_tno=value;}
			get{return _teacher_tno;}
		}
		#endregion Model

	}
}


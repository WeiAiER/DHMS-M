using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Material:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Material
	{
		public DHMS_Material()
		{}
		#region Model
		private string _material_id;
		private string _material_name;
		private string _material_specs;
		private string _material_unit;
		private string _material_place;
		private string _material_certificate;
		private DateTime _material_pdatetime;
		private DateTime _material_edatetime;
		private string _material_method;
		/// <summary>
		/// 物资详情ID
		/// </summary>
		public string Material_ID
		{
			set{ _material_id=value;}
			get{return _material_id;}
		}
		/// <summary>
		/// 物资名称
		/// </summary>
		public string Material_Name
		{
			set{ _material_name=value;}
			get{return _material_name;}
		}
		/// <summary>
		/// 物资规格
		/// </summary>
		public string Material_Specs
		{
			set{ _material_specs=value;}
			get{return _material_specs;}
		}
		/// <summary>
		/// 物资单位
		/// </summary>
		public string Material_Unit
		{
			set{ _material_unit=value;}
			get{return _material_unit;}
		}
		/// <summary>
		/// 物资产地
		/// </summary>
		public string Material_Place
		{
			set{ _material_place=value;}
			get{return _material_place;}
		}
		/// <summary>
		/// 物资合格证
		/// </summary>
		public string Material_Certificate
		{
			set{ _material_certificate=value;}
			get{return _material_certificate;}
		}
		/// <summary>
		/// 物资采购日期
		/// </summary>
		public DateTime Material_PDateTime
		{
			set{ _material_pdatetime=value;}
			get{return _material_pdatetime;}
		}
		/// <summary>
		/// 物资有效日期
		/// </summary>
		public DateTime Material_EDateTime
		{
			set{ _material_edatetime=value;}
			get{return _material_edatetime;}
		}
		/// <summary>
		/// 物资使用方法
		/// </summary>
		public string Material_Method
		{
			set{ _material_method=value;}
			get{return _material_method;}
		}
		#endregion Model

	}
}


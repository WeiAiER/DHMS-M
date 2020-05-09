using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Role
	{
		public DHMS_Role()
		{}
		#region Model
		private string _role_id;
		private string _role_name;
		private string _role_introduction;
		/// <summary>
		/// 角色ID
		/// </summary>
		public string Role_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string Role_Name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 简介
		/// </summary>
		public string Role_Introduction
		{
			set{ _role_introduction=value;}
			get{return _role_introduction;}
		}
		#endregion Model

	}
}


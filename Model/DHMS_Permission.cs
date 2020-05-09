using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_Permission:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_Permission
	{
		public DHMS_Permission()
		{}
		#region Model
		private string _permissions_id;
		private string _permissions_name;
		private string _permissions_introduction;
		/// <summary>
		/// 权限ID
		/// </summary>
		public string Permissions_ID
		{
			set{ _permissions_id=value;}
			get{return _permissions_id;}
		}
		/// <summary>
		/// 权限名称
		/// </summary>
		public string Permissions_Name
		{
			set{ _permissions_name=value;}
			get{return _permissions_name;}
		}
		/// <summary>
		/// 权限简介
		/// </summary>
		public string Permissions_Introduction
		{
			set{ _permissions_introduction=value;}
			get{return _permissions_introduction;}
		}
		#endregion Model

	}
}


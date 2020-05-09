using System;
namespace DHMSClass.Model
{
	/// <summary>
	/// DHMS_RolePer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DHMS_RolePer
	{
		public DHMS_RolePer()
		{}
		#region Model
		private string _roleper_id;
		private string _role_id;
		private string _permissions_id;
		/// <summary>
		/// 角色权限ID
		/// </summary>
		public string RolePer_ID
		{
			set{ _roleper_id=value;}
			get{return _roleper_id;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public string Role_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 权限ID
		/// </summary>
		public string Permissions_ID
		{
			set{ _permissions_id=value;}
			get{return _permissions_id;}
		}
		#endregion Model

	}
}


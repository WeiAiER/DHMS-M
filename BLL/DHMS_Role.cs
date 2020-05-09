﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using DHMSClass.Model;
namespace DHMSClass.BLL
{
	/// <summary>
	/// DHMS_Role
	/// </summary>
	public partial class DHMS_Role
	{
		private readonly DHMSClass.DAL.DHMS_Role dal=new DHMSClass.DAL.DHMS_Role();
		public DHMS_Role()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Role_ID)
		{
			return dal.Exists(Role_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Role model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DHMSClass.Model.DHMS_Role model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Role_ID)
		{
			
			return dal.Delete(Role_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Role_IDlist )
		{
			return dal.DeleteList(Role_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DHMSClass.Model.DHMS_Role GetModel(string Role_ID)
		{
			
			return dal.GetModel(Role_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DHMSClass.Model.DHMS_Role GetModelByCache(string Role_ID)
		{
			
			string CacheKey = "DHMS_RoleModel-" + Role_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Role_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DHMSClass.Model.DHMS_Role)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DHMSClass.Model.DHMS_Role> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DHMSClass.Model.DHMS_Role> DataTableToList(DataTable dt)
		{
			List<DHMSClass.Model.DHMS_Role> modelList = new List<DHMSClass.Model.DHMS_Role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DHMSClass.Model.DHMS_Role model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


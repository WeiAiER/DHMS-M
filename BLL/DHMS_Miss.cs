﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using DHMSClass.Model;
namespace DHMSClass.BLL
{
	/// <summary>
	/// DHMS_Miss
	/// </summary>
	public partial class DHMS_Miss
	{
		private readonly DHMSClass.DAL.DHMS_Miss dal=new DHMSClass.DAL.DHMS_Miss();
		public DHMS_Miss()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Miss_ID)
		{
			return dal.Exists(Miss_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Miss model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DHMSClass.Model.DHMS_Miss model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Miss_ID)
		{
			
			return dal.Delete(Miss_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Miss_IDlist )
		{
			return dal.DeleteList(Miss_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DHMSClass.Model.DHMS_Miss GetModel(string Miss_ID)
		{
			
			return dal.GetModel(Miss_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DHMSClass.Model.DHMS_Miss GetModelByCache(string Miss_ID)
		{
			
			string CacheKey = "DHMS_MissModel-" + Miss_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Miss_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DHMSClass.Model.DHMS_Miss)objModel;
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
		public List<DHMSClass.Model.DHMS_Miss> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DHMSClass.Model.DHMS_Miss> DataTableToList(DataTable dt)
		{
			List<DHMSClass.Model.DHMS_Miss> modelList = new List<DHMSClass.Model.DHMS_Miss>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DHMSClass.Model.DHMS_Miss model;
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


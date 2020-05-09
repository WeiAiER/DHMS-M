using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Material
	/// </summary>
	public partial class DHMS_Material
	{
		public DHMS_Material()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Material_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Material");
			strSql.Append(" where Material_ID='"+Material_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Material model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Material_ID != null)
			{
				strSql1.Append("Material_ID,");
				strSql2.Append("'"+model.Material_ID+"',");
			}
			if (model.Material_Name != null)
			{
				strSql1.Append("Material_Name,");
				strSql2.Append("'"+model.Material_Name+"',");
			}
			if (model.Material_Specs != null)
			{
				strSql1.Append("Material_Specs,");
				strSql2.Append("'"+model.Material_Specs+"',");
			}
			if (model.Material_Unit != null)
			{
				strSql1.Append("Material_Unit,");
				strSql2.Append("'"+model.Material_Unit+"',");
			}
			if (model.Material_Place != null)
			{
				strSql1.Append("Material_Place,");
				strSql2.Append("'"+model.Material_Place+"',");
			}
			if (model.Material_Certificate != null)
			{
				strSql1.Append("Material_Certificate,");
				strSql2.Append("'"+model.Material_Certificate+"',");
			}
			if (model.Material_PDateTime != null)
			{
				strSql1.Append("Material_PDateTime,");
				strSql2.Append("'"+model.Material_PDateTime+"',");
			}
			if (model.Material_EDateTime != null)
			{
				strSql1.Append("Material_EDateTime,");
				strSql2.Append("'"+model.Material_EDateTime+"',");
			}
			if (model.Material_Method != null)
			{
				strSql1.Append("Material_Method,");
				strSql2.Append("'"+model.Material_Method+"',");
			}
			strSql.Append("insert into DHMS_Material(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DHMSClass.Model.DHMS_Material model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Material set ");
			if (model.Material_Name != null)
			{
				strSql.Append("Material_Name='"+model.Material_Name+"',");
			}
			if (model.Material_Specs != null)
			{
				strSql.Append("Material_Specs='"+model.Material_Specs+"',");
			}
			else
			{
				strSql.Append("Material_Specs= null ,");
			}
			if (model.Material_Unit != null)
			{
				strSql.Append("Material_Unit='"+model.Material_Unit+"',");
			}
			else
			{
				strSql.Append("Material_Unit= null ,");
			}
			if (model.Material_Place != null)
			{
				strSql.Append("Material_Place='"+model.Material_Place+"',");
			}
			else
			{
				strSql.Append("Material_Place= null ,");
			}
			if (model.Material_Certificate != null)
			{
				strSql.Append("Material_Certificate='"+model.Material_Certificate+"',");
			}
			else
			{
				strSql.Append("Material_Certificate= null ,");
			}
			if (model.Material_PDateTime != null)
			{
				strSql.Append("Material_PDateTime='"+model.Material_PDateTime+"',");
			}
			if (model.Material_EDateTime != null)
			{
				strSql.Append("Material_EDateTime='"+model.Material_EDateTime+"',");
			}
			if (model.Material_Method != null)
			{
				strSql.Append("Material_Method='"+model.Material_Method+"',");
			}
			else
			{
				strSql.Append("Material_Method= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Material_ID='"+ model.Material_ID+"' ");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Material_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Material ");
			strSql.Append(" where Material_ID='"+Material_ID+"' " );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Material_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Material ");
			strSql.Append(" where Material_ID in ("+Material_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DHMSClass.Model.DHMS_Material GetModel(string Material_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Material_ID,Material_Name,Material_Specs,Material_Unit,Material_Place,Material_Certificate,Material_PDateTime,Material_EDateTime,Material_Method ");
			strSql.Append(" from DHMS_Material ");
			strSql.Append(" where Material_ID='"+Material_ID+"' " );
			DHMSClass.Model.DHMS_Material model=new DHMSClass.Model.DHMS_Material();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DHMSClass.Model.DHMS_Material DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Material model=new DHMSClass.Model.DHMS_Material();
			if (row != null)
			{
				if(row["Material_ID"]!=null)
				{
					model.Material_ID=row["Material_ID"].ToString();
				}
				if(row["Material_Name"]!=null)
				{
					model.Material_Name=row["Material_Name"].ToString();
				}
				if(row["Material_Specs"]!=null)
				{
					model.Material_Specs=row["Material_Specs"].ToString();
				}
				if(row["Material_Unit"]!=null)
				{
					model.Material_Unit=row["Material_Unit"].ToString();
				}
				if(row["Material_Place"]!=null)
				{
					model.Material_Place=row["Material_Place"].ToString();
				}
				if(row["Material_Certificate"]!=null)
				{
					model.Material_Certificate=row["Material_Certificate"].ToString();
				}
				if(row["Material_PDateTime"]!=null && row["Material_PDateTime"].ToString()!="")
				{
					model.Material_PDateTime=DateTime.Parse(row["Material_PDateTime"].ToString());
				}
				if(row["Material_EDateTime"]!=null && row["Material_EDateTime"].ToString()!="")
				{
					model.Material_EDateTime=DateTime.Parse(row["Material_EDateTime"].ToString());
				}
				if(row["Material_Method"]!=null)
				{
					model.Material_Method=row["Material_Method"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Material_ID,Material_Name,Material_Specs,Material_Unit,Material_Place,Material_Certificate,Material_PDateTime,Material_EDateTime,Material_Method ");
			strSql.Append(" FROM DHMS_Material ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Material_ID,Material_Name,Material_Specs,Material_Unit,Material_Place,Material_Certificate,Material_PDateTime,Material_EDateTime,Material_Method ");
			strSql.Append(" FROM DHMS_Material ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM DHMS_Material ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Material_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Material T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}


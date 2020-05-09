using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_RolePer
	/// </summary>
	public partial class DHMS_RolePer
	{
		public DHMS_RolePer()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string RolePer_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_RolePer");
			strSql.Append(" where RolePer_ID='"+RolePer_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_RolePer model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.RolePer_ID != null)
			{
				strSql1.Append("RolePer_ID,");
				strSql2.Append("'"+model.RolePer_ID+"',");
			}
			if (model.Role_ID != null)
			{
				strSql1.Append("Role_ID,");
				strSql2.Append("'"+model.Role_ID+"',");
			}
			if (model.Permissions_ID != null)
			{
				strSql1.Append("Permissions_ID,");
				strSql2.Append("'"+model.Permissions_ID+"',");
			}
			strSql.Append("insert into DHMS_RolePer(");
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
		public bool Update(DHMSClass.Model.DHMS_RolePer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_RolePer set ");
			if (model.Role_ID != null)
			{
				strSql.Append("Role_ID='"+model.Role_ID+"',");
			}
			if (model.Permissions_ID != null)
			{
				strSql.Append("Permissions_ID='"+model.Permissions_ID+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where RolePer_ID='"+ model.RolePer_ID+"' ");
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
		public bool Delete(string RolePer_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_RolePer ");
			strSql.Append(" where RolePer_ID='"+RolePer_ID+"' " );
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
		public bool DeleteList(string RolePer_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_RolePer ");
			strSql.Append(" where RolePer_ID in ("+RolePer_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_RolePer GetModel(string RolePer_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" RolePer_ID,Role_ID,Permissions_ID ");
			strSql.Append(" from DHMS_RolePer ");
			strSql.Append(" where RolePer_ID='"+RolePer_ID+"' " );
			DHMSClass.Model.DHMS_RolePer model=new DHMSClass.Model.DHMS_RolePer();
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
		public DHMSClass.Model.DHMS_RolePer DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_RolePer model=new DHMSClass.Model.DHMS_RolePer();
			if (row != null)
			{
				if(row["RolePer_ID"]!=null)
				{
					model.RolePer_ID=row["RolePer_ID"].ToString();
				}
				if(row["Role_ID"]!=null)
				{
					model.Role_ID=row["Role_ID"].ToString();
				}
				if(row["Permissions_ID"]!=null)
				{
					model.Permissions_ID=row["Permissions_ID"].ToString();
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
			strSql.Append("select RolePer_ID,Role_ID,Permissions_ID ");
			strSql.Append(" FROM DHMS_RolePer ");
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
			strSql.Append(" RolePer_ID,Role_ID,Permissions_ID ");
			strSql.Append(" FROM DHMS_RolePer ");
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
			strSql.Append("select count(1) FROM DHMS_RolePer ");
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
				strSql.Append("order by T.RolePer_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_RolePer T ");
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


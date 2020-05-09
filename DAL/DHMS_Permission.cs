using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Permission
	/// </summary>
	public partial class DHMS_Permission
	{
		public DHMS_Permission()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Permissions_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Permission");
			strSql.Append(" where Permissions_ID='"+Permissions_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Permission model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Permissions_ID != null)
			{
				strSql1.Append("Permissions_ID,");
				strSql2.Append("'"+model.Permissions_ID+"',");
			}
			if (model.Permissions_Name != null)
			{
				strSql1.Append("Permissions_Name,");
				strSql2.Append("'"+model.Permissions_Name+"',");
			}
			if (model.Permissions_Introduction != null)
			{
				strSql1.Append("Permissions_Introduction,");
				strSql2.Append("'"+model.Permissions_Introduction+"',");
			}
			strSql.Append("insert into DHMS_Permission(");
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
		public bool Update(DHMSClass.Model.DHMS_Permission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Permission set ");
			if (model.Permissions_Name != null)
			{
				strSql.Append("Permissions_Name='"+model.Permissions_Name+"',");
			}
			if (model.Permissions_Introduction != null)
			{
				strSql.Append("Permissions_Introduction='"+model.Permissions_Introduction+"',");
			}
			else
			{
				strSql.Append("Permissions_Introduction= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Permissions_ID='"+ model.Permissions_ID+"' ");
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
		public bool Delete(string Permissions_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Permission ");
			strSql.Append(" where Permissions_ID='"+Permissions_ID+"' " );
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
		public bool DeleteList(string Permissions_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Permission ");
			strSql.Append(" where Permissions_ID in ("+Permissions_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Permission GetModel(string Permissions_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Permissions_ID,Permissions_Name,Permissions_Introduction ");
			strSql.Append(" from DHMS_Permission ");
			strSql.Append(" where Permissions_ID='"+Permissions_ID+"' " );
			DHMSClass.Model.DHMS_Permission model=new DHMSClass.Model.DHMS_Permission();
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
		public DHMSClass.Model.DHMS_Permission DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Permission model=new DHMSClass.Model.DHMS_Permission();
			if (row != null)
			{
				if(row["Permissions_ID"]!=null)
				{
					model.Permissions_ID=row["Permissions_ID"].ToString();
				}
				if(row["Permissions_Name"]!=null)
				{
					model.Permissions_Name=row["Permissions_Name"].ToString();
				}
				if(row["Permissions_Introduction"]!=null)
				{
					model.Permissions_Introduction=row["Permissions_Introduction"].ToString();
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
			strSql.Append("select Permissions_ID,Permissions_Name,Permissions_Introduction ");
			strSql.Append(" FROM DHMS_Permission ");
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
			strSql.Append(" Permissions_ID,Permissions_Name,Permissions_Introduction ");
			strSql.Append(" FROM DHMS_Permission ");
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
			strSql.Append("select count(1) FROM DHMS_Permission ");
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
				strSql.Append("order by T.Permissions_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Permission T ");
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


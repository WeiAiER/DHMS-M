using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Investigation
	/// </summary>
	public partial class DHMS_Investigation
	{
		public DHMS_Investigation()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Investigation_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Investigation");
			strSql.Append(" where Investigation_ID='"+Investigation_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Investigation model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Investigation_ID != null)
			{
				strSql1.Append("Investigation_ID,");
				strSql2.Append("'"+model.Investigation_ID+"',");
			}
			if (model.Investigation_Order != null)
			{
				strSql1.Append("Investigation_Order,");
				strSql2.Append(""+model.Investigation_Order+",");
			}
			if (model.Investigation_Problem != null)
			{
				strSql1.Append("Investigation_Problem,");
				strSql2.Append("'"+model.Investigation_Problem+"',");
			}
			if (model.Investigation_Option != null)
			{
				strSql1.Append("Investigation_Option,");
				strSql2.Append("'"+model.Investigation_Option+"',");
			}
			if (model.Investigation_Type != null)
			{
				strSql1.Append("Investigation_Type,");
				strSql2.Append("'"+model.Investigation_Type+"',");
			}
			strSql.Append("insert into DHMS_Investigation(");
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
		public bool Update(DHMSClass.Model.DHMS_Investigation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Investigation set ");
			if (model.Investigation_Order != null)
			{
				strSql.Append("Investigation_Order="+model.Investigation_Order+",");
			}
			else
			{
				strSql.Append("Investigation_Order= null ,");
			}
			if (model.Investigation_Problem != null)
			{
				strSql.Append("Investigation_Problem='"+model.Investigation_Problem+"',");
			}
			else
			{
				strSql.Append("Investigation_Problem= null ,");
			}
			if (model.Investigation_Option != null)
			{
				strSql.Append("Investigation_Option='"+model.Investigation_Option+"',");
			}
			else
			{
				strSql.Append("Investigation_Option= null ,");
			}
			if (model.Investigation_Type != null)
			{
				strSql.Append("Investigation_Type='"+model.Investigation_Type+"',");
			}
			else
			{
				strSql.Append("Investigation_Type= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Investigation_ID='"+ model.Investigation_ID+"' ");
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
		public bool Delete(string Investigation_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Investigation ");
			strSql.Append(" where Investigation_ID='"+Investigation_ID+"' " );
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
		public bool DeleteList(string Investigation_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Investigation ");
			strSql.Append(" where Investigation_ID in ("+Investigation_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Investigation GetModel(string Investigation_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Investigation_ID,Investigation_Order,Investigation_Problem,Investigation_Option,Investigation_Type ");
			strSql.Append(" from DHMS_Investigation ");
			strSql.Append(" where Investigation_ID='"+Investigation_ID+"' " );
			DHMSClass.Model.DHMS_Investigation model=new DHMSClass.Model.DHMS_Investigation();
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
		public DHMSClass.Model.DHMS_Investigation DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Investigation model=new DHMSClass.Model.DHMS_Investigation();
			if (row != null)
			{
				if(row["Investigation_ID"]!=null)
				{
					model.Investigation_ID=row["Investigation_ID"].ToString();
				}
				if(row["Investigation_Order"]!=null && row["Investigation_Order"].ToString()!="")
				{
					model.Investigation_Order=int.Parse(row["Investigation_Order"].ToString());
				}
				if(row["Investigation_Problem"]!=null)
				{
					model.Investigation_Problem=row["Investigation_Problem"].ToString();
				}
				if(row["Investigation_Option"]!=null)
				{
					model.Investigation_Option=row["Investigation_Option"].ToString();
				}
				if(row["Investigation_Type"]!=null)
				{
					model.Investigation_Type=row["Investigation_Type"].ToString();
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
			strSql.Append("select Investigation_ID,Investigation_Order,Investigation_Problem,Investigation_Option,Investigation_Type ");
			strSql.Append(" FROM DHMS_Investigation ");
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
			strSql.Append(" Investigation_ID,Investigation_Order,Investigation_Problem,Investigation_Option,Investigation_Type ");
			strSql.Append(" FROM DHMS_Investigation ");
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
			strSql.Append("select count(1) FROM DHMS_Investigation ");
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
				strSql.Append("order by T.Investigation_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Investigation T ");
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Daily
	/// </summary>
	public partial class DHMS_Daily
	{
		public DHMS_Daily()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Daily_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Daily");
			strSql.Append(" where Daily_ID='"+Daily_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Daily model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Daily_ID != null)
			{
				strSql1.Append("Daily_ID,");
				strSql2.Append("'"+model.Daily_ID+"',");
			}
			if (model.Teacher_Tno != null)
			{
				strSql1.Append("Teacher_Tno,");
				strSql2.Append("'"+model.Teacher_Tno+"',");
			}
			if (model.Investigation_ID != null)
			{
				strSql1.Append("Investigation_ID,");
				strSql2.Append("'"+model.Investigation_ID+"',");
			}
			if (model.Daily_Reply != null)
			{
				strSql1.Append("Daily_Reply,");
				strSql2.Append("'"+model.Daily_Reply+"',");
			}
			if (model.Daily_DateTime != null)
			{
				strSql1.Append("Daily_DateTime,");
				strSql2.Append("'"+model.Daily_DateTime+"',");
			}
			strSql.Append("insert into DHMS_Daily(");
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
		public bool Update(DHMSClass.Model.DHMS_Daily model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Daily set ");
			if (model.Teacher_Tno != null)
			{
				strSql.Append("Teacher_Tno='"+model.Teacher_Tno+"',");
			}
			if (model.Investigation_ID != null)
			{
				strSql.Append("Investigation_ID='"+model.Investigation_ID+"',");
			}
			if (model.Daily_Reply != null)
			{
				strSql.Append("Daily_Reply='"+model.Daily_Reply+"',");
			}
			else
			{
				strSql.Append("Daily_Reply= null ,");
			}
			if (model.Daily_DateTime != null)
			{
				strSql.Append("Daily_DateTime='"+model.Daily_DateTime+"',");
			}
			else
			{
				strSql.Append("Daily_DateTime= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Daily_ID='"+ model.Daily_ID+"' ");
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
		public bool Delete(string Daily_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Daily ");
			strSql.Append(" where Daily_ID='"+Daily_ID+"' " );
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
		public bool DeleteList(string Daily_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Daily ");
			strSql.Append(" where Daily_ID in ("+Daily_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Daily GetModel(string Daily_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Daily_ID,Teacher_Tno,Investigation_ID,Daily_Reply,Daily_DateTime ");
			strSql.Append(" from DHMS_Daily ");
			strSql.Append(" where Daily_ID='"+Daily_ID+"' " );
			DHMSClass.Model.DHMS_Daily model=new DHMSClass.Model.DHMS_Daily();
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
		public DHMSClass.Model.DHMS_Daily DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Daily model=new DHMSClass.Model.DHMS_Daily();
			if (row != null)
			{
				if(row["Daily_ID"]!=null)
				{
					model.Daily_ID=row["Daily_ID"].ToString();
				}
				if(row["Teacher_Tno"]!=null)
				{
					model.Teacher_Tno=row["Teacher_Tno"].ToString();
				}
				if(row["Investigation_ID"]!=null)
				{
					model.Investigation_ID=row["Investigation_ID"].ToString();
				}
				if(row["Daily_Reply"]!=null)
				{
					model.Daily_Reply=row["Daily_Reply"].ToString();
				}
				if(row["Daily_DateTime"]!=null && row["Daily_DateTime"].ToString()!="")
				{
					model.Daily_DateTime=DateTime.Parse(row["Daily_DateTime"].ToString());
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
			strSql.Append("select Daily_ID,Teacher_Tno,Investigation_ID,Daily_Reply,Daily_DateTime ");
			strSql.Append(" FROM DHMS_Daily ");
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
			strSql.Append(" Daily_ID,Teacher_Tno,Investigation_ID,Daily_Reply,Daily_DateTime ");
			strSql.Append(" FROM DHMS_Daily ");
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
			strSql.Append("select count(1) FROM DHMS_Daily ");
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
				strSql.Append("order by T.Daily_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Daily T ");
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


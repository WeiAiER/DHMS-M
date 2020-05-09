using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_BoarderLeave
	/// </summary>
	public partial class DHMS_BoarderLeave
	{
		public DHMS_BoarderLeave()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BoarderLeave_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_BoarderLeave");
			strSql.Append(" where BoarderLeave_ID='"+BoarderLeave_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_BoarderLeave model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.BoarderLeave_ID != null)
			{
				strSql1.Append("BoarderLeave_ID,");
				strSql2.Append("'"+model.BoarderLeave_ID+"',");
			}
			if (model.BoarderLeave_Date != null)
			{
				strSql1.Append("BoarderLeave_Date,");
				strSql2.Append("'"+model.BoarderLeave_Date+"',");
			}
			if (model.BoarderLeave_Reason != null)
			{
				strSql1.Append("BoarderLeave_Reason,");
				strSql2.Append("'"+model.BoarderLeave_Reason+"',");
			}
			if (model.BoarderLeave_Auditor != null)
			{
				strSql1.Append("BoarderLeave_Auditor,");
				strSql2.Append("'"+model.BoarderLeave_Auditor+"',");
			}
			if (model.BoarderLeave_State != null)
			{
				strSql1.Append("BoarderLeave_State,");
				strSql2.Append("'"+model.BoarderLeave_State+"',");
			}
			strSql.Append("insert into DHMS_BoarderLeave(");
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
		public bool Update(DHMSClass.Model.DHMS_BoarderLeave model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_BoarderLeave set ");
			if (model.BoarderLeave_Date != null)
			{
				strSql.Append("BoarderLeave_Date='"+model.BoarderLeave_Date+"',");
			}
			if (model.BoarderLeave_Reason != null)
			{
				strSql.Append("BoarderLeave_Reason='"+model.BoarderLeave_Reason+"',");
			}
			if (model.BoarderLeave_Auditor != null)
			{
				strSql.Append("BoarderLeave_Auditor='"+model.BoarderLeave_Auditor+"',");
			}
			if (model.BoarderLeave_State != null)
			{
				strSql.Append("BoarderLeave_State='"+model.BoarderLeave_State+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where BoarderLeave_ID='"+ model.BoarderLeave_ID+"' ");
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
		public bool Delete(string BoarderLeave_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_BoarderLeave ");
			strSql.Append(" where BoarderLeave_ID='"+BoarderLeave_ID+"' " );
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
		public bool DeleteList(string BoarderLeave_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_BoarderLeave ");
			strSql.Append(" where BoarderLeave_ID in ("+BoarderLeave_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_BoarderLeave GetModel(string BoarderLeave_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" BoarderLeave_ID,BoarderLeave_Date,BoarderLeave_Reason,BoarderLeave_Auditor,BoarderLeave_State ");
			strSql.Append(" from DHMS_BoarderLeave ");
			strSql.Append(" where BoarderLeave_ID='"+BoarderLeave_ID+"' " );
			DHMSClass.Model.DHMS_BoarderLeave model=new DHMSClass.Model.DHMS_BoarderLeave();
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
		public DHMSClass.Model.DHMS_BoarderLeave DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_BoarderLeave model=new DHMSClass.Model.DHMS_BoarderLeave();
			if (row != null)
			{
				if(row["BoarderLeave_ID"]!=null)
				{
					model.BoarderLeave_ID=row["BoarderLeave_ID"].ToString();
				}
				if(row["BoarderLeave_Date"]!=null && row["BoarderLeave_Date"].ToString()!="")
				{
					model.BoarderLeave_Date=DateTime.Parse(row["BoarderLeave_Date"].ToString());
				}
				if(row["BoarderLeave_Reason"]!=null)
				{
					model.BoarderLeave_Reason=row["BoarderLeave_Reason"].ToString();
				}
				if(row["BoarderLeave_Auditor"]!=null)
				{
					model.BoarderLeave_Auditor=row["BoarderLeave_Auditor"].ToString();
				}
				if(row["BoarderLeave_State"]!=null)
				{
					model.BoarderLeave_State=row["BoarderLeave_State"].ToString();
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
			strSql.Append("select BoarderLeave_ID,BoarderLeave_Date,BoarderLeave_Reason,BoarderLeave_Auditor,BoarderLeave_State ");
			strSql.Append(" FROM DHMS_BoarderLeave ");
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
			strSql.Append(" BoarderLeave_ID,BoarderLeave_Date,BoarderLeave_Reason,BoarderLeave_Auditor,BoarderLeave_State ");
			strSql.Append(" FROM DHMS_BoarderLeave ");
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
			strSql.Append("select count(1) FROM DHMS_BoarderLeave ");
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
				strSql.Append("order by T.BoarderLeave_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_BoarderLeave T ");
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_BoarderManage
	/// </summary>
	public partial class DHMS_BoarderManage
	{
		public DHMS_BoarderManage()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BoarderManage_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_BoarderManage");
			strSql.Append(" where BoarderManage_ID='"+BoarderManage_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_BoarderManage model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.BoarderManage_ID != null)
			{
				strSql1.Append("BoarderManage_ID,");
				strSql2.Append("'"+model.BoarderManage_ID+"',");
			}
			if (model.BoarderManage_Date != null)
			{
				strSql1.Append("BoarderManage_Date,");
				strSql2.Append("'"+model.BoarderManage_Date+"',");
			}
			if (model.Student_Sno != null)
			{
				strSql1.Append("Student_Sno,");
				strSql2.Append("'"+model.Student_Sno+"',");
			}
			if (model.BoarderManage_RTime != null)
			{
				strSql1.Append("BoarderManage_RTime,");
				strSql2.Append("'"+model.BoarderManage_RTime+"',");
			}
			if (model.BoarderManage_Feedback != null)
			{
				strSql1.Append("BoarderManage_Feedback,");
				strSql2.Append("'"+model.BoarderManage_Feedback+"',");
			}
			if (model.BoarderManage_NTime != null)
			{
				strSql1.Append("BoarderManage_NTime,");
				strSql2.Append("'"+model.BoarderManage_NTime+"',");
			}
			strSql.Append("insert into DHMS_BoarderManage(");
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
		public bool Update(DHMSClass.Model.DHMS_BoarderManage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_BoarderManage set ");
			if (model.BoarderManage_Date != null)
			{
				strSql.Append("BoarderManage_Date='"+model.BoarderManage_Date+"',");
			}
			if (model.Student_Sno != null)
			{
				strSql.Append("Student_Sno='"+model.Student_Sno+"',");
			}
			if (model.BoarderManage_RTime != null)
			{
				strSql.Append("BoarderManage_RTime='"+model.BoarderManage_RTime+"',");
			}
			if (model.BoarderManage_Feedback != null)
			{
				strSql.Append("BoarderManage_Feedback='"+model.BoarderManage_Feedback+"',");
			}
			else
			{
				strSql.Append("BoarderManage_Feedback= null ,");
			}
			if (model.BoarderManage_NTime != null)
			{
				strSql.Append("BoarderManage_NTime='"+model.BoarderManage_NTime+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where BoarderManage_ID='"+ model.BoarderManage_ID+"' ");
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
		public bool Delete(string BoarderManage_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_BoarderManage ");
			strSql.Append(" where BoarderManage_ID='"+BoarderManage_ID+"' " );
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
		public bool DeleteList(string BoarderManage_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_BoarderManage ");
			strSql.Append(" where BoarderManage_ID in ("+BoarderManage_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_BoarderManage GetModel(string BoarderManage_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" BoarderManage_ID,BoarderManage_Date,Student_Sno,BoarderManage_RTime,BoarderManage_Feedback,BoarderManage_NTime ");
			strSql.Append(" from DHMS_BoarderManage ");
			strSql.Append(" where BoarderManage_ID='"+BoarderManage_ID+"' " );
			DHMSClass.Model.DHMS_BoarderManage model=new DHMSClass.Model.DHMS_BoarderManage();
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
		public DHMSClass.Model.DHMS_BoarderManage DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_BoarderManage model=new DHMSClass.Model.DHMS_BoarderManage();
			if (row != null)
			{
				if(row["BoarderManage_ID"]!=null)
				{
					model.BoarderManage_ID=row["BoarderManage_ID"].ToString();
				}
				if(row["BoarderManage_Date"]!=null && row["BoarderManage_Date"].ToString()!="")
				{
					model.BoarderManage_Date=DateTime.Parse(row["BoarderManage_Date"].ToString());
				}
				if(row["Student_Sno"]!=null)
				{
					model.Student_Sno=row["Student_Sno"].ToString();
				}
				if(row["BoarderManage_RTime"]!=null && row["BoarderManage_RTime"].ToString()!="")
				{
					model.BoarderManage_RTime=DateTime.Parse(row["BoarderManage_RTime"].ToString());
				}
				if(row["BoarderManage_Feedback"]!=null)
				{
					model.BoarderManage_Feedback=row["BoarderManage_Feedback"].ToString();
				}
				if(row["BoarderManage_NTime"]!=null && row["BoarderManage_NTime"].ToString()!="")
				{
					model.BoarderManage_NTime=DateTime.Parse(row["BoarderManage_NTime"].ToString());
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
			strSql.Append("select BoarderManage_ID,BoarderManage_Date,Student_Sno,BoarderManage_RTime,BoarderManage_Feedback,BoarderManage_NTime ");
			strSql.Append(" FROM DHMS_BoarderManage ");
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
			strSql.Append(" BoarderManage_ID,BoarderManage_Date,Student_Sno,BoarderManage_RTime,BoarderManage_Feedback,BoarderManage_NTime ");
			strSql.Append(" FROM DHMS_BoarderManage ");
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
			strSql.Append("select count(1) FROM DHMS_BoarderManage ");
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
				strSql.Append("order by T.BoarderManage_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_BoarderManage T ");
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


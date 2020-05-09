using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Boarder
	/// </summary>
	public partial class DHMS_Boarder
	{
		public DHMS_Boarder()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Boarder_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Boarder");
			strSql.Append(" where Boarder_ID='"+Boarder_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Boarder model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Boarder_ID != null)
			{
				strSql1.Append("Boarder_ID,");
				strSql2.Append("'"+model.Boarder_ID+"',");
			}
			if (model.Student_Sno != null)
			{
				strSql1.Append("Student_Sno,");
				strSql2.Append("'"+model.Student_Sno+"',");
			}
			if (model.Boarder_HostelNum != null)
			{
				strSql1.Append("Boarder_HostelNum,");
				strSql2.Append("'"+model.Boarder_HostelNum+"',");
			}
			strSql.Append("insert into DHMS_Boarder(");
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
		public bool Update(DHMSClass.Model.DHMS_Boarder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Boarder set ");
			if (model.Student_Sno != null)
			{
				strSql.Append("Student_Sno='"+model.Student_Sno+"',");
			}
			if (model.Boarder_HostelNum != null)
			{
				strSql.Append("Boarder_HostelNum='"+model.Boarder_HostelNum+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Boarder_ID='"+ model.Boarder_ID+"' ");
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
		public bool Delete(string Boarder_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Boarder ");
			strSql.Append(" where Boarder_ID='"+Boarder_ID+"' " );
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
		public bool DeleteList(string Boarder_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Boarder ");
			strSql.Append(" where Boarder_ID in ("+Boarder_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Boarder GetModel(string Boarder_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Boarder_ID,Student_Sno,Boarder_HostelNum ");
			strSql.Append(" from DHMS_Boarder ");
			strSql.Append(" where Boarder_ID='"+Boarder_ID+"' " );
			DHMSClass.Model.DHMS_Boarder model=new DHMSClass.Model.DHMS_Boarder();
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
		public DHMSClass.Model.DHMS_Boarder DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Boarder model=new DHMSClass.Model.DHMS_Boarder();
			if (row != null)
			{
				if(row["Boarder_ID"]!=null)
				{
					model.Boarder_ID=row["Boarder_ID"].ToString();
				}
				if(row["Student_Sno"]!=null)
				{
					model.Student_Sno=row["Student_Sno"].ToString();
				}
				if(row["Boarder_HostelNum"]!=null)
				{
					model.Boarder_HostelNum=row["Boarder_HostelNum"].ToString();
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
			strSql.Append("select Boarder_ID,Student_Sno,Boarder_HostelNum ");
			strSql.Append(" FROM DHMS_Boarder ");
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
			strSql.Append(" Boarder_ID,Student_Sno,Boarder_HostelNum ");
			strSql.Append(" FROM DHMS_Boarder ");
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
			strSql.Append("select count(1) FROM DHMS_Boarder ");
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
				strSql.Append("order by T.Boarder_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Boarder T ");
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


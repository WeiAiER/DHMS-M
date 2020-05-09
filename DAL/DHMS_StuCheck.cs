using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_StuCheck
	/// </summary>
	public partial class DHMS_StuCheck
	{
		public DHMS_StuCheck()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StuCheck_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_StuCheck");
			strSql.Append(" where StuCheck_ID='"+StuCheck_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_StuCheck model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.StuCheck_ID != null)
			{
				strSql1.Append("StuCheck_ID,");
				strSql2.Append("'"+model.StuCheck_ID+"',");
			}
			if (model.Student_Sno != null)
			{
				strSql1.Append("Student_Sno,");
				strSql2.Append("'"+model.Student_Sno+"',");
			}
			if (model.StuCheck_Term != null)
			{
				strSql1.Append("StuCheck_Term,");
				strSql2.Append("'"+model.StuCheck_Term+"',");
			}
			if (model.StuCheck_Date != null)
			{
				strSql1.Append("StuCheck_Date,");
				strSql2.Append("'"+model.StuCheck_Date+"',");
			}
			if (model.StuCheck_Stage != null)
			{
				strSql1.Append("StuCheck_Stage,");
				strSql2.Append("'"+model.StuCheck_Stage+"',");
			}
			if (model.StuCheck_Remarks != null)
			{
				strSql1.Append("StuCheck_Remarks,");
				strSql2.Append("'"+model.StuCheck_Remarks+"',");
			}
			strSql.Append("insert into DHMS_StuCheck(");
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
		public bool Update(DHMSClass.Model.DHMS_StuCheck model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_StuCheck set ");
			if (model.Student_Sno != null)
			{
				strSql.Append("Student_Sno='"+model.Student_Sno+"',");
			}
			if (model.StuCheck_Term != null)
			{
				strSql.Append("StuCheck_Term='"+model.StuCheck_Term+"',");
			}
			if (model.StuCheck_Date != null)
			{
				strSql.Append("StuCheck_Date='"+model.StuCheck_Date+"',");
			}
			if (model.StuCheck_Stage != null)
			{
				strSql.Append("StuCheck_Stage='"+model.StuCheck_Stage+"',");
			}
			if (model.StuCheck_Remarks != null)
			{
				strSql.Append("StuCheck_Remarks='"+model.StuCheck_Remarks+"',");
			}
			else
			{
				strSql.Append("StuCheck_Remarks= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where StuCheck_ID='"+ model.StuCheck_ID+"' ");
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
		public bool Delete(string StuCheck_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_StuCheck ");
			strSql.Append(" where StuCheck_ID='"+StuCheck_ID+"' " );
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
		public bool DeleteList(string StuCheck_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_StuCheck ");
			strSql.Append(" where StuCheck_ID in ("+StuCheck_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_StuCheck GetModel(string StuCheck_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" StuCheck_ID,Student_Sno,StuCheck_Term,StuCheck_Date,StuCheck_Stage,StuCheck_Remarks ");
			strSql.Append(" from DHMS_StuCheck ");
			strSql.Append(" where StuCheck_ID='"+StuCheck_ID+"' " );
			DHMSClass.Model.DHMS_StuCheck model=new DHMSClass.Model.DHMS_StuCheck();
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
		public DHMSClass.Model.DHMS_StuCheck DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_StuCheck model=new DHMSClass.Model.DHMS_StuCheck();
			if (row != null)
			{
				if(row["StuCheck_ID"]!=null)
				{
					model.StuCheck_ID=row["StuCheck_ID"].ToString();
				}
				if(row["Student_Sno"]!=null)
				{
					model.Student_Sno=row["Student_Sno"].ToString();
				}
				if(row["StuCheck_Term"]!=null)
				{
					model.StuCheck_Term=row["StuCheck_Term"].ToString();
				}
				if(row["StuCheck_Date"]!=null && row["StuCheck_Date"].ToString()!="")
				{
					model.StuCheck_Date=DateTime.Parse(row["StuCheck_Date"].ToString());
				}
				if(row["StuCheck_Stage"]!=null)
				{
					model.StuCheck_Stage=row["StuCheck_Stage"].ToString();
				}
				if(row["StuCheck_Remarks"]!=null)
				{
					model.StuCheck_Remarks=row["StuCheck_Remarks"].ToString();
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
			strSql.Append("select StuCheck_ID,Student_Sno,StuCheck_Term,StuCheck_Date,StuCheck_Stage,StuCheck_Remarks ");
			strSql.Append(" FROM DHMS_StuCheck ");
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
			strSql.Append(" StuCheck_ID,Student_Sno,StuCheck_Term,StuCheck_Date,StuCheck_Stage,StuCheck_Remarks ");
			strSql.Append(" FROM DHMS_StuCheck ");
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
			strSql.Append("select count(1) FROM DHMS_StuCheck ");
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
				strSql.Append("order by T.StuCheck_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_StuCheck T ");
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


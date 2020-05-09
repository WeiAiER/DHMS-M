using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_TeaCheck
	/// </summary>
	public partial class DHMS_TeaCheck
	{
		public DHMS_TeaCheck()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TeaCheck_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_TeaCheck");
			strSql.Append(" where TeaCheck_ID='"+TeaCheck_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_TeaCheck model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.TeaCheck_ID != null)
			{
				strSql1.Append("TeaCheck_ID,");
				strSql2.Append("'"+model.TeaCheck_ID+"',");
			}
			if (model.Teacher_Tno != null)
			{
				strSql1.Append("Teacher_Tno,");
				strSql2.Append("'"+model.Teacher_Tno+"',");
			}
			if (model.TeaCheck_Term != null)
			{
				strSql1.Append("TeaCheck_Term,");
				strSql2.Append("'"+model.TeaCheck_Term+"',");
			}
			if (model.TeaCheck_Date != null)
			{
				strSql1.Append("TeaCheck_Date,");
				strSql2.Append("'"+model.TeaCheck_Date+"',");
			}
			if (model.TeaCheck_Stage != null)
			{
				strSql1.Append("TeaCheck_Stage,");
				strSql2.Append("'"+model.TeaCheck_Stage+"',");
			}
			if (model.TeaCheck_Remarks != null)
			{
				strSql1.Append("TeaCheck_Remarks,");
				strSql2.Append("'"+model.TeaCheck_Remarks+"',");
			}
			strSql.Append("insert into DHMS_TeaCheck(");
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
		public bool Update(DHMSClass.Model.DHMS_TeaCheck model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_TeaCheck set ");
			if (model.Teacher_Tno != null)
			{
				strSql.Append("Teacher_Tno='"+model.Teacher_Tno+"',");
			}
			if (model.TeaCheck_Term != null)
			{
				strSql.Append("TeaCheck_Term='"+model.TeaCheck_Term+"',");
			}
			if (model.TeaCheck_Date != null)
			{
				strSql.Append("TeaCheck_Date='"+model.TeaCheck_Date+"',");
			}
			if (model.TeaCheck_Stage != null)
			{
				strSql.Append("TeaCheck_Stage='"+model.TeaCheck_Stage+"',");
			}
			if (model.TeaCheck_Remarks != null)
			{
				strSql.Append("TeaCheck_Remarks='"+model.TeaCheck_Remarks+"',");
			}
			else
			{
				strSql.Append("TeaCheck_Remarks= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where TeaCheck_ID='"+ model.TeaCheck_ID+"' ");
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
		public bool Delete(string TeaCheck_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_TeaCheck ");
			strSql.Append(" where TeaCheck_ID='"+TeaCheck_ID+"' " );
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
		public bool DeleteList(string TeaCheck_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_TeaCheck ");
			strSql.Append(" where TeaCheck_ID in ("+TeaCheck_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_TeaCheck GetModel(string TeaCheck_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" TeaCheck_ID,Teacher_Tno,TeaCheck_Term,TeaCheck_Date,TeaCheck_Stage,TeaCheck_Remarks ");
			strSql.Append(" from DHMS_TeaCheck ");
			strSql.Append(" where TeaCheck_ID='"+TeaCheck_ID+"' " );
			DHMSClass.Model.DHMS_TeaCheck model=new DHMSClass.Model.DHMS_TeaCheck();
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
		public DHMSClass.Model.DHMS_TeaCheck DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_TeaCheck model=new DHMSClass.Model.DHMS_TeaCheck();
			if (row != null)
			{
				if(row["TeaCheck_ID"]!=null)
				{
					model.TeaCheck_ID=row["TeaCheck_ID"].ToString();
				}
				if(row["Teacher_Tno"]!=null)
				{
					model.Teacher_Tno=row["Teacher_Tno"].ToString();
				}
				if(row["TeaCheck_Term"]!=null)
				{
					model.TeaCheck_Term=row["TeaCheck_Term"].ToString();
				}
				if(row["TeaCheck_Date"]!=null && row["TeaCheck_Date"].ToString()!="")
				{
					model.TeaCheck_Date=DateTime.Parse(row["TeaCheck_Date"].ToString());
				}
				if(row["TeaCheck_Stage"]!=null)
				{
					model.TeaCheck_Stage=row["TeaCheck_Stage"].ToString();
				}
				if(row["TeaCheck_Remarks"]!=null)
				{
					model.TeaCheck_Remarks=row["TeaCheck_Remarks"].ToString();
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
			strSql.Append("select TeaCheck_ID,Teacher_Tno,TeaCheck_Term,TeaCheck_Date,TeaCheck_Stage,TeaCheck_Remarks ");
			strSql.Append(" FROM DHMS_TeaCheck ");
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
			strSql.Append(" TeaCheck_ID,Teacher_Tno,TeaCheck_Term,TeaCheck_Date,TeaCheck_Stage,TeaCheck_Remarks ");
			strSql.Append(" FROM DHMS_TeaCheck ");
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
			strSql.Append("select count(1) FROM DHMS_TeaCheck ");
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
				strSql.Append("order by T.TeaCheck_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_TeaCheck T ");
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


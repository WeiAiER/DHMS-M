﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Class
	/// </summary>
	public partial class DHMS_Class
	{
		public DHMS_Class()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Class_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Class");
			strSql.Append(" where Class_ID='"+Class_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Class model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Class_ID != null)
			{
				strSql1.Append("Class_ID,");
				strSql2.Append("'"+model.Class_ID+"',");
			}
			if (model.Class_Name != null)
			{
				strSql1.Append("Class_Name,");
				strSql2.Append("'"+model.Class_Name+"',");
			}
			if (model.Department_ID != null)
			{
				strSql1.Append("Department_ID,");
				strSql2.Append("'"+model.Department_ID+"',");
			}
			if (model.Teacher_Tno != null)
			{
				strSql1.Append("Teacher_Tno,");
				strSql2.Append("'"+model.Teacher_Tno+"',");
			}
			strSql.Append("insert into DHMS_Class(");
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
		public bool Update(DHMSClass.Model.DHMS_Class model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Class set ");
			if (model.Class_Name != null)
			{
				strSql.Append("Class_Name='"+model.Class_Name+"',");
			}
			if (model.Department_ID != null)
			{
				strSql.Append("Department_ID='"+model.Department_ID+"',");
			}
			if (model.Teacher_Tno != null)
			{
				strSql.Append("Teacher_Tno='"+model.Teacher_Tno+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Class_ID='"+ model.Class_ID+"' ");
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
		public bool Delete(string Class_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Class ");
			strSql.Append(" where Class_ID='"+Class_ID+"' " );
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
		public bool DeleteList(string Class_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Class ");
			strSql.Append(" where Class_ID in ("+Class_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Class GetModel(string Class_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Class_ID,Class_Name,Department_ID,Teacher_Tno ");
			strSql.Append(" from DHMS_Class ");
			strSql.Append(" where Class_ID='"+Class_ID+"' " );
			DHMSClass.Model.DHMS_Class model=new DHMSClass.Model.DHMS_Class();
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
		public DHMSClass.Model.DHMS_Class DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Class model=new DHMSClass.Model.DHMS_Class();
			if (row != null)
			{
				if(row["Class_ID"]!=null)
				{
					model.Class_ID=row["Class_ID"].ToString();
				}
				if(row["Class_Name"]!=null)
				{
					model.Class_Name=row["Class_Name"].ToString();
				}
				if(row["Department_ID"]!=null)
				{
					model.Department_ID=row["Department_ID"].ToString();
				}
				if(row["Teacher_Tno"]!=null)
				{
					model.Teacher_Tno=row["Teacher_Tno"].ToString();
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
			strSql.Append("select Class_ID,Class_Name,Department_ID,Teacher_Tno ");
			strSql.Append(" FROM DHMS_Class ");
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
			strSql.Append(" Class_ID,Class_Name,Department_ID,Teacher_Tno ");
			strSql.Append(" FROM DHMS_Class ");
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
			strSql.Append("select count(1) FROM DHMS_Class ");
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
				strSql.Append("order by T.Class_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Class T ");
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


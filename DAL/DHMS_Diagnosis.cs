using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Diagnosis
	/// </summary>
	public partial class DHMS_Diagnosis
	{
		public DHMS_Diagnosis()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Diagnosis_Number)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Diagnosis");
			strSql.Append(" where Diagnosis_Number='"+Diagnosis_Number+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DHMSClass.Model.DHMS_Diagnosis model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Diagnosis_Number != null)
			{
				strSql1.Append("Diagnosis_Number,");
				strSql2.Append("'"+model.Diagnosis_Number+"',");
			}
			if (model.Diagnosis_Name != null)
			{
				strSql1.Append("Diagnosis_Name,");
				strSql2.Append("'"+model.Diagnosis_Name+"',");
			}
			strSql.Append("insert into DHMS_Diagnosis(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(DHMSClass.Model.DHMS_Diagnosis model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Diagnosis set ");
			if (model.Diagnosis_Name != null)
			{
				strSql.Append("Diagnosis_Name='"+model.Diagnosis_Name+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Diagnosis_ID="+ model.Diagnosis_ID+"");
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
		public bool Delete(int Diagnosis_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Diagnosis ");
			strSql.Append(" where Diagnosis_ID="+Diagnosis_ID+"" );
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Diagnosis_Number)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Diagnosis ");
			strSql.Append(" where Diagnosis_Number=@Diagnosis_Number ");
			SqlParameter[] parameters = {
					new SqlParameter("@Diagnosis_Number", SqlDbType.VarChar,-1)};
			parameters[0].Value = Diagnosis_Number;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Diagnosis_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Diagnosis ");
			strSql.Append(" where Diagnosis_ID in ("+Diagnosis_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Diagnosis GetModel(int Diagnosis_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Diagnosis_ID,Diagnosis_Number,Diagnosis_Name ");
			strSql.Append(" from DHMS_Diagnosis ");
			strSql.Append(" where Diagnosis_ID="+Diagnosis_ID+"" );
			DHMSClass.Model.DHMS_Diagnosis model=new DHMSClass.Model.DHMS_Diagnosis();
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
		public DHMSClass.Model.DHMS_Diagnosis DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Diagnosis model=new DHMSClass.Model.DHMS_Diagnosis();
			if (row != null)
			{
				if(row["Diagnosis_ID"]!=null && row["Diagnosis_ID"].ToString()!="")
				{
					model.Diagnosis_ID=int.Parse(row["Diagnosis_ID"].ToString());
				}
				if(row["Diagnosis_Number"]!=null)
				{
					model.Diagnosis_Number=row["Diagnosis_Number"].ToString();
				}
				if(row["Diagnosis_Name"]!=null)
				{
					model.Diagnosis_Name=row["Diagnosis_Name"].ToString();
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
			strSql.Append("select Diagnosis_ID,Diagnosis_Number,Diagnosis_Name ");
			strSql.Append(" FROM DHMS_Diagnosis ");
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
			strSql.Append(" Diagnosis_ID,Diagnosis_Number,Diagnosis_Name ");
			strSql.Append(" FROM DHMS_Diagnosis ");
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
			strSql.Append("select count(1) FROM DHMS_Diagnosis ");
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
				strSql.Append("order by T.Diagnosis_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Diagnosis T ");
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


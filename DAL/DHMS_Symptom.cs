using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Symptom
	/// </summary>
	public partial class DHMS_Symptom
	{
		public DHMS_Symptom()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Symptom_Number)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Symptom");
			strSql.Append(" where Symptom_Number='"+Symptom_Number+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DHMSClass.Model.DHMS_Symptom model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Symptom_Number != null)
			{
				strSql1.Append("Symptom_Number,");
				strSql2.Append("'"+model.Symptom_Number+"',");
			}
			if (model.Symptom_Name != null)
			{
				strSql1.Append("Symptom_Name,");
				strSql2.Append("'"+model.Symptom_Name+"',");
			}
			strSql.Append("insert into DHMS_Symptom(");
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
		public bool Update(DHMSClass.Model.DHMS_Symptom model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Symptom set ");
			if (model.Symptom_Name != null)
			{
				strSql.Append("Symptom_Name='"+model.Symptom_Name+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Symptom_ID="+ model.Symptom_ID+"");
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
		public bool Delete(int Symptom_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Symptom ");
			strSql.Append(" where Symptom_ID="+Symptom_ID+"" );
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
		public bool Delete(string Symptom_Number)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Symptom ");
			strSql.Append(" where Symptom_Number=@Symptom_Number ");
			SqlParameter[] parameters = {
					new SqlParameter("@Symptom_Number", SqlDbType.VarChar,-1)};
			parameters[0].Value = Symptom_Number;

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
		public bool DeleteList(string Symptom_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Symptom ");
			strSql.Append(" where Symptom_ID in ("+Symptom_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Symptom GetModel(int Symptom_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Symptom_ID,Symptom_Number,Symptom_Name ");
			strSql.Append(" from DHMS_Symptom ");
			strSql.Append(" where Symptom_ID="+Symptom_ID+"" );
			DHMSClass.Model.DHMS_Symptom model=new DHMSClass.Model.DHMS_Symptom();
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
		public DHMSClass.Model.DHMS_Symptom DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Symptom model=new DHMSClass.Model.DHMS_Symptom();
			if (row != null)
			{
				if(row["Symptom_ID"]!=null && row["Symptom_ID"].ToString()!="")
				{
					model.Symptom_ID=int.Parse(row["Symptom_ID"].ToString());
				}
				if(row["Symptom_Number"]!=null)
				{
					model.Symptom_Number=row["Symptom_Number"].ToString();
				}
				if(row["Symptom_Name"]!=null)
				{
					model.Symptom_Name=row["Symptom_Name"].ToString();
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
			strSql.Append("select Symptom_ID,Symptom_Number,Symptom_Name ");
			strSql.Append(" FROM DHMS_Symptom ");
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
			strSql.Append(" Symptom_ID,Symptom_Number,Symptom_Name ");
			strSql.Append(" FROM DHMS_Symptom ");
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
			strSql.Append("select count(1) FROM DHMS_Symptom ");
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
				strSql.Append("order by T.Symptom_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Symptom T ");
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


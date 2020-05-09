using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Teacher
	/// </summary>
	public partial class DHMS_Teacher
	{
		public DHMS_Teacher()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Teacher_Tno)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Teacher");
			strSql.Append(" where Teacher_Tno='"+Teacher_Tno+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DHMSClass.Model.DHMS_Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Teacher_Tno != null)
			{
				strSql1.Append("Teacher_Tno,");
				strSql2.Append("'"+model.Teacher_Tno+"',");
			}
			if (model.Teacher_Name != null)
			{
				strSql1.Append("Teacher_Name,");
				strSql2.Append("'"+model.Teacher_Name+"',");
			}
			if (model.Teacher_Sex != null)
			{
				strSql1.Append("Teacher_Sex,");
				strSql2.Append("'"+model.Teacher_Sex+"',");
			}
			if (model.Teacher_Birthday != null)
			{
				strSql1.Append("Teacher_Birthday,");
				strSql2.Append("'"+model.Teacher_Birthday+"',");
			}
			if (model.Teacher_Num != null)
			{
				strSql1.Append("Teacher_Num,");
				strSql2.Append("'"+model.Teacher_Num+"',");
			}
			if (model.Department_ID != null)
			{
				strSql1.Append("Department_ID,");
				strSql2.Append("'"+model.Department_ID+"',");
			}
			strSql.Append("insert into DHMS_Teacher(");
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
		public bool Update(DHMSClass.Model.DHMS_Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Teacher set ");
			if (model.Teacher_Name != null)
			{
				strSql.Append("Teacher_Name='"+model.Teacher_Name+"',");
			}
			if (model.Teacher_Sex != null)
			{
				strSql.Append("Teacher_Sex='"+model.Teacher_Sex+"',");
			}
			if (model.Teacher_Birthday != null)
			{
				strSql.Append("Teacher_Birthday='"+model.Teacher_Birthday+"',");
			}
			if (model.Teacher_Num != null)
			{
				strSql.Append("Teacher_Num='"+model.Teacher_Num+"',");
			}
			if (model.Department_ID != null)
			{
				strSql.Append("Department_ID='"+model.Department_ID+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Teacher_ID="+ model.Teacher_ID+"");
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
		public bool Delete(int Teacher_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Teacher ");
			strSql.Append(" where Teacher_ID="+Teacher_ID+"" );
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
		public bool Delete(string Teacher_Tno)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Teacher ");
			strSql.Append(" where Teacher_Tno=@Teacher_Tno ");
			SqlParameter[] parameters = {
					new SqlParameter("@Teacher_Tno", SqlDbType.VarChar,-1)};
			parameters[0].Value = Teacher_Tno;

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
		public bool DeleteList(string Teacher_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Teacher ");
			strSql.Append(" where Teacher_ID in ("+Teacher_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Teacher GetModel(int Teacher_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Teacher_ID,Teacher_Tno,Teacher_Name,Teacher_Sex,Teacher_Birthday,Teacher_Num,Department_ID ");
			strSql.Append(" from DHMS_Teacher ");
			strSql.Append(" where Teacher_ID="+Teacher_ID+"" );
			DHMSClass.Model.DHMS_Teacher model=new DHMSClass.Model.DHMS_Teacher();
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
		public DHMSClass.Model.DHMS_Teacher DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Teacher model=new DHMSClass.Model.DHMS_Teacher();
			if (row != null)
			{
				if(row["Teacher_ID"]!=null && row["Teacher_ID"].ToString()!="")
				{
					model.Teacher_ID=int.Parse(row["Teacher_ID"].ToString());
				}
				if(row["Teacher_Tno"]!=null)
				{
					model.Teacher_Tno=row["Teacher_Tno"].ToString();
				}
				if(row["Teacher_Name"]!=null)
				{
					model.Teacher_Name=row["Teacher_Name"].ToString();
				}
				if(row["Teacher_Sex"]!=null)
				{
					model.Teacher_Sex=row["Teacher_Sex"].ToString();
				}
				if(row["Teacher_Birthday"]!=null && row["Teacher_Birthday"].ToString()!="")
				{
					model.Teacher_Birthday=DateTime.Parse(row["Teacher_Birthday"].ToString());
				}
				if(row["Teacher_Num"]!=null)
				{
					model.Teacher_Num=row["Teacher_Num"].ToString();
				}
				if(row["Department_ID"]!=null)
				{
					model.Department_ID=row["Department_ID"].ToString();
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
			strSql.Append("select Teacher_ID,Teacher_Tno,Teacher_Name,Teacher_Sex,Teacher_Birthday,Teacher_Num,Department_ID ");
			strSql.Append(" FROM DHMS_Teacher ");
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
			strSql.Append(" Teacher_ID,Teacher_Tno,Teacher_Name,Teacher_Sex,Teacher_Birthday,Teacher_Num,Department_ID ");
			strSql.Append(" FROM DHMS_Teacher ");
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
			strSql.Append("select count(1) FROM DHMS_Teacher ");
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
				strSql.Append("order by T.Teacher_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Teacher T ");
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


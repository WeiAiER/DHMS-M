using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Miss
	/// </summary>
	public partial class DHMS_Miss
	{
		public DHMS_Miss()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Miss_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Miss");
			strSql.Append(" where Miss_ID='"+Miss_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Miss model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Miss_ID != null)
			{
				strSql1.Append("Miss_ID,");
				strSql2.Append("'"+model.Miss_ID+"',");
			}
			if (model.Student_Sno != null)
			{
				strSql1.Append("Student_Sno,");
				strSql2.Append("'"+model.Student_Sno+"',");
			}
			if (model.Miss_Fever != null)
			{
				strSql1.Append("Miss_Fever,");
				strSql2.Append("'"+model.Miss_Fever+"',");
			}
			if (model.Symptom_Number != null)
			{
				strSql1.Append("Symptom_Number,");
				strSql2.Append("'"+model.Symptom_Number+"',");
			}
			if (model.Diagnosis_Number != null)
			{
				strSql1.Append("Diagnosis_Number,");
				strSql2.Append("'"+model.Diagnosis_Number+"',");
			}
			if (model.Miss_MState != null)
			{
				strSql1.Append("Miss_MState,");
				strSql2.Append("'"+model.Miss_MState+"',");
			}
			if (model.Miss_MHospital != null)
			{
				strSql1.Append("Miss_MHospital,");
				strSql2.Append("'"+model.Miss_MHospital+"',");
			}
			if (model.Miss_Days != null)
			{
				strSql1.Append("Miss_Days,");
				strSql2.Append(""+model.Miss_Days+",");
			}
			if (model.Miss_ClassHour != null)
			{
				strSql1.Append("Miss_ClassHour,");
				strSql2.Append(""+model.Miss_ClassHour+",");
			}
			if (model.Miss_Type != null)
			{
				strSql1.Append("Miss_Type,");
				strSql2.Append("'"+model.Miss_Type+"',");
			}
			if (model.Epidemic_Number != null)
			{
				strSql1.Append("Epidemic_Number,");
				strSql2.Append("'"+model.Epidemic_Number+"',");
			}
			if (model.Teacher_Tno != null)
			{
				strSql1.Append("Teacher_Tno,");
				strSql2.Append("'"+model.Teacher_Tno+"',");
			}
			if (model.Miss_RDateTime != null)
			{
				strSql1.Append("Miss_RDateTime,");
				strSql2.Append("'"+model.Miss_RDateTime+"',");
			}
			strSql.Append("insert into DHMS_Miss(");
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
		public bool Update(DHMSClass.Model.DHMS_Miss model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Miss set ");
			if (model.Student_Sno != null)
			{
				strSql.Append("Student_Sno='"+model.Student_Sno+"',");
			}
			if (model.Miss_Fever != null)
			{
				strSql.Append("Miss_Fever='"+model.Miss_Fever+"',");
			}
			if (model.Symptom_Number != null)
			{
				strSql.Append("Symptom_Number='"+model.Symptom_Number+"',");
			}
			if (model.Diagnosis_Number != null)
			{
				strSql.Append("Diagnosis_Number='"+model.Diagnosis_Number+"',");
			}
			if (model.Miss_MState != null)
			{
				strSql.Append("Miss_MState='"+model.Miss_MState+"',");
			}
			if (model.Miss_MHospital != null)
			{
				strSql.Append("Miss_MHospital='"+model.Miss_MHospital+"',");
			}
			if (model.Miss_Days != null)
			{
				strSql.Append("Miss_Days="+model.Miss_Days+",");
			}
			if (model.Miss_ClassHour != null)
			{
				strSql.Append("Miss_ClassHour="+model.Miss_ClassHour+",");
			}
			if (model.Miss_Type != null)
			{
				strSql.Append("Miss_Type='"+model.Miss_Type+"',");
			}
			if (model.Epidemic_Number != null)
			{
				strSql.Append("Epidemic_Number='"+model.Epidemic_Number+"',");
			}
			else
			{
				strSql.Append("Epidemic_Number= null ,");
			}
			if (model.Teacher_Tno != null)
			{
				strSql.Append("Teacher_Tno='"+model.Teacher_Tno+"',");
			}
			if (model.Miss_RDateTime != null)
			{
				strSql.Append("Miss_RDateTime='"+model.Miss_RDateTime+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Miss_ID='"+ model.Miss_ID+"' ");
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
		public bool Delete(string Miss_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Miss ");
			strSql.Append(" where Miss_ID='"+Miss_ID+"' " );
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
		public bool DeleteList(string Miss_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Miss ");
			strSql.Append(" where Miss_ID in ("+Miss_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Miss GetModel(string Miss_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Miss_ID,Student_Sno,Miss_Fever,Symptom_Number,Diagnosis_Number,Miss_MState,Miss_MHospital,Miss_Days,Miss_ClassHour,Miss_Type,Epidemic_Number,Teacher_Tno,Miss_RDateTime ");
			strSql.Append(" from DHMS_Miss ");
			strSql.Append(" where Miss_ID='"+Miss_ID+"' " );
			DHMSClass.Model.DHMS_Miss model=new DHMSClass.Model.DHMS_Miss();
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
		public DHMSClass.Model.DHMS_Miss DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Miss model=new DHMSClass.Model.DHMS_Miss();
			if (row != null)
			{
				if(row["Miss_ID"]!=null)
				{
					model.Miss_ID=row["Miss_ID"].ToString();
				}
				if(row["Student_Sno"]!=null)
				{
					model.Student_Sno=row["Student_Sno"].ToString();
				}
				if(row["Miss_Fever"]!=null)
				{
					model.Miss_Fever=row["Miss_Fever"].ToString();
				}
				if(row["Symptom_Number"]!=null)
				{
					model.Symptom_Number=row["Symptom_Number"].ToString();
				}
				if(row["Diagnosis_Number"]!=null)
				{
					model.Diagnosis_Number=row["Diagnosis_Number"].ToString();
				}
				if(row["Miss_MState"]!=null)
				{
					model.Miss_MState=row["Miss_MState"].ToString();
				}
				if(row["Miss_MHospital"]!=null)
				{
					model.Miss_MHospital=row["Miss_MHospital"].ToString();
				}
				if(row["Miss_Days"]!=null && row["Miss_Days"].ToString()!="")
				{
					model.Miss_Days=int.Parse(row["Miss_Days"].ToString());
				}
				if(row["Miss_ClassHour"]!=null && row["Miss_ClassHour"].ToString()!="")
				{
					model.Miss_ClassHour=int.Parse(row["Miss_ClassHour"].ToString());
				}
				if(row["Miss_Type"]!=null)
				{
					model.Miss_Type=row["Miss_Type"].ToString();
				}
				if(row["Epidemic_Number"]!=null)
				{
					model.Epidemic_Number=row["Epidemic_Number"].ToString();
				}
				if(row["Teacher_Tno"]!=null)
				{
					model.Teacher_Tno=row["Teacher_Tno"].ToString();
				}
				if(row["Miss_RDateTime"]!=null && row["Miss_RDateTime"].ToString()!="")
				{
					model.Miss_RDateTime=DateTime.Parse(row["Miss_RDateTime"].ToString());
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
			strSql.Append("select Miss_ID,Student_Sno,Miss_Fever,Symptom_Number,Diagnosis_Number,Miss_MState,Miss_MHospital,Miss_Days,Miss_ClassHour,Miss_Type,Epidemic_Number,Teacher_Tno,Miss_RDateTime ");
			strSql.Append(" FROM DHMS_Miss ");
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
			strSql.Append(" Miss_ID,Student_Sno,Miss_Fever,Symptom_Number,Diagnosis_Number,Miss_MState,Miss_MHospital,Miss_Days,Miss_ClassHour,Miss_Type,Epidemic_Number,Teacher_Tno,Miss_RDateTime ");
			strSql.Append(" FROM DHMS_Miss ");
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
			strSql.Append("select count(1) FROM DHMS_Miss ");
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
				strSql.Append("order by T.Miss_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Miss T ");
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


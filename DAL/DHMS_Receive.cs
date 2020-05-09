using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace DHMSClass.DAL
{
	/// <summary>
	/// 数据访问类:DHMS_Receive
	/// </summary>
	public partial class DHMS_Receive
	{
		public DHMS_Receive()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Receive_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DHMS_Receive");
			strSql.Append(" where Receive_ID='"+Receive_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DHMSClass.Model.DHMS_Receive model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Receive_ID != null)
			{
				strSql1.Append("Receive_ID,");
				strSql2.Append("'"+model.Receive_ID+"',");
			}
			if (model.Material_ID != null)
			{
				strSql1.Append("Material_ID,");
				strSql2.Append("'"+model.Material_ID+"',");
			}
			if (model.Teacher_Tno != null)
			{
				strSql1.Append("Teacher_Tno,");
				strSql2.Append("'"+model.Teacher_Tno+"',");
			}
			if (model.Receive_Number != null)
			{
				strSql1.Append("Receive_Number,");
				strSql2.Append(""+model.Receive_Number+",");
			}
			if (model.Receive_DateTime != null)
			{
				strSql1.Append("Receive_DateTime,");
				strSql2.Append("'"+model.Receive_DateTime+"',");
			}
			strSql.Append("insert into DHMS_Receive(");
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
		public bool Update(DHMSClass.Model.DHMS_Receive model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DHMS_Receive set ");
			if (model.Material_ID != null)
			{
				strSql.Append("Material_ID='"+model.Material_ID+"',");
			}
			if (model.Teacher_Tno != null)
			{
				strSql.Append("Teacher_Tno='"+model.Teacher_Tno+"',");
			}
			if (model.Receive_Number != null)
			{
				strSql.Append("Receive_Number="+model.Receive_Number+",");
			}
			if (model.Receive_DateTime != null)
			{
				strSql.Append("Receive_DateTime='"+model.Receive_DateTime+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Receive_ID='"+ model.Receive_ID+"' ");
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
		public bool Delete(string Receive_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Receive ");
			strSql.Append(" where Receive_ID='"+Receive_ID+"' " );
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
		public bool DeleteList(string Receive_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DHMS_Receive ");
			strSql.Append(" where Receive_ID in ("+Receive_IDlist + ")  ");
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
		public DHMSClass.Model.DHMS_Receive GetModel(string Receive_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Receive_ID,Material_ID,Teacher_Tno,Receive_Number,Receive_DateTime ");
			strSql.Append(" from DHMS_Receive ");
			strSql.Append(" where Receive_ID='"+Receive_ID+"' " );
			DHMSClass.Model.DHMS_Receive model=new DHMSClass.Model.DHMS_Receive();
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
		public DHMSClass.Model.DHMS_Receive DataRowToModel(DataRow row)
		{
			DHMSClass.Model.DHMS_Receive model=new DHMSClass.Model.DHMS_Receive();
			if (row != null)
			{
				if(row["Receive_ID"]!=null)
				{
					model.Receive_ID=row["Receive_ID"].ToString();
				}
				if(row["Material_ID"]!=null)
				{
					model.Material_ID=row["Material_ID"].ToString();
				}
				if(row["Teacher_Tno"]!=null)
				{
					model.Teacher_Tno=row["Teacher_Tno"].ToString();
				}
				if(row["Receive_Number"]!=null && row["Receive_Number"].ToString()!="")
				{
					model.Receive_Number=int.Parse(row["Receive_Number"].ToString());
				}
				if(row["Receive_DateTime"]!=null && row["Receive_DateTime"].ToString()!="")
				{
					model.Receive_DateTime=DateTime.Parse(row["Receive_DateTime"].ToString());
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
			strSql.Append("select Receive_ID,Material_ID,Teacher_Tno,Receive_Number,Receive_DateTime ");
			strSql.Append(" FROM DHMS_Receive ");
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
			strSql.Append(" Receive_ID,Material_ID,Teacher_Tno,Receive_Number,Receive_DateTime ");
			strSql.Append(" FROM DHMS_Receive ");
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
			strSql.Append("select count(1) FROM DHMS_Receive ");
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
				strSql.Append("order by T.Receive_ID desc");
			}
			strSql.Append(")AS Row, T.*  from DHMS_Receive T ");
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


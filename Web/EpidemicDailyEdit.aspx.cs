using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHMSClass.Web
{
    public partial class EpidemicDailyEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_Daily bll_Daily = new BLL.DHMS_Daily();
        DHMSClass.DAL.DHMS_Daily dal_Daily = new DAL.DHMS_Daily();
        DHMSClass.Model.DHMS_Daily model_Daily = new Model.DHMS_Daily();

        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();
        DHMSClass.BLL.DHMS_Investigation bll_Investigation = new BLL.DHMS_Investigation();

        DealID deal_Daily = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_DailyDate.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd") + "',lang:'zh-cn'})");

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "EpidemicDaily.aspx");
                    return;
                }
                DataSet ds_Daily = bll_Daily.GetList("Daily_ID = '" + id.ToString() + "'");

                if (ds_Daily.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "EpidemicDaily.aspx");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (action == "Edit") //修改
                {
                    ShowInfo(this.id);
                }
            }
        }
        
        /// <summary>
        /// 判断日期的格式
        /// </summary>
        /// <param name="StrSource">传递的值</param>
        /// <returns>返回布尔值</returns>
        public bool IsDate(string StrSource)
        {
            return Regex.IsMatch(StrSource, "^(?<year>\\d{2,4})-(?<month>\\d{1,2})-(?<day>\\d{1,2})$");
        }

        #region 赋值操作=================================
        /// <summary>
        /// 修改时赋值
        /// </summary>
        /// <param name="_id"></param>
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_Daily = bll_Daily.GetList("Daily_ID = '" + _id.ToString() + "'");
            DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Tno = '" + ds_Daily.Tables[0].Rows[0]["Teacher_Tno"].ToString() + "'");
            DataSet ds_Investigation = bll_Investigation.GetList("Investigation_ID = '" + ds_Daily.Tables[0].Rows[0]["Investigation_ID"].ToString() + "'");

            txt_TName.Text = ds_Teacher.Tables[0].Rows[0]["Teacher_Name"].ToString();
            txt_IProblem.Text = ds_Investigation.Tables[0].Rows[0]["Investigation_Problem"].ToString();
            txt_DailyReply.Text = ds_Daily.Tables[0].Rows[0]["Daily_Reply"].ToString();
            txt_DailyDate.Text = ds_Daily.Tables[0].Rows[0]["Daily_DateTime"].ToString();

        }
        #endregion

        #region 增加操作=================================
        /// <summary>
        /// 疫情日报信息新增
        /// </summary>
        /// <returns></returns>
        private bool DoAdd()
        {
            try
            {
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_TName.Text + "'");
                DataSet ds_Investigation = bll_Investigation.GetList("Investigation_Problem = '" + txt_IProblem.Text + "'");

                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    if (!IsDate(txt_DailyDate.Text))
                    {
                        Alert.AlertNo("请正确输入日期类型：yyyy-MM-dd", "EpidemicDailyEdit.aspx");
                        return false;
                    }

                    model_Daily.Daily_ID = deal_Daily.Deal_ID();
                    model_Daily.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_Daily.Investigation_ID = ds_Investigation.Tables[0].Rows[0]["Investigation_ID"].ToString();
                    model_Daily.Daily_Reply = txt_DailyReply.Text;
                    model_Daily.Daily_DateTime = Convert.ToDateTime(txt_DailyDate.Text);
                    bll_Daily.Add(model_Daily);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的教师或问题不存在，请重新输入！", "EpidemicDailyEdit.aspx");
                return false;
            }

            return true;
        }
        #endregion

        #region 修改操作=================================
        /// <summary>
        /// 疫情日报信息修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoEdit(long id)
        {
            try
            {
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_TName.Text + "'");
                DataSet ds_Investigation = bll_Investigation.GetList("Investigation_Problem = '" + txt_IProblem.Text + "'");

                if (Session["admin_id"] == null)
                {
                    if (!IsDate(txt_DailyDate.Text))
                    {
                        Alert.AlertAndRedirect("请正确输入日期类型：yyyy-MM-dd", "EpidemicDaily.aspx");
                        return false;
                    }

                    model_Daily.Daily_ID = id.ToString();
                    model_Daily.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_Daily.Investigation_ID = ds_Investigation.Tables[0].Rows[0]["Investigation_ID"].ToString();
                    model_Daily.Daily_Reply = txt_DailyReply.Text;
                    model_Daily.Daily_DateTime = Convert.ToDateTime(txt_DailyDate.Text);
                    dal_Daily.Update(model_Daily);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的教师或问题不存在，请重新输入！", "EpidemicDaily.aspx");
                return false;
            }

            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_TName.Text == "" || txt_IProblem.Text == "" || txt_DailyReply.Text == "")
            {
                Alert.AlertNo("*为必填项！", "EpidemicDailyEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "EpidemicDailyEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新疫情日报成功！", "EpidemicDaily.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "EpidemicDailyEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加疫情日报成功！", "EpidemicDaily.aspx");
            }
        }

    }
}
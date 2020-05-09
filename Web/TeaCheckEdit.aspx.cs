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
    public partial class TeaCheckEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_TeaCheck bll_TeaCheck = new BLL.DHMS_TeaCheck();
        DHMSClass.DAL.DHMS_TeaCheck dal_TeaCheck = new DAL.DHMS_TeaCheck();
        DHMSClass.Model.DHMS_TeaCheck model_TeaCheck = new Model.DHMS_TeaCheck();

        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();

        DealID deal = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_Date.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd HH时mm分ss秒',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd HH时mm分ss秒") + "',lang:'zh-cn'})");

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "TeaCheckEdit.aspx");
                    return;
                }
                DataSet ds_Student = bll_TeaCheck.GetList("TeaCheck_ID = '" + id.ToString() + "'");

                if (ds_Student.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "TeaCheckEdit.aspx");
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

        #region 赋值操作=================================
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_TeaCheck = bll_TeaCheck.GetList("TeaCheck_ID = '" + _id.ToString() + "'");
            DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Tno = '" + ds_TeaCheck.Tables[0].Rows[0]["Teacher_Tno"].ToString() + "'");

            txt_Name.Text = ds_Teacher.Tables[0].Rows[0]["Teacher_Name"].ToString();
            txt_Term.Text = ds_TeaCheck.Tables[0].Rows[0]["TeaCheck_Term"].ToString();
            txt_Date.Text = ds_TeaCheck.Tables[0].Rows[0]["TeaCheck_Date"].ToString();
            txt_Stage.Text = ds_TeaCheck.Tables[0].Rows[0]["TeaCheck_Stage"].ToString();
            txt_Remarks.Text = ds_TeaCheck.Tables[0].Rows[0]["TeaCheck_Remarks"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_Name.Text + "'");

                    model_TeaCheck.TeaCheck_ID = deal.Deal_ID();
                    model_TeaCheck.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_TeaCheck.TeaCheck_Term = txt_Term.Text;
                    model_TeaCheck.TeaCheck_Date = Convert.ToDateTime(txt_Date.Text);
                    model_TeaCheck.TeaCheck_Stage = txt_Stage.Text;
                    model_TeaCheck.TeaCheck_Remarks = txt_Remarks.Text;
                    bll_TeaCheck.Add(model_TeaCheck);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
        }
            catch (Exception)
            {

                Alert.AlertNo("教工不存在！", "TeaCheckEdit.aspx");
                return false;
            }
            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(long id)
        {
            try
            {
                DataSet ds_StuCheck = bll_TeaCheck.GetList("TeaCheck_ID = '" + id.ToString() + "'");
                DataSet ds_Student = bll_Teacher.GetList("Teacher_Name = '" + txt_Name.Text + "'");

                if (Session["admin_id"] == null)
                {
                    model_TeaCheck.TeaCheck_ID = id.ToString();
                    model_TeaCheck.Teacher_Tno = ds_Student.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_TeaCheck.TeaCheck_Term = txt_Term.Text;
                    model_TeaCheck.TeaCheck_Date = Convert.ToDateTime(txt_Date.Text);
                    model_TeaCheck.TeaCheck_Stage = txt_Stage.Text;
                    model_TeaCheck.TeaCheck_Remarks = txt_Remarks.Text;
                    dal_TeaCheck.Update(model_TeaCheck);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("教工不存在！", "TeaCheckEdit.aspx");
                return false;
            }

            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Term.Text == "" || txt_Date.Text == "" || txt_Stage.Text == "")
            {
                Alert.AlertNo("*为必填项！", "TeaCheckEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "TeaCheckEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新用户成功！", "TeaCheck.aspx");
            }
            else
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "TeaCheckEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加用户成功！", "TeaCheck.aspx");
            }
        }
    }
}
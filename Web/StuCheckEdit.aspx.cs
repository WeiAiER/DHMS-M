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
    public partial class StuCheckEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_StuCheck bll_StuCheck = new BLL.DHMS_StuCheck();
        DHMSClass.DAL.DHMS_StuCheck dal_StuCheck = new DAL.DHMS_StuCheck();
        DHMSClass.Model.DHMS_StuCheck model_StuCheck = new Model.DHMS_StuCheck();

        DHMSClass.BLL.DHMS_Student bll_Student = new BLL.DHMS_Student();

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
                    Alert.AlertAndRedirect("传输参数不正确！", "StuCheckEdit.aspx");
                    return;
                }
                DataSet ds_Student = bll_StuCheck.GetList("StuCheck_ID = '" + id.ToString() + "'");

                if (ds_Student.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "StuCheckEdit.aspx");
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
            DataSet ds_StuCheck = bll_StuCheck.GetList("StuCheck_ID = '" + _id.ToString() + "'");
            DataSet ds_Student = bll_Student.GetList("Student_Sno = '" + ds_StuCheck.Tables[0].Rows[0]["Student_Sno"].ToString() + "'");

            txt_Name.Text = ds_Student.Tables[0].Rows[0]["Student_Name"].ToString();
            txt_Term.Text = ds_StuCheck.Tables[0].Rows[0]["StuCheck_Term"].ToString();
            txt_Date.Text = ds_StuCheck.Tables[0].Rows[0]["StuCheck_Date"].ToString();
            txt_Stage.Text = ds_StuCheck.Tables[0].Rows[0]["StuCheck_Stage"].ToString();
            txt_Remarks.Text = ds_StuCheck.Tables[0].Rows[0]["StuCheck_Remarks"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    DataSet ds_Student = bll_Student.GetList("Student_Name = '" + txt_Name.Text + "'");

                    model_StuCheck.StuCheck_ID = deal.Deal_ID();
                    model_StuCheck.Student_Sno = ds_Student.Tables[0].Rows[0]["Student_Sno"].ToString();
                    model_StuCheck.StuCheck_Term = txt_Term.Text;
                    model_StuCheck.StuCheck_Date = Convert.ToDateTime(txt_Date.Text);
                    model_StuCheck.StuCheck_Stage = txt_Stage.Text;
                    model_StuCheck.StuCheck_Remarks = txt_Remarks.Text;
                    bll_StuCheck.Add(model_StuCheck);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("学生不存在！", "StuCheckEdit.aspx");
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
                DataSet ds_StuCheck = bll_StuCheck.GetList("StuCheck_ID = '" + id.ToString() + "'");
                DataSet ds_Student = bll_Student.GetList("Student_Name = '" + txt_Name.Text + "'");

                if (Session["admin_id"] == null)
                {
                    model_StuCheck.StuCheck_ID = id.ToString();
                    model_StuCheck.Student_Sno = ds_Student.Tables[0].Rows[0]["Student_Sno"].ToString();
                    model_StuCheck.StuCheck_Term = txt_Term.Text;
                    model_StuCheck.StuCheck_Date = Convert.ToDateTime(txt_Date.Text);
                    model_StuCheck.StuCheck_Stage = txt_Stage.Text;
                    model_StuCheck.StuCheck_Remarks = txt_Remarks.Text;
                    dal_StuCheck.Update(model_StuCheck);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("学生不存在！", "StuCheckEdit.aspx");
                return false;
            }

            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Term.Text == "" || txt_Date.Text == "" || txt_Stage.Text == "")
            {
                Alert.AlertNo("*为必填项！", "StuCheckEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "StuCheckEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新用户成功！", "StuCheck.aspx");
            }
            else
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "StuCheckEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加用户成功！", "StuCheck.aspx");
            }
        }
    }
}
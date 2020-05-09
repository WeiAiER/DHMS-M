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
    public partial class StudentEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_Student bll_Student = new BLL.DHMS_Student();
        DHMSClass.DAL.DHMS_Student dal_Student = new DAL.DHMS_Student();
        DHMSClass.Model.DHMS_Student model_Student = new Model.DHMS_Student();

        DHMSClass.BLL.DHMS_Department bll_Department = new BLL.DHMS_Department();
        DHMSClass.BLL.DHMS_Class bll_Class = new BLL.DHMS_Class();

        DealID deal = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
         
            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "StudentEdit.aspx");
                    return;
                }
                DataSet ds_Student = bll_Student.GetList("Student_Sno = '" + id.ToString() + "'");

                if (ds_Student.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "StudentEdit.aspx");
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
            DataSet ds_Student = bll_Student.GetList("Student_Sno = '" + _id.ToString() + "'");
            DataSet ds_Class = bll_Class.GetList("Class_ID = '" + ds_Student.Tables[0].Rows[0]["Class_ID"].ToString() + "'");
            DataSet ds_Department = bll_Department.GetList("Department_ID = '" + ds_Student.Tables[0].Rows[0]["Department_ID"].ToString() + "'");

            txt_Name.Text = ds_Student.Tables[0].Rows[0]["Student_Name"].ToString();
            txt_Sex.Text = ds_Student.Tables[0].Rows[0]["Student_Sex"].ToString();
            txt_Birthday.Text = ds_Student.Tables[0].Rows[0]["Student_Birthday"].ToString();
            txt_Num.Text = ds_Student.Tables[0].Rows[0]["Student_Num"].ToString();
            txt_Department.Text = ds_Department.Tables[0].Rows[0]["Department_Name"].ToString();
            txt_Class.Text = ds_Class.Tables[0].Rows[0]["Class_Name"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    DataSet ds_Class = bll_Class.GetList("Class_Name = '" + txt_Class.Text + "'");
                    DataSet ds_Department = bll_Department.GetList("Department_Name = '" + txt_Department.Text + "'");

                    model_Student.Student_Sno = deal.Deal_ID();
                    model_Student.Student_Name = txt_Name.Text;
                    model_Student.Student_Sex = txt_Sex.Text;
                    model_Student.Student_Birthday = Convert.ToDateTime(txt_Birthday.Text);
                    model_Student.Student_Num = txt_Num.Text;
                    model_Student.Department_ID = ds_Department.Tables[0].Rows[0]["Department_ID"].ToString();
                    model_Student.Class_ID = ds_Class.Tables[0].Rows[0]["Class_ID"].ToString();
                    bll_Student.Add(model_Student);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的系部或班级不存在！", "StudentEdit.aspx");
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
                DataSet ds_Student = bll_Student.GetList("Student_Sno = '" + id.ToString() + "'");
                DataSet ds_Class = bll_Class.GetList("Class_Name = '" + txt_Class.Text + "'");
                DataSet ds_Department = bll_Department.GetList("Department_Name = '" + txt_Department.Text + "'");

                if (Session["admin_id"] == null)
                {
                    model_Student.Student_ID = Convert.ToInt32(ds_Student.Tables[0].Rows[0]["Student_ID"].ToString());
                    model_Student.Student_Sno = id.ToString();
                    model_Student.Student_Name = txt_Name.Text;
                    model_Student.Student_Sex = txt_Sex.Text;
                    model_Student.Student_Birthday = Convert.ToDateTime(txt_Birthday.Text);
                    model_Student.Student_Num = txt_Num.Text;
                    model_Student.Department_ID = ds_Department.Tables[0].Rows[0]["Department_ID"].ToString();
                    model_Student.Class_ID = ds_Class.Tables[0].Rows[0]["Class_ID"].ToString();
                    dal_Student.Update(model_Student);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的系部或班级不存在！", "StudentEdit.aspx");
                return false;
            }

            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Sex.Text == "" || txt_Birthday.Text == "" || txt_Department.Text == "" || txt_Class.Text == "")
            {
                Alert.AlertNo("*为必填项！", "StudentEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "StudentEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新用户成功！", "Student.aspx");
            }
            else
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "StudentEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加用户成功！", "Student.aspx");
            }
        }
    }
}
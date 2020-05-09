using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Data;
using System.Text.RegularExpressions;

namespace DHMSClass.Web
{
    public partial class DepartmentEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_Department bll_Department = new BLL.DHMS_Department();
        DHMSClass.DAL.DHMS_Department dal_Department = new DAL.DHMS_Department();
        DHMSClass.Model.DHMS_Department model_Department = new Model.DHMS_Department();
        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();
        DealID deal_Department = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {


            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "DepartmentEdit.aspx");
                    return;
                }
                DataSet ds_Purchase = bll_Department.GetList("Department_ID = '" + id.ToString() + "'");

                if (ds_Purchase.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "DepartmentEdit.aspx");
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
            DataSet ds_Department = bll_Department.GetList("Department_ID = '" + _id.ToString() + "'");
            DataSet ds_Teacher= bll_Teacher.GetList("Teacher_Tno = '" + ds_Department.Tables[0].Rows[0]["Teacher_Tno"].ToString() + "'");

            txt_Department.Text = ds_Department.Tables[0].Rows[0]["Department_Name"].ToString();
            txt_Teacher.Text = ds_Teacher.Tables[0].Rows[0]["Teacher_Name"].ToString();


        }

        #endregion






        #region 增加操作=================================
        private bool DoAdd(long id)
        {
            try
            {
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_Teacher.Text + "'");


                //if (Session["admin_id"] != null)//如果id不为空，进行赋值
                //{
                    model_Department.Department_ID = deal_Department.Deal_ID();
                    model_Department.Department_Name = txt_Department.Text;
                    model_Department.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    bll_Department.Add(model_Department);

                //}
                //else
                //{
                //    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                //    return false;
                //}
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的教师不存在！", "DepartmentEdit.aspx");
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
                DataSet ds_Department = bll_Department.GetList("Department_ID = '" + id.ToString() + "'");
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_Teacher.Text + "'");


                //if (Session["admin_id"] != null)
                //{
                    model_Department.Department_ID = id.ToString();
                    model_Department.Department_Name = txt_Department.Text;
                    model_Department.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    dal_Department.Update(model_Department);
                //}
                //else
                //{
                //    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                //    return false;
                //}
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的教师不存在！", "DepartmentEdit.aspx");
                return false;
            }

            return true;
        }
        #endregion


        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Department.Text == "")
            {
                Alert.AlertNo("*为必填项！", "DepartmentEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "DepartmentEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新信息成功！", "Department.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "DepartmentEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加信息成功！", "Department.aspx");
            }
        }
    }
}
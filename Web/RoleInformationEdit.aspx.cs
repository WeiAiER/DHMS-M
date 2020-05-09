using DHMSClass.BLL;
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
    public partial class RoleInformationEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;
        DHMSClass.BLL.DHMS_Role bll_Role = new BLL.DHMS_Role();
        DHMSClass.DAL.DHMS_Role dal_Role = new DAL.DHMS_Role();
        DHMSClass.Model.DHMS_Role model_Role = new Model.DHMS_Role();
        DealID Deal_Role=new DealID();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "RoleInformationEdit.aspx");
                    return;
                }
                DataSet ds_Register = bll_Role.GetList("Role_ID = '" + id.ToString() + "'");

                if (ds_Register.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "RoleInformationEdit.aspx");
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
            DataSet ds_Role = bll_Role.GetList("Role_ID = '" + _id.ToString() + "'");
            Role_Name.Text = ds_Role.Tables[0].Rows[0]["Role_Name"].ToString();
           Role_Introduction.Text = ds_Role.Tables[0].Rows[0]["Role_Introduction"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd(long id)
        {
            try
            {
                DataSet ds_Role = bll_Role.GetList("Role_ID = '" + id.ToString() + "'");
                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    model_Role.Role_ID = Deal_Role.Deal_ID();
                    model_Role.Role_Name = Role_Name.Text;
                    model_Role.Role_Introduction = Role_Introduction.Text;
                    bll_Role.Add(model_Role);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的值有误！", "RoleInformationEdit.aspx");
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
                DataSet ds_Role = bll_Role.GetList("Role_ID = '" + id.ToString() + "'");
                if (Session["admin_id"] == null)
                {
                    model_Role.Role_ID = id.ToString();
                    model_Role.Role_Name = Role_Name.Text;
                    model_Role.Role_Introduction = Role_Introduction.Text;
                    dal_Role.Update(model_Role);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的值有误！", "RoleInformationEdit.aspx");
                return false;
            }
            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (Role_Name.Text == "" || Role_Introduction.Text == "")
            {
                Alert.AlertNo("值为必填项！", "RoleInformationEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "RoleInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新角色成功！", "RoleInformation.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "RoleInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加角色成功！", "RoleInformation.aspx");
            }
        }
    }
}
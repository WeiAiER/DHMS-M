using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DHMSClass.Web
{
    public partial class PermissionsInformationEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;
        DHMSClass.BLL.DHMS_Permission bll_Permissions = new BLL.DHMS_Permission();
        DHMSClass.DAL.DHMS_Permission dal_Permissions = new DAL.DHMS_Permission();
        DHMSClass.Model.DHMS_Permission model_Permissions = new Model.DHMS_Permission();
        DealID Deal_Permissions = new DealID();
        protected void Page_Load(object sender, EventArgs e)
        {
             string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "PermissionsInformationEdit.aspx");
                    return;
                }
                DataSet ds_Register = bll_Permissions.GetList("Permissions_ID = '" + id.ToString() + "'");

                if (ds_Register.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "PermissionsInformationEdit.aspx");
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
            DataSet ds_Permissions = bll_Permissions.GetList("Permissions_ID = '" + _id.ToString() + "'");
            Permissions_Name.Text = ds_Permissions.Tables[0].Rows[0]["Permissions_Name"].ToString();
           Permissions_Introduction.Text = ds_Permissions.Tables[0].Rows[0]["Permissions_Introduction"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd(long id)
        {
            try
            {
                DataSet ds_Permissions = bll_Permissions.GetList("Permissions_ID = '" + id.ToString() + "'");
                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    model_Permissions.Permissions_ID = Deal_Permissions.Deal_ID();
                    model_Permissions.Permissions_Name = Permissions_Name.Text;
                    model_Permissions.Permissions_Introduction = Permissions_Introduction.Text;
                    bll_Permissions.Add(model_Permissions);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的值有误！", "PermissionsInformationEdit.aspx");
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
                DataSet ds_Permissions = bll_Permissions.GetList("Permissions_ID = '" + id.ToString() + "'");
                if (Session["admin_id"] == null)
                {
                    model_Permissions.Permissions_ID = id.ToString();
                    model_Permissions.Permissions_Name = Permissions_Name.Text;
                    model_Permissions.Permissions_Introduction = Permissions_Introduction.Text;
                    dal_Permissions.Update(model_Permissions);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的值有误！", "PermissionsInformationEdit.aspx");
                return false;
            }
            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (Permissions_Name.Text == "" || Permissions_Introduction.Text == "")
            {
                Alert.AlertNo("值为必填项！", "PermissionsInformationEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "PermissionsInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新权限成功！", "PermissionsInformation.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "PermissionsInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加权限成功！", "PermissionsInformation.aspx");
            }
        }
    }
}
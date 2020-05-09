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
    public partial class ClassEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_Class bll_Class = new BLL.DHMS_Class();
        DHMSClass.DAL.DHMS_Class dal_Class = new DAL.DHMS_Class();
        DHMSClass.Model.DHMS_Class model_Class = new Model.DHMS_Class();
        DHMSClass.BLL.DHMS_Department bll_Department = new BLL.DHMS_Department();
        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();
        DealID deal_Class = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "ClassEdit.aspx");
                    return;
                }
                DataSet ds_Purchase = bll_Class.GetList("Class_ID = '" + id.ToString() + "'");

                if (ds_Purchase.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "ClassEdit.aspx");
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
        public bool IsName(string str)
        {
            Regex reg2 = new System.Text.RegularExpressions.Regex(@"^\d{4}$");
            return reg2.IsMatch(str);
        }
        #region 赋值操作=================================
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_Class = bll_Class.GetList("Class_ID = '" + _id.ToString() + "'");
            DataSet ds_Department = bll_Department.GetList("Department_ID = '" + ds_Class.Tables[0].Rows[0]["Department_ID"].ToString() + "'");
            DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Tno = '" + ds_Class.Tables[0].Rows[0]["Teacher_Tno"].ToString() + "'");

            txt_Name.Text = ds_Class.Tables[0].Rows[0]["Class_Name"].ToString();
            txt_Department.Text = ds_Department.Tables[0].Rows[0]["Department_Name"].ToString();
            txt_Teacher.Text = ds_Class.Tables[0].Rows[0]["Teacher_Name"].ToString();


        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd(long id)
        {
            try
            {
                DataSet ds_Department = bll_Department.GetList("Department_Name = '" + txt_Department.Text + "'");
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_Teacher.Text + "'");

                //if (Session["admin_id"] != null)//如果id不为空，进行赋值
                //{
                if (!IsName(txt_Name.Text))
                {
                    Alert.AlertNo("请输入正确的班级", "ClassEdit.aspx");
                    return false;
                }


                model_Class.Class_ID = deal_Class.Deal_ID();
                model_Class.Class_Name = txt_Name.Text;

                model_Class.Department_ID = ds_Department.Tables[0].Rows[0]["Department_ID"].ToString();
                model_Class.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                bll_Class.Add(model_Class);

                //}
                //else
                //{
                //    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                //    return false;
                //}
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的教师或系部不存在！", "DepartmentEdit.aspx");
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
                DataSet ds_Class = bll_Class.GetList("Class_ID = '" + id.ToString() + "'");
                DataSet ds_Department = bll_Department.GetList("Department_Name = '" + txt_Department.Text + "'");
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_Teacher.Text + "'");

                //if (Session["admin_id"] != null)
                //{
                if (!IsName(txt_Name.Text))
                {
                    Alert.AlertNo("请输入正确的班级", "ClassEdit.aspx");
                    return false;
                }


                model_Class.Class_ID = id.ToString();
                model_Class.Class_Name = txt_Name.Text;
                model_Class.Department_ID = ds_Department.Tables[0].Rows[0]["Department_ID"].ToString();
                model_Class.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                dal_Class.Update(model_Class);
                //}
                //else
                //{
                //    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                //    return false;
                //}
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的教师或系部不存在！", "DepartmentEdit.aspx");
                return false;
            }

            return true;
        }
        #endregion


        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Department.Text == "" || txt_Teacher.Text == "")
            {
                Alert.AlertNo("*为必填项！", "ClassEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "ClassEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新信息成功！", "Class.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "ClassEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加信息成功！", "Class.aspx");
            }
        }
    }
}
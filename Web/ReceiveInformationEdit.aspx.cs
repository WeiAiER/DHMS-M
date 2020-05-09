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
    public partial class ReceiveInformationEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_Receive bll_Receive = new BLL.DHMS_Receive();
        DHMSClass.DAL.DHMS_Receive dal_Receive = new DAL.DHMS_Receive();
        DHMSClass.Model.DHMS_Receive model_Receive = new Model.DHMS_Receive();

        DHMSClass.BLL.DHMS_Material bll_Material = new BLL.DHMS_Material();
        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();

        DealID deal_Receive = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_RDateTime.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd") + "',lang:'zh-cn'})");

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "ReceiveInformation.aspx");
                    return;
                }
                DataSet ds_Receive = bll_Receive.GetList("Receive_ID = '" + id.ToString() + "'");

                if (ds_Receive.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "ReceiveInformation.aspx");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                Boon();
                if (action == "Edit") //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        public void Boon()
        {
            DataTable dt_Material = bll_Material.GetList("").Tables[0];
            ddl_MName.DataSource = dt_Material;//设置数据源
            ddl_MName.DataTextField = "Material_Name";//设置所要读取的数据表里的列名
            ddl_MName.DataBind();//数据绑定
        }

        public bool IsDate(string StrSource)
        {
            return Regex.IsMatch(StrSource, "^(?<year>\\d{2,4})-(?<month>\\d{1,2})-(?<day>\\d{1,2})$");
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }

        #region 赋值操作=================================
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值

            DataSet ds_Receive = bll_Receive.GetList("Receive_ID = '" + _id.ToString() + "'");
            DataSet ds_Material = bll_Material.GetList("Material_ID = '" + ds_Receive.Tables[0].Rows[0]["Material_ID"].ToString() + "'");
            DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Tno = '" + ds_Receive.Tables[0].Rows[0]["Teacher_Tno"].ToString() + "'");

            ddl_MName.SelectedValue = ds_Material.Tables[0].Rows[0]["Material_Name"].ToString();
            txt_TName.Text = ds_Teacher.Tables[0].Rows[0]["Teacher_Name"].ToString();
            txt_RNumber.Text = ds_Receive.Tables[0].Rows[0]["Receive_Number"].ToString();
            txt_RDateTime.Text = ds_Receive.Tables[0].Rows[0]["Receive_DateTime"].ToString();
            
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    DataSet ds_Material = bll_Material.GetList("Material_Name = '" + ddl_MName.SelectedValue + "'");
                    DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_TName.Text + "'");

                    if (!IsDate(txt_RDateTime.Text))
                    {
                        Alert.AlertNo("请正确输入日期类型：yyyy-MM-dd", "ReceiveInformationEdit.aspx");
                        return false;
                    }
                    if (!IsNumeric(txt_RNumber.Text))
                    {
                        Alert.AlertNo("请输入正确的数值", "ReceiveInformationEdit.aspx");
                        return false;
                    }

                    model_Receive.Receive_ID = deal_Receive.Deal_ID();
                    model_Receive.Material_ID = ds_Material.Tables[0].Rows[0]["Material_ID"].ToString();
                    model_Receive.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_Receive.Receive_Number = Convert.ToInt32(txt_RNumber.Text);
                    model_Receive.Receive_DateTime = Convert.ToDateTime(txt_RDateTime.Text);
                    bll_Receive.Add(model_Receive);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("教师或物资不存在，请重新输入！", "ReceiveInformationEdit.aspx");
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
                if (Session["admin_id"] == null)
                {
                    DataSet ds_Material = bll_Material.GetList("Material_Name = '" + ddl_MName.SelectedValue + "'");
                    DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_TName.Text + "'");

                    if (!IsDate(txt_RDateTime.Text))
                    {
                        Alert.AlertAndRedirect("请正确输入日期类型：yyyy-MM-dd", "ReceiveInformation.aspx");
                        return false;
                    }
                    if (!IsNumeric(txt_RNumber.Text))
                    {
                        Alert.AlertAndRedirect("请输入正确的数值", "ReceiveInformation.aspx");
                        return false;
                    }

                    model_Receive.Receive_ID = id.ToString();
                    model_Receive.Material_ID = ds_Material.Tables[0].Rows[0]["Material_ID"].ToString();
                    model_Receive.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_Receive.Receive_Number = Convert.ToInt32(txt_RNumber.Text);
                    model_Receive.Receive_DateTime = Convert.ToDateTime(txt_RDateTime.Text);
                    dal_Receive.Update(model_Receive);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("教师或物资不存在，请重新输入！", "ReceiveInformation.aspx");
                return false;
            }

            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_RNumber.Text == "" || txt_RDateTime.Text == "" || txt_TName.Text == "")
            {
                Alert.AlertAndRedirect("*为必填项！", "ReceiveInformationEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "ReceiveInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新物资领用成功！", "ReceiveInformation.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "ReceiveInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加物资领用成功！", "ReceiveInformation.aspx");
            }
        }

    }
}
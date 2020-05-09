using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace DHMSClass.Web
{
    public partial class PurchaseInformationEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;
        private static int Material_Stock = 0;
        private static int Material_Count = 0;

        DHMSClass.BLL.DHMS_Purchase bll_Purchase = new BLL.DHMS_Purchase();
        DHMSClass.DAL.DHMS_Purchase dal_Purchase = new DAL.DHMS_Purchase();
        DHMSClass.Model.DHMS_Purchase model_Purchase = new Model.DHMS_Purchase();

        DHMSClass.BLL.DHMS_Material bll_Material = new BLL.DHMS_Material();
        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();

        DealID deal_Purchase = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_PPDateTime.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd") + "',lang:'zh-cn'})");

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "PurchaseInformation.aspx");
                    return;
                }
                DataSet ds_Purchase = bll_Purchase.GetList("Purchase_ID = '" + id.ToString() + "'");

                if (ds_Purchase.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "PurchaseInformation.aspx");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (action == "Edit") //修改
                {
                    txt_PNumber.Enabled = false;
                    ShowInfo(this.id);
                }
            }
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

            DataSet ds_Purchase = bll_Purchase.GetList("Purchase_ID = '" + _id.ToString() + "'");
            DataSet ds_Material = bll_Material.GetList("Material_ID = '" + ds_Purchase.Tables[0].Rows[0]["Material_ID"].ToString() + "'");
            DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Tno = '" + ds_Purchase.Tables[0].Rows[0]["Teacher_Tno"].ToString() + "'");

            txt_MName.Text = ds_Material.Tables[0].Rows[0]["Material_Name"].ToString();
            txt_PNumber.Text = ds_Purchase.Tables[0].Rows[0]["Purchase_Number"].ToString();
            txt_PPDateTime.Text = ds_Purchase.Tables[0].Rows[0]["Purchase_DateTime"].ToString();
            txt_TName.Text = ds_Teacher.Tables[0].Rows[0]["Teacher_Name"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    DataSet ds_Material = bll_Material.GetList("Material_Name = '" + txt_MName.Text + "'");
                    DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_TName.Text + "'");

                    if (!IsDate(txt_PPDateTime.Text))
                    {
                        Alert.AlertNo("请正确输入日期类型：yyyy-MM-dd", "PurchaseInformationEdit.aspx");
                        return false;
                    }
                    if (!IsNumeric(txt_PNumber.Text))
                    {
                        Alert.AlertNo("请输入正确的数值", "PurchaseInformationEdit.aspx");
                        return false;
                    }

                    model_Purchase.Purchase_ID = deal_Purchase.Deal_ID();
                    model_Purchase.Material_ID = ds_Material.Tables[0].Rows[0]["Material_ID"].ToString();
                    model_Purchase.Purchase_Number = Convert.ToInt32(txt_PNumber.Text);
                    model_Purchase.Purchase_DateTime = Convert.ToDateTime(txt_PPDateTime.Text);
                    model_Purchase.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    bll_Purchase.Add(model_Purchase);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("教师或物资不存在，请重新输入！", "PurchaseInformationEdit.aspx");
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
                    DataSet ds_Purchase = bll_Purchase.GetList("Purchase_ID = '" + id.ToString() + "'");
                    DataSet ds_Material = bll_Material.GetList("Material_Name = '" + txt_MName.Text + "'");
                    DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_TName.Text + "'");

                    if (!IsDate(txt_PPDateTime.Text))
                    {
                        Alert.AlertAndRedirect("请正确输入日期类型：yyyy-MM-dd", "PurchaseInformation.aspx");
                        return false;
                    }
                    if (!IsNumeric(txt_PNumber.Text))
                    {
                        Alert.AlertAndRedirect("请输入正确的数值", "PurchaseInformation.aspx");
                        return false;
                    }

                    model_Purchase.Purchase_ID = id.ToString();
                    model_Purchase.Material_ID = ds_Material.Tables[0].Rows[0]["Material_ID"].ToString();
                    model_Purchase.Purchase_Number = Convert.ToInt32(ds_Purchase.Tables[0].Rows[0]["Purchase_Number"].ToString());
                    model_Purchase.Purchase_DateTime = Convert.ToDateTime(txt_PPDateTime.Text);
                    model_Purchase.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    dal_Purchase.Update(model_Purchase);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("教师或物资不存在，请重新输入！", "PurchaseInformation.aspx");
                return false;
            }

            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (action == "Edit") //修改
            {
                if (txt_MName.Text == "" || txt_PPDateTime.Text == "" || txt_TName.Text == "")
                {
                    Alert.AlertNo("*为必填项！", "PurchaseInformationEdit.aspx");
                    return;
                }

                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "PurchaseInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新物资采购成功！", "PurchaseInformation.aspx");
            }
            if (action == "Add")
            {
                if (txt_MName.Text == "" || txt_PNumber.Text == "" || txt_PPDateTime.Text == "" || txt_TName.Text == "")
                {
                    Alert.AlertNo("*为必填项！", "PurchaseInformationEdit.aspx");
                    return;
                }

                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "PurchaseInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加物资采购成功！", "PurchaseInformation.aspx");
            }
        }

    }
}
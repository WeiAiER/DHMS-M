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
    public partial class MaterialInformationEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_Material bll_Material = new BLL.DHMS_Material();
        DHMSClass.DAL.DHMS_Material dal_Material = new DAL.DHMS_Material();
        DHMSClass.Model.DHMS_Material model_Material = new Model.DHMS_Material();

        DHMSClass.BLL.DHMS_Purchase bll_Purchase = new BLL.DHMS_Purchase();
        DHMSClass.BLL.DHMS_Receive bll_Receive = new BLL.DHMS_Receive();

        DealID deal_Material = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_MPDateTime.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd") + "',lang:'zh-cn'})");
            txt_MEDateTime.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd") + "',lang:'zh-cn'})");

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "MaterialInformation.aspx");
                    return;
                }
                DataSet ds_Material = bll_Material.GetList("Material_ID = '" + id.ToString() + "'");

                if (ds_Material.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "MaterialInformation.aspx");
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
        /// <summary>
        /// 物资修改时赋值
        /// </summary>
        /// <param name="_id"></param>
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_Material = bll_Material.GetList("Material_ID = '" + _id.ToString() + "'");

            txt_MName.Text = ds_Material.Tables[0].Rows[0]["Material_Name"].ToString();
            txt_MSpecs.Text = ds_Material.Tables[0].Rows[0]["Material_Specs"].ToString();
            txt_MUnit.Text = ds_Material.Tables[0].Rows[0]["Material_Unit"].ToString();
            txt_MPlace.Text = ds_Material.Tables[0].Rows[0]["Material_Place"].ToString();
            txt_MCertificate.Text = ds_Material.Tables[0].Rows[0]["Material_Certificate"].ToString();
            txt_MPDateTime.Text = ds_Material.Tables[0].Rows[0]["Material_PDateTime"].ToString();
            txt_MEDateTime.Text = ds_Material.Tables[0].Rows[0]["Material_EDateTime"].ToString();
            txt_MMethod.Text = ds_Material.Tables[0].Rows[0]["Material_Method"].ToString();
        }
        #endregion

        #region 增加操作=================================
        /// <summary>
        /// 物资新增
        /// </summary>
        /// <returns></returns>
        private bool DoAdd()
        {
            try
            {
                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    if (!IsDate(txt_MPDateTime.Text) || !IsDate(txt_MEDateTime.Text))
                    {
                        Alert.AlertNo("请正确输入日期类型：yyyy-MM-dd", "MaterialInformationEdit.aspx");
                        return false;
                    }

                    model_Material.Material_ID = deal_Material.Deal_ID();
                    model_Material.Material_Name = txt_MName.Text;
                    model_Material.Material_Specs = txt_MSpecs.Text;
                    model_Material.Material_Unit = txt_MUnit.Text;
                    model_Material.Material_Place = txt_MPlace.Text;
                    model_Material.Material_Certificate = txt_MCertificate.Text;
                    model_Material.Material_PDateTime = Convert.ToDateTime(txt_MPDateTime.Text);
                    model_Material.Material_EDateTime = Convert.ToDateTime(txt_MEDateTime.Text);
                    model_Material.Material_Method = txt_MMethod.Text;
                    bll_Material.Add(model_Material);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的值有误，请重新输入！", "MaterialInformationEdit.aspx");
                return false;
            }

            return true;
        }
        #endregion

        #region 修改操作=================================
        /// <summary>
        /// 对物资进行修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoEdit(long id)
        {
            try
            {
                if (Session["admin_id"] == null)
                {
                    if (!IsDate(txt_MPDateTime.Text) || !IsDate(txt_MEDateTime.Text))
                    {
                        Alert.AlertAndRedirect("请正确输入日期类型：yyyy-MM-dd", "MaterialInformation.aspx");
                        return false;
                    }

                    model_Material.Material_ID = id.ToString();
                    model_Material.Material_Name = txt_MName.Text;
                    model_Material.Material_Specs = txt_MSpecs.Text;
                    model_Material.Material_Unit = txt_MUnit.Text;
                    model_Material.Material_Place = txt_MPlace.Text;
                    model_Material.Material_Certificate = txt_MCertificate.Text;
                    model_Material.Material_PDateTime = Convert.ToDateTime(txt_MPDateTime.Text);
                    model_Material.Material_EDateTime = Convert.ToDateTime(txt_MEDateTime.Text);
                    model_Material.Material_Method = txt_MMethod.Text;
                    dal_Material.Update(model_Material);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的值有误，请重新输入！", "MaterialInformation.aspx");
                return false;
            }

            return true;
        }
        #endregion
        
        /// <summary>
        /// 确认新增或修改物资
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_MName.Text == "" || txt_MPDateTime.Text == "" || txt_MEDateTime.Text == "")
            {
                Alert.AlertNo("*为必填项！", "MaterialInformationEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "MaterialInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新物资成功！", "MaterialInformation.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "MaterialInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加物资成功！", "MaterialInformation.aspx");
            }
        }

    }
}
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
    public partial class BoarderManageEdit : System.Web.UI.Page
    {

        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_BoarderManage bll_boardermange = new BLL.DHMS_BoarderManage();
        DHMSClass.DAL.DHMS_BoarderManage dal_boardermange = new DAL.DHMS_BoarderManage();
        DHMSClass.Model.DHMS_BoarderManage model_boardermange = new Model.DHMS_BoarderManage();

        DHMSClass.BLL.DHMS_Student bll_Student = new BLL.DHMS_Student();

        DealID deal_boardermange = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {

            txt_date.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd HH时mm分ss秒',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd HH时mm分ss秒") + "',lang:'zh-cn'})");
            txt_BoarderManage_NTime.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd HH时mm分ss秒',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd HH时mm分ss秒") + "',lang:'zh-cn'})");
            txt_BoarderManage_RTime.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd HH时mm分ss秒',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd HH时mm分ss秒") + "',lang:'zh-cn'})");

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "BoarderInformationEdit.aspx");
                    return;
                }
                DataSet ds_Purchase = bll_boardermange.GetList("BoarderManage_ID = '" + id.ToString() + "'");

                if (ds_Purchase.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "BoarderInformationEdit.aspx");
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
            Regex reg2 = new System.Text.RegularExpressions.Regex(@"^[\u4E00-\u9FA5]{2,4}$");
            return reg2.IsMatch(str);
        }

        #region 赋值操作=================================
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_boardermange = bll_boardermange.GetList("BoarderManage_ID = '" + _id.ToString() + "'");
            DataSet ds_Student = bll_Student.GetList("Student_Sno = '" + ds_boardermange.Tables[0].Rows[0]["Student_Sno"].ToString() + "'");
            txt_SName.Text = ds_Student.Tables[0].Rows[0]["Student_Name"].ToString();
            txt_date.Text = ds_boardermange.Tables[0].Rows[0]["BoarderManage_Date"].ToString();
            txt_BoarderManage_RTime.Text = ds_boardermange.Tables[0].Rows[0]["BoarderManage_RTime"].ToString();
            txt_BoarderManage_Feedback.Text = ds_boardermange.Tables[0].Rows[0]["BoarderManage_Feedback"].ToString();
            txt_BoarderManage_NTime.Text = ds_boardermange.Tables[0].Rows[0]["BoarderManage_NTime"].ToString();

        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd(long id)
        {
            try
            {
                DataSet ds_BoarderManage = bll_boardermange.GetList("BoarderManage_ID = '" + id.ToString() + "'");
                DataSet ds_Student = bll_Student.GetList("Student_Name = '" + txt_SName.Text + "'");

                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    if (!IsName(txt_SName.Text))
                    {
                        Alert.AlertNo("请输入正确的姓名", "BoarderManageEdit.aspx");
                        return false;
                    }

                    model_boardermange.BoarderManage_ID = deal_boardermange.Deal_ID();
                    model_boardermange.Student_Sno = ds_Student.Tables[0].Rows[0]["Student_Sno"].ToString();
                    model_boardermange.BoarderManage_Date = Convert.ToDateTime(txt_date.Text);
                    model_boardermange.BoarderManage_RTime = Convert.ToDateTime(txt_BoarderManage_RTime.Text);
                    model_boardermange.BoarderManage_Feedback = txt_BoarderManage_Feedback.Text;
                    model_boardermange.BoarderManage_NTime = Convert.ToDateTime(txt_BoarderManage_NTime.Text);
                    bll_boardermange.Add(model_boardermange);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的值有误！", "BoarderManageEdit.aspx");
            }

            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(long id)
        {
            try
            {
                DataSet ds_BoarderManage = bll_boardermange.GetList("BoarderManage_ID = '" + id.ToString() + "'");
                DataSet ds_Student = bll_Student.GetList("Student_Name = '" + txt_SName.Text + "'");

                if (Session["admin_id"] == null)
                {
                    if (!IsName(txt_SName.Text))
                    {
                        Alert.AlertNo("请输入正确的姓名", "BoarderManageEdit.aspx");
                        return false;
                    }

                    model_boardermange.BoarderManage_ID = id.ToString();
                    model_boardermange.Student_Sno = ds_Student.Tables[0].Rows[0]["Student_Sno"].ToString();
                    model_boardermange.BoarderManage_Date = Convert.ToDateTime(txt_date.Text);
                    model_boardermange.BoarderManage_RTime = Convert.ToDateTime(txt_BoarderManage_RTime.Text);
                    model_boardermange.BoarderManage_Feedback = txt_BoarderManage_Feedback.Text;
                    model_boardermange.BoarderManage_NTime = Convert.ToDateTime(txt_BoarderManage_NTime.Text);
                    dal_boardermange.Update(model_boardermange);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的值有误！", "BoarderManageEdit.aspx");
            }

            return true;
        }
        #endregion


        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_SName.Text == "")
            {
                Alert.AlertNo("*为必填项！", "BoarderManageEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "BoarderManageEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新信息成功！", "BoarderManage.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "BoarderManageEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加信息成功！", "BoarderManage.aspx");
            }
        }
    }
}
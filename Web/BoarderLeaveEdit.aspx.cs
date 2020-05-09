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
    public partial class BoarderLeaveEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_BoarderLeave bll_boarderLeave = new BLL.DHMS_BoarderLeave();
        DHMSClass.DAL.DHMS_BoarderLeave dal_boarderLeave = new DAL.DHMS_BoarderLeave();
        DHMSClass.Model.DHMS_BoarderLeave model_boarderLeave = new Model.DHMS_BoarderLeave();

        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();

        DealID deal_boarderleave = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {

            txt_Date.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd") + "',lang:'zh-cn'})");

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "BoarderLeaveEdit.aspx");
                    return;
                }
                DataSet ds_Purchase = bll_boarderLeave.GetList("BoarderLeave_ID = '" + id.ToString() + "'");

                if (ds_Purchase.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "BoarderLeaveEdit.aspx");
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
            DataSet ds_BoarderLeave = bll_boarderLeave.GetList("BoarderLeave_ID = '" + _id.ToString() + "'");

            txt_Date.Text = ds_BoarderLeave.Tables[0].Rows[0]["BoarderLeave_Date"].ToString();
            txt_Reason.Text = ds_BoarderLeave.Tables[0].Rows[0]["BoarderLeave_Reason"].ToString();
            txt_Auditor.Text = ds_BoarderLeave.Tables[0].Rows[0]["BoarderLeave_Auditor"].ToString();
            txt_State.Text = ds_BoarderLeave.Tables[0].Rows[0]["BoarderLeave_State"].ToString();
        }

        #endregion

        #region 增加操作=================================
        private bool DoAdd(long id)
        {
            try
            {
                DataSet ds_BoarderLeave = bll_boarderLeave.GetList("BoarderLeave_ID = '" + id.ToString() + "'");

                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    if (!IsName(txt_Auditor.Text))
                    {
                        Alert.AlertNo("请输入正确的姓名", "BoarderLeaveEdit.aspx");
                        return false;
                    }

                    model_boarderLeave.BoarderLeave_ID = deal_boarderleave.Deal_ID();
                    model_boarderLeave.BoarderLeave_Date = Convert.ToDateTime(txt_Date.Text);
                    model_boarderLeave.BoarderLeave_Reason = txt_Reason.Text;
                    model_boarderLeave.BoarderLeave_Auditor = txt_Auditor.Text;
                    model_boarderLeave.BoarderLeave_State = txt_State.Text;
                    bll_boarderLeave.Add(model_boarderLeave);

                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的值有误！", "BoarderLeaveEdit.aspx");
            }

            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(long id)
        {
            try
            {
                DataSet ds_BoarderLeave = bll_boarderLeave.GetList("BoarderLeave_ID = '" + id.ToString() + "'");


                if (Session["admin_id"] == null)
                {
                    if (!IsName(txt_Auditor.Text))
                    {
                        Alert.AlertNo("请输入正确的姓名", "BoarderLeaveEdit.aspx");
                        return false;
                    }
                    model_boarderLeave.BoarderLeave_ID = id.ToString();
                    model_boarderLeave.BoarderLeave_Date = Convert.ToDateTime(txt_Date.Text);
                    model_boarderLeave.BoarderLeave_Reason = txt_Reason.Text;
                    model_boarderLeave.BoarderLeave_Auditor = txt_Auditor.Text;
                    dal_boarderLeave.Update(model_boarderLeave);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的值有误！", "BoarderLeaveEdit.aspx");
            }

            return true;
        }
        #endregion


        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Auditor.Text == "")
            {
                Alert.AlertNo("*为必填项！", "BoarderLeaveEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "BoarderLeaveEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新信息成功！", "BoarderLeave.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "BoarderLeaveEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加信息成功！", "BoarderLeave.aspx");
            }
        }
    }
}
using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace DHMSClass.Web
{
    public partial class BoarderInformationEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_Boarder bll_boarder = new BLL.DHMS_Boarder();
        DHMSClass.DAL.DHMS_Boarder dal_boarder = new DAL.DHMS_Boarder();
        DHMSClass.Model.DHMS_Boarder model_boarder = new Model.DHMS_Boarder();

        DHMSClass.BLL.DHMS_Student bll_Student = new BLL.DHMS_Student();
        DealID deal_boarder = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "BoarderInformationEdit.aspx");
                    return;
                }
                DataSet ds_Purchase = bll_boarder.GetList("Boarder_ID = '" + id.ToString() + "'");

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

        public bool IsBoarder(string str)
        {
            Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[1-9]-\d{3}$");
            return reg1.IsMatch(str);
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
            DataSet ds_Boarder = bll_boarder.GetList("Boarder_ID = '" + _id.ToString() + "'");
            DataSet ds_Student = bll_Student.GetList("Student_Sno = '" + ds_Boarder.Tables[0].Rows[0]["Student_Sno"].ToString() + "'");
            txt_SName.Text = ds_Student.Tables[0].Rows[0]["Student_Name"].ToString();
            txt_board.Text = ds_Boarder.Tables[0].Rows[0]["Boarder_HostelNum"].ToString();

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd(long id)
        {
            try
            {
                DataSet ds_Boarder = bll_boarder.GetList("Boarder_ID = '" + id.ToString() + "'");
                DataSet ds_Student = bll_Student.GetList("Student_Name = '" + txt_SName.Text + "'");

                if (Session["admin_id"] != null)//如果id不为空，进行赋值
                {

                    if (!IsBoarder(txt_board.Text))
                    {
                        Alert.AlertNo("请输入正确的住宿号", "BoarderInformationEdit.aspx");
                        return false;
                    }

                    if (!IsName(txt_SName.Text))
                    {
                        Alert.AlertNo("请输入正确的姓名", "BoarderInformationEdit.aspx");
                        return false;
                    }

                    model_boarder.Boarder_ID = deal_boarder.Deal_ID();
                    model_boarder.Student_Sno = ds_Student.Tables[0].Rows[0]["Student_Sno"].ToString();
                    model_boarder.Boarder_HostelNum = txt_board.Text;
                    bll_boarder.Add(model_boarder);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的信息有误！", "BoarderInformationEdit.aspx");
            }

            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(long id)
        {
            try
            {
                DataSet ds_Boarder = bll_boarder.GetList("Boarder_ID = '" + id.ToString() + "'");
                DataSet ds_Student = bll_Student.GetList("Student_Name = '" + txt_SName.Text + "'");

                if (Session["admin_id"] == null)
                {

                if (!IsBoarder(txt_board.Text))
                {
                    Alert.AlertNo("请输入正确的住宿号", "BoarderInformationEdit.aspx");
                    return false;
                }

                if (!IsName(txt_SName.Text))
                {
                    Alert.AlertNo("请输入正确的姓名", "BoarderInformationEdit.aspx");
                    return false;
                }

                model_boarder.Boarder_ID = id.ToString();
                model_boarder.Student_Sno = ds_Student.Tables[0].Rows[0]["Student_Sno"].ToString();
                model_boarder.Boarder_HostelNum = txt_board.Text;
                dal_boarder.Update(model_boarder);

                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的值有误！", "BoarderInformationEdit.aspx");
            }

            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_SName.Text == "")
            {
                Alert.AlertNo("*为必填项！", "BoarderInformationEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "BoarderInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新信息成功！", "BoarderInformation.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "BoarderInformationEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加信息成功！", "BoarderInformation.aspx");
            }
        }
    }
}
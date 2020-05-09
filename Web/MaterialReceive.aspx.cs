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
    public partial class MaterialReceive : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;
        private int Material_Count = 0;

        DHMSClass.BLL.DHMS_Receive bll_Receive = new BLL.DHMS_Receive();
        DHMSClass.DAL.DHMS_Receive dal_Receive = new DAL.DHMS_Receive();
        DHMSClass.Model.DHMS_Receive model_Receive = new Model.DHMS_Receive();

        DHMSClass.BLL.DHMS_Material bll_Material = new BLL.DHMS_Material();
        DHMSClass.BLL.DHMS_Purchase bll_Purchase = new BLL.DHMS_Purchase();
        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();

        DealID deal_Receive = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "PurchaseInformation.aspx");
                    return;
                }
                DataSet ds_Receive = bll_Receive.GetList("Receive_ID = '" + id.ToString() + "'");

                if (ds_Receive.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "PurchaseInformation.aspx");
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

        public bool IsNumeric(string str)
        {
            Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }

        #region 赋值操作=================================
        /// <summary>
        /// 领用时赋值
        /// </summary>
        /// <param name="_id">MaterialReceive页面传递的id值</param>
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_Receive = bll_Receive.GetList("Receive_ID = '" + _id.ToString() + "'");
            DataSet ds_Material = bll_Material.GetList("Material_ID = '" + ds_Receive.Tables[0].Rows[0]["Material_ID"].ToString() + "'");

            txt_MName.Text = ds_Material.Tables[0].Rows[0]["Material_Name"].ToString();
            txt_MSpecs.Text = ds_Material.Tables[0].Rows[0]["Material_Specs"].ToString();
        }
        #endregion

        #region 增加操作=================================
        /// <summary>
        /// 新增物资领用
        /// </summary>
        /// <param name="id">领用物资的id</param>
        /// <returns>返回布尔值</returns>
        private bool DoAdd(long id)
        {
            try
            {
                DataSet ds_Material = bll_Material.GetList("Material_Name = '" + txt_MName.Text + "'");
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_UName.Text + "'");

                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    if (!IsNumeric(txt_RNumber.Text))
                    {
                        Alert.AlertNo("输入的数值不正确！", "MaterialReceive.aspx");
                    }

                    model_Receive.Receive_ID = deal_Receive.Deal_ID();
                    model_Receive.Material_ID = ds_Material.Tables[0].Rows[0]["Material_ID"].ToString();
                    model_Receive.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_Receive.Receive_Number = Convert.ToInt32(txt_RNumber.Text);
                    model_Receive.Receive_DateTime = DateTime.Now.Date;
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
                Alert.AlertNo("输入的物资或教师不存在，请重新输入！", "MaterialReceive.aspx");
                return false;
            }

            return true;
        }
        #endregion

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            DataSet ds_Material = bll_Material.GetList("Material_ID = '" + id.ToString() + "'");
            DataSet ds_Purchase = bll_Purchase.GetList("Material_ID = '" + ds_Material.Tables[0].Rows[0]["Material_ID"].ToString() + "'");

            for (int i = 0; i < ds_Purchase.Tables[0].Rows.Count; i++)
            {
                Material_Count += Convert.ToInt32(ds_Purchase.Tables[0].Rows[i]["Purchase_Number"].ToString());
            }

            if (Convert.ToInt32(txt_RNumber.Text) > Material_Count)
            {
                Alert.AlertNo("领用量大于库存量！", "MaterialReceive.aspx");
                return;
            }

            if (txt_MName.Text == "" || txt_RNumber.Text == "" || txt_UName.Text == "")
            {
                Alert.AlertNo("*为必填项！", "MaterialReceive.aspx");
                return;
            }

            if (!DoAdd(this.id))
            {
                Alert.AlertAndRedirect("领用发生错误！", "MaterialReceive.aspx");
                return;
            }
            Alert.AlertAndRedirect("领用成功！", "PurchaseInformation.aspx");
        }

    }
}
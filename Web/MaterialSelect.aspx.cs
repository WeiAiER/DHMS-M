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
    public partial class MaterialSelect : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;
        private int Material_Receive = 0;
        private int Material_Stock = 0;
        private int Material_Count = 0;

        DHMSClass.BLL.DHMS_Material bll_Material = new BLL.DHMS_Material();
        DHMSClass.DAL.DHMS_Material dal_Material = new DAL.DHMS_Material();
        DHMSClass.Model.DHMS_Material model_Material = new Model.DHMS_Material();

        DHMSClass.BLL.DHMS_Purchase bll_Purchase = new BLL.DHMS_Purchase();
        DHMSClass.BLL.DHMS_Receive bll_Receive = new BLL.DHMS_Receive();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Select")
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
                if (action == "Select") //修改
                {
                    ShowInfo(this.id);
                    DoSelect();
                }
            }
        }

        #region 赋值操作=================================
        /// <summary>
        /// 修改时赋值
        /// </summary>
        /// <param name="_id">MaterialReceive页面传来的对应id</param>
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_Material = bll_Material.GetList("Material_ID = '" + _id.ToString() + "'");

            txt_MName.Text = ds_Material.Tables[0].Rows[0]["Material_Name"].ToString();
            txt_MSpecs.Text = ds_Material.Tables[0].Rows[0]["Material_Specs"].ToString();
        }
        #endregion

        #region 获取物资的库存量和采购总量=================================
        /// <summary>
        /// 库存量和采购总量
        /// </summary>
        private void DoSelect()
        {
            try
            {
                DataSet ds_Material = bll_Material.GetList("Material_ID = '" + id.ToString() + "'");
                DataSet ds_Purchase = bll_Purchase.GetList("Material_ID = '" + ds_Material.Tables[0].Rows[0]["Material_ID"].ToString() + "'");
                DataSet ds_Receive = bll_Receive.GetList("Material_ID = '" + ds_Material.Tables[0].Rows[0]["Material_ID"].ToString() + "'");

                for (int i = 0; i < ds_Purchase.Tables[0].Rows.Count; i++)
                {
                    Material_Count += Convert.ToInt32(ds_Purchase.Tables[0].Rows[i]["Purchase_Number"].ToString());
                }

                for (int i = 0; i < ds_Receive.Tables[0].Rows.Count; i++)
                {
                    Material_Receive += Convert.ToInt32(ds_Receive.Tables[0].Rows[i]["Receive_Number"].ToString());
                }

                txt_MCount.Text = Material_Count.ToString();
                Material_Stock = Material_Count - Material_Receive;
                txt_MStock.Text = Material_Stock.ToString();

            }
            catch (Exception)
            {
                Alert.AlertNo("有误！", "MaterialSelect.aspx");
            }
        }
        #endregion

    }
}
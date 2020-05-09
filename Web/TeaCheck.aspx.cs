using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace DHMSClass.Web
{
    public partial class TeaCheck : System.Web.UI.Page
    {
        protected int totalCount;//总用户条数
        protected int page;//页数
        protected int pageSize;//每页条数
        protected string keywords = string.Empty;//查询条件

        DHMSClass.BLL.DHMS_TeaCheck bll_TeaCheck = new BLL.DHMS_TeaCheck();
        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = HttpContext.Current.Request.QueryString["keywords"];//从网址上取keywords
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                //RptBind();
                RptBind(keywords);//获取数据
            }
        }

        #region 数据绑定=================================
        private void RptBind(string strWhere)
        {
            if (strWhere == null)
            {
                strWhere = "";
            }
            this.page = MXRequest.GetQueryInt("page", 1);//获取第一页内容
            txtKeywords.Text = this.keywords;//保留查询条件值

            DataTable dt_TeaCheck = bll_TeaCheck.GetList("").Tables[0];
            DataTable dt_Teacher = bll_Teacher.GetList("").Tables[0];

            //用Linq语句实现对部门表的模糊查询
            var result = from r in dt_TeaCheck.AsEnumerable()
                         join g in dt_Teacher.AsEnumerable() on r.Field<string>("Teacher_Tno") equals g.Field<string>("Teacher_Tno")
                         where g.Field<string>("Teacher_Name").Contains(strWhere) || r.Field<string>("TeaCheck_Stage").Contains(strWhere)
                         select new
                         {
                             TeaCheck_ID = r.Field<string>("TeaCheck_ID"),
                             Teacher_Name = g.Field<string>("Teacher_Name"),
                             TeaCheck_Term = r.Field<string>("TeaCheck_Term"),
                             TeaCheck_Date = r.Field<DateTime>("TeaCheck_Date"),
                             TeaCheck_Stage = r.Field<string>("TeaCheck_Stage"),
                             TeaCheck_Remarks = r.Field<string>("TeaCheck_Remarks")
                         };

            this.totalCount = result.AsQueryable().Count();//符合条件的用户总数
            //分页获取数据
            this.rptList.DataSource = result.AsQueryable().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("TeaCheck.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manager_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 页面刷新=============================
        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("TeaCheck.aspx", "keywords={0}", txtKeywords.Text));//跳转页面，并携带keywords
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manager_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("TeaCheck.aspx", "keywords={0}", this.keywords));
        }
        #endregion

        #region 批量删除=============================
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int sucCount = 0;//成功删除数量
            int errorCount = 0;//删除出错数量

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                long id = long.Parse(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            Alert.AlertAndRedirect("删除成功！", Utils.CombUrlTxt("TeaCheck.aspx", "keywords={0}", this.keywords));
        }

        //删除线路
        private bool Delete(long id)
        {
            DataSet ds_Student = bll_TeaCheck.GetList("TeaCheck_ID = '" + id.ToString() + "'");

            try
            {
                if (!bll_TeaCheck.Delete(id.ToString()))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    #endregion
}
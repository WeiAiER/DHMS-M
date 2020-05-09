using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Data;
namespace DHMSClass.Web
{
    public partial class BoarderManage : System.Web.UI.Page
    {

        protected int totalCount;//总用户条数
        protected int page;//页数
        protected int pageSize;//每页条数
        protected string keywords = string.Empty;//查询条件

        DHMSClass.BLL.DHMS_BoarderManage boarderManage = new BLL.DHMS_BoarderManage();
        DHMSClass.BLL.DHMS_Student bll_Student = new BLL.DHMS_Student();

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

        private void RptBind(string strWhere)
        {
            if (strWhere == null)
            {
                strWhere = "";
            }
            this.page = MXRequest.GetQueryInt("page", 1);//获取第一页内容
            txtKeywords.Text = this.keywords;//保留查询条件值

            DataTable dt_BoarderManage = boarderManage.GetList("").Tables[0];
            DataTable dt_Student = bll_Student.GetList("").Tables[0];

            //用Linq语句实现对部门表的模糊查询
            var result = from b in dt_BoarderManage.AsEnumerable()
                         join s in dt_Student.AsEnumerable() on b.Field<string>("Student_Sno") equals s.Field<string>("Student_Sno")
                         where b.Field<string>("BoarderManage_Feedback").Contains(strWhere) || s.Field<string>("Student_Name").Contains(strWhere)
                         select new
                         {
                             BoarderManage_ID = b.Field<string>("BoarderManage_ID"),
                             BoarderManage_Date = b.Field<DateTime>("BoarderManage_Date"),
                             Student_Name = s.Field<string>("Student_Name"),
                             BoarderManage_RTime = b.Field<DateTime>("BoarderManage_RTime"),
                             BoarderManage_Feedback = b.Field<string>("BoarderManage_Feedback"),
                             BoarderManage_NTime = b.Field<DateTime>("BoarderManage_NTime")
                         };

            this.totalCount = result.AsQueryable().Count();//符合条件的用户总数
            //分页获取数据
            this.rptList.DataSource = result.AsQueryable().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("BoarderManage.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);


        }
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
            Alert.AlertAndRedirect("删除成功！", Utils.CombUrlTxt("BoarderManage.aspx", "keywords={0}", this.keywords));

        }

        private bool Delete(long id)
        {
            DataSet ds_Purchase = boarderManage.GetList("BoarderManage_ID = '" + id.ToString() + "'");
            try
            {
                if (!boarderManage.Delete(id.ToString()))
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
            Response.Redirect(Utils.CombUrlTxt("BoarderManage.aspx", "keywords={0}", this.keywords));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("BoarderManage.aspx", "keywords={0}", txtKeywords.Text));//跳转页面，并携带keywords
        }

    }
}
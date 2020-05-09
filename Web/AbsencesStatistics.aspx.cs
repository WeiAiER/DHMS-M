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
    public partial class AbsencesStatistics : System.Web.UI.Page
    {
        protected int totalCount;//总用户条数
        protected int page;//页数
        protected int pageSize;//每页条数
        protected string keywords = string.Empty;//查询条件

        DHMSClass.BLL.DHMS_Miss bll_Miss = new BLL.DHMS_Miss();
        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();
        DHMSClass.BLL.DHMS_Student bll_Student = new BLL.DHMS_Student();
        DHMSClass.BLL.DHMS_Diagnosis bll_Diagnosis = new BLL.DHMS_Diagnosis();
        DHMSClass.BLL.DHMS_Epidemic bll_Epidemic = new BLL.DHMS_Epidemic();
        DHMSClass.BLL.DHMS_Symptom bll_Symptom = new BLL.DHMS_Symptom();

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
        /// <summary>
        /// 前台数据绑定
        /// </summary>
        /// <param name="strWhere">查询的内容</param>
        private void RptBind(string strWhere)
        {
            if (strWhere == null)
            {
                strWhere = "";
            }
            this.page = MXRequest.GetQueryInt("page", 1);//获取第一页内容
            txtKeywords.Text = this.keywords;//保留查询条件值

            DataTable dt_Miss = bll_Miss.GetList("").Tables[0];
            DataTable dt_Student = bll_Student.GetList("").Tables[0];
            DataTable dt_Teacher = bll_Teacher.GetList("").Tables[0];
            DataTable dt_Diagnosis = bll_Diagnosis.GetList("").Tables[0];
            DataTable dt_Epidemic = bll_Epidemic.GetList("").Tables[0];
            DataTable dt_Symptom = bll_Symptom.GetList("").Tables[0];


            //用Linq语句实现对缺课表的模糊查询
            var result = from m in dt_Miss.AsEnumerable()
                         join st in dt_Student.AsEnumerable() on m.Field<string>("Student_Sno") equals st.Field<string>("Student_Sno")
                         join sy in dt_Symptom.AsEnumerable() on m.Field<string>("Symptom_Number") equals sy.Field<string>("Symptom_Number")
                         join d in dt_Diagnosis.AsEnumerable() on m.Field<string>("Diagnosis_Number") equals d.Field<string>("Diagnosis_Number")
                         join e in dt_Epidemic.AsEnumerable() on m.Field<string>("Epidemic_Number") equals e.Field<string>("Epidemic_Number")
                         join t in dt_Teacher.AsEnumerable() on m.Field<string>("Teacher_Tno") equals t.Field<string>("Teacher_Tno")
                         where st.Field<string>("Student_Name").Contains(strWhere) || t.Field<string>("Teacher_Name").Contains(strWhere)
                         select new
                         {
                             Miss_ID = m.Field<string>("Miss_ID"),
                             Student_Name = st.Field<string>("Student_Name"),
                             Miss_Fever = m.Field<string>("Miss_Fever"),
                             Symptom_Name = sy.Field<string>("Symptom_Name"),
                             Diagnosis_Name = d.Field<string>("Diagnosis_Name"),
                             Miss_MState = m.Field<string>("Miss_MState"),
                             Miss_MHospital = m.Field<string>("Miss_MHospital"),
                             Miss_Days = m.Field<dynamic>("Miss_Days"),
                             Miss_ClassHour = m.Field<dynamic>("Miss_ClassHour"),
                             Miss_Type = m.Field<string>("Miss_Type"),
                             Epidemic_Name = e.Field<string>("Epidemic_Name"),
                             Teacher_Name = t.Field<string>("Teacher_Name"),
                             Miss_RDateTime = m.Field<DateTime>("Miss_RDateTime")
                         };

            this.totalCount = result.AsQueryable().Count();//符合条件的用户总数
            //分页获取数据
            this.rptList.DataSource = result.AsQueryable().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("AbsencesStatistics.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每页数量=============================
        /// <summary>
        /// 每页的数据条数
        /// </summary>
        /// <param name="_default_size">值</param>
        /// <returns>返回值</returns>
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
        /// <summary>
        /// 关健字查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("AbsencesStatistics.aspx", "keywords={0}", txtKeywords.Text));//跳转页面，并携带keywords
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
            Response.Redirect(Utils.CombUrlTxt("AbsencesStatistics.aspx", "keywords={0}", this.keywords));
        }
        #endregion

        #region 批量删除=============================
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            Alert.AlertAndRedirect("删除成功！", Utils.CombUrlTxt("AbsencesStatistics.aspx", "keywords={0}", this.keywords));
        }

        //删除线路
        private bool Delete(long id)
        {
            DataSet ds_Miss = bll_Miss.GetList("Miss_ID = '" + id.ToString() + "'");
            try
            {
                if (!bll_Miss.Delete(id.ToString()))
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
        #endregion

    }
}
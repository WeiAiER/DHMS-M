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
    public partial class AbsencesStatisticsEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        DHMSClass.BLL.DHMS_Miss bll_Miss = new BLL.DHMS_Miss();
        DHMSClass.DAL.DHMS_Miss dal_Miss = new DAL.DHMS_Miss();
        DHMSClass.Model.DHMS_Miss model_Miss = new Model.DHMS_Miss();

        DHMSClass.BLL.DHMS_Student bll_Student = new BLL.DHMS_Student();
        DHMSClass.BLL.DHMS_Teacher bll_Teacher = new BLL.DHMS_Teacher();
        DHMSClass.BLL.DHMS_Diagnosis bll_Diagnosis = new BLL.DHMS_Diagnosis();
        DHMSClass.BLL.DHMS_Epidemic bll_Epidemic = new BLL.DHMS_Epidemic();
        DHMSClass.BLL.DHMS_Symptom bll_Symptom = new BLL.DHMS_Symptom();

        DealID deal_Miss = new DealID();//新增时id处理

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_ReportDate.Attributes.Add("onfocus", "WdatePicker({doubleCalendar:false,dateFmt:'yyyy-MM-dd',minDate:'2010-01-01',maxDate:'" + DateTime.Now.AddDays(730).ToString("yyyy-MM-dd") + "',lang:'zh-cn'})");

            string _action = MXRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "AbsencesStatistics.aspx");
                    return;
                }
                DataSet ds_Miss = bll_Miss.GetList("Miss_ID = '" + id.ToString() + "'");

                if (ds_Miss.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "AbsencesStatistics.aspx");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                Sym();
                Dia();
                Epi();

                if (action == "Edit") //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        /// <summary>
        /// 判断日期格式
        /// </summary>
        /// <param name="StrSource">传递的值</param>
        /// <returns>返回布尔值</returns>
        public bool IsDate(string StrSource)
        {
            return Regex.IsMatch(StrSource, "^(?<year>\\d{2,4})-(?<month>\\d{1,2})-(?<day>\\d{1,2})$");
        }

        /// <summary>
        /// 判断是否为正整数
        /// </summary>
        /// <param name="str">传递的值</param>
        /// <returns>返回布尔值</returns>
        public bool IsNumeric(string str)
        {
            Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str);
        }

        #region 赋值操作=================================
        /// <summary>
        /// 修改时赋值
        /// </summary>
        /// <param name="_id">AbsencesStatisticsEdit页面传递的id值</param>
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_Miss = bll_Miss.GetList("Miss_ID = '" + _id.ToString() + "'");
            DataSet ds_Student = bll_Student.GetList("Student_Sno = '" + ds_Miss.Tables[0].Rows[0]["Student_Sno"].ToString() + "'");
            DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Tno = '" + ds_Miss.Tables[0].Rows[0]["Teacher_Tno"].ToString() + "'");
            DataSet ds_Symptom = bll_Symptom.GetList("Symptom_Number = '" + ds_Miss.Tables[0].Rows[0]["Symptom_Number"].ToString() + "'");
            DataSet ds_Diagnosis = bll_Diagnosis.GetList("Diagnosis_Number = '" + ds_Miss.Tables[0].Rows[0]["Diagnosis_Number"].ToString() + "'");
            DataSet ds_Epidemic = bll_Epidemic.GetList("Epidemic_Number = '" + ds_Miss.Tables[0].Rows[0]["Epidemic_Number"].ToString() + "'");

            txt_SName.Text = ds_Student.Tables[0].Rows[0]["Student_Name"].ToString();
            txt_Fever.Text = ds_Miss.Tables[0].Rows[0]["Miss_Fever"].ToString();
            ddl_Sym.SelectedValue = ds_Symptom.Tables[0].Rows[0]["Symptom_Name"].ToString();
            ddl_Dia.SelectedValue = ds_Diagnosis.Tables[0].Rows[0]["Diagnosis_Name"].ToString();
            txt_MState.Text = ds_Miss.Tables[0].Rows[0]["Miss_MState"].ToString();
            txt_MHospital.Text = ds_Miss.Tables[0].Rows[0]["Miss_MHospital"].ToString();
            txt_MDays.Text = ds_Miss.Tables[0].Rows[0]["Miss_Days"].ToString();
            txt_MHourClass.Text = ds_Miss.Tables[0].Rows[0]["Miss_ClassHour"].ToString();
            txt_MType.Text = ds_Miss.Tables[0].Rows[0]["Miss_Type"].ToString();
            ddl_Epi.SelectedValue = ds_Epidemic.Tables[0].Rows[0]["Epidemic_Name"].ToString();
            txt_TName.Text = ds_Teacher.Tables[0].Rows[0]["Teacher_Name"].ToString();
            txt_ReportDate.Text = ds_Miss.Tables[0].Rows[0]["Miss_RDateTime"].ToString();
        }
        #endregion

        #region 下拉框绑定=================================
        public void Sym()
        {
            DataTable dt_Symptom = bll_Symptom.GetList("").Tables[0];
            ddl_Sym.DataSource = dt_Symptom;//设置数据源
            ddl_Sym.DataTextField = "Symptom_Name";//设置所要读取的数据表里的列名
            ddl_Sym.DataBind();//数据绑定
        }

        public void Dia()
        {
            DataTable dt_Diagnosis = bll_Diagnosis.GetList("").Tables[0];
            ddl_Dia.DataSource = dt_Diagnosis;//设置数据源
            ddl_Dia.DataTextField = "Diagnosis_Name";//设置所要读取的数据表里的列名
            ddl_Dia.DataBind();//数据绑定
        }

        public void Epi()
        {
            DataTable dt_Epidemic = bll_Epidemic.GetList("").Tables[0];
            ddl_Epi.DataSource = dt_Epidemic;//设置数据源
            ddl_Epi.DataTextField = "Epidemic_Name";//设置所要读取的数据表里的列名
            ddl_Epi.DataBind();//数据绑定
        }
        #endregion

        #region 增加操作=================================
        /// <summary>
        /// 新增缺课信息
        /// </summary>
        /// <returns>返回布尔值</returns>
        private bool DoAdd()
        {
            try
            {
                DataSet ds_Student = bll_Student.GetList("Student_Name = '" + txt_SName.Text + "'");
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_TName.Text + "'");
                DataSet ds_Symptom = bll_Symptom.GetList("Symptom_Name = '" + ddl_Sym.SelectedValue + "'");
                DataSet ds_Diagnosis = bll_Diagnosis.GetList("Diagnosis_Name = '" + ddl_Dia.SelectedValue + "'");
                DataSet ds_Epidemic = bll_Epidemic.GetList("Epidemic_Name = '" + ddl_Epi.SelectedValue + "'");

                if (Session["admin_id"] == null)//如果id不为空，进行赋值
                {
                    if (!IsDate(txt_ReportDate.Text))
                    {
                        Alert.AlertNo("请正确输入日期类型：yyyy-MM-dd", "AbsencesStatisticsEdit.aspx");
                        return false;
                    }
                    if (!IsNumeric(txt_MDays.Text) || !IsNumeric(txt_MHourClass.Text))
                    {
                        Alert.AlertNo("请输入正确的数值", "AbsencesStatisticsEdit.aspx");
                        return false;
                    }

                    model_Miss.Miss_ID= deal_Miss.Deal_ID();
                    model_Miss.Student_Sno = ds_Student.Tables[0].Rows[0]["Student_Sno"].ToString();
                    model_Miss.Miss_Fever = txt_Fever.Text;
                    model_Miss.Symptom_Number = ds_Symptom.Tables[0].Rows[0]["Symptom_Number"].ToString();
                    model_Miss.Diagnosis_Number = ds_Diagnosis.Tables[0].Rows[0]["Diagnosis_Number"].ToString();
                    model_Miss.Miss_MState = txt_MState.Text;
                    model_Miss.Miss_MHospital = txt_MHospital.Text;
                    model_Miss.Miss_Days = Convert.ToInt32(txt_MDays.Text);
                    model_Miss.Miss_ClassHour = Convert.ToInt32(txt_MHourClass.Text);
                    model_Miss.Miss_Type = txt_MType.Text;
                    model_Miss.Epidemic_Number = ds_Epidemic.Tables[0].Rows[0]["Epidemic_Number"].ToString();
                    model_Miss.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_Miss.Miss_RDateTime = Convert.ToDateTime(txt_ReportDate.Text);
                    bll_Miss.Add(model_Miss);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertNo("输入的学生或教师不存在，请重新输入！", "AbsencesStatisticsEdit.aspx");
                return false;
            }
            return true;
        }
        #endregion

        #region 修改操作=================================
        /// <summary>
        /// 修改缺课信息
        /// </summary>
        /// <param name="id">对应缺课的id</param>
        /// <returns>返回布尔值</returns>
        private bool DoEdit(long id)
        {
            try
            {
                DataSet ds_Student = bll_Student.GetList("Student_Name = '" + txt_SName.Text + "'");
                DataSet ds_Teacher = bll_Teacher.GetList("Teacher_Name = '" + txt_TName.Text + "'");
                DataSet ds_Symptom = bll_Symptom.GetList("Symptom_Name = '" + ddl_Sym.SelectedValue + "'");
                DataSet ds_Diagnosis = bll_Diagnosis.GetList("Diagnosis_Name = '" + ddl_Dia.SelectedValue + "'");
                DataSet ds_Epidemic = bll_Epidemic.GetList("Epidemic_Name = '" + ddl_Epi.SelectedValue + "'");

                if (Session["admin_id"] == null)
                {
                    if (!IsDate(txt_ReportDate.Text))
                    {
                        Alert.AlertAndRedirect("请正确输入日期类型：yyyy-MM-dd", "AbsencesStatistics.aspx");
                        return false;
                    }
                    if (!IsNumeric(txt_MDays.Text) || !IsNumeric(txt_MHourClass.Text))
                    {
                        Alert.AlertAndRedirect("请输入正确的数值", "AbsencesStatistics.aspx");
                        return false;
                    }

                    model_Miss.Miss_ID = id.ToString();
                    model_Miss.Student_Sno = ds_Student.Tables[0].Rows[0]["Student_Sno"].ToString();
                    model_Miss.Miss_Fever = txt_Fever.Text;
                    model_Miss.Symptom_Number = ds_Symptom.Tables[0].Rows[0]["Symptom_Number"].ToString();
                    model_Miss.Diagnosis_Number = ds_Diagnosis.Tables[0].Rows[0]["Diagnosis_Number"].ToString();
                    model_Miss.Miss_MState = txt_MState.Text;
                    model_Miss.Miss_MHospital = txt_MHospital.Text;
                    model_Miss.Miss_Days = Convert.ToInt32(txt_MDays.Text);
                    model_Miss.Miss_ClassHour = Convert.ToInt32(txt_MHourClass.Text);
                    model_Miss.Miss_Type = txt_MType.Text;
                    model_Miss.Epidemic_Number = ds_Epidemic.Tables[0].Rows[0]["Epidemic_Number"].ToString();
                    model_Miss.Teacher_Tno = ds_Teacher.Tables[0].Rows[0]["Teacher_Tno"].ToString();
                    model_Miss.Miss_RDateTime = Convert.ToDateTime(txt_ReportDate.Text);
                    dal_Miss.Update(model_Miss);
                }
                else
                {
                    Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                    return false;
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("输入的学生或教师不存在，请重新输入！", "AbsencesStatistics.aspx");
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 确认修改或新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_SName.Text == "" || txt_Fever.Text == "" || txt_MDays.Text == "" || txt_MHourClass.Text == "" || txt_MType.Text == "" || txt_TName.Text == "")
            {
                Alert.AlertNo("*为必填项！", "AbsencesStatisticsEdit.aspx");
                return;
            }

            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "AbsencesStatisticsEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新缺课成功！", "AbsencesStatistics.aspx");
            }
            if (action == "Add")
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "AbsencesStatisticsEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加缺课成功！", "AbsencesStatistics.aspx");
            }
        }

    }
}
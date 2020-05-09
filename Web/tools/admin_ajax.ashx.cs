using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace MxWeiXinPF.Web.tools
{
    /// <summary>
    /// admin_ajax 的摘要说明
    /// </summary>
    public class admin_ajax : IHttpHandler, IRequiresSessionState
    {


        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = HttpContext.Current.Request.QueryString["action"];

            switch (action)
            {
                case "get_navigation_list": //获取后台导航字符串
                    get_navigation_list(context);
                    break;
                
            }

        }

        #region 获取后台导航字符串==============================
        private void get_navigation_list(HttpContext context)
        {
            /***商品管理***/
            context.Response.Write("<div class=\"list-group\" name=\"个人信息\">\n");
            context.Response.Write("<h2>个人信息<i></i></h2>\n");
            context.Response.Write("<ul>\n");
            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"Role\" href=\"OldMan.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>养老人员信息</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"YeJi\" href=\"Doctor.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>医护人员信息</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("</ul>\n");
            context.Response.Write("</div>\n");

            /***优惠活动管理***/
            context.Response.Write("<div class=\"list-group\" name=\"健康监督\">\n");
            context.Response.Write("<h2>健康监督<i></i></h2>\n");
            context.Response.Write("<ul>\n");
            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"Role\" href=\"HealthSupervision.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>养老人员监督</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"YeJi\" href=\"HealthDetails.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>医护人员监督</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("</ul>\n");
            context.Response.Write("</div>\n");

            /***微信营销活动***/
            context.Response.Write("<div class=\"list-group\" name=\"电子病历\">\n");
            context.Response.Write("<h2>电子病历<i></i></h2>\n");
            context.Response.Write("<ul>\n");
            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"Role\" href=\"CaseHistory.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>养老人员</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"YeJi\" href=\"DcaseHistory.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>医护人员</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("</ul>\n");
            context.Response.Write("</div>\n");
            
            /***角色管理***/
            context.Response.Write("<div class=\"list-group\" name=\"预约就诊\">\n");
            context.Response.Write("<h2>角色管理<i></i></h2>\n");
            context.Response.Write("<ul>\n");
            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"Role\" href=\"RoleManage.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>角色管理</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"YeJi\" href=\"UserWeiXinYeJi.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>操作记录管理</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("</ul>\n");
            context.Response.Write("</div>\n");

            /***用户管理***/
            context.Response.Write("<div class=\"list-group\" name=\"系统管理\">\n");
            context.Response.Write("<h2>用户管理<i></i></h2>\n");
            context.Response.Write("<ul>\n");
            context.Response.Write("<li>\n");
            context.Response.Write("<a navid=\"User\" href=\"PersonnelManage.aspx\" target=\"mainframe\" class=\"item\">\n");
            context.Response.Write("<span>用户管理</span>\n");
            context.Response.Write("</a></li>\n");

            context.Response.Write("</ul>\n");
            context.Response.Write("</div>\n");

        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
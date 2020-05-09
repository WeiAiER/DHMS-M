<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleInformation.aspx.cs" Inherits="DHMSClass.Web.RoleInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="keywords" content=""/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="icon" href="assets/images/favicon.png" type="image/png"/>
    <title>日常健康管理系统</title>

    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="assets/plugins/datatables/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/datatables/css/jquery.dataTables-custom.css" rel="stylesheet" type="text/css"/>
    <!-- END PAGE LEVEL STYLES -->
    <link href="assets/css/icons.css" rel="stylesheet"/>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="assets/css/style.css" rel="stylesheet"/>
    <link href="assets/css/responsive.css" rel="stylesheet"/>

    <script src="js/print.min.js"></script>
    <link rel="stylesheet" type="text/css" href="js/print.min.css"/>

</head>
<<body class="sticky-header">
    <!--Start left side Menu-->
    <div class="left-side sticky-left-side">

        <!--logo-->
        <div class="logo">
            <h3 style="color: white">日常健康管理系统</h3>
        </div>

        <div class="logo-icon text-center">
            <a href="GoodsIndex.aspx">
                <img src="assets/images/logo-icon.png" alt="" /></a>
        </div>
        <!--logo-->

        <div class="left-side-inner">
            <!--Sidebar nav-->
            <ul class="nav nav-pills nav-stacked custom-nav">
                <li class="menu-list nav-active"><a href="#"><i class="icon-home"></i><span>管理总览</span></a>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="Student.aspx">学生管理</a></li>
                    </ul>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="Teacher.aspx">教工管理</a></li>
                    </ul>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="Department.aspx">系部管理</a></li>
                    </ul>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="Class.aspx">班级管理</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="nav nav-pills nav-stacked custom-nav">
                <li class="menu-list nav-active"><a href="#"><i class="icon-pie-chart"></i><span>晨午检总览</span></a>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="StuCheck.aspx">学生晨午检</a></li>
                    </ul>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="TeaCheck.aspx">教工晨午检</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="nav nav-pills nav-stacked custom-nav">
                <li class="menu-list nav-active"><a href="#"><i class="icon-film"></i><span>住宿生总览</span></a>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="BoarderInformation.aspx">住宿生信息</a></li>
                    </ul>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="BoarderManage.aspx">住宿生管理</a></li>
                    </ul>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="BoarderLeave.aspx">住宿生请假</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="nav nav-pills nav-stacked custom-nav">
                <li class="menu-list nav-active"><a href="#"><i class="icon-loop"></i><span>缺课管理</span></a>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="AbsencesStatistics.aspx">缺课统计</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="nav nav-pills nav-stacked custom-nav">
                <li class="menu-list nav-active"><a href="#"><i class="icon-layers"></i><span>疫情日报管理</span></a>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="EpidemicDaily.aspx">疫情日报查询</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="nav nav-pills nav-stacked custom-nav">
                <li class="menu-list nav-active"><a href="#"><i class="icon-grid"></i><span>物资管理</span></a>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="MaterialInformation.aspx">物资总览</a></li>
                    </ul>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="ReceiveInformation.aspx">物资领用</a></li>
                    </ul>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="PurchaseInformation.aspx">物资采购</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="nav nav-pills nav-stacked custom-nav">
                <li class="menu-list nav-active"><a href="#"><i class="icon-note"></i><span>角色管理</span></a>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="RoleInformation.aspx">角色总览</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="nav nav-pills nav-stacked custom-nav">
                <li class="menu-list nav-active"><a href="#"><i class="icon-lock"></i><span>权限管理</span></a>
                    <ul class="sub-menu-list">
                        <li class="active"><a href="PermissionsInformation.aspx">权限总览</a></li>
                    </ul>
                </li>
            </ul>
            <!--End sidebar nav-->
        </div>
    </div>
    <!--End left side menu-->


    <!-- main content start-->
    <div class="main-content">

        <!-- header section start-->
        <div class="header-section">

            <a class="toggle-btn"><i class="fa fa-bars"></i></a>

            <!--notification menu start -->
            <div class="menu-right">
                <ul class="notification-menu">
                    <li>
                        <a href="#" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            <img src="assets/images/users/avatar-6.jpg" alt="" />
                            <asp:Label ID="lab_UserName" runat="server" class="page-title" Text="用户名"></asp:Label>
                            <span class="caret"></span>
                        </a>
                        <ul class="dropdown-menu dropdown-menu-usermenu pull-right">
                            <li><a href="Login.aspx"><i class="fa fa-lock"></i>退出 </a></li>
                        </ul>
                    </li>

                </ul>
            </div>
            <!--notification menu end -->

        </div>
        <!-- header section end-->



        <!--body wrapper start-->
        <div class="wrapper">

            <!--Start Page Title-->
            <div class="page-title-box">
                <h4 class="page-title">角色信息</h4>
                <div class="clearfix"></div>
            </div>
            <!--End Page Title-->
            <!--Start row-->
            <div class="row">
                <div class="col-md-12">
                    <div class="white-box">
                        <div class="table-responsive">
                            <form id="form1" runat="server">
                                <main class="app-layout-content">
                    <!-- Page Content -->
                    <div class="container-fluid p-y-md">
                        <div class="card">
                            <div class="card-block">
            <div class="toolbar-wrap">
                <div id="floatHead" class="toolbar" runat="server">
                    <div class="l-list">
                        <div style="width:100px;float:left;margin-right:20px">
                                    <a href="RoleInformationEdit.aspx?action=Add"><button style="margin:auto" class="btn btn-inverse" data-toggle="modal" data-target="#modal-top" type="button">新增</button></a>
                                </div> 
                        <div style="width:100px;float:left">
                                    <asp:LinkButton ID="btnDelete" runat="server" class="btn btn-inverse" OnClientClick="return ExePostBack('btnDelete');" 
                                    OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton>
                                </div> 
                </div>
                    <div class="r-list" style="float:right">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-inverse" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
            <!--/工具栏-->
            <!--列表-->
                                <div class="row"><div id="print" class="col-sm-12">
            <asp:Repeater id="rptList" runat="server">
                <HeaderTemplate>
                    <table class="display table" id="DataTables_Table_1" role="grid" aria-describedby="DataTables_Table_1_info">
                        <tr>
                            <th style="text-align:center">选择</th>
                            <th style="text-align:center">角色名称</th>
                            <th style="text-align:center">角色简介</th>
                            <th style="text-align:center">修改操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("Role_ID")%>' runat="server" />
                        </td>
                        <td align="center"><%#Eval("Role_Name")%></td>
                        <td align="center"><%#Eval("Role_Introduction")%></td>
                        <td class="text-center">
                            <div>
                                <a href="RoleInformationEdit.aspx?action=Edit&id=<%#Eval("Role_ID")%>">&nbsp;修改&nbsp;</a>
                            </div> 
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</main>
                                <!--/列表-->
                                <!--内容底部-->
                                <div class="line20"></div>
                                <div class="pagelist">
                                    <div class="l-btns" style="float: right; margin-right: 20px">
                                        <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                                            OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
                                    </div>
                                    <div id="PageContent" runat="server" class="default"></div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!--End row-->
        </div>
        <!-- End Wrapper-->
    </div>
    <!--End main content -->

    <!--Begin core plugin -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/plugins/moment/moment.js"></script>
    <script src="assets/js/jquery.slimscroll.js "></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/functions.js"></script>
    <!-- End core plugin -->

    <!--Begin Page Level Plugin-->
    <!--<script src="assets/plugins/datatables/js/jquery.dataTables.min.js"></script>-->
    <script src="assets/pages/table-data.js"></script>
    <!--End Page Level Plugin-->

    <script language="javascript" src="js/jquery-1.4.4.min.js"></script>
    <script language="javascript" src="js/jquery.jqprint-0.3.js"></script>

    <script language="javascript">
        function a() {
            $("#print").jqprint();
        }
    </script>

</body>
</html>

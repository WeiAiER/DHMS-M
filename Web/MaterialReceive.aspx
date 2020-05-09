﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialReceive.aspx.cs" Inherits="DHMSClass.Web.MaterialReceive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords" content="">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="assets/images/favicon.png" type="image/png">
    <title>日常健康管理系统</title>
    <link href="assets/css/icons.css" rel="stylesheet">
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/responsive.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
          <script src="js/html5shiv.min.js"></script>
          <script src="js/respond.min.js"></script>
    <![endif]-->

</head>
<body class="sticky-header">
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

            <form class="searchform">
                <input type="text" class="form-control" name="keyword" placeholder="Search here..." />
            </form>

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
            </div>
            <!--End Page Title-->
            <!--Start row-->
            <div class="row">
                <div class="col-md-12">
                    <div class="white-box">
                        <h2 class="header-title">物资领用详情</h2>

                        <form id="Form1" class="form-horizontal" runat="server">
                            <div class="form-group">
                                <label class="col-md-2 control-label" for="example-email">物资名称 *</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txt_MName" runat="server" class="form-control" placeholder="物资名称"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label" for="example-email">物资规格</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txt_MSpecs" runat="server" class="form-control" placeholder="物资规格"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label" for="example-email">领用数量 *</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txt_RNumber" runat="server" class="form-control" placeholder="领用数量"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label" for="example-email">领用人 *</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txt_UName" runat="server" class="form-control" placeholder="领用人"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group m-b-0">
                                <div class="col-sm-offset-3 col-sm-9">
                                    <asp:Button ID="btn_Confirm" runat="server" Text="确定" class="btn btn-primary" OnClick="btn_Confirm_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <!--End row-->

        </div>
        <!-- End Wrapper-->


        <!--Start  Footer -->
        <footer class="footer-main">Copyright &copy; 2018.Company name All rights reserved.<a target="_blank" href="http://sc.chinaz.com/moban/">&#x7F51;&#x9875;&#x6A21;&#x677F;</a></footer>
        <!--End footer -->

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

</body>
</html>
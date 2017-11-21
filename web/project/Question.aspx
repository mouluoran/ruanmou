<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="project.Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="include/headercon.html"-->
    <link href="css/Question.css" rel="stylesheet" />
    <script src="js/Question.js"></script>
</head>
<body>
    <form id="form1" class="layui-form">
        <!--#include file="include/header.html"-->
        <!--#include file="include/nav.html"-->
        <div id="quemian">
            <div id="qsort">
                <div class="layui-tab" style="margin-top: 0px; width: 600px; float: left;">
                    <ul class="layui-tab-title" id="tcat">
                        <li class="layui-this" data-c="0">全部问题</li>
                        <li data-c="1">前端开发</li>
                        <li data-c="2">ASP.NET</li>
                        <li data-c="3">JAVA</li>
                    </ul>
                </div>
                <div id="qsort-see">
                    <ul>
                        <li class="qsort-ask"><a href="javascript:;" class="qsort-sel">提问</a></li>
                        <li class="qsort-line">/</li>
                        <li id="qsort-noreply"><a href="javascript:;" class="qsort-item">待回复</a></li>
                        <li class="qsort-line">/</li>
                        <li id="qsort-reply"><a href="javascript:;" class="qsort-item">已回复</a></li>
                        <li class="qsort-line">/</li>
                        <li id="qsort-over"><a href="javascript:;" class="qsort-item">已结贴</a></li>
                        <li class="qsort-line">/</li>
                        <li id="qsort-all"><a href="javascript:;" class="qsort-sel qsort-item">默认</a></li>
                    </ul>
                </div>
            </div>
            <div id="dquecon-left">
                <div id="asklist">
                </div>
                <div id="pager"></div>
            </div>
            <div id="dquecon-right">
                <h3 class="page-title">答疑团队</h3>
                <div id="soreuserlist">
                    <%=GetTeacherTeam() %>
                </div>
                <h3 class="page-title">最近热帖 - TOP 10</h3>
                <div id="viewtop">
                    <%=GetAskViewTop() %>
                </div>
                <h3 class="page-title">最近热评 - TOP 10</h3>
                <div id="recount">
                    <%=GetAskReplyTop() %>
                </div>
            </div>
            <div style="clear: both;"></div>

        </div>
        <!--#include file="include/footer.html"-->
    </form>
</body>
</html>

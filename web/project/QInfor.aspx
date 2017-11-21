<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QInfor.aspx.cs" Inherits="project.QInfor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="include/headercon.html"-->
    <link href="css/QInfor.css" rel="stylesheet" />
    <link href="highlight/styles/default.css" rel="stylesheet" />
    <link href="css/icon.css" rel="stylesheet" />
    <script src="highlight/highlight.pack.js"></script>
    <script src="ckeditor/ckeditor.js"></script>
    <script src="js/QInfor.js"></script>
    <script>hljs.initHighlightingOnLoad();</script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <!--#include file="include/header.html"-->
        <!--#include file="include/nav.html"-->
        <div id="quemian">
            <div id="dquecon-left">
                <div id="daskcon">
                    <%=GetAskCon() %>
                </div>
                <div id="dcomentlist">
                </div>


                <div id="dpostask">
                    <div class="layui-form-item">
                        <div class="layui-input-block" style="margin-left: 0px; width: 600px; margin-top: 20px;">
                            <textarea id="txtBody1"></textarea>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <div class="layui-input-block" style="margin-left: 0px; width: 600px; margin-top: 20px;">
                            <button class="layui-btn layui-btn-big" id="btnRCom">回复帖子</button>
                        </div>
                    </div>
                </div>
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
        <input type="hidden" id="hidQId" runat="server" />

    </form>
    <!--#include file="include/footer.html"-->
</body>
</html>

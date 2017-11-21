<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCom.aspx.cs" Inherits="project.MyCom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--#include file="../include/headercon.html"-->
    <link href="../css/MyIndex.css" rel="stylesheet" />
    <link href="../css/MyAsk.css" rel="stylesheet" />
    <script src="../js/MyCom.js"></script>
</head>
<body>
    <form id="form1" class="layui-form">
        <!--#include file="../include/header.html"-->
        <!--#include file="../include/nav.html"-->
        <div id="mymain">
            <!--#include file="../include/myleft.html"-->
            <div id="myright">
                <div class="ucenter-right-head">
                    <h3>我的评论</h3>
                </div>
                <div class="inforbox">
                    <ul id="ucomlist">
                     
                    </ul>
                    <div id="pager"></div>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </form>
    <!--#include file="../include/footer.html"-->
</body>
</html>

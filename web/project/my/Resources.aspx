<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" Inherits="project.Resources" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="../include/headercon.html"-->
    <link href="../css/MyIndex.css" rel="stylesheet" />
    <link href="../css/MyAsk.css" rel="stylesheet" />
    <script src="../js/Resources.js"></script>
</head>
<body>
    <form id="form1">
        <!--#include file="../include/header.html"-->
        <!--#include file="../include/nav.html"-->
        <div id="mymain">
            <!--#include file="../include/myleft.html"-->
            <div id="myright">
                <div class="ucenter-right-head">
                    <h3>我的资源</h3>
                </div>
                <div class="inforbox">
                    <ul id="urslist">
                       
                    </ul>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </form>
    <!--#include file="../include/footer.html"-->
</body>
</html>

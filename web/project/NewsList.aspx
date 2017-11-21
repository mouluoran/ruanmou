<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="project.NewsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!--#include file="include/headercon.html"-->
    <link href="css/NewsList.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="include/header.html"-->
        <!--#include file="include/nav.html"-->
        <div id="newsmain">
            <div class="crumbs"><a href="Default.aspx">首页</a> > 新闻动态</div>
            <div id="newslist">
                <%=GetNewsList() %>
            </div>
            <%=GetPagerHtml() %>
        </div>
        <!--#include file="include/footer.html"-->
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsPage.aspx.cs" Inherits="project.NewsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!--#include file="include/headercon.html"-->
    <link href="css/NewsPage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="include/header.html"-->
        <!--#include file="include/nav.html"-->
        <div id="newsmain">
            <div class="crumbs"><a href="Default.aspx">首页</a> > <%=GetTitle() %></div>
            <div class="newsbody">
               <%=GetNews() %>
            </div>
        </div>
        <!--#include file="include/footer.html"-->
    </form>
</body>
</html>

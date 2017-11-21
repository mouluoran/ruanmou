<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RsInfor.aspx.cs" Inherits="project.RsInfor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <!--#include file="../include/headercon.html"-->
    <link href="../css/RsInfor.css" rel="stylesheet" />
</head>
<body>
   <form id="form1">
        <!--#include file="../include/header.html"-->
        <!--#include file="../include/nav.html"-->
        <div id="mymain">
            <!--#include file="../include/myleft.html"-->
            <div id="myright">
                <div class="ucenter-right-head">
                    <h3>资源详情</h3>
                </div>
                <div class="inforbox">
                      <div id="rsinfor">
                          <%=GetRsInfor() %>
                      </div>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </form>
    <!--#include file="../include/footer.html"-->
</body>
</html>

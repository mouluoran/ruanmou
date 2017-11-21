<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SRecords.aspx.cs" Inherits="project.SRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <!--#include file="/include/headercon.html"-->
    <link href="../css/MyIndex.css" rel="stylesheet" />
    <script src="../js/StuLeave.js"></script>
</head>
<body>
    <!--#include file="../include/header.html"-->
    <!--#include file="../include/nav.html"-->
    <div id="mymain">
        <!--#include file="../include/myleft.html"-->
        <div id="myright">
            <div class="ucenter-right-head">
                <h3>上课记录<span style="color: #cccccc;">（本期课程你累计已旷课<%=GetSignCount() %>次，<a style="color: red;" data-toggle="tooltip" data-placement="top" title="旷课累计达3次老师将电话和你沟通，累计达6次将移到下一期学习">说明</a>）</span></h3>
            </div>
            <div class="inforbox" style="color:#cccccc;">
                <%=GetSignStr() %>
            </div>

        </div>
         <div style="clear:both;"></div>
    </div>
      <!--#include file="/include/footer.html"-->
</body>

</html>

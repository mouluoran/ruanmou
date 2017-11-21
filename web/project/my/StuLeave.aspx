<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuLeave.aspx.cs" Inherits="project.StuLeave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <!--#include file="/include/headercon.html"-->
    <link href="../css/MyIndex.css" rel="stylesheet" />
 
    <script src="../js/StuLeave.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="../include/header.html"-->
        <!--#include file="../include/nav.html"-->
        <div id="mymain">
            <!--#include file="../include/myleft.html"-->
            <div id="myright">
                <div class="ucenter-right-head">
                    <h3>学生请假<span style="color: #cccccc;">（学生只能在上课当天请假，请假后不计旷课）</span></h3>
                </div>
                <div class="inforbox">
                    <div class="item-sign">
                        <input type="button" value="请假" class="layui-btn" id="btnLeave" />
                    </div>
                </div>
                <div class="ucenter-right-head">
                    <h3>请假记录<span style="color: #cccccc;">（本期课程你累计已请假<%=GetLeaveCount() %>次，<a style="color: red;" data-toggle="tooltip" data-placement="top" title="请假累计达5次老师将电话和你沟通，累计达15次将移到下一期学习">说明</a>）</span></h3>
                </div>
                <div class="inforbox" style="color:#cccccc;">
                    <%=GetLeaveStr() %>
                </div>
            </div>
             <div style="clear:both;"></div>
        </div>
    </form>
     <!--#include file="/include/footer.html"-->
</body>
</html>

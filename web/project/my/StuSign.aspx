<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuSign.aspx.cs" Inherits="project.StuSign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="/include/headercon.html"-->

    <link href="../css/MyIndex.css" rel="stylesheet" />
   
    <script src="../js/StuSign.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="../include/header.html"-->
        <!--#include file="../include/nav.html"-->
        <div id="mymain">
            <!--#include file="../include/myleft.html"-->
            <div id="myright">
                <div class="ucenter-right-head">
                    <h3>上课签到<span style="color:#cccccc;">（上课当天未签到或未请假记为旷课）</span></h3>
                </div>
                <div class="inforbox">
                    <div class="item-sign">
                        <input type="button" value="签到" class="layui-btn" id="btnSign"/>
                    </div>
                </div>
            </div>
             <div style="clear:both;"></div>
        </div>

    </form>
     <!--#include file="/include/footer.html"-->
</body>
</html>

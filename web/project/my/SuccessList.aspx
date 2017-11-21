<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuccessList.aspx.cs" Inherits="project.SuccessList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="../include/headercon.html"-->
    <link href="../css/MyIndex.css" rel="stylesheet" />
    <script src="../layui-new/layui.js"></script>
    <script src="../js/Audition.js"></script>
     <style>
        .layui-table td,.layui-table th {
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1">
        <!--#include file="../include/header.html"-->
        <!--#include file="../include/nav.html"-->
        <div id="mymain">
            <!--#include file="../include/myleft.html"-->
            <div id="myright">
                <div class="ucenter-right-head">
                    <h3>转化统计</h3>
                </div>
                <div class="inforbox">

                    <table class="layui-table" lay-data="{limit:10,page:true,height:413,width:758, url:'/ajax/AuditionAjax.ashx?type=2'}">
                        <thead>
                            <tr>
                                <th lay-data="{field:'TargetQQ', width:180,align:'center'}">目标QQ</th>
                                <th lay-data="{field:'ConverDate', width:160,sort: true,align:'center'}">转化时间</th>
                                 <th lay-data="{field:'CourseType', width:120,align:'center'}">课程类型</th>
                                <th lay-data="{field:'TranModel', width:380,align:'center'}">成功方式</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </form>
    <!--#include file="../include/footer.html"-->

</body>
</html>

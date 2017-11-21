<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskInsert.aspx.cs" Inherits="project.TaskInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="../include/headercon.html"-->
    <link href="../css/MyIndex.css" rel="stylesheet" />
    <script src="../layui-new/layui.js"></script>
    <script src="../js/TaskInsert.js"></script>
    <style>
        .ucenter-right-head {
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" class="layui-form">
        <!--#include file="../include/header.html"-->
        <!--#include file="../include/nav.html"-->
        <div id="mymain">
            <!--#include file="../include/myleft.html"-->
            <div id="myright">
                <div class="ucenter-right-head">
                    <h3>任务录入</h3>
                </div>
                <div class="inforbox">
                    <div class="form-item">
                        <div class="item-label">
                            <label>录入时间：</label>
                        </div>
                        <div class="item-cont">
                            <input type="text" class="txt sm" id="test1" placeholder="yyyy-MM-dd" />
                        </div>
                    </div>
                         <div class="form-item">
                        <div class="item-label">
                            <label>课程类型：</label>
                        </div>
                        <div class="item-cont">
                              <div class="layui-input-inline">
                        <select id="selPhase">
                            <option selected="selected" value="请选课程类型">请选课程类型</option>
                            <option value="Web前端">Web前端</option>
                             <option value=".NET">.NET</option>
                            <option value="JAVA">JAVA</option>
                        </select>
                    </div>
                        </div>
                    </div>
                    <div class="form-item">
                        <div class="item-label">
                            <label>录入QQ：</label>
                        </div>
                        <div class="item-cont">
                             <input type="text" class="txt sm" id="txtQQs" placeholder="请输入QQ号，一次只能输入一个" />
                        </div>
                    </div>
                    <div class="form-item">
                        <div class="item-cont">
                            <input type="button" value="录入任务" class="layui-btn" id="btninsert"  onclick="insertTask()"/>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>
    </form>
    <!--#include file="../include/footer.html"-->

</body>
</html>

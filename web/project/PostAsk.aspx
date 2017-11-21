<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostAsk.aspx.cs" Inherits="project.PostAsk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="include/headercon.html"-->
    <link href="css/Question.css" rel="stylesheet" />
    <script src="ckeditor/ckeditor.js"></script>
    <script src="js/PostAsk.js"></script>
</head>
<body>
    <form id="form1" class="layui-form">
        <div id="dpostask">
            <div class="layui-form-item">
                <div class="layui-input-block" style="margin-left: 50px; width: 600px; margin-top: 20px;">
                    <input type="text" id="txtTitle" placeholder="请输入标题" class="layui-input" />
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-input-block" style="margin-left: 50px; width: 600px; margin-top: 20px;">
                    <select id="selCategory">
                        <option selected="selected" value="0">请选问题分类</option>
                        <option value="1">前端开发</option>
                        <option value="2">ASP.NET</option>
                        <option value="3">JAVA</option>
                        <option value="4">小程序</option>
                    </select>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-input-block" style="margin-left: 50px; width: 600px; margin-top: 20px;">
                    <textarea id="txtBody1"></textarea>
                </div>
            </div>
            <div class="layui-form-item">
                <div class="layui-input-block" style="margin-left: 50px; width: 600px; margin-top: 20px;">
                    <button class="layui-btn layui-btn-big" id="btnPostAsk">发表帖子</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

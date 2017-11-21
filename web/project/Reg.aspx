<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="project.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="include/headercon.html"-->
    <link href="css/Reg.css" rel="stylesheet" />
    <script src="js/Reg.js"></script>

</head>
<body>
    <form id="form1" class="layui-form">
        <!--#include file="include/header.html"-->
        <!--#include file="include/nav.html"-->
        <div id="regmain">
            <div id="regleft">
                <div>
                    <img src="image/login-pic.png" />
                </div>
                <div class="begininfor">
                    注册软谋教育帐号<p class="l_f">简单几步，即可开启您的软谋教育学习之旅！</p>
                </div>
            </div>
            <div id="regright">
                <div class="regitem1">
                    <div id="stratinfor">开启您的软谋之旅-注册</div>
                    <div id="reglogin"><a href="javascript:;" onclick="ShowLoginBox()">登陆</a></div>
                </div>

                <div class="layui-form-item">
                    <label class="layui-form-label"><i class="layui-icon">&#xe63b;</i> </label>
                    <div class="layui-input-block">
                        <input type="text" id="txtTel" placeholder="请输入手机号" class="layui-input" />
                    </div>
                </div>
                <div class="layui-form-item">
                    <label class="layui-form-label"><i class="layui-icon">&#xe642;</i> </label>
                    <div class="layui-input-block">
                        <input type="password" id="txtPwd1" placeholder="请输入密码，数字、字母组成，6~12位" class="layui-input" />
                    </div>
                </div>
                <div class="layui-form-item">
                    <label class="layui-form-label"><i class="layui-icon">&#xe611;</i> </label>
                    <div class="layui-input-block">
                        <input type="text" id="txtQQ" placeholder="请输入QQ号" class="layui-input" />
                    </div>
                </div>

                <div class="layui-form-item">
                    <label class="layui-form-label"><i class="layui-icon">&#xe62a;</i> </label>
                    <div class="layui-input-inline">
                        <select id="selPhase">
                            <option selected="selected" value="请选报名班级">请选报名班级</option>
                            <option value="Web全栈开发24期">Web全栈开发24期</option>
                             <option value="Web前端高级01期">Web前端高级01期</option>
                            <option value=".NET高级班10期">.NET高级班10期</option>
                            <option value=".NET实战班01期">.NET实战班01期</option>
                            <option value="JAVA01期">JAVA01期</option>
                        </select>
                    </div>
                </div>
                <div class="layui-form-item">
                    <label class="layui-form-label"><i class="layui-icon">&#xe643;</i> </label>
                    <div class="layui-inline">
                        <input type="text" id="txtCheckCode" placeholder="请输入验证码" class="layui-input" style="width: 120px;" />
                    </div>
                    <div class="layui-inline">
                        <img src="/mg/image.aspx" id="imgcheckcode" onclick="RefreshCkc()" />
                    </div>
                </div>
                <div class="layui-form-item">
                    <div class="layui-input-block">
                        <button class="layui-btn layui-btn-big" id="btnReg">马上注册</button>
                    </div>
                </div>
            </div>
        </div>
        <!--#include file="include/footer.html"-->
    </form>

</body>
</html>

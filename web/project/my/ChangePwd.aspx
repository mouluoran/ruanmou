<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="project.ChangePwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <!--#include file="../include/headercon.html"-->
    <link href="../css/MyIndex.css" rel="stylesheet" />
    <script src="../js/ChangePwd.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="../include/header.html"-->
        <!--#include file="../include/nav.html"-->
        <div id="mymain">
            <!--#include file="../include/myleft.html"-->
            <div id="myright">
                <div class="ucenter-right-head">
                    <h3>信息管理</h3>
                </div>
                <div class="inforbox">
                 
                    <div class="form-item">
                        <div class="item-label">
                            <label>新密码：</label>
                        </div>
                        <div class="item-cont">
                            <input type="password" class="txt sm" value="" maxlength="100" id="txtpwd" />
                        </div>
                    </div>
                       <div class="form-item">
                        <div class="item-cont">
                            <input type="button" value="保存密码"  class="layui-btn" id="btnsavepwd" />
                        </div>
                    </div>
                 
                </div>
            </div>
               <div style="clear:both;"></div>
        </div>

        <!--#include file="../include/footer.html"-->
    </form>
</body>
</html>

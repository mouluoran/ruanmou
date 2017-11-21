<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyIndex.aspx.cs" Inherits="project.MyIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#include file="../include/headercon.html"-->
    <link href="../css/MyIndex.css" rel="stylesheet" />
    <script src="../js/MyIndex.js"></script>
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
                            <label>头像：</label>
                        </div>
                        <div class="item-cont">
                            <img src="" id="imgheadpic" />
                        </div>
                    </div>
                    <div class="form-item">
                        <div class="item-label">
                            <label>昵称：</label>
                        </div>
                        <div class="item-cont">
                               <input type="text" class="txt sm" value="" maxlength="100" id="usernickname" />
                        </div>
                    </div>
                    <div class="form-item">
                        <div class="item-label">
                            <label>真实姓名：</label>
                        </div>
                        <div class="item-cont">
                            <input type="text" class="txt sm" value="" maxlength="100" id="truename" />
                        </div>
                    </div>
                    <div class="form-item">
                        <div class="item-label">
                            <label>用户性别：</label>
                        </div>
                        <div class="item-cont">
                            <select name="sex" id="uesrsex" class="select w-xs">
                                <option value="男">纯爷们</option>
                                <option value="女">萌妹子</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-item">
                        <div class="item-label">
                            <label>手机号：</label>
                        </div>
                        <div class="item-cont">
                            <input type="text" class="txt sm" value="" maxlength="100" id="userphone" />
                        </div>
                    </div>
                    <div class="form-item">
                        <div class="item-label">
                            <label>QQ：</label>
                        </div>
                        <div class="item-cont">
                            <input type="text" class="txt sm" value="" maxlength="100" id="userqq" />
                        </div>
                    </div>
                    <div class="form-item">
                        <div class="item-cont">
                            <input type="button" value="保存资料" class="layui-btn" id="btnsave" />
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>

        <!--#include file="../include/footer.html"-->

    </form>
</body>
</html>

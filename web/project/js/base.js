/// <reference path="jquery-1.10.2.min.js" />





//回到顶部

function goTop() {
    $('html,body').animate({ 'scrollTop': 0 }, 400);
}

$(function () {
    /*回到顶部*/
    $("#rightask ul li").hover(function () {
        $(this).find(".sidebox").stop().animate({ "width": "124px" }, 200).css({ "opacity": "1", "filter": "Alpha(opacity=100)", "background": "#009688" })
    }, function () {
        $(this).find(".sidebox").stop().animate({ "width": "54px" }, 200).css({ "opacity": "0.8", "filter": "Alpha(opacity=80)", "background": "#000" })
    });

    /*验证是否已登陆*/
    $.post("/ajax/HeaderAjax.ashx", { "cmd": "checkislogin" }, function (data) {
        var data = eval('(' + data + ')');
        if (data.Success) {
            $("#headerright2").show();
            $("#headerright1").hide();
        }
        else {
            $("#headerright1").show();
            $("#headerright2").hide();
        }
    });
});

/*退出*/
function Exit() {
    $.cookie('CLoginUser', null);
    $.cookie('CLoginUser', null, { path: '/' });
    location.reload();
}

function ShowLoginBox() {
    $("#txtUserName").val("");
    $("#txtPwd").val("");
    layer.open({
        type: 1,
        title: false,
        area: ['360px', '295px'],
        content: $("#loginbox")
    });
};


var regphone = /^0?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/;//验证手机号
var regqq = /^\d{5,11}$/;//验证qq号
var reg = /^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,12}$/ //验证密码，由数字和字母组成长度为6~12
var username1 = "";
var pwd1 = "";
var sResult = "";
var umtype = "";
function CheckUserName1() {
    username1 = $.trim($("#txtUserName").val());
    if (username1 == "") {
        sResult = "用户名不能为空";
        return
    }
    if (regphone.test(username1)) {
        sResult = "";
        umtype = "tel";
        return;
    }
    if (regqq.test(username1)) {
        sResult = "";
        umtype = "qq";
        return;
    }
    else {
        sResult = "不是有效的QQ或手机号";
    }
}
function CheckPwd1() {
    pwd1 = $.trim($("#txtPwd").val());
    if (pwd1 == "") {
        sResult = "密码不能为空";
        return;
    }
    if (pwd1.length < 6 || pwd1.length > 12) {
        sResult = "密码为6~12个长度";
        return;
    }
    if (!reg.test(pwd1)) {
        sResult = "密码格式不正确";
    }
}
function Login() {
    sResult = "";
    CheckUserName1();
    CheckPwd1();
    if (sResult != "") {
        layer.msg(sResult, { icon: 5, time: 1000 });
        return;
    }
    else {
        $.post("../ajax/HeaderAjax.ashx", { "username": username1, "pwd": pwd1, "cmd": "userlogin", "umtype": umtype }, function (data) {
            var data = eval('(' + data + ')');
            if (data.Success == true) {
                location.reload();
            }
            else {
                layer.msg(data.Info, { icon: 5, time: 1000 });
            }
        });
    }
}

//分页
$(function () {
    $("#mypager a").click(function () {
        var strUrl = window.location.href.substring(0, window.location.href.indexOf("?"));//获取到浏览器的地址栏?前面的内容
        var page = parseInt($(this).attr("title"));
        if ($("#hidcate").val() == "0" || isNaN($("#hidcate").val())) {
            window.location.href = strUrl + "?page=" + page;
        }
        else {
            window.location.href = strUrl + "?cate=" + parseInt($("#hidcate").val()) + "&page=" + page;
        }
    });
});

/*my里面的公共js*/
$(function () {
    $(".nav_item").hover(function () {
        $(this).addClass("mynavitembg");
    }, function () {
        $(this).removeClass("mynavitembg");
    });
});

$(function () {
    $("#weixin").hover(function () {
        $("#weixinbox").append("<img src='../image/weixin.jpg'/>");
        var o = $(this).offset();
        $("#weixinbox").css("position", "absolute").css({ "left": o.left - 28, "top": o.top - 100 });
    }, function () {
        $("#weixinbox").empty();
    });
});
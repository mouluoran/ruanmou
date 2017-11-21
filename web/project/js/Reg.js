
/// <reference path="jquery-1.10.2.min.js" />


/*验证用户名*/
var reg = /^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,12}$/ //验证密码，由数字和字母组成长度为6~12
var regphone = /^0?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/;//验证手机号
var regqq = /^\d{5,11}$/;//验证qq号
var checkcode;
var pwd;
var phonenum;
var phase;
var inputcode;
var qq;
var sResult = "";
//验证验证码
function CheckCheckCode() {
    checkcode = $.trim($("#txtCheckCode").val().toUpperCase());
    if (checkcode == "") {
        sResult = "验证码不能为空";
        return;
    }
}
/*验证密码*/
function CheckPwd() {
    pwd = $.trim($("#txtPwd1").val());
    if (pwd == "") {
        sResult = "密码不能为空";
        return;
    }
    if (!reg.test(pwd)) {
        sResult = "密码由数字和字母组成，且长度为6~12";
        return;
    }
}
/*验证手机号*/
function CheckPhone() {
    phonenum = $.trim($("#txtTel").val());
    qq = $.trim($("#txtQQ").val());
    if (phonenum == "") {
        sResult = "手机号不能为空";
        return;
    }
    if (!regphone.test(phonenum)) {
        sResult = "手机号格式不正确";
        return;
    }
    $.ajax({
        url: "../ajax/RegAjax.ashx?cmd=checkphoneqq",
        data: { "phonenum": phonenum, "qq": qq },
        type: "POST",
        async: false,//同步请求
        success: function (data) {
            var data = eval('(' + data + ')');
            if (!data.Success) {
                sResult = "该手机号或QQ号已注册";
            }
        }
    });
}
/*验证qq号*/
function CheckQQ() {
    qq = $.trim($("#txtQQ").val());
    if (qq == "") {
        sResult = "QQ号不能为空";
        return;
    }
    if (!regqq.test(qq)) {
        sResult = "QQ号格式不正确";
        return;
    }
}
/*验证预报班级*/
function CheckSelPhase() {
    phase = $("#selPhase").children("option:selected").val();
    if (phase == "请选报名班级") {
        sResult = "请选报名班级";
        return;
    }
}
$(function () {
    layui.use(['layer', 'form'], function () { });
    $("#btnReg").click(function (e) {
        e.preventDefault();
        sResult = "";
        CheckCheckCode();
        CheckSelPhase();
        CheckQQ();
        CheckPwd();
        CheckPhone();
        if (sResult != "") {
            layer.msg(sResult, { icon: 5, time: 1000 });
        }
        else {
            $.post("../ajax/RegAjax.ashx?cmd=reguser", { "pwd": pwd, "phonenum": phonenum, "qq": qq, "phase": phase, "checkcode": checkcode }, function (data) {
                var data = eval('(' + data + ')');
                if (data.Success == true) {
                    layer.msg(data.Info, {
                        icon: 6,
                        time: 1000
                    }, function () { window.location.href = "Default.aspx"; });
                }
                else {
                    if (data.Info == "验证码输入不正确") {
                        layer.msg("验证码输入不正确", { "icon": 5, time: 1000 });
                    }
                    else {
                        layer.msg(data.Info, { "icon": 5, time: 1000 });
                    }
                }
            });
        }
    });
});
function RefreshCkc() {
    var timenow = new Date().getTime();
    var ccImg = document.getElementById("imgcheckcode");
    if (ccImg) {
        ccImg.src = "/mg/image.aspx?" + timenow;
    }
}
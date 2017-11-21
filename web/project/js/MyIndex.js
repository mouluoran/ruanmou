/// <reference path="_references.js" />

var regphone = /^0?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/;//验证手机号
var regqq = /^\d{5,11}$/;//验证qq号
$(function () {
    $.post("../ajax/MyIndexAjax.ashx?cmd=showinfor", "", function (data) {
        var data = eval('(' + data + ')');
        $("#usernickname").val(data.NickName);
        $("#truename").val(data.RealName);
        $("#userphone").val(data.PhoneNum);
        $("#userqq").val(data.QQ);
        $("#imgheadpic").attr("src", "/upfile/HeadPic/" + data.HeadPic);
        if (data.Sex == "男") {
            $("#uesrsex").eq(0).attr("selected", "selected");
        }
        else {
            $("#uesrsex").eq(1).attr("selected", "selected");
        }
    });



    $("#btnsave").click(function () {
        var nickname = $.trim($("#usernickname").val());
        var realname = $.trim($("#truename").val());
        var phonenum = $.trim($("#userphone").val());
        var qq = $.trim($("#userqq").val());
        var sex = $("#uesrsex").val() == "纯爷们" ? "男" : "女";
        if (realname == "" || phonenum == "" || qq == "") {
            layer.msg("各项不能为空", { time: 1000, icon: 5 });
            return;
        }
        if (!regphone.test(phonenum)) {
            layer.msg("手机号格式不正确", { time: 1000, icon: 5 });
            return;
        }
        if (!regqq.test(qq)) {
            layer.msg("号格式不正确", { time: 1000, icon: 5 });
            return;
        }
        else {
            $.post("../ajax/MyIndexAjax.ashx?cmd=updateinfor", {
                "realname": realname, "phonenum": phonenum, "qq": qq,
                "sex": sex, "nickname": nickname
            }, function (data) {
                var data = eval('(' + data + ')');
                layer.msg(data.Info, { time: 1000, icon: 6 });
            });
        }
    });
});
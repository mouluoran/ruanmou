/// <reference path="jquery-1.10.2.min.js" />
$(function () {
    layui.use(['layer', 'form'], function () { });
    layui.use('laydate', function () {
        var laydate = layui.laydate;
        //执行一个laydate实例
        laydate.render({
            elem: '#test1' //指定元素
        });
    });
});


function insertTask() {
    var d = $.trim($("#test1").val());
    var qqs = $.trim($("#txtQQs").val());
    var coursetype = $("#selPhase").children("option:selected").val();
    var rqq = /^\d{5,11}$/;
    if (!rqq.test(qqs)) {
        layer.msg("qq格式不正确", {
            time: 1000,
            icon: 5
        });
        return;
    }
    if (d == "" || qqs == "" || coursetype == "请选课程类型") {
        layer.msg("各项不能为空", {
            time: 1000,
            icon: 5
        });
    }
    else {
        $.post("/ajax/BeeAjax.ashx", { "type": "insert", "d": d, "qqs": qqs, "coursetype": coursetype }, function (data) {
            if (data == "ok") {
                layer.msg("录入成功", {
                    time: 1000,
                    icon: 6
                });
            }
            else if (data == "exis") {
                layer.msg("录入无效，QQ已被录入过", {
                    time: 1000,
                    icon: 5
                });
            }
            else {
                layer.msg("录入失败", {
                    time: 1000,
                    icon: 5
                });
            }
            $("#txtQQs").val("");
            $("#test1").val("");
        });
    }
}
/// <reference path="jquery-1.10.2.min.js" />

var isloginvip = false;
var editor;
var islower = false;
var askid = 0;
function ShowIsOwer() {
    $.post("/ajax/ComAjax.ashx", { "cmd": "checkisower", "askid": askid }, function (data2) {
        var data2 = eval('(' + data2 + ')');
        islower = data2.Success;
    });
}

$(function () {
    askid = $("#hidQId").val();
    CheckIsVip();
    ShowIsOwer();
    $.post("/ajax/ComAjax.ashx", { "cmd": "comlist", "askid": askid }, function (data) {
        $("#dcomentlist").html(data);
        $("#dcomentlist").find(".jieda-zan").bind("click", function () {
            if (isloginvip == false) {
                layer.msg("已登录的软谋VIP学员方可点赞", {
                    icon: 5,
                    time: 1000
                });
            }
            else {
                var comid = $(this).attr("id").split("-")[1];
                $.post("/ajax/ComAjax.ashx", { "cmd": "dianzan", "askid": askid, "comid": comid }, function (data3) {
                    var data3 = eval('(' + data3 + ')');
                    if (data3.Success) {
                        var zancount = parseInt($("#zan-" + comid).find("em").text()) + 1;
                        $("#zan-" + comid).find("em").text(zancount);
                        layer.msg(data3.Info, {
                            icon: 6,
                            time: 1000
                        });
                    }
                    else {
                        layer.msg(data3.Info, {
                            icon: 5,
                            time: 1000
                        });
                    }
                });
            }
        });
        $("#dcomentlist").find(".reply").bind("click", function () {
            if (isloginvip == false) {
                layer.msg("已登录的软谋VIP学员方可回复", {
                    icon: 5,
                    time: 1000
                });
            }
            else {
                var rusername = "@" + $(this).parent().parent().find(".jie-user").find("i").text() + "：";
                editor.focus();
                editor.setData(rusername);
            }
        });

        $("#dcomentlist").find(".adopt").bind("click", function () {
            if (isloginvip == false) {
                layer.msg("已登录的软谋VIP学员方可采纳回答", {
                    icon: 5,
                    time: 1000
                });
            }
            else {
                if (islower) {
                    var comid = $(this).attr("id").split("-")[1];
                    $.post("/ajax/ComAjax.ashx", { "cmd": "clcomlist", "askid": askid, "comid": comid }, function (data1) {
                        $("#dcomentlist").html(data1);
                        layer.msg("该答案已采纳", {
                            icon: 6,
                            time: 1000
                        });
                    });
                }
                else {
                    layer.msg("只有该发帖人才能采纳答案", {
                        icon: 5,
                        time: 1000
                    });
                }
            }
        });
    });




    layui.use(['layer', 'form'], function () { });
    editor = CKEDITOR.replace('txtBody1',
  {
      filebrowserImageUploadUrl: "ajax/AjaxUpImage.ashx?cmd=uploadImage"
  });

    $(".jieda-zan").click(function () {
        if (isloginvip == false) {
            layer.msg("用户未登陆且只有软谋VIP方可点赞", {
                icon: 5,
                time: 2000
            });
        }
    });

    $("#btnRCom").click(function (e) {
        e.preventDefault();
        var askid = $("#hidQId").val();
        var text = editor.getData();
        if (text == "") {
            layer.msg("评论内容不能为空", {
                icon: 5,
                time: 2000
            });
        }
        else {
            $.post("/ajax/ComAjax.ashx", { "askid": askid, "comtext": text, "cmd": "add" }, function (data) {
                var data = eval('(' + data + ')');
                if (data.Success) {
                    location.reload();
                }
                else {
                    layer.msg(data.Info, {
                        icon: 5,
                        time: 2000
                    });
                }
            });
        }
    });

});


function CheckIsVip() {
    $.post("ajax/HeaderAjax.ashx", { "cmd": "vip" }, function (data) {
        var data = eval('(' + data + ')');
        isloginvip = data.Success;
        if (isloginvip == false) {
            CKEDITOR.on('instanceReady', function (ev) {
                editor = ev.editor;
                editor.setReadOnly(true);
                $("#btnRCom").css("background-color", "#ccc").attr("title", "用户未登陆且只有软谋VIP方可回帖");
            });
        }
        else {
            $("#btnRCom").css("background-color", "#009688").attr("title", "");
        }
    });
}


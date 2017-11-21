/// <reference path="jquery-1.10.2.min.js" />

var editor;
$(function () {
    layui.use(['layer', 'form'], function () { });
    editor = CKEDITOR.replace('txtBody1',
    {
        filebrowserImageUploadUrl: "ajax/AjaxUpImage.ashx?cmd=uploadImage"
    });

    $("#btnPostAsk").click(function (e) {
        e.preventDefault();
        var title = $.trim($("#txtTitle").val());
        var cate = $("#selCategory").children("option:selected").val();
        var text = editor.getData();

        if (title == "" || cate == "0" || text == "") {
            layer.msg("各项不能为空", {
                icon: 5,
                time: 1000
            });
            return;
        }
        if (title.length > 35) {
            layer.msg("标题长度不能超过35", {
                icon: 5,
                time: 1000
            });
            return;
        }
        else {
            $.post("ajax/QueAjax.ashx", { "title": title, "cate": cate, "text": text, "cmd": "PostAsk" }, function (data) {
                var data = eval('(' + data + ')');
                if (data.Success == true) {
                    layer.msg(data.Info, {
                        icon: 6,
                        time: 1000
                    }, function () { parent.location.reload(); });
                }
                else {
                    layer.msg(data.Info, { time: 1000, icon: 5 });
                }
            });
        }
    });
});

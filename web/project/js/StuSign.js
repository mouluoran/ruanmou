/// <reference path="_references.js" />
$(function () {
    $("#btnSign").removeAttr("disabled");
    $.post("../ajax/SignAjax.ashx?cmd=showbtninfor", "", function (data) {
        var data = eval('(' + data + ')');
        if (data.Info != "") {
            $("#btnSign").css("background-color", "#cccccc").val(data.Info).attr("disabled", "disabled");
        }
    });


    $("#btnSign").click(function () {
        $.post("../ajax/SignAjax.ashx?cmd=addsign", "", function (data) {
            var data = eval('(' + data + ')');
            layer.msg(data.Info, { time: 1000, icon: 6 }, function () { location.reload(); });
        });

    });
});
/// <reference path="_references.js" />
$(function () {

    $("#btnLeave").removeAttr("disabled");
    $.post("../ajax/LeaveAjax.ashx?cmd=showbtninfor", "", function (data) {
        var data = eval('(' + data + ')');
        if (data.Info != "") {
            $("#btnLeave").css("background-color", "#cccccc").val(data.Info).attr("disabled", "disabled");
        }
    });


    $("#btnLeave").click(function () {
        $.post("../ajax/LeaveAjax.ashx?cmd=addleave", "", function (data) {
            var data = eval('(' + data + ')');
            layer.msg(data.Info, { time: 1000, icon: 6 }, function () { location.reload(); });
        });

    });
});

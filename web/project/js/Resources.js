/// <reference path="jquery-1.10.2.min.js" />
$(function () {
    $.post("../ajax/MyAskComRs.ashx", { "cmd": "myrslist" }, function (data) {
        $("#urslist").html("").append(data);
    });
});
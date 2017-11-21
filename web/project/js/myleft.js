/// <reference path="jquery-1.10.2.min.js" />

$(function () {
    $.post("../ajax/myleftajax.ashx?cmd=showleft", "", function (data) {
        var data = eval('(' + data + ')');
        switch (data.TypeID) {
            case 1:
                $("#myleft1").show().siblings().hide();
                break;
            case 2:
                $("#myleft1").show().siblings().hide();
                break;
            case 3:
                $("#myleft1").show();
                $("#myleft2").show();
                $("#myleft3").show();
                $("#myleft4").hide();
                break;
            case 4:
                $("#myleft1").show().siblings().hide();
                break;
        }

    });
});
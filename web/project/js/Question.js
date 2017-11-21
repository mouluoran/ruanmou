/// <reference path="jquery-1.10.2.min.js" />

var askcategory = 0;
var askstate = 0;
var isreply = 0;
var pageindex = 1;
var pagesize = 10;
var pagecount = 0;
var isloginvip = false;

function CheckIsVip() {
    $.post("ajax/HeaderAjax.ashx", { "cmd": "vip" }, function (data) {
        var data = eval('(' + data + ')');
        isloginvip = data.Success;
    });
}

$(function () {
    CheckIsVip();
    $(".qsort-ask a").click(function () {
        if (isloginvip == false) {
            layer.msg("用户未登陆且只有软谋VIP方可发帖", {
                icon: 5,
                time: 2000
            });
        }
        else {
            layer.open({
                title: "发帖",
                area: ["700px", "570px"],
                type: 2,
                content: 'PostAsk.aspx'
            });
        }
    });
    ShowAskList();
    layui.use(['layer', 'form'], function () { });
    layui.use('element', function () {
        var $ = layui.jquery
        , element = layui.element();
    });

    $("#tcat li").click(function () {
        $(".qsort-item").removeClass("qsort-sel");
        askstate = 0;
        isreply = 0;
        var cat = $(this).attr("data-c");
        askcategory = cat;
        pageindex = 1;
        ShowAskList();
    });
    $(".qsort-item").click(function () {
        var itemindex = $(".qsort-item").index($(this));
        $(this).addClass("qsort-sel");
        $(".qsort-item").not(":eq(" + itemindex + ")").removeClass("qsort-sel");
        switch (itemindex) {
            case 0:
                isreply = 2;
                askstate = 0;
                break;
            case 1:
                isreply = 1;
                askstate = 0;
                break;
            case 2:
                askstate = 1;
                isreply = 0;
                break;
            case 3:
                askstate = 0;
                isreply = 0;
                break;
        }
        ShowAskList();
    });
});

function ShowAskList() {
    $.post("ajax/QueAjax.ashx", { "askcategory": askcategory, "askstate": askstate, "isreply": isreply, "pageindex": pageindex, "pagesize": pagesize, "cmd": "GetAskList" }, function (data) {
        var data = eval('(' + data + ')');
        pagecount = data.pagecount;
        $("#asklist").html("").append(data.pagelist);
        layui.use(['laypage', 'layer'], function () {
            var nums = pagesize; //每页出现的数据量
            var laypage = layui.laypage
            , layer = layui.layer;
            laypage({
                cont: 'pager'
               , pages: pagecount //总页数
               , groups: 5
                , jump: function (obj) {
                    pageindex = obj.curr;//获取到当前页
                    $.post("ajax/QueAjax.ashx", { "askcategory": askcategory, "askstate": askstate, "isreply": isreply, "pageindex": pageindex, "pagesize": pagesize, "cmd": "GetAskList" }, function (data) {
                        var data = eval('(' + data + ')');
                        pagecount = data.pagecount;
                        $("#asklist").html("").append(data.pagelist);
                    });

                }
            });
        });
    });

}


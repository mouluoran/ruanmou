
var pageindex = 1;
var pagesize = 10;
var pagecount = 0;
$(function () {
    $.post("../ajax/MyAskComRs.ashx", { "cmd": "myasklist", "pageindex": pageindex, "pagesize": pagesize }, function (data) {
        var data = eval('(' + data + ')');
        pagecount = data.pagecount;
        $("#uasklist").html("").append(data.pagelist);
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
                    $.post("../ajax/MyAskComRs.ashx", { "cmd": "myasklist", "pageindex": pageindex, "pagesize": pagesize }, function (data) {
                        var data = eval('(' + data + ')');
                        pagecount = data.pagecount;
                        $("#uasklist").html("").append(data.pagelist);
                    });
                }
            });
        });
    });
});
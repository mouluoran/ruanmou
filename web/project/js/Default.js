/// <reference path="jquery-1.10.2.min.js" />
var timer;
var i = 0;
$(function () {
    ShowTab();
    $("#carousel").hover(function () {
        $(".flip").show();
    }, function () {
        $(".flip").hide();
    });
    $(".cpic").eq(0).show().siblings().hide();
    BeginCarousel();
    $(".tab").hover(function () {
        i = $(this).index();
        clearInterval(timer);
        ShowPicTab();
    }, function () {
        BeginCarousel();
    });
    $(".preflip").click(function () {
        clearInterval(timer);
        i--;
        if (i == -1) {
            i = 4;
        }
        ShowPicTab();
        BeginCarousel();
    });
    $(".nextflip").click(function () {
        clearInterval(timer);
        i++;
        if (i == 5) {
            i = 0;
        }
        ShowPicTab();
        BeginCarousel();
    });
});

function BeginCarousel() {
    timer = setInterval(function () {
        i++;
        if (i == 5) {
            i = 0;
        }
        ShowPicTab();
    }, 5000);
}
function ShowPicTab() {
    $(".cpic").eq(i).stop(true, true).fadeIn(300).siblings().stop(true, true).fadeOut(300);
    $(".tab").eq(i).addClass("bg").siblings().removeClass("bg");
}

function ShowTab()
{
    var tabNum = $(".important").find("li");
    var contentNum = $(".contents").children();
    var timer;
    $(tabNum).each(function (index) {
        $(this).hover(function () {
            var that = $(this)
            timer = window.setTimeout(function () {
                $(contentNum).eq(index).css({ "display": "block" });
                $(contentNum).eq(index).siblings().css({ "display": "none" });
                that.find("a").css({ "background": "#FFF", "color": "#fff" });
                that.find("strong").show();
                that.siblings().find("strong").hide();
                that.siblings().find("a").css({ "background": "#fff", "color": "black" });
            }, 100)
        }, function () {
            window.clearTimeout(timer);
        })
    })
}
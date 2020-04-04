
//请注意，生产环境使用的是index.min.js压缩文件
//您可以安装Bundler & Minifier插件，使压缩文件跟随该文件自动更新
//https://marketplace.visualstudio.com/items?itemName=MadsKristensen.BundlerMinifier

//半屏高度
var halfScreen = window.screen.height / 2;
//获取对象
var navbarBurger = $('.navbar-burger');
var navbarMenu = $('.navbar-menu');
var navbar = $('nav');
var contactBtn_1 = $('#contactBtn_1');
var contactBtn_2 = $('#contactBtn_2');

$(document).ready(function () {
    //浏览器宽度>768时加载body的backgroundImage
    if (window.innerWidth > 768) {
        document.body.style.backgroundImage = 'url(/images/home/bg.jpg)';
    }
    //滚动超过半屏时，navbar由透明变为白色
    if (document.documentElement.scrollTop + document.body.scrollTop > halfScreen) {
        navbar.addClass('has-background-white');
    }
    /*
     *监听navbar的下拉菜单按钮（针对移动端）
     *Document：https://bulma.io/documentation/components/navbar/
     */
    navbarBurger.click(function () {
        navbarBurger.toggleClass("is-active");
        navbarMenu.toggleClass("is-active");
    });
});

$(window).scroll(function () {
    //当前滚动到的位置
    var scrollt = document.documentElement.scrollTop + document.body.scrollTop;
    if (scrollt > halfScreen) {
        //滚动超过半屏时，navbar变为白色背景
        navbar.addClass('has-background-white');
        //切换右上角hello按钮（仅desktop宽屏可见）
        contactBtn_1.addClass('is-hidden');
        contactBtn_2.removeClass('is-hidden');
    } else {
        //否置navbar透明背景
        navbar.removeClass('has-background-white');
        //切换右上角hello按钮（仅desktop宽屏可见）
        contactBtn_2.addClass('is-hidden');
        contactBtn_1.removeClass('is-hidden');
    }
});

$(window).resize(function () {
    //浏览器宽度>768时加载body的backgroundImage
    if (window.innerWidth > 768) {
        document.body.style.backgroundImage = 'url(/images/home/bg.jpg)';
    }
});

//收起navbar的下拉菜单（针对移动端）
function inactiveNav() {
    navbarBurger.removeClass("is-active");
    navbarMenu.removeClass("is-active");
}

//滑动回到顶部
function toHeader() {
    $.scrollTo(0, 800);
    inactiveNav();
}

//滑动到“关于我”
function toAbout() {
    $.scrollTo('#_about', 800);
    inactiveNav();
}

//原理同上
function toSkills() {
    $.scrollTo('#_skills', 800);
    inactiveNav();
}
function toWorks() {
    $.scrollTo('#_works', 800);
    inactiveNav();
}
function toContact() {
    $.scrollTo('#_contact', 800);
    inactiveNav();
}

/*
 * form post后的行为
 * Document：https://dotnetthoughts.net/jquery-unobtrusive-ajax-helpers-in-aspnet-core/
*/

//form submit按钮
var submitBtn;
function onBegin() {
    //获取submit按钮对象
    submitBtn = $('#submitBtn');
    //按钮disable，显示转圈圈图标
    submitBtn.addClass('is-loading');
}

function onComplete(result) {
    var state = result.responseJSON.state;
    switch (state) {
        case "succeed":
            $("#content").val('');
            alert('消息发送成功！\n(oﾟvﾟ)ノ');
            break;
        case "invalid":
            alert('很抱歉，您输入的信息似乎有误，请修改后再试一试吧。');
            break;
        case "faild":
        case "error":
            alert('很抱歉，遇到了一些问题，请稍后重试。\n (T_T)');
            break;
        case "wait":
            alert('小火箭正在补充燃料，请稍后再试。\n (ง •_•)ง');
            break;
    };
    submitBtn.removeClass('is-loading');
    countDown(result.responseJSON.timeo);
}

function onFailure() {
    alert('啊哦，遇到了一些问题 (T_T)\n\n•请检查您的网络，并稍后重试\n•请允许网页使用Cookie\n•请勿在此提交代码');
    submitBtn.removeClass('is-loading');
    countDown(3);
}

//submit按钮显示倒计时
function countDown(timeo) {
    var $submitBtn = $('#submitBtn');
    $submitBtn.addClass('is-static');
    $submitBtn.html("&emsp;" + timeo + "s&emsp;");
    var timeStop = setInterval(function () {
        timeo--;
        if (timeo > 0) {
            $submitBtn.html("&emsp;" + timeo + "s&emsp;");
        }
        else {
            $submitBtn.html('<span>发送&nbsp;<span role="img" aria-label="emoji">🚀</span></span>');
            $submitBtn.removeClass('is-static');
            clearInterval(timeStop);
        }
    }, 1000);
}

//杂项
function jellow() {
    alert('Jellow ID: Surbowl \n欢迎来Jellow找我玩儿！');
}
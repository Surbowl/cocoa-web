<template>
    <div>
        <!--navbar-->
        <nav class="navbar is-fixed-top" role="navigation" aria-label="main navigation"
             :class="{'has-background-white' : (overHalfScreen || navbarBurgersIsActive)}">
            <div class="navbar-brand">
                <a class="navbar-item"><img src="https://vuejs.org/images/logo.png" height="40"></a>
                <a role="button" class="navbar-burger burger" aria-label="menu" aria-expanded="false" data-target="navbarBasicExample"
                   @click="onNavbarBurgersClick" :class="{'is-active' : navbarBurgersIsActive}">
                    <span aria-hidden="true"></span><span aria-hidden="true"></span><span aria-hidden="true"></span>
                </a>
            </div>
            <div id="navbarBasicExample" class="navbar-menu"
                 :class="{'is-active' : navbarBurgersIsActive}">
                <div class="navbar-end" data-aos="fade-left" aos-once="true">
                    <a class="navbar-item has-underline">About</a>
                    <a class="navbar-item has-underline">Projects</a>
                    <!--touch-->
                    <a class="navbar-item has-underline is-hidden-desktop">Say Hello</a>
                    <!--desktop-->
                    <a id="contactBtn_1" v-show="!overHalfScreen" class="navbar-item has-underline is-hidden-touch">Say Hello</a>
                    <a id="contactBtn_2" v-show="overHalfScreen" class="navbar-item is-hidden-touch jump-in">
                        <button class="button is-primary is-rounded"><span>Hello&nbsp;<span role="img" aria-label="emoji">👋</span></span></button>
                    </a>
                </div>
            </div>
        </nav>
        <!--header-->
        <div class="columns is-hidden-mobile" style="margin:0;"
             :style="{height: screenHeight + 'px'}">
            <div class="column is-half has-background-white">
                <div class="hello-div fade-jump-in">
                    <div class="is-float-text">
                        <span class="has-text-grey-dark is-size-3">Hi&thinsp;<span id="face" role="img" aria-label="emoji">😃</span></span>
                    </div>
                    <div class="is-float-text">
                        <span class="has-text-grey-darker is-size-2">我是杰文</span>
                    </div>
                    <div class="is-float-text">
                        <span class="has-text-grey-dark is-size-5">一名物联网学生</span>
                    </div>
                    <a class="button is-primary is-rounded is-medium" style="margin-top:.6rem">
                        <span>Hello&nbsp;<span role="img" aria-label="emoji">👋</span></span>
                    </a>
                </div>
            </div>
        </div>
        <div class="is-hidden-tablet has-background-white" style="margin:0;"
             :style="{height: screenHeight + 'px'}">
            <div class="hello-div fade-jump-in has-text-centered">
                <div><span class="has-text-grey-dark is-size-3">Aloha&thinsp;<span role="img" aria-label="emoji">😃</span></span></div>
                <div><span class="has-text-grey-darker is-size-2">我是杰文</span></div>
                <div><span class="has-text-grey-dark is-size-5">一名物联网学生</span></div>
            </div>
        </div>

        <footer class="footer">
            <div class="content has-text-centered">
                <p id="footerInfo">
                    🚀&thinsp;Powered&nbsp;by&nbsp;.NET&nbsp;5.0.0
                    <br />Source&nbsp;code&nbsp;on&nbsp;<a class=has-text-black href="https://github.com/Surbowl/cocoa-web" target="_blank"><u>Github</u></a>
                    <br /><a class="has-text-grey-dark is-size-7" href="http://www.beian.miit.gov.cn/">闽ICP备xxxxxxx号-x</a>
                </p>
            </div>
        </footer>
    </div>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';
    import bgImg from './assets/bg.jpg';

    @Component({
        name: 'App'
    })
    export default class App extends Vue {
        screenHeight: number = 0;
        screenHeightHalf: number = 0;
        currentHeight: number = 0;
        // https://bulma.io/documentation/components/navbar/
        navbarBurgersIsActive: boolean = false;

        mounted(): void {
            this.onResize();
            this.onScroll();

            window.onresize = this.onResize;
            window.addEventListener('scroll', this.onScroll);
        }

        // methods
        onResize(): void {
            this.screenHeight = window.innerHeight;
            this.screenHeightHalf = window.innerHeight / 2;

            // set body background image if screen width than 768
            if (window.innerWidth > 768) {
                document.body.style.background = `#CED7DC url(${bgImg}) no-repeat fixed right`; //color url() repeat attachment position
                document.body.style.backgroundSize = 'cover';
            }
        }
        onScroll(): void {
            this.currentHeight = document.documentElement.scrollTop + document.body.scrollTop;
        }
        onNavbarBurgersClick(): void {
            this.navbarBurgersIsActive = !this.navbarBurgersIsActive;
        }

        // computed
        get overHalfScreen(): boolean {
            return this.currentHeight > this.screenHeightHalf
        }
    }

    import * as Aos from 'aos';
    Aos.init();
</script>

<style scoped lang="scss">
    @import './design/app.scss';
    @import '~aos/dist/aos.css';
</style>
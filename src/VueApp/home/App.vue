<template>
    <div>
        <!--NAVBAR-->
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
                    <a class="navbar-item has-underline">关于我</a>
                    <a class="navbar-item has-underline">项目</a>
                    <a class="navbar-item has-underline">简历</a>
                    <a class="navbar-item has-underline">Api</a>
                    <!--desktop-->
                    <a id="contactBtn_1" v-show="!overHalfScreen" class="navbar-item has-underline is-hidden-touch">Say Hello</a>
                    <a id="contactBtn_2" v-show="overHalfScreen" class="navbar-item is-hidden-touch jump-in">
                        <button class="button is-primary is-rounded"><span>Hello&nbsp;<span role="img" aria-label="emoji">👋</span></span></button>
                    </a>
                    <!--touch-->
                    <a class="navbar-item has-underline is-hidden-desktop">Say Hello</a>
                </div>
            </div>
        </nav>

        <!--HELLO-->
        <!--desktop-->
        <div class="columns is-hidden-mobile" style="margin:0;"
             :style="{height: screenHeight + 'px'}">
            <div class="column is-half has-background-white">
                <div class="hello-div fade-jump-in">
                    <figure class="image is-48x48">
                        <img src="./assets/emoji-cool.gif">
                    </figure>
                    <div class="is-float-text">
                        <span class="has-text-grey-darker is-size-2">Hi，我是杰文</span>
                    </div>
                    <div class="is-float-text">
                        <span class="has-text-grey-dark is-size-5">Nice to see you&thinsp;~</span>
                    </div>
                    <a class="button is-primary is-rounded is-medium gap-top">
                        <span>Hello&nbsp;<span role="img" aria-label="emoji">👋</span></span>
                    </a>
                </div>
            </div>
        </div>
        <!--touch-->
        <div class="is-hidden-tablet has-background-white" style="margin:0;"
             :style="{height: screenHeight + 'px'}">
            <div class="hello-div fade-jump-in has-text-centered">
                <figure class="image is-48x48 is-inline-block">
                    <img src="./assets/emoji-cool.gif">
                </figure>
                <div><span class="has-text-grey-darker is-size-2">Hi，我是杰文</span></div>
                <div><span class="has-text-grey-dark is-size-5">Nice to see you&thinsp;~</span></div>
            </div>
        </div>

        <!--ABOUT ME-->
        <section class="section">
            <div class="columns">
                <div class="column is-4 is-offset-1 has-text-centered-mobile has-text-left-tablet" data-aos="fade-up" aos-once="true">
                    <div class="field"><span class="is-size-3 has-shadow-blue">&nbsp;关于我&nbsp;</span></div>
                    <span class="gap-top">
                        📍&nbsp;生长于福建省的野生后端
                        <br />
                        闽院&nbsp;2020&nbsp;届物联网学子
                        <br />
                        目前在某司敲&nbsp;.NET
                        <br />
                        <label onclick="alert('大师球！')">欢迎大家前来捕获</label>
                    </span>
                </div>
                <div class="column is-5 is-offset-1 no-overflow-x">
                    <div class="box has-text-centered" data-aos="zoom-in-left" aos-once="true">
                        <span class="is-size-2" role="img" aria-label="emoji">👨‍💻</span>
                        <div class="columns is-centered">
                            <div class="column is-four-fifths">
                                <div class="field gap-top"><span class="is-size-5">Languages</span></div>
                                <div class="field">
                                    <div class="tags is-centered">
                                        <span class="tag">C#</span><span class="tag">C/C++</span><span class="tag">SQL</span><span class="tag">TypeScript</span><span class="tag">JavaScript</span><span class="tag">Sass</span>
                                    </div>
                                </div>
                                <div class="field gap-top"><span class="is-size-5">Frameworks</span></div>
                                <div class="field">
                                    <div class="tags is-centered">
                                        <span class="tag">.NET</span><span class="tag">Vue</span><span class="tag">Element</span><span class="tag">Bulma</span>
                                    </div>
                                </div>
                                <div class="field gap-top"><span class="is-size-5">Tools</span></div>
                                <div class="field">
                                    <div class="tags is-centered">
                                        <span class="tag">VS</span><span class="tag">dnSpy</span><span class="tag">Dev-C++</span><span class="tag">HBuilder</span>
                                        <span class="tag">Docker</span><span class="tag">Node.js</span><span class="tag">git</span>
                                    </div>
                                </div>
                                <span class="gap-top"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <footer class="footer">
            <div class="content has-text-centered">
                <p id="footerInfo">
                    <span>
                        🚀&thinsp;Powered&nbsp;by&nbsp;<a class="has-text-black" href="https://dotnet.microsoft.com/download/dotnet/5.0" target="_blank"><u>.NET&nbsp;5.0.0-rc.2</u></a>
                        <br />
                    </span>
                    <span v-show="showBackgroundImg">
                        Photo&nbsp;by&nbsp;<a class="has-text-black" href="https://unsplash.com/powwpic" target="_blank"><u>Ines&nbsp;Álvarez&nbsp;Fdez</u></a>
                        <br />
                    </span>
                    <span>
                        Source&nbsp;code&nbsp;on&nbsp;<a class="has-text-black" href="https://github.com/Surbowl/cocoa-web" target="_blank"><u>Github</u></a>
                        <br />
                    </span>
                    <span>
                        <a class="has-text-grey-dark is-size-7" href="http://www.beian.miit.gov.cn/">闽ICP备xxxxxxx号-x</a>
                        <br />
                    </span>
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
        showBackgroundImg: boolean = false;
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
            this.showBackgroundImg = window.innerWidth > 768;

            // set body background image if screen width than 768
            if (this.showBackgroundImg) {
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
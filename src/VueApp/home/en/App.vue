<template>
    <div>
        <!--Float Down Arrow-->
        <div id="_floatDownArrowDiv" class="has-text-centered is-size-5"><span class="icon-chevron-down" v-scroll-to="'#_aboutMe'"></span></div>

        <!--NAVBAR-->
        <nav class="navbar is-fixed-top" role="navigation" aria-label="main navigation"
             :class="{'has-background-white' : (overHalfScreen || navbarBurgersIsActive)}">
            <div class="navbar-brand">
                <a class="navbar-item" v-scroll-to="'#_hello'">
                    <img src="./assets/nav.png" height="40">
                </a>
                <a role="button" class="navbar-burger burger" aria-label="menu" aria-expanded="false" data-target="navbarBasicExample"
                   @click="onNavbarBurgersClick" :class="{'is-active' : navbarBurgersIsActive}">
                    <span aria-hidden="true"></span><span aria-hidden="true"></span><span aria-hidden="true"></span>
                </a>
            </div>
            <div id="navbarBasicExample" class="navbar-menu"
                 :class="{'is-active' : navbarBurgersIsActive}">
                <div class="navbar-start">
                    <div class="navbar-item has-dropdown is-hoverable">
                        <a class="navbar-link">
                            English
                        </a>
                        <div class="navbar-dropdown">
                            <a class="navbar-item" href="/home?lang=zh">
                                中文 Chinese
                            </a>
                        </div>
                    </div>
                </div>
                <div class="navbar-end" data-aos="fade-left" aos-once="true">
                    <a class="navbar-item has-underline" v-scroll-to="'#_aboutMe'">About&thinsp;Me</a>
                    <a class="navbar-item has-underline" v-scroll-to="'#_findMe'">Social</a>
                    <!--desktop-->
                    <a id="contactBtn_1" class="navbar-item has-underline is-hidden-touch" v-show="!overHalfScreen" v-scroll-to="'#_contact'">Say&thinsp;Hello</a>
                    <a id="contactBtn_2" class="navbar-item is-hidden-touch jump-in" v-show="overHalfScreen">
                        <button class="button is-primary is-rounded" v-scroll-to="'#_contact'">
                            <span>Hello&nbsp;<span role="img" aria-label="emoji">👋</span></span>
                        </button>
                    </a>
                    <!--touch-->
                    <a class="navbar-item has-underline is-hidden-desktop" v-scroll-to="'#_contact'">Say&thinsp;Hello</a>
                </div>
            </div>
        </nav>

        <!--HELLO-->
        <div id="_hello">
            <!--desktop-->
            <div class="columns is-hidden-mobile" style="margin:0;"
                 :style="{height: screenHeight + 'px'}">
                <div class="column is-half has-background-white">
                    <div class="hello-div fade-jump-in">
                        <figure class="image is-48x48">
                            <img src="./assets/emoji-cool.gif">
                        </figure>
                        <div class="is-float-text">
                            <span class="has-text-grey-darker is-size-2">Hi, I'm Jiewen</span>
                        </div>
                        <div class="is-float-text">
                            <span class="has-text-grey-dark is-size-5">Welcome to my dom</span>
                        </div>
                        <a class="button is-primary is-rounded is-medium gap-top" v-scroll-to="'#_contact'">
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
                    <div><span class="has-text-grey-darker is-size-2">Hi, I'm Jiewen</span></div>
                    <div><span class="has-text-grey-dark is-size-5">Nice to see you&thinsp;!</span></div>
                </div>
            </div>
        </div>

        <!--ABOUT ME-->
        <section id="_aboutMe" class="section">
            <div class="columns about-me-div">
                <div class="column is-4 is-offset-1 has-text-centered-mobile has-text-left-tablet" data-aos="fade-up" aos-once="true">
                    <div class="field"><span class="is-size-3 has-shadow-blue">My latest info</span></div>
                    <span class="gap-top">
                        <span role="img" aria-label="emoji">💻</span>&nbsp;Back-End Engineer
                        <br />
                        <span role="img" aria-label="emoji">📍</span>&nbsp;Living in Fujian Province, China
                        <br />
                        <span role="img" aria-label="emoji">❤️</span>&nbsp;Love open source
                    </span>
                </div>
                <!--AOS causing horizontal scroll bar to appear https://github.com/michalsnik/aos/issues/416 so add style="overflow-x:hidden;"-->
                <div class="column is-5 is-offset-1" style="overflow-x:hidden;">
                    <div data-aos="zoom-in-left" aos-once="true">
                        <skills-box></skills-box>
                    </div>
                </div>
            </div>
        </section>

        <!--FIND ME-->
        <section id="_findMe" class="section">
            <div class="columns is-centered">
                <div class="column is-three-fifths has-text-centered">
                    <div class="field" data-aos="fade-up" aos-once="true">
                        <span class="is-size-3 has-shadow-yellow">&nbsp;Find Me&nbsp;</span><br /><br />
                    </div>
                    <div data-aos="fade-up" aos-once="true">
                        <social-buttons></social-buttons>
                    </div>
                    <span class="gap-top"></span>
                </div>
            </div>
        </section>

        <!--CONTACT-->
        <section id="_contact" class="section">
            <div class="columns is-centered">
                <div class="column is-two-fifths has-text-centered">
                    <div class="field" data-aos="fade-up" aos-once="true">
                        <span class="is-size-3 has-shadow-green">&nbsp;Say Hello&nbsp;</span><br /><br />
                    </div>
                    <div data-aos="fade-up" aos-once="true">
                        <message-board></message-board>
                    </div>
                    <span class="gap-top"></span>
                </div>
            </div>
        </section>

        <!--FOOTER-->
        <footer class="footer">
            <div class="content has-text-centered">
                <p id="footerInfo">
                    <span>
                        <span role="img" aria-label="emoji">🚀</span>&thinsp;Powered by {{runtimeInfo.framework}} on Docker
                        <br />
                    </span>
                    <span v-show="showBackgroundImg">
                        Photo by <a class="has-text-black" href="https://unsplash.com/powwpic" target="_blank"><u>Ines Álvarez Fdez</u></a>
                        <br />
                    </span>
                    <span>
                        Source code on <a class="has-text-black" href="https://github.com/Surbowl/cocoa-web" target="_blank"><u>Github</u></a>
                        <br />
                    </span>
                    <span>
                        <a class="has-text-grey-dark is-size-7" href="http://beian.miit.gov.cn/" target="_blank">京ICP备xxxxxxxx号-1</a>
                        <br />
                    </span>
                </p>
            </div>
        </footer>
    </div>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';
    import * as Aos from 'aos';

    import SkillsBox from '@/home/en/components/SkillsBox.vue'
    import MessageBoard from '@/home/en/components/MessageBoard.vue'
    import SocialButtons from '@/home/en/components/SocialButtons.vue'

    import BgImg from '@/home/en/assets/bg.jpg';

    @Component({
        name: 'App',
        components: {
            SkillsBox,
            MessageBoard,
            SocialButtons
        }
    })
    export default class App extends Vue {
        screenHeight: number = 0;
        screenHeightHalf: number = 0;
        currentHeight: number = 0;
        showBackgroundImg: boolean = false;
        navbarBurgersIsActive: boolean = false;  // https://bulma.io/documentation/components/navbar/
        runtimeInfo: any = _runtimeInfo;

        mounted(): void {
            this.onResize();
            this.onScroll();

            window.onresize = this.onResize;
            window.addEventListener('scroll', this.onScroll);
        }

        onResize(): void {
            this.screenHeight = window.innerHeight;
            this.screenHeightHalf = window.innerHeight / 2;
            this.showBackgroundImg = window.innerWidth > 768;

            // set body background image if screen width than 768
            if (this.showBackgroundImg) {
                document.body.style.background = `#CED7DC url(${BgImg}) no-repeat fixed right`; //color url() repeat attachment position
                document.body.style.backgroundSize = 'cover';
            }
        }
        onScroll(): void {
            this.currentHeight = document.documentElement.scrollTop + document.body.scrollTop;
        }
        onNavbarBurgersClick(): void {
            this.navbarBurgersIsActive = !this.navbarBurgersIsActive;
        }

        get overHalfScreen(): boolean {
            return this.currentHeight > this.screenHeightHalf
        }
    }

    Aos.init();
</script>

<style scoped lang="scss">
    @import '~aos/dist/aos.css';

    #_floatDownArrowDiv {
        width: 100%;
        position: absolute;
        bottom: 24px;
        animation: float 2.5s ease infinite;
    }

    @keyframes float {
        0%, 100% {
            -webkit-transform: translateY(0);
            transform: translateY(0);
        }

        50% {
            -webkit-transform: translateY(-10px);
            transform: translateY(-10px);
        }
    }

    .hello-div {
        position: relative;
        top: 26%;
        width: 70%;
        margin: auto;
    }

    .about-me-div {
        margin-top: 4rem;
    }

    /* cover global style */
    .navbar {
        transition: background-color .2s ease-in-out;
        background-color: transparent;
        background-image: none;
        .navbar-item:hover

    {
        background-color: transparent;
    }

    /* prevent box-shadow from spilling navbar div*/
    .button:hover {
        box-shadow: 0 4px 6px 0 rgba(0,0,0,.1);
    }

    }

    $navbar-link-color: #4A4A4A;

    .navbar-link {
        &:hover

    {
        color: $navbar-link-color;
    }

    &:not(.is-arrowless)::after {
        border-color: $navbar-link-color;
    }

    }

    .navbar-end {
        overflow: hidden;
    }

    @media screen and (min-width: 1024px) {
        .navbar .has-underline:hover {
            border-bottom: 1px solid;
            color: $navbar-link-color;
        }
    }

    @media screen and (max-width: 1023px) {
        .navbar-menu {
            box-shadow: 0 6px 6px rgba(10,10,10,.1);
        }
    }

    .section {
        background-color: white;
    }
</style>
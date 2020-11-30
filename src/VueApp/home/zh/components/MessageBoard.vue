<template>
    <div>
        <div class="has-text-left">
            <div class="field">
                <input v-model="name" class="form-item" type="text" placeholder="昵称 *">
                <p class="help has-text-danger" v-show="nameErrorMsg != ''">{{nameErrorMsg}}</p>
            </div>
            <div class="field">
                <input v-model="email" class="form-item" type="email" placeholder="电子邮箱">
                <p class="help has-text-danger" v-show="emailErrorMsg != ''">{{emailErrorMsg}}</p>
            </div>
            <div class="field">
                <textarea v-model="content" class="form-item" rows="8" placeholder="正文 *"></textarea>
                <p class="help has-text-danger" v-show="contentErrorMsg != ''">{{contentErrorMsg}}</p>
            </div>
        </div>

        <p class="help jump-in" v-show="sended"><br />发送成功&nbsp;<span role="img" aria-label="emoji">😉</span></p>
        <p class="help has-text-danger" v-show="errorMsg != ''"><br />{{errorMsg}}</p>
        <br />
        <div class="has-text-centered">
            <button class="button is-primary is-rounded is-medium" :class="{'is-loading':isLoading}" @click="sendMessage"
                    v-show="remainingCountdown <= 0">
                <span>
                    发送&nbsp;<span role="img" aria-label="emoji">{{sended ? '📫':'📪'}}</span>
                </span>
            </button>
            <button class="button is-static is-rounded is-medium"
                    v-show="remainingCountdown > 0">
                <span>
                    &emsp;{{remainingCountdown}}&emsp;
                </span>
            </button>
        </div>
    </div>
</template>

<script lang="ts">
    import { Vue, Component, Watch } from 'vue-property-decorator'
    import Axios from 'axios';

    @Component({
        name: 'MessageBoard'
    })
    export default class MessageBoard extends Vue {
        name: string = '';
        email: string = '';
        content: string = '';

        nameErrorMsg: string = '';
        emailErrorMsg: string = '';
        contentErrorMsg: string = '';
        errorMsg: string = '';

        isLoading: boolean = false;
        sended: boolean = false;

        remainingCountdown: number = 0;

        sendMessage(): void {
            this.sended = false;
            this.errorMsg = '';
            if (!this.checkForm()) {
                return;
            }

            this.isLoading = true;

            Axios.post('/api/home/message', {
                name: this.name,
                email: this.email,
                content: this.content,
                lang: 'zh'
            })
                .then(response => {
                    this.isLoading = false;
                    if (response.data.code === 200) {
                        this.sended = true;
                    }
                    else {
                        alert(response.data.message);
                    }

                    if (response.data.countdown > 0) {
                        this.setCountDown(response.data.countdown as number);
                    }
                })
                .catch(error => {
                    this.isLoading = false;
                    this.errorMsg = '很抱歉，发送失败，请稍后再试';
                    console.log(error);
                });
        }

        checkForm(): boolean {
            let available: boolean = true;
            if (this.name.length === 0) {
                this.nameErrorMsg = '请告诉我如何称呼您';
                available = false;
            }
            if (this.name.length > 200) {
                this.nameErrorMsg = '请使用简短一些的昵称';
                available = false;
            }

            if (this.email.length > 0) {
                if (this.email.length > 500) {
                    this.emailErrorMsg = '您输入的邮箱地址过长，请换一个';
                    available = false;
                } else {
                    var emailReg = /^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
                    if (!emailReg.test(this.email)) {
                        this.emailErrorMsg = '请输入有效的邮箱';
                        available = false;
                    }
                }
            }

            if (this.content.length === 0) {
                this.contentErrorMsg = '请输入内容';
                available = false;
            }
            if (this.content.length > 2000) {
                this.contentErrorMsg = '内容最长 2000 字哦';
                available = false;
            }

            return available;
        }

        // count down
        setCountDown(seconds: number): void {
            this.remainingCountdown = seconds;
            let timeStop = setInterval(() => {
                this.remainingCountdown--;
                if (this.remainingCountdown <= 0) {
                    clearInterval(timeStop);
                }
            }, 1000);
        }

        @Watch('name')
        onNameChanged(): void {
            this.nameErrorMsg = '';
        }

        @Watch('email')
        onEmailChanged(): void {
            this.emailErrorMsg = '';
        }

        @Watch('content')
        onContentChanged(): void {
            if (this.content.length > 2000) {
                this.contentErrorMsg = '内容最长 2000 字哦';
            } else {
                this.contentErrorMsg = '';
            }
        }
    }
</script>

<style scoped lang="scss">
    .form-item {
        width: 100%;
        max-width: 100%;
        padding: 1rem;
        border: none;
        background: #f0f0f5;
        border-radius: 1rem;
        font-size: 1rem;
        outline: none;
        transition: all .2s ease-in-out;
    }
</style>

<template>
    <div>
        <div class="has-text-left">
            <div class="field">
                <input v-model="name" class="form-item" type="text" placeholder="Name *">
                <p class="help has-text-danger" v-show="nameErrorMsg != ''">{{nameErrorMsg}}</p>
            </div>
            <div class="field">
                <input v-model="email" class="form-item" type="email" placeholder="Email">
                <p class="help has-text-danger" v-show="emailErrorMsg != ''">{{emailErrorMsg}}</p>
            </div>
            <div class="field">
                <textarea v-model="content" class="form-item" rows="8" placeholder="Content *"></textarea>
                <p class="help has-text-danger" v-show="contentErrorMsg != ''">{{contentErrorMsg}}</p>
            </div>
        </div>

        <p class="help jump-in" v-show="sended"><br />Send Successfully&nbsp;<span role="img" aria-label="emoji">😉</span></p>
        <p class="help has-text-danger" v-show="errorMsg != ''"><br />{{errorMsg}}</p>
        <br />
        <div class="has-text-centered">
            <button class="button is-primary is-rounded is-medium" :class="{'is-loading':isLoading}" @click="sendMessage"
                    v-show="remainingCountdown <= 0">
                <span>
                    POST&nbsp;<span role="img" aria-label="emoji">{{sended ? '📫':'📪'}}</span>
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
                lang: 'en'
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
                    this.errorMsg = 'Sorry, msssage sending failed, please try again later';
                    console.log(error);
                });
        }

        checkForm(): boolean {
            let available: boolean = true;
            if (this.name.length === 0) {
                this.nameErrorMsg = 'Please enter your name';
                available = false;
            }
            if (this.name.length > 200) {
                this.nameErrorMsg = 'Sorry, the name you entered is too long';
                available = false;
            }

            if (this.email.length > 0) {
                if (this.email.length > 800) {
                    this.emailErrorMsg = 'Sorry, the email address you entered is too long';
                    available = false;
                } else {
                    var emailReg = /^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
                    if (!emailReg.test(this.email)) {
                        this.emailErrorMsg = 'Please enter a valid email address';
                        available = false;
                    }
                }
            }

            if (this.content.length === 0) {
                this.contentErrorMsg = 'Please enter content';
                available = false;
            }
            if (this.content.length > 2000) {
                this.contentErrorMsg = 'Sorry, the maximum content is 2000 words';
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
                this.contentErrorMsg = 'Sorry, the maximum content is 2000 words';
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

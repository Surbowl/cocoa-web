<template>
    <div>
        <div class="has-text-left">
            <div class="field">
                <input v-model="name" class="form-item" type="text" placeholder="Name *">
                <p class="help is-danger" v-show="nameErrorMsg != ''">{{nameErrorMsg}}</p>
            </div>
            <div class="field">
                <input v-model="email" class="form-item" type="email" placeholder="Email (optional)">
                <p class="help is-danger" v-show="emailErrorMsg != ''">{{emailErrorMsg}}</p>
            </div>
            <div class="field">
                <input v-model="phone" class="form-item" type="tel" placeholder="Tel (optional)">
                <p class="help is-danger" v-show="phoneErrorMsg != ''">{{phoneErrorMsg}}</p>
            </div>
            <div class="field">
                <textarea v-model="content" class="form-item" rows="6" placeholder="Message *"></textarea>
                <p class="help is-danger" v-show="contentErrorMsg != ''">{{contentErrorMsg}}</p>
            </div>
        </div>

        <p class="help jump-in" v-show="sended"><br />发送成功&nbsp;<span role="img" aria-label="emoji">✔</span></p>
        <p class="help is-danger" v-show="errorMsg != ''"><br />{{errorMsg}}</p>
        <br />
        <div class="has-text-centered" data-aos="fade-up" aos-once="true">
            <button class="button is-primary is-rounded is-medium"
                    :class="{'is-loading':isLoading}" @click="sendMessage">
                <span>
                    发送&nbsp;
                    <span role="img" aria-label="emoji">{{sended ? '📫':'📪'}}</span>
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
        phone: string = '';
        content: string = '';

        nameErrorMsg: string = '';
        emailErrorMsg: string = '';
        phoneErrorMsg: string = '';
        contentErrorMsg: string = '';
        errorMsg: string = '';

        isLoading: boolean = false;
        sended: boolean = false;

        sendMessage(): void {
            this.sended = false;
            this.errorMsg = '';
            if (!this.checkForm()) {
                return;
            }

            this.isLoading = true;

            Axios.post('/api/home/postmessage', {
                name: this.name,
                email: this.email,
                phone: this.phone,
                content: this.content
            })
                .then(response => {
                    this.isLoading = false;
                    if (response.data.code === 200) {
                        this.sended = true;
                    }
                    else {
                        alert(response.data.message);
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
            if (this.name.length > 100) {
                this.nameErrorMsg = '请使用简短一些的昵称哦';
                available = false;
            }

            if (this.email.length > 200) {
                this.emailErrorMsg = '您输入的邮箱地址似乎有误';
                available = false;
            }

            if (this.phone.length > 25) {
                this.phoneErrorMsg = '您输入的联系电话似乎有误';
                available = false;
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

        @Watch('name')
        onNameChanged(): void {
            this.nameErrorMsg = '';
        }

        @Watch('email')
        onEmailChanged(): void {
            this.emailErrorMsg = '';
        }

        @Watch('phone')
        onPhoneChanged(): void {
            this.phoneErrorMsg = '';
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
<template>
    <div>
        <div class="container">
            <h1 class="title" data-aos="zoom-out-left">
                {{ pageTitle }}
            </h1>
            <h2 class="subtitle" data-aos="zoom-out-left">
                Template is created using Vue, Vue router, Vuex, TypeScript and Bulma.
            </h2>
            <hello-banner></hello-banner>
            <!--<template-info-stack></template-info-stack>-->
        </div>
    </div>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator'

    import HelloBanner from '@/home/components/Hello/HelloBanner.vue'
    //import TemplateInfoStack from '@/home/components/Home/TemplateInfoStack.vue'

    @Component({
        name: 'Hello',
        components: {
            HelloBanner,
            //TemplateInfoStack
        }
    })
    export default class Hello extends Vue {
        pageTitle: string = '.NET with Vue and TypeScript'
    }
</script>

<style scoped>
</style>

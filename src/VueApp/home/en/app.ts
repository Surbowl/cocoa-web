import Vue from 'vue'
import VueScrollTo from 'vue-scrollto';

Vue.use(VueScrollTo)

import App from './App.vue'

new Vue({
    render: h => h(App)
}).$mount('#app')
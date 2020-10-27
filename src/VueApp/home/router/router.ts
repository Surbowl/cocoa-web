import VueRouter from 'vue-router'

// Pages
import Vuex from '@/home/views/Vuex.vue'
import Hello from '@/home/views/Hello.vue'
import ThirdPartyLibraries from '@/home/views/ThirdPartyLibraries.vue'
import CompositionApi from '@/home/views/CompositionApi.vue'

const routePrefix = 'home'

const routes = [
	{
		path: '*',
		redirect: { name: 'hello' }
	},
	{
		name: 'hello',
		path: `/${routePrefix}/hello`,
		component: Hello
	},
	{
		name: 'compositionApi',
		path: `/${routePrefix}/compositionApi`,
		component: CompositionApi
	},
	{
		name: 'vuex',
		path: `/${routePrefix}/vuex`,
		component: Vuex
	},
	{
		name: 'thirdpartylibraries',
		path: `/${routePrefix}/thirdpartylibraries`,
		component: ThirdPartyLibraries
	}
]

export const router = new VueRouter({
	mode: 'history',
	routes,
	linkActiveClass: 'is-active'
})

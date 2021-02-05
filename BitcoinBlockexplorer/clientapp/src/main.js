import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import Vue from 'vue'
import App from './App.vue'
import RequestHelper from './utils/request-helper'
import GridHelper from './utils/grid-helper'
import TransactionsHelper from './utils/transactions-helper'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

//Router
import VueRouter from 'vue-router'
import Transactions from '@components/transactions/transactions'
import Blocks from '@components/blocks/blocks'
import Search from '@components/search/search'

const routes = [
  {path: '/transactions', component: Transactions},
  {path: '/blocks', component: Blocks},
  {path: '/search', component: Search}
]

const router = new VueRouter({
  routes,
  mode: 'history'
});

Vue.config.productionTip = false

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(RequestHelper)
Vue.use(GridHelper)
Vue.use(TransactionsHelper)
Vue.use(VueRouter)

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

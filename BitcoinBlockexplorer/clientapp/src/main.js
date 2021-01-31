import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import Vue from 'vue'
import App from './App.vue'
import RequestHelper from './utils/request-helper'
import GridHelper from './utils/grid-helper'
import TransactionsHelper from './utils/transactions-helper'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

Vue.config.productionTip = false

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(RequestHelper)
Vue.use(GridHelper)
Vue.use(TransactionsHelper)

new Vue({
  render: h => h(App),
}).$mount('#app')

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import Vue from 'vue'
import App from './App.vue'
import RequestHelper from './utils/request-helper'
import GridHelper from './utils/grid-helper'
import { BootstrapVue } from 'bootstrap-vue'

Vue.config.productionTip = false

Vue.use(BootstrapVue)
Vue.use(RequestHelper)
Vue.use(GridHelper)

new Vue({
  render: h => h(App),
}).$mount('#app')

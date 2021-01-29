import Vue from 'vue'
import App from './App.vue'
import RequestHelper from './utils/request-helper'
import { BootstrapVue } from 'bootstrap-vue'

Vue.config.productionTip = false

Vue.use(BootstrapVue)
Vue.use(RequestHelper)

new Vue({
  render: h => h(App),
}).$mount('#app')

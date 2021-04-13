import Vue from 'vue'
import App from './App.vue'
import Vuex from 'vuex'
import 'bootstrap/dist/css/bootstrap.css'

Vue.config.productionTip = false
Vue.use(Vuex);


import store from './store'
new Vue({
  render: h => h(App),
  store
}).$mount('#app')

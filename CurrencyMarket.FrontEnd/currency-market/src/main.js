import Vue from 'vue'
import App from './App.vue'
import router from './router/index';
import 'bootstrap/dist/css/bootstrap.css'

Vue.config.productionTip = false


import store from './store'
new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')

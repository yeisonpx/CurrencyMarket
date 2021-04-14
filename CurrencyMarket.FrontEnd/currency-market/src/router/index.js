import Vue from 'vue'
import Router from 'vue-router'
import Home from '../components/HomePage.vue'
import CurrencyPrices from '../components/CurrencyPrices.vue';
import CurrencyExchange from '../components/CurrencyExchange.vue';

Vue.use(Router);

export default new Router({
    routes: [
      { path: '/', component: Home },
      {
        path: '/cotizaciones',
        name: 'cotizaciones',
        component: CurrencyPrices
      },
      {
        path: '/compra',
        name: 'compra',
        component: CurrencyExchange
      }
    ]
})
import currencyService from './api/currenciesService'
import Vuex from 'vuex'
import Vue from 'vue'

Vue.use(Vuex);
export default new Vuex.Store({
    state: {
      currencies:null,
      loadingCurrencies:false
    },
    mutations: {
      async updateCurrencies  (state) {
          state.loadingCurrencies= true;
          let currencies = [];
          try{                      
            let dolarPrice = await currencyService.getCurrencies("dolar");          
            let realPrice = await currencyService.getCurrencies("real");
            dolarPrice.DisplayName = "Dolar";
            realPrice.DisplayName = "Real";
            currencies.push(dolarPrice);
            currencies.push(realPrice);
            state.currencies = currencies;
            state.loadingCurrencies = false;
          } catch(error){
              console.log(error);
          }
      }
    },
    actions: {
      refreshCurrenciesPrices(context){
          context.commit("updateCurrencies");
      }
    }
  });
<template>
  <div id="app" class="container">
    <div class="display-4">Currency Market Prices</div>
    <div v-if="currencies.length>0">
      <div class="d-flex flex-row">  
          <Currency v-for="currency in currencies"
          :name="currency.DisplayName"
          :key="currency.name"
          :buy-price="currency.buyPrice"
          :sales-price="currency.salePrice" 
          :message="currency.message"           
          />              
      </div>
                                       
      <div class="text-left">
        <button id="btn-refresh" class="btn btn-lg btn-success" v-on:click="refreshCurrencyPrices">Refresh Prices</button>        
      </div>
    </div>
      <div id="loadingoverlay" v-if="isLoadingCurrencies">
        <img src="./assets/imgs/loading.gif" alt="Loading" id="loading-img">
      </div>
  </div>
</template>

<script>
import Currency from './components/Currency.vue'
export default {
  name: 'App',
  components: {
     Currency
  },
  mounted: function(){
      if(this.currencies.length == 0){
        this.refreshCurrencyPrices();
      }
  },
  computed: {
    currencies: function(){
      return this.$store.state.currencies || []; 
    },
    isLoadingCurrencies: function (){
      return this.$store.state.loadingCurrencies;
    } 
  },
  methods:{
      refreshCurrencyPrices:  function() {
         this.$store.dispatch("refreshCurrenciesPrices");
      }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

#loadingoverlay {
    position: fixed;
    top: 0;
    left: 0;
    z-index: 9999;
    width: 100%;
    height: 100%;
    background: rgba(0,0,0,0.6);
}

#loading-img{
  position: absolute;
  width: 40px;
  height: 40px;
  margin-top: 0 auto;
}
</style>

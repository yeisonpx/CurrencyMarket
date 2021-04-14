<template>
  <div>  
      <div class="display-4 mb-3">Exchange Currencies</div>
      <div class="card card-body container-fluid">
      <div class="row">
      <div class="from-group col-4">
          <label for="userId">User:</label>
          <input type="text" class="form-control" name="userId" id="userId" v-model="model.userId">                    
      </div>
      <div class="form-group col-4">
              <label for="userId">Currency Code:</label>
            <input type="text" class="form-control " name="currency" id="currency" v-model="model.currency">
          </div>
        <div class="form-group col-4">
        <label for="userId">Amount:</label>
        <input type="number" class="form-control" name="amount" id="amount" v-model="model.amount">
        </div>
        <div>
        <button id="buyCurrency" v-on:click="exchangeCurrencies" class="btn btn-primary">Buy</button>
        </div>
    </div>   
      </div>      
    
    <router-link to="/" class="btn btn-lg btn-default ">Back to Home</router-link>
    <div v-if="model.lastExchangeAmount>0 && !hasErrors">
            <div class="alert alert-success mt-3">
                    <div class="text-bold"> 
                        You have exchange {{ model.lastExchangeAmount }} to {{model.exchangeResult.amount}} {{model.currency}}
                    </div>
            </div>
    </div>
    <div v-if="hasErrors">
        <div class="alert alert-danger">
            <div>
            {{ model.errorMessage}}
            </div>
            <div 
            v-for="error in model.errors"
            :key="error.name"></div>
        </div>        
    </div>
    </div>
</template>

<script>
import exchageService from '../api/exchangeService';
export default {
data() {
    return {
        model:{
            userId: 0,
            currency:"",
            amount:0,
            lastExchangeAmount:0,
            exchangeResult: {
                   id: 0,
                   userId: 0,
                   amount: 0.0,
                   currencyId: null,
                   currencyName: null           
            },
            errorMessage:"",
            errors:[]
        }              
    }
},
computed: {
    hasErrors() {
        return this.model.errorMessage != "";
    }
},
methods: {
    async exchangeCurrencies() {
        this.model.errorMessage="";
        let request = {
            userId: this.model.userId,
            amount: this.model.amount,        
            currencyCode: this.model.currency
        };
        try{
            let response = await exchageService.exchange(request);
            if(response){
                this.model.exchangeResult = response;
                this.model.lastExchangeAmount = request.amount;
            }
        } catch(error){          
            if(error.responseJSON.errors){
                this.model.errors = error.responseJSON.errors;
                this.model.errorMessage = error.responseJSON.title;
              
            }
            if(error.responseJSON.Message){
                this.model.errorMessage = error.responseJSON.Message;
            }
        }

    }
},
}
</script>

<style>

</style>
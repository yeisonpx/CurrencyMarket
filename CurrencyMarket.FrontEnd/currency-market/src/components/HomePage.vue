<template>
    <div class="mt-2">
    <div class="display-4">Currency Market Front-End</div>        
    <div class="mt-3">
        
    <router-link :to="{ name: 'cotizaciones'} " class="btn btn-lg btn-primary mr-3">Currencies Prices</router-link>
    <router-link :to="{ name: 'compra'} "  class="btn btn-lg btn-primary">Exchange Currencies</router-link>
    </div>
  </div>
</template>

<script>
export default {

}
</script>

<style>

</style>
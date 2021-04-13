<template>
  <div class="card my-3 mr-4">
      <div class="card-header">
          {{ name }}
      </div>
    <div class="card-body">
        <div class="card card-body">
            <div class="subtitle">Buy Price</div>
            <div class="buy-price">
             {{ buyPrice }}
            </div>
        </div>
        <div class="card card-body">
            <div class="subtitle">Sales Price</div>
            <div class="sale-price">
             {{ salesPrice}}
            </div>
        </div>                
    </div>
    <div class="card-footer">
        {{ message }}
    </div>
  </div>

</template>
<style scoped>
    .subtitle{
        font-size: 1.3em;
        font-weight: bold;
    }
</style>
<script>
export default {
props: {
    name: {
        type: String,
        default: ""
    },
    buyPrice:{
        type: Number,
        default: 0.00
    },
    salesPrice:{
        type:Number,
        default:0.00
    },
    message:{
        type: String,
        default:""
    }
},
}
</script>

<style scoped>
    .card{
        min-width: 400px;        
    }
</style>
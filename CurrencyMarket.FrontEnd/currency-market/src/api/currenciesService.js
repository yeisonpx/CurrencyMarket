import $ from 'jquery';

export default {
    getCurrencies: async function (code) {      
        console.log(process.env);
       return await $.get(`${process.env.VUE_APP_ROOT_API}/api/currencies/${code}`);
    }
};
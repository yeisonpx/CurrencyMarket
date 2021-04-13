import $ from 'jquery';

export default {
    getCurrencies: async function (code) {           
       return await $.get(`https://localhost:44392/api/currencies/${code}`);
    }
};
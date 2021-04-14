 import $ from 'jquery';
export default {
    exchange: async function (request){
        let promise = new Promise((resolve,reject)=>{
            $.ajax({
                method: "POST",
                url: "https://localhost:44392/api/exchanges",
                data: JSON.stringify(request),
                dataType:"json",
                contentType: 'application/json'
              }).done((data)=>{
                resolve(data);
              }).fail(error=>{
                  reject(error)
              });
        });
        return promise;
    }
}
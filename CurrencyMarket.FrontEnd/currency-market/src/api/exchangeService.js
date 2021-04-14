 import $ from 'jquery';
export default {
    exchange: async function (request){
        let promise = new Promise((resolve,reject)=>{
            $.ajax({
                method: "POST",
                url: `${process.env.VUE_APP_ROOT_API}/api/exchanges`,
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
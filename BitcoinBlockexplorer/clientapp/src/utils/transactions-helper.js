
const GridHelper = {
    install(Vue) {

        Vue.prototype.$outputTotal = function (transaction) {         
            let outputTotal = 0
            transaction.result.vout.forEach(vout => {
                outputTotal+=vout.value
            });
            return outputTotal
        }
    }
}

export default GridHelper
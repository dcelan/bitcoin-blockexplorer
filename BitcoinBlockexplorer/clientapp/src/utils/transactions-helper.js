import Axios from 'axios'

const GridHelper = {
    install(Vue) {

        Vue.prototype.$outputTotal = function (transaction) {         
            let outputTotal = 0
            transaction.result.vout.forEach(vout => {
                outputTotal+=vout.value
            });
            return outputTotal
        }

        Vue.prototype.$inputTotal = async function (transaction) {         
            let inputTotal
            let transactionOutput = 0

            await transaction.result.vin.forEach(vin => {
                Axios
                    .get('/api/BlockChainExplorer/getrawtransaction?transactionId=' + vin.txid)
                    .then(response => { 
                        transactionOutput = this.$outputTotal(response.data)
                    })
                    .finally(() => {
                        inputTotal=transactionOutput
                        console.log(inputTotal)
                    })
            });
            console.log(inputTotal)
            return inputTotal
        }  
    }
}

export default GridHelper
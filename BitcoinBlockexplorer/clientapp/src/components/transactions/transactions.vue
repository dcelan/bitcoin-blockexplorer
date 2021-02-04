<script>
import Axios from 'axios'
import TransactionDetails from '@components/transactions/transaction-details'

export default {
  components: {
    TransactionDetails
  },
  data() {
      return {
        loading: true,
        txDetails: null,
        transactionIds: null,
        transactions: [],
        previousBlockHash: null,
        fields: [ 
          { key: 'txid', label: "TXID", sortable: false },
          { key: 'result.size', label: "Size (B)", sortable: true },
          { key: 'value', label: "Output (tBTC)", sortable: false },
        ]
      }
  },
  created() {    
    Axios
        .all([
            Axios.get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getrawmempool", [false])),
            Axios.get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getbestblockhash", [])),        
        ])
        .then(
            Axios.spread((mempool, bestblock) => {              
              Axios
                .get('/api/BlockChainExplorer/getblock?blockHash=' + bestblock.data.result)
                .then(block => {
                  this.previousBlockHash = block.data.result.previousblockhash
                  this.transactionIds = mempool.data.result
                  this.transactionIds.push(...block.data.result.tx)
                  this.getTransactions(this.transactionIds.slice(0, 10))
                })
            })
        )
  },
  methods: {
    loadPreviousBlockTransactions() {
      Axios
        .get('/api/BlockChainExplorer/getblock?blockHash=' + this.previousBlockHash)
        .then(block => {
          this.previousBlockHash = block.data.result.previousblockhash
          this.transactionIds.push(...block.data.result.tx)
          this.loadMoreTransactions()
        })
    },
    loadMoreTransactions() {
      this.loading = true
      var increasement = 10
      if ((this.transactions.length + increasement) > this.transactionIds.length){
        increasement = this.transactionIds.length - this.transactions.length
      }
      if (increasement <= 0){
        this.loadPreviousBlockTransactions()
      } else {
        this.getTransactions(this.transactionIds.slice(this.transactions.length, this.transactions.length + increasement)) 
      }       
    },
    getTransactions(transactionIds){
      Axios
        .post('/api/BlockChainExplorer/getrawtransactions', transactionIds)
        .then(response => {          
            this.transactions.push(...response.data)
        })
        .finally(() => {
        this.loading = false
      })
    },
    showTransactionDetails(record){
      this.txDetails = record
    },
    back(){
      this.txDetails = null
    }
  }
}
</script>

<template>
  <b-overlay :show="loading" variant="white">
    <b-card class="mt-1 bg-white text-dark" style="padding:0 13rem">
      <div v-if="txDetails == null">
        <b-table outlined
                  hover
                  primary-key="hash"
                  :items="transactions"
                  :fields="fields"
                  id="data-table"
                  class="mb-2"
                  @row-clicked="showTransactionDetails"
                  style="cursor:pointer">  
                <template v-slot:cell(value)="row">
                      {{$outputTotal(row.item)}}
                </template>
                <template v-slot:cell(txid)="row">                      
                      <div class="text-info"> {{row.item.result.txid}} </div>
                </template>   
        </b-table>

        <div class="text-center" style="padding:0.5rem 0">
          <b-button @click="loadMoreTransactions" variant="outline-info">Load More <b-icon icon="arrow-down">
            </b-icon>
          </b-button>
        </div>
      </div>  

      <TransactionDetails v-else :txDetails="txDetails" @back="back" />
    </b-card>
  </b-overlay>  
</template>

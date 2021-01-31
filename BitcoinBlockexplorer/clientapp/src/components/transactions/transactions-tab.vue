<script>
import Axios from 'axios'
import TransactionDetails from '@components/transactions/transaction-details'

export default {
  components: {
    TransactionDetails
  },
  data() {
      return {
        startingTxDetails: null,
        rawMempool: null, //transactionIds
        transactions: [], //transactions from mempool shown on the screen
        fields: [ 
          { key: 'result.txid', label: "TXID", sortable: true },
          { key: 'result.size', label: "Size (B)", sortable: true },
          { key: 'value', label: "Output (tBTC)", sortable: true },
          // { key: 'value2', label: "Input (tBTC)", sortable: true },
          // { key: 'fee', label: "Fee (tBTC)", sortable: true },
        ]
      }
  },
  created() {
    Axios
      .get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getrawmempool", [false]))
      .then(response => {
          this.rawMempool = response.data.result
          this.getTransactions(response.data.result.slice(0, 10))
      })
      .catch(error => {
          this.$bvToast.toast(error.response.data,
              { title: "Error", variant: "danger", solid: true })
      })
  },
  methods: {
    loadMoreTransactions() {
      var increasement = 10
      if ((this.transactions.length + increasement) > this.rawMempool.length){
        increasement = this.rawMempool.length - this.transactions.length
      }
      if (increasement <= 0){
         this.$bvToast.toast("There are no more transactions in mempool. Try to refresh page or search for transaction.",
              { title: "Warning", variant: "info", solid: true })
      } else {
        this.getTransactions(this.rawMempool.slice(this.transactions.length, this.transactions.length + increasement))
      }      
    },
    getTransactions(transactionIds){
      Axios
        .post('/api/BlockChainExplorer/getrawtransactions', transactionIds)
        .then(response => {          
            this.transactions.push(...response.data)
        })
    },
    showTransactionDetails(record){
      this.startingTxDetails = record
    },
    back(){
      this.startingTxDetails = null
    }
  }
}
</script>

<template>
  <b-card class="mt-1">
    <div v-if="startingTxDetails == null">
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
              <!-- <template v-slot:cell(value2)="row">
                    {{$inputTotal(row.item)}}
              </template>    -->
              <!-- <template v-slot:cell(fee)="row">
                    {{$transactionFee(row.item)}}
              </template>    -->
      </b-table>

      <div class="text-center" style="padding:0.5rem 0">
        <b-button @click="loadMoreTransactions" variant="outline-secondary">Load More <b-icon icon="arrow-down">
          </b-icon>
        </b-button>
      </div>
    </div>  

    <TransactionDetails v-else :startingTxDetails="startingTxDetails" @back="back" />
  </b-card>
</template>

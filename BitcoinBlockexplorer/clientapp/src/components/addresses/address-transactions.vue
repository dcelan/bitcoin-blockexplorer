<script>
import Axios from 'axios'

export default {
    props: {
      transactionsIds: {
          type: Array
      },
  },
  data() {
      return {
        loading: true,
        transactions: [],
        fields: [ 
          { key: 'txid', label: "TXID", sortable: true },
          { key: 'result.size', label: "Size (B)", sortable: true },
          { key: 'value', label: "Output (tBTC)", sortable: true },
        ]
      }
  },
  created() {
    this.getTransactions(this.transactionsIds)
  },
  methods: {
    copyToClipboard(record){
      navigator.clipboard.writeText(record.result.txid)
          .then(()=> {                    
              this.$bvToast.toast("Transaction id copied to clipboard",
                  { title: "Success", variant: "info", solid: true, autoHideDelay:1000 })
          }, function(err) {
              console.error('Async: Could not copy to clipboard: ', err);
          });
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
  }
}
</script>

<template>
  <b-overlay :show="loading" variant="white">
    <b-card class="mt-1">
      <h5 class="card-title text-info" style="padding-bottom:0.8rem">Address transactions</h5> 
      
      <div class="bg-light text-dark">
        <b-table outlined
                  hover
                  primary-key="hash"
                  :items="transactions"
                  :fields="fields"
                  id="data-table"
                  class="mb-2"
                  @row-clicked="copyToClipboard"
                  style="cursor:pointer">  
                <template v-slot:cell(value)="row">
                      {{$outputTotal(row.item)}}
                </template>
                <template v-slot:cell(txid)="row">                      
                    <div class="text-info"> {{row.item.result.txid}} </div>
              </template>  
        </b-table>
      </div>  
    </b-card>
  </b-overlay>  
</template>

<script>
import Axios from 'axios'
import TransactionDetails from '@components/transactions/transaction-details'

export default {
    props: {
      transactionsIds: {
          type: Array
      },
  },
  components: {
    TransactionDetails
  },
  data() {
      return {
        loading: true,
        txDetails: null,
        transactions: [],
        fields: [ 
          { key: 'result.txid', label: "TXID", sortable: true },
          { key: 'result.size', label: "Size (B)", sortable: true },
          { key: 'value', label: "Output (tBTC)", sortable: true },
        ]
      }
  },
  created() {
    this.getTransactions(this.transactionsIds)
  },
  methods: {
    showTransactionDetails(record){
      this.txDetails = record
    },
    back(){
      this.txDetails = null
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
      <div class="col text-left title" style="color:#0275d8">Block transactions</div>
      <div class="w-100"><hr></div> 
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
        </b-table>
      </div>  

      <TransactionDetails v-else :txDetails="txDetails" @back="back" />
    </b-card>
  </b-overlay>  
</template>

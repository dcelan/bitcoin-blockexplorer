<script>
import Axios from 'axios'
import TransactionDetailsSimpleData from '@components/transactions/transaction-details-simple-data'
import TransactionDetailsInputOutput from '@components/transactions/transaction-details-input-output'
import TransactionDetailsRecipients from '@components/transactions/transaction-details-recipients'
import TransactionDetailsSenders from '@components/transactions/transaction-details-senders'
import AddressInfo from '@components/addresses/address-info'

export default {
  props: {
      txDetails: {
          type: Object
      },
  },
  components: {
    TransactionDetailsSimpleData,
    TransactionDetailsInputOutput,
    TransactionDetailsRecipients,
    TransactionDetailsSenders,
    AddressInfo
  },  
  data() {
      return {
        loading: true,
        address: null,
        transactionDetails: null,
        additionalTxDetails: null,
      }
  },
  created() {
    this.transactionDetails = this.txDetails
    this.getAdditionalTxDetails(this.txDetails.result.txid)
  },
  methods: {
    changeTransactionDetails(transactionId){
      this.loading = true
        Axios
          .get('/api/BlockChainExplorer/gettransaction?transactionId=' + transactionId)
          .then(response => {
              this.transactionDetails = response.data
              this.getAdditionalTxDetails(response.data.result.txid)
          })          
    },
    getAdditionalTxDetails(transactionId){
      Axios
          .get('/api/BlockChainExplorer/getadditionaltxinfo?transactionId=' + transactionId)
          .then(response => {
              this.additionalTxDetails = response.data.data[transactionId]
          })
          .finally(() => {
            this.loading = false
          })
    },
    showAddressInfo(address){
      this.address = address
    },
    back(){
      this.address = null
    }
  }
}
</script>

<template>
  <b-overlay :show="loading" variant="white">
    
    <div v-if="address == null">
      <div class="text-right">
        <b-button variant="outline-secondary" @click="$emit('back')"> Back</b-button>
      </div>

      <h5 class="card-title text-primary">Bitcoin transaction</h5>
      <p>{{transactionDetails.result.txid}} <b-icon @click="$copyToClipboard(transactionDetails.result.txid)"
          class="clickable-icon" icon="clipboard">
        </b-icon>
      </p>

      <div class="border-top-0" style="margin-top:-1px">
        <div class="card-body p-1">
          <b-row>
            <b-col lg="12" class="p-1">
              <TransactionDetailsSimpleData :transactionDetails="transactionDetails"  @change-transaction-details="changeTransactionDetails" />
            </b-col>
          </b-row>
          <b-row>
            <b-col lg="12" class="p-1">
              <TransactionDetailsInputOutput :transactionDetails="transactionDetails" :additionalTxDetails="additionalTxDetails" />
            </b-col>
          </b-row>
          <b-row>
            <b-col lg="6" class="p-1">
              <TransactionDetailsSenders :transactionDetails="transactionDetails" :additionalTxDetails="additionalTxDetails" @show-address-info="showAddressInfo" />
            </b-col>
            <b-col lg="6" class="p-1">
              <TransactionDetailsRecipients :transactionDetails="transactionDetails" :additionalTxDetails="additionalTxDetails" @show-address-info="showAddressInfo" />
            </b-col>
          </b-row>
        </div>
      </div>
    </div>

    <AddressInfo v-else :address="address" @back="back" />

  </b-overlay>
</template>
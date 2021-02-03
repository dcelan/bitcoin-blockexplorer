<script>
import Axios from 'axios'
// import TransactionDetailsSimpleData from '@components/transactions/transaction-details-simple-data'
// import TransactionDetailsInputOutput from '@components/transactions/transaction-details-input-output'
// import TransactionDetailsRecipients from '@components/transactions/transaction-details-recipients'
// import TransactionDetailsSenders from '@components/transactions/transaction-details-senders'

export default {
  props: {
      address: {
          type: String
      },
  },
  components: {
    // TransactionDetailsSimpleData,
    // TransactionDetailsInputOutput,
    // TransactionDetailsRecipients,
    // TransactionDetailsSenders
  },  
  data() {
      return {
        loading: true,
        addressInfo: null,
        additionalAddressInfo: null,
      }
  },
  created() {
    this.changeAddressInfo(this.address)
  },
  methods: {
    changeAddressInfo(address){
      if (!address.startsWith("d-"))
        this.getAddressInfo(address)
      this.getAdditionalAdrInfo(address)        
    },
    getAddressInfo(address){
      Axios
          .get('/api/BlockChainExplorer/getaddressinfo?address=' + address)
          .then(response => {
              this.addressInfo = response.data.result
          })
          .finally(() => {
            this.loading = false
          })
    },
    getAdditionalAdrInfo(address){
      Axios
          .get('/api/BlockChainExplorer/getadditionaladrinfo?address=' + address)
          .then(response => {
              this.additionalAddressInfo = response.data.data[address]
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
    
    <div v-if="addressInfo || additionalAddressInfo">
      <div class="text-right">
        <b-button variant="outline-secondary" @click="$emit('back')"> Back</b-button>
      </div>

      <h5 class="card-title text-primary">Address</h5>{{addressInfo}} {{additionalAddressInfo}}
      <!-- <p>{{addressInfo.result.txid}} <b-icon @click="$copyToClipboard(addressInfo.result.txid)"
          class="clickable-icon" icon="clipboard">
        </b-icon>
      </p>

      <div class="border-top-0" style="margin-top:-1px">
        <div class="card-body p-1">
          <b-row>
            <b-col lg="12" class="p-1">
              <TransactionDetailsSimpleData :addressInfo="addressInfo"  @change-transaction-details="changeAddressInfo" />
            </b-col>
          </b-row>
          <b-row>
            <b-col lg="12" class="p-1">
              <TransactionDetailsInputOutput :addressInfo="addressInfo" :additionalAddressInfo="additionalAddressInfo" />
            </b-col>
          </b-row>
          <b-row>
            <b-col lg="6" class="p-1">
              <TransactionDetailsSenders :addressInfo="addressInfo" :additionalAddressInfo="additionalAddressInfo" />
            </b-col>
            <b-col lg="6" class="p-1">
              <TransactionDetailsRecipients :addressInfo="addressInfo" :additionalAddressInfo="additionalAddressInfo" />
            </b-col>
          </b-row>
        </div>
      </div> -->

    </div>
  </b-overlay>
</template>
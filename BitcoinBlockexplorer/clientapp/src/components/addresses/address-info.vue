<script>
import Axios from 'axios'
import AddressInfoReceivedSpent from '@components/addresses/address-info-received-spent'
import AddressInfoSimpleData from '@components/addresses/address-info-simple-data'
import AddressInfoTransactions from '@components/addresses/address-transactions'

export default {
  props: {
      address: {
          type: String
      },
      search: {
        type: Boolean
      }
  },
  components: {
    AddressInfoReceivedSpent,
    AddressInfoSimpleData,
    AddressInfoTransactions
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
      if (this.addressInfo)
        this.getAdditionalAdrInfo(address)        
    },
    getAddressInfo(address){
      Axios
          .get('/api/BlockChainExplorer/getaddressinfo?address=' + address)
          .then(response => {
              this.addressInfo = response.data.result
          })
          .catch(error => {
              console.log(error.response.data)
              this.$bvToast.toast("No address: " + address,
                  { title: 'No result', variant: "secondary", solid: true, autoHideDelay:3000 })
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
    
    <div v-if="additionalAddressInfo">
      <div v-if="!search" class="text-right">
        <b-button variant="outline-secondary" @click="$emit('back')"> Back</b-button>
      </div>

      <h5 class="card-title text-info">Address</h5>
      <p>{{address}} <b-icon @click="$copyToClipboard(address)"
          class="clickable-icon" style="padding:0 0.6rem" icon="clipboard">
        </b-icon>
      </p>
   

      <div class="border-top-0" style="margin-top:-1px">
        <div class="card-body p-1">
          <b-row>
            <b-col lg="12" class="p-1">
              <AddressInfoSimpleData :addressInfo="addressInfo" :additionalAddressInfo="additionalAddressInfo" />
            </b-col>
          </b-row>
          <b-row>
            <b-col lg="12" class="p-1">
              <AddressInfoReceivedSpent :addressInfo="addressInfo" :additionalAddressInfo="additionalAddressInfo" />
            </b-col>
          </b-row>
          <b-row>
            <b-col lg="12" class="p-1">
              <AddressInfoTransactions :transactionsIds="additionalAddressInfo.transactions" />
            </b-col>
          </b-row>
        </div>
      </div>

    </div>
  </b-overlay>
</template>
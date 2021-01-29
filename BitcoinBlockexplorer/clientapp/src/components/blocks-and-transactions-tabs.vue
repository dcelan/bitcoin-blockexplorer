<script>
import Blocks from '@components/blocks-tab'
import Transactions from '@components/transactions-tab'

export default {
  components: {
    Blocks,
    Transactions
  },
  data() {
      return {
        test: null
      }
  },
  created() {
    // Axios
    //   .get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getrawtransaction", ["194413584f3920fe5c97566e0d43cbc5707da4d0f121ca1f5435007181cb003b"]))
    //   .then(response => {
    //       console.log(response.data)
    //       this.test = response.data
    //   })
    //   .catch(error => {
    //       this.$bvToast.toast(error.response.data,
    //           { title: this.$t('error'), variant: "danger", solid: true })
    //   })
  },
}
</script>

<template>
  <div>
    <b-tabs content-class="mt-3">
      <b-tab title="First" active><Blocks /></b-tab>
      <b-tab title="Second"><Transactions /></b-tab>
    </b-tabs>
  </div>
</template>

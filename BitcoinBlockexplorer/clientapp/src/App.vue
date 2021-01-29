<script>
import Axios from 'axios'

export default {
  name: 'App',
  components: {
    
  },
   data() {
      return {
        test: null
      }
  },
  created() {
      Axios
          .post('/api/BlockChainExplorer/getresults?queryJson={"jsonrpc": "1.0", "id":"curltest", "method": "getrawtransaction", "params": ["194413584f3920fe5c97566e0d43cbc5707da4d0f121ca1f5435007181cb003b"] }')
          .then(response => {
              console.log(response.data)
              this.test = response.data
          })
          .catch(error => {
              this.$bvToast.toast(error.response.data,
                  { title: this.$t('error'), variant: "danger", solid: true })
          })
  },
}
</script>

<template>
  <div id="app">
    {{test}}
  </div>
</template>

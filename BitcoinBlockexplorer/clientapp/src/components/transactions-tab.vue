<script>

export default {
  components: {
    
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
    <p>this is transactions tab</p>
  </div>
</template>

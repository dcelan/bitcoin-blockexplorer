<script>
import Axios from 'axios'
import PageHeader from '@components/layout/page-header'
import NavBar from '@components/layout/nav-bar'

export default {
  name: 'App',
  components: {
    PageHeader,
    NavBar
  },
  data() {
      return {
        test: null
      }
  },
  created() {
    Axios
      .get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getrawtransaction", ["194413584f3920fe5c97566e0d43cbc5707da4d0f121ca1f5435007181cb003b"]))
      .then(response => {
          this.test = response.data
      })
      .catch(error => {
          this.$bvToast.toast(error.response.data,
              { title: this.$t('error'), variant: "secondary", solid: true })
      })
  },
}
</script>

<template>
  <div>
    <NavBar />
    <PageHeader />
    <router-view> </router-view>
  </div>
</template>

<style>
    .clickable-icon {
        cursor:pointer
    }
    .clickable-text {
        cursor:pointer;
        color: #5bc0de;
    }
    .subtitle {
      color: #5bc0de;
      font-weight:bolder;
    }
    option:hover {
      background-color: #5bc0de;
    }
</style>

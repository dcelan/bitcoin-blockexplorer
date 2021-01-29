<script>
import Axios from 'axios'

export default {
  components: {
    
  },
  data() {
      return {
        rawMempool: null, //transactionIds
        mempoolEntries: [], //transactions from mempool shown on the screen
        fields: [ 
          { key: 'result.hash', label: "Test", sortable: true },
          { key: 'result.height', label: "Test", sortable: true },
          { key: 'result.difficulty', label: "Test", sortable: true },
          { key: 'result.size', label: "Test", sortable: true },
          { key: 'result.time', label: "Test", sortable: true },
          { key: 'result.weight', label: "Test", sortable: true },
        ]
      }
  },
  created() {
    Axios
      .get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getrawmempool", [false]))
      .then(response => {
          this.rawMempool = response.data.result
          this.getMempoolEntries(response.data.result.slice(0, 10))
      })
      .catch(error => {
          this.$bvToast.toast(error.response.data,
              { title: "Error", variant: "danger", solid: true })
      })
  },
  methods: {
    loadMoreMempoolEntries() {
      var increasement = 10
      if ((this.mempoolEntries.length + increasement) > this.rawMempool.length){
        increasement = this.rawMempool.length - this.mempoolEntries.length
      }
      if (increasement <= 0){
         this.$bvToast.toast("There is no more data to show. Try refreshing page.",
              { title: "Warrning", variant: "info", solid: true })
      } else {
        this.getMempoolEntries(this.rawMempool.slice(this.mempoolEntries.length, this.mempoolEntries.length + increasement))
      }      
    },
    getMempoolEntries(transactionIds){
      Axios
        .post('/api/BlockChainExplorer/getmempoolentries', transactionIds)
        .then(response => {          
            this.mempoolEntries.push(...response.data)
        })
    }
  }
}
</script>

<template>
  <div>
    <b-table outlined
              hover
              primary-key="hash"
              :items="mempoolEntries"
              :fields="fields"
              id="data-table"
              class="mb-2"
              style="cursor:pointer">           
    </b-table>
    <b-button @click="loadMoreMempoolEntries" block variant="outline-secondary">Load More</b-button>
  </div>
</template>

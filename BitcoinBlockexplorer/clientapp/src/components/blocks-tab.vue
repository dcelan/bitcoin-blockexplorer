<script>
import Axios from 'axios'

export default {
  components: {
    
  },
  data() {
      return {
        blocks: [],
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
      .get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getbestblockhash", []))
      .then(response => {
          this.getNLastBlocks(10, response.data.result)
      })
      .catch(error => {
          this.$bvToast.toast(error.response.data,
              { title: this.$t('error'), variant: "danger", solid: true })
      })
  },
  methods: {
    loadMoreBlocks() {
      var nextBlockHash = this.blocks[this.blocks.length - 1].result.previousblockhash
      this.getNLastBlocks(10, nextBlockHash)
    },
    getNLastBlocks(numberOfBlocks, startingBlockHash){
      Axios
        .get('/api/BlockChainExplorer/getnlastblocks?numberOfBlocks=' + numberOfBlocks + '&startingBlockHash=' + startingBlockHash)
        .then(response => {          
            this.blocks.push(...response.data)
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
              :items="blocks"
              :fields="fields"
              id="data-table"
              class="mb-2"
              style="cursor:pointer">           
    </b-table>
    <b-button @click="loadMoreBlocks" block variant="outline-secondary">Load More</b-button>
  </div>
</template>

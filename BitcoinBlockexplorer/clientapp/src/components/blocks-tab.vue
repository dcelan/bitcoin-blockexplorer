<script>
import Axios from 'axios'

export default {
  components: {
    
  },
  data() {
      return {
        blocks: [],
        fields: [ 
          { key: 'result.height', label: "Height", sortable: true },
          { key: 'time', label: "Time", sortable: true },
          { key: 'result.nTx', label: "Transactions", sortable: true },
          { key: 'size', label: "Size (KB)", sortable: true },
          { key: 'weight', label: "Weight (KWU)", sortable: true },
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
            <template v-slot:cell(time)="row">
                  {{$secondsToDateTime(row.item.result.time)}}
            </template>          
            <template v-slot:cell(size)="row">
                  {{$turnToKilo(row.item.result.size)}}
            </template>          
            <template v-slot:cell(weight)="row">
                  {{$turnToKilo(row.item.result.weight)}}
            </template>        
      </b-table>
    <b-button @click="loadMoreBlocks" block variant="outline-secondary">Load More</b-button>
  </div>
</template>

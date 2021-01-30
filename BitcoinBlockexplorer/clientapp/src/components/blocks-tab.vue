<script>
import Axios from 'axios'
import BlockDetails from '@components/blocks/block-details'

export default {
  components: {
    BlockDetails
  },
  data() {
      return {
        startingBlockDetails: null,
        blocks: [],
        fields: [ 
          { key: 'result.height', label: "Height", sortable: true },
          { key: 'time', label: "Time", sortable: true },
          { key: 'result.nTx', label: "Transactions", sortable: true },
          { key: 'size', label: "Size (kB)", sortable: true },
          { key: 'weight', label: "Weight (kWU)", sortable: true },
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
    },
    showBlockDetails(record){
      this.startingBlockDetails = record
    },
    back(){
      this.startingBlockDetails = null
    }
  }
}
</script>

<template>
  <b-card class="mt-1">
    <div v-if="startingBlockDetails == null">
      <b-table outlined
                hover
                primary-key="hash"
                :items="blocks"
                :fields="fields"
                id="data-table"
                class="mb-2"
                @row-clicked="showBlockDetails"
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
      
      <div class="text-center" style="padding:0.5rem 0">
        <b-button @click="loadMoreBlocks" variant="outline-secondary">Load More <b-icon icon="arrow-down"></b-icon></b-button>
      </div>
    </div>
    
    <BlockDetails v-else :startingBlockDetails="startingBlockDetails" @back="back" />
  </b-card>
</template>

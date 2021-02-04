<script>
import Axios from 'axios'
import BlockDetails from '@components/blocks/block-details'

export default {
  components: {
    BlockDetails
  },
  data() {
      return {
        loading: true,
        startingBlockDetails: null,
        blocks: [],
        fields: [ 
          { key: 'height', label: "Height", sortable: false },
          { key: 'time', label: "Time", sortable: false },
          { key: 'result.nTx', label: "Transactions", sortable: false },
          { key: 'size', label: "Size (kB)", sortable: false },
          { key: 'weight', label: "Weight (kWU)", sortable: false },
        ]
      }
  },
  created() {
    Axios
      .get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getbestblockhash", []))
      .then(response => {
          this.getNLastBlocks(10, response.data.result)
      })
  },
  methods: {
    loadMoreBlocks() {
      this.loading = true
      var nextBlockHash = this.blocks[this.blocks.length - 1].result.previousblockhash
      this.getNLastBlocks(10, nextBlockHash)
    },    
    getNLastBlocks(numberOfBlocks, startingBlockHash){
      Axios
        .get('/api/BlockChainExplorer/getnlastblocks?numberOfBlocks=' + numberOfBlocks + '&startingBlockHash=' + startingBlockHash)
        .then(response => {          
            this.blocks.push(...response.data)
        })
        .finally(() => {
          this.loading = false
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
  <b-overlay :show="loading" variant="white">
    <b-card class="mt-1 bg-white text-dark" style="padding:0 13rem">
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
                <template v-slot:cell(height)="row">                      
                      <div class="text-info"> {{row.item.result.height}} </div>
                </template>        
        </b-table>
        
        <div class="text-center" style="padding:0.5rem 0">
          <b-button @click="loadMoreBlocks" variant="outline-info">Load More <b-icon icon="arrow-down"></b-icon></b-button>
        </div>
      </div>
      
      <BlockDetails v-else :startingBlockDetails="startingBlockDetails" @back="back" />
    </b-card>

  </b-overlay>
</template>

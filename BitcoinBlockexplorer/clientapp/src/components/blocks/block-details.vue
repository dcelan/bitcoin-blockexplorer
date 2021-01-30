<script>
import Axios from 'axios'
import BlockDetailsSimpleData from '@components/blocks/block-details-simple-data'
import BlockDetailsLinks from '@components/blocks/block-details-links'
import BlockDetailsFees from '@components/blocks/block-details-fees'
import BlockDetailsFeeRates from '@components/blocks/block-details-fee-rates'

export default {
  props: {
      startingBlockDetails: {
          type: Object
      },
  },
  components: {
    BlockDetailsSimpleData,
    BlockDetailsLinks,
    BlockDetailsFees,
    BlockDetailsFeeRates
  },  
  data() {
      return {
        loading: true,
        blockDetails: null,
        blockStatistics: null
      }
  },
  created() {
    this.blockDetails = this.startingBlockDetails
    this.getBlockStatistics(this.blockDetails.result.height)
  },
  methods: {
    changeBlockDetails(blockHash){
      this.loading = true
        Axios
          .get('/api/BlockChainExplorer/getblock?blockHash=' + blockHash)
          .then(response => {
              this.blockDetails = response.data
              this.getBlockStatistics(response.data.result.height)
          })
    },
    getBlockStatistics(blockHeight){
      Axios
        .get('/api/BlockChainExplorer/getresultsfromhost?queryJson=' + this.$createRequestData("getblockstats", [blockHeight]))
        .then(response => {
            this.blockStatistics = response.data.result
        })
        .finally(() => {
          this.loading = false
        })
    }
  }
}
</script>

<template>
  <b-overlay :show="loading" variant="white">
    
    <div class="text-right">
      <b-button variant="light" @click="$emit('back')"> Back</b-button>
    </div>

    <h5 class="card-title text-primary">Bitcoin block <small class="text-muted"
        style="font-size:1.5rem">{{blockDetails.result.height}}</small></h5>

    <div class="border-top-0" style="margin-top:-1px">
      <div class="card-body p-1">
        <b-row>
          <b-col lg="12" class="p-1">
            <BlockDetailsLinks :blockDetails="blockDetails" :blockStatistics="blockStatistics" @change-block-details="changeBlockDetails" />
          </b-col>
        </b-row>
        <b-row>
          <b-col lg="12" class="p-1">
            <BlockDetailsSimpleData :blockDetails="blockDetails" :blockStatistics="blockStatistics" />
          </b-col>
        </b-row>
        <b-row>
          <b-col lg="6" class="p-1">
            <BlockDetailsFees :blockDetails="blockDetails" :blockStatistics="blockStatistics" />
          </b-col>
          <b-col lg="6" class="p-1">
            <BlockDetailsFeeRates :blockDetails="blockDetails" :blockStatistics="blockStatistics" />
          </b-col>
        </b-row>
      </div>
    </div>

  </b-overlay>
</template>
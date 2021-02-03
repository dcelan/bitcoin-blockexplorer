<script>
    export default {
        props: {
            blockDetails: {
                type: Object
            },
            blockStatistics: {
                type: Object
            },
        },
    }
</script>

<template>
    <b-card class="mt-1">
        <div v-if="blockDetails && blockStatistics">
            
           <div v-if="blockDetails.result.hash" style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Block</label>
               {{blockDetails.result.hash}} <b-icon @click="$copyToClipboard(blockDetails.result.hash)"
                   class="clickable-icon" style="padding:0 1rem" icon="clipboard">
               </b-icon>
           </div>

           <div v-if="blockDetails.result.previousblockhash" style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Previous
                   block</label>
               <div class="clickable-text"
                   @click="$emit('change-block-details', blockDetails.result.previousblockhash)">
                   {{blockDetails.result.previousblockhash}}</div>
               <b-icon @click="$copyToClipboard(blockDetails.result.previousblockhash)" class="clickable-icon"
                   style="padding:0 1rem" icon="clipboard">
               </b-icon>
           </div>

           <div v-if="blockDetails.result.nextblockhash" style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Next
                   block</label>
               <div class="clickable-text"
                   @click="$emit('change-block-details', blockDetails.result.nextblockhash)">
                   {{blockDetails.result.nextblockhash}}</div>
               <b-icon @click="$copyToClipboard(blockDetails.result.nextblockhash)" class="clickable-icon"
                   style="padding:0 1rem" icon="clipboard">
               </b-icon>
           </div>

           <div v-if="blockDetails.result.merkleroot" style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Merkle root</label>
               {{blockDetails.result.merkleroot}} <b-icon @click="$copyToClipboard(blockDetails.result.merkleroot)"
                   class="clickable-icon" style="padding:0 1rem" icon="clipboard">
               </b-icon>
           </div>
        </div>
    </b-card>
</template>

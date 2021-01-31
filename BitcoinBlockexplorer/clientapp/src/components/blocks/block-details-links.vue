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

            <div class="row">
                <div v-if="blockDetails.result.hash" class="col text-left title">Block</div>
                <div v-if="blockDetails.result.hash" class="col text-right">{{blockDetails.result.hash}} <b-icon
                        @click="$copyToClipboard(blockDetails.result.hash)" class="clickable-icon" icon="clipboard">
                    </b-icon>
                </div>
                <div class="w-100"></div>

                <div v-if="blockDetails.result.previousblockhash" class="col text-left title">Previous block</div>
                <div v-if="blockDetails.result.previousblockhash" class="col text-right clickable-text"
                    @click="$emit('change-block-details', blockDetails.result.previousblockhash)">
                    {{blockDetails.result.previousblockhash}} <b-icon
                        @click="$copyToClipboard(blockDetails.result.previousblockhash)" class="clickable-icon"
                        icon="clipboard" style="color:black"></b-icon>
                </div>
                <div class="w-100"></div>

                <div v-if="blockDetails.result.nextblockhash" class="col text-left title">Next block</div>
                <div v-if="blockDetails.result.nextblockhash" class="col text-right clickable-text"
                    @click="$emit('change-block-details', blockDetails.result.nextblockhash)">
                    {{blockDetails.result.nextblockhash}} <b-icon
                        @click="$copyToClipboard(blockDetails.result.nextblockhash)" class="clickable-icon"
                        icon="clipboard"></b-icon>
                </div>
                <div class="w-100"></div>

                <div class="col text-left title">Merkle root</div>
                <div class="col text-right" v-if="blockDetails.result.merkleroot">{{blockDetails.result.merkleroot}}
                    <b-icon @click="$copyToClipboard(blockDetails.result.merkleroot)" class="clickable-icon"
                        icon="clipboard">
                    </b-icon>
                </div>
                <div class="w-100"></div>
            </div>

        </div>
    </b-card>
</template>

<style>
    .title {
        font-size:1.2rem
    }
    .clickable-icon {
        cursor:pointer
    }
    .clickable-text {
        cursor:pointer;
        color: #0275d8;
    }
</style>

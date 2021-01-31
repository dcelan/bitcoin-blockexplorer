<script>
    export default {
        props: {
            transactionDetails: {
                type: Object
            },
        },
    }
</script>

<template>
    <b-card class="mt-1"> 
        <div v-if="transactionDetails">  

            <div class="row">
                <div v-if="transactionDetails.result.time != 0">
                    <div class="col text-left title">Time</div>
                    <div class="col text-right">{{$secondsToDateTime(transactionDetails.result.time)}}</div>
                    <div class="w-100"></div>
                </div>

                <div v-if="transactionDetails.result.blocktime != 0">
                    <div class="col text-left title">Block time</div>
                    <div class="col text-right">{{$secondsToDateTime(transactionDetails.result.blocktime)}}</div>
                    <div class="w-100"><hr></div>  
                </div>

                <div class="col text-left title">Size</div>
                <div class="col text-right">{{transactionDetails.result.size}} B</div>
                <div class="w-100"></div>                
                <div class="col text-left title">Virtual size</div>
                <div class="col text-right">{{transactionDetails.result.vsize}} vB</div>
                <div class="w-100"></div>                
                <div class="col text-left title">Weight units</div>
                <div class="col text-right">{{transactionDetails.result.weight}} WU</div>
                <div class="w-100"><hr></div>   

                <div class="col text-left title">Version</div>
                <div class="col text-right">{{transactionDetails.result.version}}</div>
                <div class="w-100"></div>                  
                <div class="col text-left title">Confirmations</div>
                <div class="col text-right">{{transactionDetails.result.confirmations}}</div>
                <div class="w-100"></div>                  
                <div class="col text-left title">Lock time</div>
                <div class="col text-right">{{transactionDetails.result.locktime}}</div>
                <div class="w-100"><hr></div>    

                <div class="w-100"></div>
                <div class="col text-left title">Transaction hash</div>
                <div class="col text-right" v-if="transactionDetails.result.hash"
                    @click="$emit('change-block-details', transactionDetails.result.hash)">
                    {{transactionDetails.result.hash}} <b-icon @click="$copyToClipboard(transactionDetails.result.hash)"
                        class="clickable-icon" icon="clipboard" style="color:black"></b-icon>
                </div>
                <div class="w-100"></div>
                <div class="col text-left title">Block hash</div>
                <div class="col text-right" v-if="transactionDetails.result.blockhash"
                    @click="$emit('change-block-details', transactionDetails.result.blockhash)">
                    {{transactionDetails.result.blockhash}} <b-icon
                        @click="$copyToClipboard(transactionDetails.result.blockhash)" class="clickable-icon"
                        icon="clipboard"></b-icon>
                </div>             
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
</style>

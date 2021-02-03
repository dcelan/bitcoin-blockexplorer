<script>
    export default {
        props: {
            transactionDetails: {
                type: Object
            },
        }
    }
</script>

<template>
    <b-card class="mt-1"> 
        <div v-if="transactionDetails"> 

            <div v-if="transactionDetails.result.hash" style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Transaction hash</label>
               {{transactionDetails.result.hash}} <b-icon @click="$copyToClipboard(transactionDetails.result.hash)"
                   class="clickable-icon" style="padding:0 1rem" icon="clipboard">
               </b-icon>
            </div> 
            <div v-if="transactionDetails.result.blockhash" style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Block hash</label>
               {{transactionDetails.result.blockhash}} <b-icon @click="$copyToClipboard(transactionDetails.result.blockhash)"
                   class="clickable-icon" style="padding:0 1rem" icon="clipboard">
               </b-icon>
            </div> 

            <div class="row">                
                <div v-if="transactionDetails.result.blockhash || transactionDetails.result.hash" class="w-100"><hr></div>
                <div v-if="transactionDetails.result.time" class="col text-left">Time</div>
                <div v-if="transactionDetails.result.time" class="col text-right">{{$secondsToDateTime(transactionDetails.result.time)}}</div>
                <div class="w-100"></div>
                <div v-if="transactionDetails.result.blocktime" class="col text-left">Block time</div>
                <div v-if="transactionDetails.result.blocktime" class="col text-right">{{$secondsToDateTime(transactionDetails.result.blocktime)}}</div>
                <div v-if="transactionDetails.result.blocktime" class="w-100"><hr></div>

                <div class="col text-left">Size</div>
                <div class="col text-right">{{transactionDetails.result.size}} B</div>
                <div class="w-100"></div>                
                <div class="col text-left">Virtual size</div>
                <div class="col text-right">{{transactionDetails.result.vsize}} vB</div>
                <div class="w-100"></div>                
                <div class="col text-left">Weight units</div>
                <div class="col text-right">{{transactionDetails.result.weight}} WU</div>
                <div class="w-100"><hr></div>   

                <div class="col text-left">Version</div>
                <div class="col text-right">{{transactionDetails.result.version}}</div>
                <div class="w-100"></div>                  
                <div class="col text-left">Confirmations</div>
                <div class="col text-right">{{transactionDetails.result.confirmations}}</div>
                <div class="w-100"></div>                  
                <div class="col text-left">Lock time</div>
                <div class="col text-right">{{transactionDetails.result.locktime}}</div>                
            </div>            
        </div>           
    </b-card>
</template>
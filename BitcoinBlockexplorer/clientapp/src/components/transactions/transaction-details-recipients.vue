<script>
    export default {
        props: {
            transactionDetails: {
                type: Object
            },
            additionalTxDetails: {
                type: Object
            },
        },
        data() {
            return {
                loading: true,
            }
        },
        created() {
            
        }
    }
</script>

<template>
    <b-card class="mt-1"> 
        <div v-if="transactionDetails && additionalTxDetails">            
            <div class="col text-left subtitle">Recipients</div>
            <div class="w-100"><hr></div>

            <div v-for="output in additionalTxDetails.outputs" :key="output.script_hex">
                <b-row>                    
                    <b-col class="lg-6 text-left clickable-text" @click="$emit('show-address-info', output.recipient)">
                        {{output.recipient}}
                    </b-col>
                    <b-col class="lg-6 text-right">{{$satoshiToBTC(output.value)}} tBTC</b-col>
                    <div class="w-100"><hr></div>
                </b-row>                    
            </div>                        
        </div>           
    </b-card>
</template>
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
            <div class="col text-left title" style="color:#0275d8">Senders</div>
            <div class="w-100"><hr></div>

            <div v-for="input in additionalTxDetails.inputs" :key="input.script_hex">
                <b-row>      
                    <b-col class="lg-6 text-left">{{$satoshiToBTC(input.value)}} tBTC</b-col>              
                    <b-col class="lg-6 text-right">{{input.recipient}}</b-col>  
                    <div class="w-100"><hr></div>                  
                </b-row>                    
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

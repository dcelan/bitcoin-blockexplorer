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
    }
</script>

<template>
    <b-card class="mt-1"> 
        <div v-if="transactionDetails && additionalTxDetails">  
           
            <b-row>
                <div class="col text-left title" style="color:#0275d8">Amount</div>
                <div class="w-100"><hr></div>
                <b-col class="lg-6">   
                    <b-row>
                        <div class="col text-left title">Input total</div>
                        <div class="col text-right" style="padding-top:0.27rem">{{$satoshiToBTC(additionalTxDetails.transaction.input_total)}} tBTC</div>
                        <div class="w-100"><hr></div>
                        <div class="col text-left title">Transaction fee</div>
                        <div class="col text-right">{{$satoshiToBTC(additionalTxDetails.transaction.fee)}} tBTC</div>
                    </b-row>
                </b-col>

                <b-col class="lg-6">
                    <b-row>
                        <div class="col text-left title">Output total</div>
                        <div class="col text-right" style="padding-top:0.27rem">{{$satoshiToBTC(additionalTxDetails.transaction.output_total)}} tBTC</div>
                        <div class="w-100"><hr></div>
                        <div class="col text-left title">Fee per byte</div>
                        <div class="col text-right">{{$turnToKilo(additionalTxDetails.transaction.fee_per_kb)}} sat</div>
                        <div class="w-100"></div>
                    </b-row>                   
                </b-col>
            </b-row>              
        </div>           
    </b-card>
</template>

<style>
    .title {
        font-size:1.2rem
    }
</style>

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
                <div class="col text-left title">Time</div>
                <div class="col text-right">{{$secondsToDateTime(blockDetails.result.time)}}</div>
                <div class="w-100"></div>                
                <div class="col text-left title">Transactions</div>
                <div class="col text-right">{{blockDetails.result.nTx}}</div>
                <div class="w-100"><hr></div>

                <div class="col text-left title">Size</div>
                <div class="col text-right">{{$turnToKilo(blockDetails.result.size)}} kB</div>
                <div class="w-100"></div>                
                <div class="col text-left title">Stripped size</div>
                <div class="col text-right">{{$turnToKilo(blockDetails.result.strippedsize)}} kB</div>
                <div class="w-100"></div>                
                <div class="col text-left title">Weight</div>
                <div class="col text-right">{{$turnToKilo(blockDetails.result.weight)}} kWU</div>
                <div class="w-100"><hr></div>   

                <div class="col text-left title">Confirmations</div>
                <div class="col text-right">{{blockDetails.result.confirmations}}</div>
                <div class="w-100"></div>   
                <div class="col text-left title">Network difficulty</div>
                <div class="col text-right">{{Math.trunc(blockDetails.result.difficulty).toLocaleString()}}</div>
                <div class="w-100"><hr></div>  

                <div class="col text-left title">Version</div>
                <div class="col text-right">0x{{blockDetails.result.versionHex}}</div>
                <div class="w-100"></div>                
                <div class="col text-left title">Bits</div>
                <div class="col text-right">0x{{blockDetails.result.bits}}</div>
                <div class="w-100"></div>                
                <div class="col text-left title">Nonce</div>
                <div class="col text-right">0x{{blockDetails.result.nonce.toString(16)}}</div>
                <div class="w-100"><hr></div>  

                <div class="col text-left title">Block reward</div>
                <div class="col text-right">{{$satoshiToBTC(blockStatistics.subsidy)}} tBTC</div>
                <div class="w-100"></div>                
                <div class="col text-left title">Fee reward</div>
                <div class="col text-right">{{$satoshiToBTC(blockStatistics.totalfee)}} tBTC</div>
                <div class="w-100"></div>                
            </div>            
        </div>           
    </b-card>
</template>

<style>
    .title {
        font-size:1.2rem
    }
</style>

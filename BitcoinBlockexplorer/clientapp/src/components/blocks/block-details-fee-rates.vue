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
                <div class="col text-left title" style="color:#0275d8">Fee rate</div>
                <div class="w-100"><hr></div>  
                <div class="col text-left title">Maximal</div>
                <div class="col text-right">{{blockStatistics.maxfeerate}} Satoshi/vByte</div>
                <div class="w-100"></div>  
                <div class="col text-left title">Minimal</div>
                <div class="col text-right">{{blockStatistics.minfeerate}} Satoshi/vByte</div>
                <div class="w-100"></div>  
                <div class="col text-left title">Average</div>
                <div class="col text-right">{{blockStatistics.avgfeerate}} Satoshi/vByte</div>
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

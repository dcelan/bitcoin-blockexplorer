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
                <div class="col text-left subtitle">Fee rate</div>
                <div class="w-100"><hr></div>  
                <div class="col text-left">Maximal</div>
                <div class="col text-right">{{blockStatistics.maxfeerate}} sat/vByte</div>
                <div class="w-100"></div>  
                <div class="col text-left">Minimal</div>
                <div class="col text-right">{{blockStatistics.minfeerate}} sat/vByte</div>
                <div class="w-100"></div>  
                <div class="col text-left">Average</div>
                <div class="col text-right">{{blockStatistics.avgfeerate}} sat/vByte</div>
                <div class="w-100"></div>                                         
            </div>  

        </div>           
    </b-card>
</template>

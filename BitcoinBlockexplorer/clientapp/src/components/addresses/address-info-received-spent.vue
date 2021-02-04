<script>
    export default {
        props: {
            addressInfo: {
                type: Object
            },
            additionalAddressInfo: {
                type: Object
            },
        },
    }
</script>

<template>
    <b-card class="mt-1"> 
        <div v-if="addressInfo && additionalAddressInfo">  
           
            <b-row>
                <b-col class="lg-6">   
                    <b-row>
                        <div class="col text-left">Total received</div>
                        <div class="col text-right">{{$satoshiToBTC(additionalAddressInfo.address.received)}} tBTC
                            / {{additionalAddressInfo.address.received_usd}} USD</div>
                        <div class="w-100"><hr></div>
                        <div class="col text-left">First seen receiving</div>
                        <div class="col text-right">{{additionalAddressInfo.address.first_seen_receiving}}</div>
                        <div class="w-100"></div>
                        <div class="col text-left">Last seen receiving</div>
                        <div class="col text-right">{{additionalAddressInfo.address.last_seen_receiving}}</div>
                        <div class="w-100"></div>
                    </b-row>
                </b-col>

                <b-col class="lg-6">
                    <b-row>
                        <div class="col text-left">Total spent</div>
                        <div class="col text-right">{{$satoshiToBTC(additionalAddressInfo.address.spent)}} tBTC
                            / {{additionalAddressInfo.address.spent_usd}} USD</div>
                        <div class="w-100"><hr></div>
                        <div class="col text-left">First seen spending</div>
                        <div class="col text-right">{{additionalAddressInfo.address.first_seen_spending}}</div>
                        <div class="w-100"></div>
                        <div class="col text-left">Last seen spending</div>
                        <div class="col text-right">{{additionalAddressInfo.address.last_seen_spending}}</div>
                        <div class="w-100"></div>
                    </b-row>
                </b-col>
            </b-row>              
        </div>           
    </b-card>
</template>
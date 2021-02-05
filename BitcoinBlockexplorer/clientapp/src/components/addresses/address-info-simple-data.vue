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
        <div v-if="additionalAddressInfo">            
           <div v-if="additionalAddressInfo.address.script_hex" style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Script</label>
               {{additionalAddressInfo.address.script_hex}} <b-icon @click="$copyToClipboard(additionalAddressInfo.address.script_hex)"
                   class="clickable-icon" style="padding:0 1rem" icon="clipboard">
               </b-icon>
           </div>

           <div style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Address type</label>
               {{additionalAddressInfo.address.type}}
           </div>  

            <b-row>
                <b-col class="lg-6">   
                    <b-row>
                        <div class="col text-left">Balance</div>
                        <div class="col text-right" style="padding-top:0.27rem">{{$satoshiToBTC(additionalAddressInfo.address.balance)}} tBTC
                            / {{additionalAddressInfo.address.balance_usd}} USD</div>
                        <div class="w-100"></div>
                    </b-row>
                </b-col>
            </b-row>  

           <div class="w-100"><hr></div>       
           <div style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Transaction count</label>
               {{additionalAddressInfo.address.transaction_count}}
           </div>          
           <div style="display:flex; align-items:center;">
               <label style="width:500rem; word-break:break-word; margin-bottom: 0; margin-right: 5px;">Output count / Unspent output count</label>
               {{additionalAddressInfo.address.output_count}}/{{additionalAddressInfo.address.unspent_output_count}}
           </div>          
        </div>
    </b-card>
</template>

<script>
import Axios from 'axios'
import Transaction from '@components/transactions/transaction-details'
import Block from '@components/blocks/block-details'
import Address from '@components/addresses/address-info'

export default {
    components: {
        Transaction,
        Block,
        Address
    },
    data() {
        return {
            loading: false,
            activeComponent: null,
            option: null,
            input: '',
            options: [ 
                { name: 'Block', value: 1 },
                { name: 'Transaction', value: 2 },
                { name: 'Address', value: 3 },
            ],
            address: null,
            block: null,
            transaction: null
        }
    },  
    methods: {
        search() {
            if (this.input.length != 0){

                this.loading = true
                this.resetValues()
                switch (this.option) {
                    case 1: 
                        Axios
                            .get('/api/BlockChainExplorer/getblock?blockHash=' + this.input)
                            .then(block => {
                                this.block = block.data
                                this.activeComponent = 'Block'
                            })    
                            .catch(error => {
                                console.log(error.response.data)
                                this.$bvToast.toast("No block with block hash: " + this.input,
                                    { title: 'No result', variant: "secondary", solid: true, autoHideDelay:3000 })
                            })   
                            .finally(() => {
                                this.loading = false
                            })                    
                        break;
                    case 2: 
                        Axios
                            .get('/api/BlockChainExplorer/getrawtransaction?transactionId=' + this.input)
                            .then(transaction => {
                                this.transaction = transaction.data
                                this.activeComponent = 'Transaction'
                            })     
                            .catch(error => {
                                console.log(error.response.data)
                                this.$bvToast.toast("No transaction with transaction id: " + this.input,
                                    { title: 'No result', variant: "secondary", solid: true, autoHideDelay:3000 })
                            })   
                            .finally(() => {
                                this.loading = false
                            })                    
                        break;
                    case 3: 
                        this.address = this.input
                        this.activeComponent = 'Address'
                        this.loading = false
                        break;                
                    default:
                        break;
                }
            }            
        },
        resetValues(){
            this.activeComponent = null;
            this.address = null;
            this.block = null;
            this.transaction = null;
        }
    }
}
</script>

<template>
    <div>
        <div style="padding-left:20rem;padding-right:20rem;padding-bottom:5rem">
            <b-input-group>
                <template #prepend>
                    <select class="form-control" v-model="option">
                        <option value="null" disabled>Choose</option>
                        <option v-for="option in options" v-bind:value="option.value" v-bind:key="option.value">
                            {{ option.name }}
                        </option>
                    </select>
                </template>

                <b-form-input :disabled="option==null" style="padding-left:1rem" v-model="input" placeholder="Search for block hash, transaction id or address"></b-form-input>
                
                <b-input-group-append>
                    <b-button variant="outline-info" @click="search"> Search</b-button>
                </b-input-group-append>            
            </b-input-group>
        </div>

        <div style="padding:0 13rem">
            <b-overlay :show="loading" variant="white">
                <component :is="activeComponent" :startingBlockDetails="block" :txDetails="transaction" :address="address" :search="true" />
            </b-overlay>
        </div>        
    </div>
</template>

<script>
import Blocks from '@components/blocks/blocks-tab'
import Transactions from '@components/transactions/transactions-tab'
import PageHeader from '@components/layout/page-header'

export default {
  components: {
    Blocks,
    Transactions,
    PageHeader
  },
}
</script>

<template>
  <div>
    <PageHeader />
    <b-tabs content-class="mt-3">
      <b-tab title="Blocks" active><Blocks /></b-tab>
      <b-tab title="Transactions"><Transactions /></b-tab>
    </b-tabs>
  </div>
</template>

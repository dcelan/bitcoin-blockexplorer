<script>
import PageHeader from '@components/layout/page-header'
import NavBar from '@components/layout/nav-bar'

export default {
  name: 'App',
  components: {
    PageHeader,
    NavBar
  }
}
</script>

<template>
  <div>
    <NavBar />
    <PageHeader />
    <router-view> </router-view>
  </div>
</template>

<style>
    .clickable-icon {
        cursor:pointer
    }
    .clickable-text {
        cursor:pointer;
        color: #5bc0de;
    }
    .subtitle {
      color: #5bc0de;
      font-weight:bolder;
    }
</style>

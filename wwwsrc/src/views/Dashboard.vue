<template>
  <div class="Dashboard">
    <div class="row">
      <div class="col-4 offset-4">
        <h2>Dashboard</h2>
      </div>
      <div class="col-4">
        <router-link :to="{name: 'home'}">Home</router-link>
      </div>
    </div>
    <h3>Your Vaults</h3>
    <div class="row">
      <DashBoardVaults v-for="vault in vaults" v-bind:vault="vault" />
    </div>
    <div class="row">

    </div>
  </div>
</template>

<script>
  import DashBoardVaults from "@/components/DashBoardVaults.vue"
  import DashBoardKeeps from "@/components/DashBoardKeeps.vue"
  export default {
    name: "",
    props: [],
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {},
    components: {
      DashBoardKeeps,
      DashBoardVaults
    },
    mounted() {
      this.$store.dispatch("getUserVaults");
      this.$store.dispatch("getAllKeeps")
    }
  }
</script>
<template>
  <div class="uniqueVault">
    <div class="row">
      <div class="col-4 offset-4">
        <h3 v-if="activeVault">{{activeVault.name}}</h3>
        <h3 v-else>Loading...</h3>

      </div>
      <div class="col-4 d-flex justify-content-around">
        <router-link :to="{name: 'home'}">Home</router-link>
        <router-link :to="{name: 'dashboard'}">My Dashboard</router-link>
      </div>

    </div>
    <div class="row">
      <VaultKeep v-for="keep in vaultKeeps" v-bind:keep="keep" v-bind:vaultId="vaultId" />
    </div>
  </div>
</template>
<script>
  import VaultKeep from "@/components/VaultKeep.vue"
  export default {
    name: "vault",
    props: ["vaultId"],
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch("getUserVaults");
      this.$store.dispatch("getKeepsByVault", this.vaultId)
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.activeVaultKeeps
      },
      activeVault() {
        return this.$store.state.vaults.find(v => v.id == this.vaultId)
      }
    },
    methods: {},
    components: {
      VaultKeep
    }
  }
</script>
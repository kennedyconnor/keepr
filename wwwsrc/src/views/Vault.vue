<template>
  <div class="uniqueVault">
    <h3>Keeps</h3>
    <ul>
      <li v-for="keep in vaultKeeps">
        {{keep.name}}
        <img :src="keep.img" alt="">
      </li>
    </ul>
  </div>
</template>

<script>
  export default {
    name: "vault",
    props: ["vaultId"],
    data() {
      return {}
    },
    mounted() {
      this.$store.commit("setActiveVault", this.$store.state.vaults.filter(v => v.id = this.vaultId))
      this.$store.dispatch("getKeepsByVault", this.vaultId)
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.activeVaultKeeps
      }
    },
    methods: {},
    components: {}
  }
</script>
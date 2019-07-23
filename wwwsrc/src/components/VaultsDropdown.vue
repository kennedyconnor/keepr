<template>
  <div class="col-4">
    <div class="dropdown">
      <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
        aria-haspopup="true" aria-expanded="false">
        My Vaults
      </button>
      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
        <a class="dropdown-item" @click="selectVault(vault.id)" v-for="vault in vaults">{{vault.name}}</a>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
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
    methods: {
      selectVault(vaultId) {
        this.$router.push({ name: "vaults", params: { vaultId } })
      }
    },
    components: {}
  }
</script>
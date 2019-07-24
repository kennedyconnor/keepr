<template>
  <div class="col-4">
    <div class="card">
      <div class="card-body ">
        <h4 class="card-title">{{vault.name}}</h4>
        <p>{{vault.description}}</p>
        <button class="btn btn-primary" @click="toVault(vault.id)">View</button>
        <button class="btn btn-danger" @click="deleteVault()">Delete</button>

      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "DashboardVaults",
    props: ["vault"],
    data() {
      return {}
    },
    methods: {
      toVault(vaultId) {
        this.$router.push({ name: "vaults", params: { vaultId } })
      },
      deleteVault() {
        this.$store.dispatch("deleteVault", this.vault.id)
      }
    },
    components: {}

  }
</script>
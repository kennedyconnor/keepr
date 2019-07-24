<template>
  <div class="Keeps row">

    <div class="col-4" v-if="user.id" v-for="keep in keeps">
      <div class="card">
        <img class="card-img-top" :src="keep.img">
        <div class="card-body d-flex justify-content-around">
          <a class="btn btn-success" data-toggle="modal" data-target="#viewModal" @click="viewedKeep = keep">View</a>
          <a class="dropdown">
            <button class="btn btn-secondary" type="button" id="dropdownMenuButton" data-toggle="dropdown"
              aria-haspopup="true" aria-expanded="false">
              Keep
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <a class="dropdown-item" @click="addKeep(vault.id,keep.id)" v-for="vault in vaults">{{vault.name}}</a>
            </div>
          </a>
          <a class="btn btn-warning">Share</a>
        </div>
      </div>
    </div>

    <div class="col-4" v-if="!user.id" v-for="keep in publicKeeps">
      <div class="card">
        <img class="card-img-top" :src="keep.img">
        <div class="card-body">
          <a class="btn btn-success">View</a>
          <a class="btn btn-primary">Keep</a>
          <a class="btn btn-warning">Share</a>
        </div>
      </div>
    </div>

    <div class="modal fade" id="viewModal" tabindex="-1" aria-labelledby="viewModalTitle" aria-hidden="true">
      <div class="modal-dialog  modal-xl">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="viewModalLongTitle">{{viewedKeep.name}}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <img class="modalKeepImage" :src="viewedKeep.img" alt="">
            <p>{{viewedKeep.description}}</p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "Keeps",
    props: [],
    data() {
      return {
        viewedKeep: {}
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      keeps() {
        return this.$store.state.keeps
      },
      publicKeeps() {
        return this.$store.state.keeps.filter(k => !k.isPrivate)
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      addKeep(vaultId, keepId) {
        let newVaultKeep = { vaultId, keepId }
        this.$store.dispatch("createVaultKeep", newVaultKeep)
      }
    },
    components: {}
  }
</script>
<style>
  .modalKeepImage {
    max-width: 100%;
  }
</style>
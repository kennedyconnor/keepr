<template>
  <div class="keepcard col-4">


    <div class="card">
      <img class="card-img-top" :src="keep.img">
      <div class="card-body d-flex justify-content-around">
        <a class="btn btn-success" data-toggle="modal" :data-target="'#modal'+keep.id" @click="viewKeep()">View</a>
        <a>{{keep.views}}</a>
        <a class="dropdown">
          <button class="btn btn-secondary" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Keep
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <a class="dropdown-item" @click="addKeep(vault.id)" v-for="vault in vaults">{{vault.name}}</a>
          </div>
        </a>
        <a>{{keep.keeps}}</a>
        <a class="btn btn-warning" @click="shareKeep()">Share</a>
        <a>{{keep.shares}}</a>
      </div>
    </div>


    <div :class="'modal fade '+ keep.id" :id="'modal'+keep.id" tabindex="-1" aria-labelledby="viewModalTitle"
      aria-hidden="true">
      <div class="modal-dialog  modal-xl">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="viewModalLongTitle">{{keep.name}}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <img class="modalKeepImage" :src="keep.img" alt="">
            <p>{{keep.description}}</p>
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
    name: "",
    props: ["keep"],
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      viewKeep(keep) {
        this.viewedKeep = keep;
        this.keep.views++;
        this.$store.dispatch("editKeep", this.keep)

      },
      addKeep(vaultId, keepId) {
        let newVaultKeep = { vaultId, keepId }
        this.$store.dispatch("createVaultKeep", newVaultKeep)
        this.keep.keeps++;
        this.$store.dispatch("editKeep", this.keep)
      },
      shareKeep() {
        this.keep.shares++;
        this.$store.dispatch("editKeep", this.keep)
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
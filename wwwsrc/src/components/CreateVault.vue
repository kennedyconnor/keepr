<template>
  <div class="col-4 ">

    <button class="btn btn-success" data-toggle="modal" data-target="#vaultModal">
      New Vault
    </button>


    <div class="modal fade" id="vaultModal" tabindex="-1" role="dialog" aria-labelledby="vaultModalTitle"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="form">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="vaultModalLongTitle">Create A Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form class="modal-body">
            <div class="form-group">
              <input type="text" class="form-control" id="keepName" placeholder="Name" v-model="name">
            </div>
            <div class="form-group">
              <input type="text" class="form-control" id="keepDesc" placeholder="Description" v-model="description">
            </div>
          </form>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary" data-dismiss="modal" @click="createVault()">Create</button>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "CreateKeep",
    props: [],
    data() {
      return {
        name: "",
        description: "",
      }
    },
    computed: {},
    methods: {
      createVault() {
        if (this.name == "" || this.description == "") {
          alert("Please fill out the required fields.")
          return
        }
        let newVault = {
          name: this.name,
          description: this.description,
        }
        this.$store.dispatch("createVault", newVault)
        this.name = ""
        this.description = ""
      }
    },
    components: {}
  }
</script>
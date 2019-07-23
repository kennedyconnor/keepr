<template>
  <div class="col-4 ">

    <button class="btn btn-success" data-toggle="modal" data-target="#keepModal">
      New Vault
    </button>


    <div class="modal fade" id="keepModal" tabindex="-1" role="dialog" aria-labelledby="keepModalTitle"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="form">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="keepModalLongTitle">Create A Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form class="modal-body">
            <div class="form-group">
              <input type="text" class="form-control" id="keepName" placeholder="Name" v-model="newKeep.name">
            </div>
            <div class="form-group">
              <input type="text" class="form-control" id="keepDesc" placeholder="Description"
                v-model="newKeep.description">
            </div>
            <div class="form-group">
              <input type="text" class="form-control" id="keepImg" placeholder="Image URL" v-model="newKeep.img">
            </div>
            <div class="form-check">
              <input class="form-check-input" type="checkbox" v-model="newKeep.isPrivate" id="defaultCheck1">
              <label class="form-check-label" for="defaultCheck1">
                Private
              </label>
            </div>
          </form>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Create</button>
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
        newKeep: {
          name: "",
          description: "",
          img: "",
          isPrivate: false
        },
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {},
    methods: {},
    components: {}
  }
</script>
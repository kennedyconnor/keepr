<template>
  <div class="col-4 offset-2">

    <button class="btn btn-success" data-toggle="modal" data-target="#keepModal">
      New Keep
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
              <input type="text" class="form-control" id="keepName" placeholder="Name" v-model="name">
            </div>
            <div class="form-group">
              <input type="text" class="form-control" id="keepDesc" placeholder="Description" v-model="description">
            </div>
            <div class="form-group">
              <input type="text" class="form-control" id="keepImg" placeholder="Image URL" v-model="img">
            </div>
            <div class="form-check">
              <input class="form-check-input" type="checkbox" v-model="isPrivate" id="defaultCheck1">
              <label class="form-check-label" for="defaultCheck1">
                Private
              </label>
            </div>
          </form>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary" data-dismiss="modal" @click="createKeep()">Create</button>
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
        img: "",
        isPrivate: false
      }
    },
    computed: {},
    methods: {
      createKeep() {
        if (this.name == "" || this.description == "" || this.img == "") {
          alert("Please fill out the required fields.")
          return
        }
        let newKeep = {
          name: this.name,
          description: this.description,
          img: this.img,
          isPrivate: this.isPrivate
        }
        this.$store.dispatch("createKeep", newKeep)
        name = ""
        description = ""
        img = ""
        isPrivate = false

      }
    },
    components: {}
  }
</script>
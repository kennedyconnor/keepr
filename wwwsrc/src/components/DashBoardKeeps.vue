<template>
  <div class="col-3">
    <div class="card">
      <img class="card-img-top" :src="keep.img">
      <div class="card-body d-flex justify-content-around">
        <a class="btn btn-primary" data-toggle="modal" :data-target="'#modal'+keep.id">View</a>
        <a class="btn btn-danger" @click="deleteKeep()">Delete</a>

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
    name: "Dashboard Keeps",
    props: ["keep"],
    data() {
      return {}
    },
    computed: {},
    methods: {
      deleteKeep() {
        this.$store.dispatch("deleteKeep", this.keep.id)
      }
    },
    components: {}
  }
</script>
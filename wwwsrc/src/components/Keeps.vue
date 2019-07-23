<template>
  <div class="Keeps row">
    <div class="col-4" v-for="keep in keeps">
      <div class="card">
        <img class="card-img-top" :src="keep.img">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <a class="btn btn-primary">Keep</a>
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
      return {}
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {},
    components: {}
  }
</script>
<template>
  <div class="Keeps row">
    <div class="col-4" v-if="user.id" v-for="keep in keeps">
      <div class="card">
        <img class="card-img-top" :src="keep.img">
        <div class="card-body">
          <a class="btn btn-primary">Keep</a>
        </div>
      </div>
    </div>
    <div class="col-4" v-if="!user.id" v-for="keep in publicKeeps">
      <div class="card">
        <img class="card-img-top" :src="keep.img">
        <div class="card-body">
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
      user() {
        return this.$store.state.user
      },
      keeps() {
        return this.$store.state.keeps
      },
      publicKeeps() {
        return this.$store.state.keeps.filter(k => !k.isPrivate)
      }
    },
    methods: {},
    components: {}
  }
</script>
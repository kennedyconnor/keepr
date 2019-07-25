<template>
  <div class="Keeps row">

    <KeepCard v-if="user.id" v-for="keep in keeps" v-bind:keep="keep" />


    <div class="col-3" v-if="!user.id" v-for="keep in publicKeeps">
      <div class="card">
        <img class="card-img-top" :src="keep.img">
        <div class="card-body">
          <a class="btn btn-success">View</a>
          <a>{{keep.views}}</a>
          <a class="btn btn-primary">Keep</a>
          <a>{{keep.keeps}}</a>
          <a class="btn btn-warning">Share</a>
          <a>{{keep.shares}}</a>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  import KeepCard from "@/components/KeepCard.vue"
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
    },
    methods: {


    },
    components: {
      KeepCard
    }
  }
</script>
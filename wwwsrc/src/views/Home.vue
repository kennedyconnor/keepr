<template>
  <div class="home">

    <div class="row">
      <div class="col-4 offset-4">
        <h3>Welcome Home {{user.username}}</h3>
        <button v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </div>
      <div class="col-4" v-if="user.id">
        <button class="btn btn-secondary" @click="routeDashboard()">Dashboard</button>
      </div>
    </div>

    <div class="row">
      <CreateKeep v-if="user.id" />
      <CreateVault v-if="user.id" />
    </div>
    <Keeps />
  </div>
</template>

<script>
  import Keeps from "@/components/Keeps.vue"
  import CreateKeep from "@/components/CreateKeep.vue"
  import CreateVault from "@/components/CreateVault.vue"
  export default {
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      },

    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      routeDashboard() {
        this.$router.push({ name: "dashboard" })
      }
    },
    mounted() {
      this.$store.dispatch("getAllKeeps")
      this.$store.dispatch("getUserVaults")
    },
    components: {
      Keeps,
      CreateKeep,
      CreateVault,
    }
  };
</script>
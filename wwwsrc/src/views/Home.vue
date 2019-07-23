<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Welcome Home {{user.username}}</h1>
        <button v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
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
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    },
    mounted() {
      this.$store.dispatch("getAllKeeps")
      this.$store.dispatch("getUserVaults")
    },
    components: {
      Keeps,
      CreateKeep,
      CreateVault
    }
  };
</script>
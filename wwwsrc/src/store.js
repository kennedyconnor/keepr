import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    activeVault: {},
    vaults: [],
  },

  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setActiveVault(state, vault) {
      state.activeVault = vault;
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    }
  },

  actions: {
    //#region AUTH
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    //#endregion

    //#region KEEPS
    async getAllKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps")
        commit("setKeeps", res.data)
      } catch (e) {
        console.warn(e.message)
      }
    },
    async createKeep({ commit, dispatch }, payload) {
      try {
        debugger
        await api.post("keeps", payload)
        dispatch("getAllKeeps")
      } catch (error) {
        console.warn(error.message)
      }
    },
    //#endregion

    //#region VAULTS
    async getUserVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults/user")
        commit("setVaults", res.data)
      } catch (e) {
        console.warn(e.message)
      }
    },
    async createVault({ commit, dispatch }, payload) {
      try {
        await api.post("vaults", payload)
        dispatch("getUserVaults")
      } catch (error) {
        console.warn(error.message)
      }
    }

    //#endregion
  }
})

import api from "@/apis/userApi";
import Crud from "@/stores/crudBase";
var crud = new Crud(api);
const state = {
  ...crud.state,
  context: {
    token: null,
    user: null
  }
};
const getters = {
  ...crud.getters,
};
const actions = {
  ...crud.actions,
  async signup(store, payload) {
    const res = await api.signup(payload);
    return res;
  },
  async login(store, payload) {
    const res = await api.login(payload);
    if (res?.data?.data?.token) {
      store.commit("setToken", res?.data?.data?.token)
    }
    return res;
  },
  async logout() {
    localStorage.clear();
  },
};
const mutations = {
  ...crud.mutations,
  setToken: (state, token) => {
    state.context.token = token
  }
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters,
};

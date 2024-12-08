import api from "@/apis/userApi";
import Crud from "@/stores/crudBase";
var crud = new Crud(api);
const state = {
  ...crud.state,
};
const getters = {
  ...crud.getters,
};
const actions = {
  ...crud.actions,
  async signup(state, payload) {
    const res = await api.signup(payload);
    return res;
  },
  async login(state, payload) {
    const res = await api.login(payload);
    if (res?.data?.token) {
      localStorage.setItem("token", res?.data?.token);
    }
    return res;
  },
  async logout() {
    localStorage.clear();
  },
};
const mutations = {
  ...crud.mutations,
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters,
};

import api from "@/apis/userApi";
import Crud from "@/stores/crudBase";
var crud = new Crud(api);
const state = {
  ...crud.state,
  context: {
    token: null,
    contextData: null
  }
};
const getters = {
  ...crud.getters,
};
const actions = {
  ...crud.actions,
  async signup(store, payload) {
    store.commit("moduleLoading/setLoading", true, { root: true });
    try {
      const res = await api.signup(payload);
      return res;
    } catch (error) {
      store.commit("setError", error);
    }
    finally {
      store.commit("moduleLoading/setLoading", false, { root: true });
    }
  },
  async login(store, payload) {
    const res = await api.login(payload);
    if (res?.data?.token) {
      store.commit("setToken", res?.data?.token)
    } if (res?.data?.contextData) {
      store.commit("setContextData", res?.data?.contextData)
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
  },
  setContextData: (state, contextData) => {
    state.context.contextData = contextData
  }
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters,
};

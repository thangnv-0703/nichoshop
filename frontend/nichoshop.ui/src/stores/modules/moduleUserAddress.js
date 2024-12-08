import api from "@/apis/userApi";
import Crud from "@/stores/crudBase";
var crud = new Crud(api);
const state = {
  ...crud.state,
  config: {
    name: "địa chỉ",
  },
};
const getters = {
  ...crud.getters,
};
const actions = {
  ...crud.actions,
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

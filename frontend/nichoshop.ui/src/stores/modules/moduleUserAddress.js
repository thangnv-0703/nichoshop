import api from "@/apis/userAddressApi";
import Crud from "@/stores/crudBase";
var crud = new Crud(api);
const state = {
  ...crud.state,
  config: {
    name: "địa chỉ",
    fieldId: 'id'
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

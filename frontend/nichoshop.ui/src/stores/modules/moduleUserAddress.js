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
  async setAsDefault(store, payload) {
    store.commit("moduleLoading/setLoading", true, { root: true });
    try {
      const res = await api.setAsDefault(payload);
      if (res?.data) {
        store.commit("setItems", store.state.items.map(item => {
          if (item[store.state.config.fieldId] == payload) {
            return { ...item, isDefault: true };
          }
          else if (item.isDefault) {
            return { ...item, isDefault: false };
          }
          return item;
        }
        ));
      }
      return res;
    } catch (error) {
      store.commit("setError", error);
    }
    finally {
      store.commit("moduleLoading/setLoading", false, { root: true });
    }
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

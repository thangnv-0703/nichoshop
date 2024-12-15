import api from "@/apis/locationApi";
import Crud from "@/stores/crudBase";
var crud = new Crud(api);
const state = {
    ...crud.state,
    config: {
    },
};
const getters = {
    ...crud.getters,

};
const actions = {
    ...crud.actions,
    async getLocation(store, payload) {
        const res = await api.getLocation(payload);
        return res;
    }
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

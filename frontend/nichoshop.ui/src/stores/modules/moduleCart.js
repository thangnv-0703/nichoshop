import api from "@/apis/cartApi";
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

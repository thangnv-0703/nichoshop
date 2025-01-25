import api from "@/apis/productApi";
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
    async getProductByCategory(store, idCategory) {
        store.commit("moduleLoading/setLoading", true, { root: true });
        try {
            let res = await api.getProductByCategory(idCategory);
            return res;
        } catch (error) {
            store.commit("setError", error);
        } finally {
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

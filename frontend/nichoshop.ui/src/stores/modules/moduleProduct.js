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
            return await api.getProductByCategory(idCategory);
        } catch (error) {
            store.commit("setError", error);
        } finally {
            store.commit("moduleLoading/setLoading", false, { root: true });
        }
    },

    async getProductHome(store, payload) {
        store.commit("moduleLoading/setLoading", true, { root: true });
        try {
            return await api.getProductHome(payload);
        } catch (error) {
            store.commit("setError", error);
        } finally {
            store.commit("moduleLoading/setLoading", false, { root: true });
        }
    },

    async getProductSearch(store, payload) {
        store.commit("moduleLoading/setLoading", true, { root: true });
        try {
            return await api.getProductSearch(payload);
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

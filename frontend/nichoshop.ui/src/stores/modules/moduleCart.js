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
    async getItem(store, id) {
        store.commit("setLoading", true);
        try {
            const response = await api.getItem(id);
            store.commit("moduleCartItem/setItems", response.data?.items, { root: true });
            return response;
        } catch (error) {
            store.commit("setError", error);
        } finally {
            store.commit("setLoading", false);
        }
    },
    async addItemToCart({ commit }, payload) {
        commit("setLoading", true);
        try {
            let res = await api.addItemToCart(payload);
            return res;
        } catch (error) {
            commit("setError", error);
        } finally {
            commit("setLoading", false);
        }
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

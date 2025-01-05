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
        store.commit("moduleLoading/setLoading", true, { root: true });
        try {
            const response = await api.getItem(id);
            store.commit("moduleCartItem/setItems", response.data?.items, { root: true });
            return response;
        } catch (error) {
            store.commit("setError", error);
        } finally {
            store.commit("moduleLoading/setLoading", false, { root: true });
        }
    },
    async addItemToCart(store, payload) {
        store.commit("moduleLoading/setLoading", true, { root: true });
        try {
            let res = await api.addItemToCart(payload);
            return res;
        } catch (error) {
            store.commit("setError", error);
        } finally {
            store.commit("moduleLoading/setLoading", false, { root: true });
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

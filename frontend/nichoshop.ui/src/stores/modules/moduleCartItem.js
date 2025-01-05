import api from "@/apis/cartApi";
import Crud from "@/stores/crudBase";
var crud = new Crud(api);
const state = {
    ...crud.state,
    config: {
        fieldId: 'id'
    },
};
const getters = {
    ...crud.getters,
};
const actions = {
    ...crud.actions,
    async updateItem({ commit, state }, payload) {
        store.commit("moduleLoading/setLoading", true, { root: true });

        try {
            const res = await api.updateCartItemQuantity(payload.id, payload);
            if (res?.data) {
                commit("setItems", state.items.map(item => {
                    if (item[state.config.fieldId] == payload.id) {
                        return payload
                    }
                    return item;
                }
                ));
            }
            return res;
        } catch (error) {
            commit("setError", error);
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

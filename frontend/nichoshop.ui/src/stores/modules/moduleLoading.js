const state = {
    loading: false
};
const getters = {
    loading: state => state.loading
};
const actions = {
    setLoading({ commit }, loading) {
        commit("setLoading", loading);
    }
};
const mutations = {
    setLoading(state, loading) {
        debugger
        state.loading = loading;
    }
};

export default {
    namespaced: true,
    state,
    mutations,
    actions,
    getters,
};

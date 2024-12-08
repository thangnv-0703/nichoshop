export default class Crud {
  constructor(api) {
    let me = this;
    me.api = api;

    me.state = {
      items: [], // Dữ liệu danh sách
      item: null, // Dữ liệu chi tiết
      loading: false, // Trạng thái loading
      error: null, // Lỗi khi thao tác
    };

    me.getters = {
      items: (state) => state.items,
      item: (state) => state.item,
      loading: (state) => state.loading,
      error: (state) => state.error,
    };

    me.actions = {
      async getPaging({ commit }, payload) {
        commit("setLoading", true);
        try {
          const response = await me.api.getPaging();
          commit("setItems", response.data);
        } catch (error) {
          commit("setError", error);
        } finally {
          commit("setLoading", false);
        }
      },
      async getAll({ commit }) {
        commit("setLoading", true);
        try {
          const response = await me.api.getAll();
          commit("setItems", response.data);
        } catch (error) {
          commit("setError", error);
        } finally {
          commit("setLoading", false);
        }
      },
      async fetchItem({ commit }, id) {
        commit("setLoading", true);
        try {
          const response = await me.api.getById(id);
          commit("setItem", response.data);
        } catch (error) {
          commit("setError", error);
        } finally {
          commit("setLoading", false);
        }
      },
      async createItem({ commit, dispatch }, payload) {
        debugger
        commit("setLoading", true);
        try {
          await me.api.create(payload);
        } catch (error) {
          commit("setError", error);
        } finally {
          commit("setLoading", false);
        }
      },
      async updateItem({ commit, dispatch }, payload) {
        commit("setLoading", true);
        try {
          await me.api.update(payload.id, payload);
        } catch (error) {
          commit("setError", error);
        } finally {
          commit("setLoading", false);
        }
      },
      async deleteItem({ commit, dispatch }, id) {
        commit("setLoading", true);
        try {
          await me.api.delete(id);
        } catch (error) {
          commit("setError", error);
        } finally {
          commit("setLoading", false);
        }
      },
    };

    me.mutations = {
      setItems(state, items) {
        state.items = items;
      },
      setItem(state, item) {
        state.item = item;
      },
      setLoading(state, loading) {
        state.loading = loading;
      },
      setError(state, error) {
        state.error = error;
      },
    };
  }
}

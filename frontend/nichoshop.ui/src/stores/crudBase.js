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
      async getItem({ commit }, id) {
        commit("setLoading", true);
        try {
          const response = await me.api.getItem(id);
          commit("setItem", response.data);
        } catch (error) {
          commit("setError", error);
        } finally {
          commit("setLoading", false);
        }
      },
      async createItem({ commit, state }, payload) {
        commit("setLoading", true);
        try {
          const res = await me.api.create(payload);
          if (res?.data) {
            commit("setItems", [...state.items, {
              ...payload,
              [state.config.fieldId]: res.data
            }]);
          }
          return res;
        } catch (error) {
          commit("setError", error);
        } finally {
          commit("setLoading", false);
        }
      },
      async updateItem({ commit, state }, payload) {
        commit("setLoading", true);
        try {
          const res = await me.api.update(payload.id, payload);
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
          commit("setLoading", false);
        }
      },
      async deleteItem({ commit, state }, id) {
        commit("setLoading", true);
        try {
          const res = await me.api.delete(id);
          debugger
          if (res) {
            commit("setItems", state.items.filter(item => item[state.config.fieldId] !== id));
          }
          return res;
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

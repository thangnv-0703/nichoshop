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
      async getPaging(store, payload) {
        try {
          store.commit("moduleLoading/setLoading", true, { root: true });
          const response = await me.api.getPaging(payload);
          debugger
          store.commit("setItems", response.data);
        }
        catch (error) {
          store.commit("setError", error);
        }
        finally {
          store.commit("moduleLoading/setLoading", false, { root: true });
        }
      },
      async getAll(store) {
        try {
          store.commit("moduleLoading/setLoading", true, { root: true });
          const response = await me.api.getAll();
          store.commit("setItems", response.data);
        }
        catch (error) {
          store.commit("setError", error);
        }
        finally {
          store.commit("moduleLoading/setLoading", false, { root: true });
        }
      },
      async getItem(store, id) {
        store.commit("moduleLoading/setLoading", true, { root: true });
        try {
          const response = await me.api.getItem(id);
          store.commit("setItem", response.data);
          return response;
        } catch (error) {
          store.commit("setError", error);
        } finally {
          store.commit("moduleLoading/setLoading", false, { root: true });
        }
      },
      async createItem(store, payload) {
        store.commit("moduleLoading/setLoading", true, { root: true });
        try {
          const res = await me.api.create(payload);
          if (res?.data) {
            store.commit("setItems", [...store.state.items, {
              ...payload,
              [store.state.config.fieldId]: res.data
            }]);
          }
          return res;
        } catch (error) {
          store.commit("setError", error);
        } finally {
          store.commit("moduleLoading/setLoading", false, { root: true });
        }
      },
      async updateItem(store, payload) {
        store.commit("moduleLoading/setLoading", true, { root: true });
        try {
          const res = await me.api.update(payload.id, payload);
          if (res?.data) {
            store.commit("setItems", store.state.items.map(item => {
              if (item[store.state.config.fieldId] == payload.id) {
                return payload
              }
              return item;
            }
            ));
          }
          return res;
        } catch (error) {
          store.commit("setError", error);
        } finally {
          store.commit("moduleLoading/setLoading", false, { root: true });
        }
      },
      async deleteItem(store, id) {
        store.commit("moduleLoading/setLoading", true, { root: true });

        try {
          const res = await me.api.delete(id);
          if (res) {
            store.commit("setItems", store.state.items.filter(item => item[store.state.config.fieldId] !== id));
          }
          return res;
        } catch (error) {
          store.commit("setError", error);
        } finally {
          store.commit("moduleLoading/setLoading", false, { root: true });
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

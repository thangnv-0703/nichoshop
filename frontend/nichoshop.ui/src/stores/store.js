import createPersistedState from 'vuex-persistedstate'
import { createStore } from "vuex";
import moduleUser from "./modules/moduleUser";
import moduleUserAddress from "./modules/moduleUserAddress";
import moduleLocation from "./modules/moduleLocation";
const store = createStore({
  modules: { moduleUser, moduleUserAddress, moduleLocation },
  plugins: [
    createPersistedState({
      key: 'vuex',
      paths: ['moduleUser'],
      getState: (key) => {
        const storedState = localStorage.getItem(key);
        if (storedState) {
          try {
            return JSON.parse(storedState);
          } catch (error) {
            console.error("Error parsing stored state:", error);
            return {};
          }
        }
        return {};
      },
      setState: (key, state) => {
        try {
          localStorage.setItem(key, JSON.stringify(state));
        } catch (error) {
          console.error("Error saving state to localStorage:", error);
        }
      },
    }),
  ],
});
export default store;

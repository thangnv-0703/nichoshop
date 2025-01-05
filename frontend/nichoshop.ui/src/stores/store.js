import createPersistedState from 'vuex-persistedstate'
import { createStore } from "vuex";
import moduleLoading from "./modules/moduleLoading";
import moduleUser from "./modules/moduleUser";
import moduleUserAddress from "./modules/moduleUserAddress";
import moduleLocation from "./modules/moduleLocation";
import moduleProduct from './modules/moduleProduct';
import moduleCart from './modules/moduleCart';
import moduleCartItem from './modules/moduleCartItem';
const store = createStore({

  modules: { moduleLoading, moduleUser, moduleUserAddress, moduleLocation, moduleProduct, moduleCart, moduleCartItem },
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

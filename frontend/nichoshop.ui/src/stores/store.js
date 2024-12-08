import { createStore } from "vuex";
import moduleUser from "./modules/ModuleUser";
import moduleUserAddress from "./modules/moduleUserAddress";
const store = createStore({
  modules: { moduleUser, moduleUserAddress },
});
export default store;

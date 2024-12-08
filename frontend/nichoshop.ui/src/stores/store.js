import { createStore } from "vuex";
import ModuleUser from "./modules/ModuleUser";
const store = createStore({
  modules: { ModuleUser },
});
export default store;

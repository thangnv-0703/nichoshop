import { createApp } from "vue";

import { createVfm } from "vue-final-modal";
import PrimeVue from "primevue/config";
import ConfirmationService from 'primevue/confirmationservice';
import ToastService from 'primevue/toastservice';
import store from "./stores/store";
import App from "./App.vue";
import router from "./router";
import enumeration from "./common/Enumeration";
import MyPreset from '@/presets/MyPreset.js'

import "./style.css";
import "vue-final-modal/style.css";
import "primeicons/primeicons.css";


const app = createApp(App);
const vfm = createVfm();
app.config.globalProperties.$nicho = {
  enumeration: enumeration,
  // commonFn: commonFn,
};
const initialiseStorePlugin = {
  install(app) {
    store.commit('initialiseStore');
  },
};

app.use(initialiseStorePlugin);
app.use(PrimeVue, {
  theme: {
    preset: MyPreset,
  },
});
app.use(ConfirmationService);
app.use(ToastService);
app.use(vfm);
app.use(store);
app.use(router);
app.mount("#app");

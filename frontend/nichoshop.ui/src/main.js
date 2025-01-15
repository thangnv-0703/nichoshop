import { createApp } from "vue";

import i18n from "./i18n/i18n";
import { createVfm } from "vue-final-modal";
import PrimeVue from "primevue/config";
import ConfirmationService from 'primevue/confirmationservice';
import ToastService from 'primevue/toastservice';
import store from "./stores/store";
import App from "./App.vue";
import router from "./router";
import enumeration from "./common/enumeration";
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

app.use(PrimeVue, {
  theme: {
    preset: MyPreset,
  },
});


app.use(i18n)
app.use(ConfirmationService);
app.use(ToastService);
app.use(vfm);
app.use(store);
app.use(router);
app.mount("#app");

import { createApp } from "vue";

import { createVfm } from "vue-final-modal";
import PrimeVue from "primevue/config";
import Aura from "@primevue/themes/aura";
import { definePreset } from "@primevue/themes";
import ConfirmationService from 'primevue/confirmationservice';
import DialogService from 'primevue/dialogservice'
import ToastService from 'primevue/toastservice';
import store from "./stores/store";
import App from "./App.vue";
import router from "./router";
import enumeration from "./common/Enumeration";

import "./style.css";
import "vue-final-modal/style.css";
import "primeicons/primeicons.css";

const MyPreset = definePreset(Aura, {
  semantic: {
    primary: {
      50: "{blue.50}",
      100: "{blue.100}",
      200: "{blue.200}",
      300: "{blue.300}",
      400: "{blue.400}",
      500: "{blue.500}",
      600: "{blue.600}",
      700: "{blue.700}",
      800: "{blue.800}",
      900: "{blue.900}",
      950: "{blue.950}",
    },
  },
});



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
app.use(ConfirmationService);
app.use(ToastService);
app.use(DialogService);
app.use(vfm);
app.use(store);
app.use(router);
app.mount("#app");

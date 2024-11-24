import { createApp } from "vue";
import { createVfm } from "vue-final-modal";
import PrimeVue from "primevue/config";
import Aura from "@primevue/themes/aura";
import "./style.css";
import "vue-final-modal/style.css";
import "primeicons/primeicons.css";

import App from "./App.vue";
import router from "./router";

const app = createApp(App);
const vfm = createVfm();
app.use(PrimeVue, {
  theme: {
    preset: Aura,
  },
});
app.use(vfm);
app.use(router);
app.mount("#app");

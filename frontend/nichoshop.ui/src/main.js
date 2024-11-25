import { createApp } from "vue";
import { createVfm } from "vue-final-modal";
import PrimeVue from "primevue/config";
import Aura from "@primevue/themes/aura";
import { definePreset } from "@primevue/themes";
import "./style.css";
import "vue-final-modal/style.css";
import "primeicons/primeicons.css";

const MyPreset = definePreset(Aura, {
  semantic: {
    primary: {
      50: "{sky.50}",
      100: "{sky.100}",
      200: "{sky.200}",
      300: "{sky.300}",
      400: "{sky.400}",
      500: "{sky.500}",
      600: "{sky.600}",
      700: "{sky.700}",
      800: "{sky.800}",
      900: "{sky.900}",
      950: "{sky.950}",
    },
  },
});

import App from "./App.vue";
import router from "./router";

const app = createApp(App);
const vfm = createVfm();
app.use(PrimeVue, {
  theme: {
    preset: MyPreset,
  },
});
app.use(vfm);
app.use(router);
app.mount("#app");

import { createRouter, createWebHistory } from "vue-router";
import routerPage from "./routerPage";

const routes = [
  ...routerPage,
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

import { createRouter, createWebHistory } from "vue-router";
import LoginPage from "../pages/Login.vue";
import HomePage from "../views/HomePage.vue";
import routerPage from "./routerPage";

const routes = [
  {
    path: "/", // Đường dẫn cho trang chủ
    name: "", // Tên của route
    component: HomePage,
  },
  ...routerPage,
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

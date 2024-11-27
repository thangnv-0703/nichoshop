import { createRouter, createWebHistory } from "vue-router";
import routerPage from "./routerPage";

const routes = [
  {
    path: "",
    component: () => import("@/layouts/MainLayout.vue"),
    meta: {},
    children: [
      {
        path: "", // Đường dẫn cho trang chủ
        name: "", // Tên của route
        component: () => import("@/pages/Home.vue"),
      },
      {
        path: "/user",
        component: () => import("@/layouts/UserLayout.vue"),
        meta: {},
        children: [
          {
            path: "",
            redirect: "user/account/profile",
          },
          {
            path: "account",
            redirect: "user/account/profile",
          },
          {
            path: "account/profile",
            name: "accountProfile",
            component: () => import("@/views/user/account/profile.vue"),
          },
        ],
      },
    ],
    ...routerPage,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

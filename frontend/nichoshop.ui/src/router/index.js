import { createRouter, createWebHistory } from "vue-router";
import routerPage from "./routerPage";

const routes = [
  ...routerPage,
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
            component: () =>
              import("@/views/user/account/profile/AccountProfile.vue"),
          },
          {
            path: "account/address",
            name: "userAddress",
            component: () =>
              import("@/views/user/account/address/UserAddress.vue"),
          },
        ],
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

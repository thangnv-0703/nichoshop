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
        path: "/product-detail", // Đường dẫn cho trang chủ
        name: "productDetail", // Tên của route
        component: () => import("@/pages/ProductDetail.vue"),
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
  {
    path: "/cart",
    name: "cart",
    component: () => import("@/views/cart/Cart.vue"),
  },
  ...routerPage,
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;

import { createRouter, createWebHistory } from "vue-router";
import routerPage from "./routerPage";
import authHelper from "../helpers/authHelper";

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
        meta: {
          anonymous: true,
        }
      },
      {
        path: "/product-detail", // Đường dẫn cho chi tiết
        name: "productDetail", // Tên của route
        component: () => import("@/pages/ProductDetail.vue"),
        meta: {
          anonymous: true,
        }
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
router.beforeEach(async (to, from, next) => {
  if (to.meta.anonymous) {
    next();
    return;
  }
  if (!authHelper.isAuthenticated()) {
    next({ path: "/login" });
    return;
  }

  next();
});
export default router;

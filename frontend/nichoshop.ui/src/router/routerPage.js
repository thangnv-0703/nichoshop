export default [
  //   {
  //     path: "/403",
  //     name: "403",
  //     component: () => import("@/pages/403.vue"),
  //     meta: {
  //       anonymous: true,
  //     },
  //   },
  //   {
  //     path: "/404",
  //     name: "404",
  //     component: () => import("@/pages/500.vue"),
  //     meta: {
  //       anonymous: true,
  //     },
  //   },

  {
    path: "/login",
    name: "Login",
    component: () => import("@/pages/Login.vue"),
    meta: {
      anonymous: true,
    },
  },
  {
    path: "/signup",
    name: "signup",
    component: () => import("@/pages/Signup.vue"),
    meta: {
      anonymous: true,
    },
  },
  //   {
  //     path: "/logout",
  //     name: "Logout",
  //     component: () => import("@/pages/Logout.vue"),
  //     meta: {
  //       anonymous: true,
  //     },
  //   },
];

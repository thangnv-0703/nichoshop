export default [
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
            {
                path: "account/password",
                name: "userPassword",
                component: () =>
                    import("@/views/user/account/password/ChangePassword.vue"),
            },
            {
                path: "purchase",
                name: "userPurchase",
                component: () =>
                    import("@/views/user/purchase/Purchase.vue"),
            },
        ],
    },
]

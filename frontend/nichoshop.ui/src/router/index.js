import { createRouter, createWebHistory } from 'vue-router';
import LoginPage from '../views/LoginPage.vue';
import HomePage from '../views/HomePage.vue';

const routes = [
    {
        path: '/',         // Đường dẫn gốc
        name: 'Login',     // Tên của route
        component: LoginPage,
    },
    {
        path: '/home',     // Đường dẫn cho trang chủ
        name: 'Home',      // Tên của route
        component: HomePage,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;

<template>
  <div style="text-align: center; margin-top: 50px">
    <h2>Đăng nhập Tĩnh làm nhé</h2>
    <button @click="handleLogin">Login</button>
  </div>
</template>

<script>
import { useRouter } from "vue-router";

export default {
  setup() {
    const router = useRouter();

    const handleLogin = () => {
      // Điều hướng đến trang chủ khi nhấn nút
      router.push("/home");
    };

    return { handleLogin };
  },
};
</script>

<style scoped>
/* Thêm CSS tùy chỉnh nếu cần */
</style>

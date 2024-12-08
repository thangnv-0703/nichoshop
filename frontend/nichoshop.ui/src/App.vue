<template>
  <div id="app">
    <router-view />
    <ModalsContainer />
  </div>
</template>

<script>
import { ModalsContainer } from "vue-final-modal";

export default {
  name: "App",
  components: { ModalsContainer },
};
</script>

<style>
/* Bạn có thể thêm CSS chung cho toàn bộ ứng dụng ở đây */
#app {
  width: 100%;
  height: 100%;
}
</style>

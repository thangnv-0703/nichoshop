<template>
  <div id="app">
    <router-view />
    <ModalsContainer />
    <ConfirmDialog></ConfirmDialog>
  </div>
</template>

<script>
import { ModalsContainer } from "vue-final-modal";
import ConfirmDialog from "primevue/confirmdialog";
export default {
  name: "App",
  components: { ModalsContainer, ConfirmDialog },
};
</script>

<style>
/* Bạn có thể thêm CSS chung cho toàn bộ ứng dụng ở đây */
#app {
  width: 100%;
  height: 100%;
}
</style>

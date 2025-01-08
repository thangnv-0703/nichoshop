<template>
  <div id="app">
    <router-view />
    <ModalsContainer />
    <ConfirmDialog></ConfirmDialog>
    <Toast position="top-center" group="tc" />
    <div class="progress-spinner" v-if="loading">
      <ProgressSpinner />
    </div>
  </div>
</template>

<script>
import { ModalsContainer } from "vue-final-modal";
import ConfirmDialog from "primevue/confirmdialog";
import { setToast } from "@/utils/toastUtil";
import { computed, getCurrentInstance } from "vue";
export default {
  name: "App",
  components: { ModalsContainer, ConfirmDialog },
  setup() {
    setToast();
    const { proxy } = getCurrentInstance();
    const loading = computed(() => {
      return proxy.$store.getters["moduleLoading/loading"];
    });
    return { loading };
  },
};
</script>

<style>
/* Bạn có thể thêm CSS chung cho toàn bộ ứng dụng ở đây */
#app {
  width: 100%;
  height: 100%;
}
.progress-spinner {
  position: fixed;
  z-index: 999;
  height: 2em;
  width: 2em;
  overflow: show;
  margin: auto;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}

/* Transparent Overlay */
.progress-spinner:before {
  content: "";
  display: block;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.25);
}
</style>

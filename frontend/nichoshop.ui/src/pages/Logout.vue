<template></template>

<script>
import { ref, getCurrentInstance, onMounted } from "vue";
import { useRouter } from "vue-router";
export default {
  setup() {
    const router = useRouter();
    onMounted(() => {
      router.push("/login");
    });
  },
};
</script>

<style lang="scss" scoped></style>

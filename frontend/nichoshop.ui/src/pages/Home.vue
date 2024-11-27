<template>
  <div>
    <Index style="margin-top: 20px"></Index>
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import Index from "@/components/home/Index.vue";

export default {
  name: "Home",
  components: [Header, Index],
};
</script>

<style scoped lang="scss"></style>

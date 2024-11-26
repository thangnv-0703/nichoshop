<template>
  <div v-if="svgSrc" class="svg-icon" :class="customClass">
    <img :src="svgSrc" :alt="alt" />
  </div>
</template>

<script>
import { icons } from "@/assets/icons/svg-icons.js";

export default {
  name: "SvgIcon",
  props: {
    name: {
      type: String,
      required: true, // Tên icon (key trong svg-icons.js)
    },
    alt: {
      type: String,
      default: "icon", // Mô tả hình ảnh
    },
    customClass: {
      type: String,
      default: "", // CSS tùy chỉnh
    },
  },
  computed: {
    svgSrc() {
      // Trả về đường dẫn SVG tương ứng với tên được truyền
      return icons[this.name] || null;
    },
  },
};
</script>

<style scoped>
.svg-licon {
  display: inline-block;
  width: 50px;
  height: 50px;
}
</style>

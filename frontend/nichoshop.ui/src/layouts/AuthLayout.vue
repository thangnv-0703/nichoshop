<template>
  <div class="flex flex-col items-center">
    <div class="p-2">
      <div class="logo"></div>
    </div>
    <div class="content"><slot /></div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.content {
  width: 500px;
}
.logo {
  height: 40px;
  width: 213px;
  background-image: url("@/assets/svg/nichoshop_logo.svg");
}
</style>

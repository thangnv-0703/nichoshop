<template>
  <div class="h-screen flex flex-col justify-between">
    <div class="flex flex-col items-center">
      <div class="p-2">
        <div class="logo mt-[8px]"></div>
      </div>
      <div class="content flex flex-col items-center"><slot /></div>
    </div>
    <div class="w-full p-[8px] border-t-2 text-center">
      <span class="text-[#6C757D]">
        Copyright 2017 NichoShop Inc. All rights reserved.
        <span class="text-[#0B80CC]">User agreement, Privacy</span>
        and
        <span class="text-[#0B80CC]">Cookies.</span>
      </span>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
.content {
  width: 500px;
  /* test */
}
.logo {
  height: 40px;
  width: 213px;
  background-image: url("@/assets/svg/nichoshop_logo.svg");
}
</style>

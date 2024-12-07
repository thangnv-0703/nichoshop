<template>
  <div class="max-w-[1200px] mx-auto">
    <div class="card flex">
      <Menu :model="items" class="w-full md:w-60">
        <template #start>
          <span class="inline-flex items-center gap-1 px-2 py-5">
            <img
              src="https://down-vn.img.susercontent.com/file/36b878bafc795dd0ad8c0b142270d8b9"
              class="rounded-full w-[34px]"
            />
            <span class="text-s font-semibold">Tên tài khoản</span>
          </span>
        </template>
        <template #submenulabel="{ item }">
          <div class="flex items-center gap-1">
            <span :class="item.icon" />
            <span class="text-primary font-bold">{{ item.label }}</span>
          </div>
        </template>
        <template #item="{ item, props }">
          <router-link :to="item.linkTo"
            ><a v-ripple class="flex items-center" v-bind="props.action">
              <span>{{ item.label }}</span>
            </a></router-link
          >
        </template>
      </Menu>
      <div class="bg-white p-4 w-[1000px]">
        <router-view />
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";

const items = ref([
  {
    separator: true,
  },

  {
    label: "Tài khoản của tôi",
    icon: "pi pi-user",
    items: [
      {
        label: "Hồ sơ",
        linkTo: "profile",
      },
      {
        label: "Ngân hàng",
        badge: 2,
        linkTo: "bank",
      },
      {
        label: "Địa chỉ",
        linkTo: "address",
      },
    ],
  },
]);
</script>
<style scoped>
:deep(.p-menu) {
  border: unset;
}
</style>

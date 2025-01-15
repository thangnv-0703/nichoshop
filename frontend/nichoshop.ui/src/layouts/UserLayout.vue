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
            <span class="text-s font-semibold">
              {{ authHelper.getContext()?.username }}</span
            >
          </span>
        </template>
        <template #submenulabel="{ item }">
          <div v-if="!item.linkTo" class="flex items-center gap-1">
            <span :class="item.icon" />
            <span class="text-primary">{{ item.label }}</span>
          </div>
          <router-link v-else :to="item.linkTo"
            ><a v-ripple class="flex items-center gap-1">
              <span :class="item.icon" />
              <span>{{ item.label }}</span>
            </a></router-link
          >
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
import authHelper from "@/helpers/AuthHelper";

const items = ref([
  {
    separator: true,
  },

  {
    label: "Tài khoản của tôi",
    icon: "nicho-icon nicho-user",
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
      {
        label: "Đổi mật khẩu",
        linkTo: "password",
      },
    ],
  },
  {
    label: "Đơn mua",
    icon: "nicho-icon nicho-purchase",
    items: [],
    linkTo: "/user/purchase",
  },
]);
</script>
<style scoped lang="scss">
:deep {
  .p-menu {
    border: unset;
  }
  .p-tab {
    font-weight: normal;
  }
}
</style>

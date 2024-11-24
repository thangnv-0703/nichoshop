<template>
  <auth-layout>
    <Form
      v-slot="$form"
      :resolver="resolver"
      :initialValues="initialValues"
      @submit="onFormSubmit"
      class="flex flex-col gap-4 w-full"
    >
      <div class="flex flex-col gap-3">
        <div class="flex flex-col gap-1">
          <InputText name="email" type="text" placeholder="Tài khoản" />
        </div>

        <Password
          name="password"
          placeholder="Mật khẩu"
          :feedback="false"
          fluid
          toggleMask
        />
      </div>
      <Button type="submit" severity="secondary" label="Đăng nhập" />
      <div class="flex items-center justify-center">
        <p class="text-[#81818F]">Chưa có tài khoản?</p>
        <Button
          class="font-bold"
          label="Đăng ký"
          @click="onClickGoToRegisterPage"
          variant="link"
        />
      </div>
    </Form>
  </auth-layout>
</template>
<script setup lang="ts">
import { ref } from "vue";
import { VueFinalModal } from "vue-final-modal";
import { zodResolver } from "@primevue/forms/resolvers/zod";
// import { useToast } from "primevue/usetoast";
import AuthLayout from "@/layouts/AuthLayout.vue";
import { z } from "zod";
import { useRouter } from "vue-router";
// const toast = useToast();
const initialValues = ref({
  password: "",
});
const router = useRouter();

const onFormSubmit = ({ valid }) => {
  if (valid) {
    router.push("/home");
  }
};
const onClickGoToRegisterPage = () => {
  router.push("/register");
};
</script>

<style scoped lang="scss">
/* Thêm CSS tùy chỉnh nếu cần */
</style>

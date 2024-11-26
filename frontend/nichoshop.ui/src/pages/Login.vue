<template>
  <auth-layout>
    <p class="text-2xl text-center py-6">Đăng nhập</p>

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

        <div class="flex justify-between">
          <div class="flex items-center gap-2">
            <Checkbox
              v-model="staySignedIn"
              inputId="staySignedIn"
              name="staySignedIn"
              binary
            />
            <label for="staySignedIn"> Stay signed in </label>
          </div>

          <p class="text-[#0B80CC] ml-[4px] cursor-pointer">Quên mật khẩu?</p>
        </div>
      </div>
      <Button type="submit" label="Đăng nhập" />
      <div class="flex items-center justify-center">
        <p class="text-[#81818F]">Chưa có tài khoản?</p>
        <p
          class="text-[#0B80CC] ml-[4px] cursor-pointer"
          @click="onClickGoToRegisterPage"
        >
          Đăng ký
        </p>
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
const staySignedIn = ref(false);
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

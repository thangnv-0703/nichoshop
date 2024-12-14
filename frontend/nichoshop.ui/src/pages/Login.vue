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
          <InputText
            name="email"
            type="text"
            placeholder="Tài khoản"
            v-model="model.PhoneNumber"
          />
        </div>

        <Password
          name="password"
          placeholder="Mật khẩu"
          :feedback="false"
          fluid
          toggleMask
          v-model="model.Password"
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
          @click="onClickGoToSignupPage"
        >
          Đăng ký
        </p>
      </div>
    </Form>
  </auth-layout>
</template>
<script setup lang="ts">
import { ref, getCurrentInstance, onMounted } from "vue";
import AuthLayout from "@/layouts/AuthLayout.vue";
import { useRouter } from "vue-router";

const { proxy } = getCurrentInstance();
const model = ref({
  PhoneNumber: null,
  Password: null,
});
const router = useRouter();
const staySignedIn = ref(false);
onMounted(() => {
  proxy.$store.dispatch("moduleUser/logout");
});
const onFormSubmit = ({ valid }) => {
  proxy.$store
    .dispatch("moduleUser/login", {
      PhoneNumber: model.value.PhoneNumber,
      Password: model.value.Password,
    })
    .then((res) => {
      if (res?.data?.data?.token) {
        router.push("/");
      }
    })
    .catch((error) => {
      console.log(error);
    });
};
const onClickGoToSignupPage = () => {
  router.push("/signup");
};
</script>

<style scoped lang="scss">
/* Thêm CSS tùy chỉnh nếu cần */
</style>

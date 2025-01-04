<template>
  <auth-layout title="Đăng nhập">
    <p class="text-xl py-6 w-full">Đăng nhập</p>
    <Form
      v-slot="$form"
      :resolver="resolver"
      :initialValues="initialValues"
      @submit="onFormSubmit"
      class="flex flex-col gap-2 w-full"
    >
      <div class="flex flex-col gap-6">
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
        <Button type="submit" severity="danger" label="ĐĂNG NHẬP" />
      </div>
      <div class="flex justify-between">
        <!-- <div class="flex items-center gap-2">
          <Checkbox
            v-model="staySignedIn"
            inputId="staySignedIn"
            name="staySignedIn"
            binary
          />
          <label for="staySignedIn"> Stay signed in </label>
        </div> -->

        <p class="text-[#0B80CC] ml-[4px] cursor-pointer text-xs">
          Quên mật khẩu
        </p>
      </div>

      <Divider layout="horizontal" align="center">
        <span class="text-[#81818F] text-xs">HOẶC</span>
      </Divider>
      <div class="flex items-center justify-center gap-4">
        <button class="social-btn">
          <div class="icon facebook"></div>
          Facebook
        </button>
        <button class="social-btn">
          <div class="icon google"></div>
          Google
        </button>
      </div>
      <div class="flex items-center justify-center mt-[16px]">
        <p class="text-[#81818F]">Chưa có tài khoản?</p>
        <p
          class="text-[#ee4d2d] ml-[4px] cursor-pointer"
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
      if (res?.data?.token) {
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
.social-btn {
  background-color: #fff;
  border: 1px solid rgba(0, 0, 0, 0.26);
  border-radius: 2px;
  height: 40px;
  outline: none;
  padding: 0 2px;
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
}

.social-btn .icon {
  width: 22px;
  height: 22px;
  background-image: url(https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/assets/7ffa33c1e9518f30.png);
  background-repeat: no-repeat;
  margin-right: 8px;
}
.social-btn .icon.facebook {
  background-position: 5.555555555555555% 62.666666666666664%;
  background-size: 325% 287.5%;
}
.social-btn .icon.google {
  background-position: 83.92857142857143% 5.154639175257732%;
  background-size: 722.2222222222222% 638.8888888888889%;
}
.p-divider-horizontal {
  margin: 0;
}
/* Thêm CSS tùy chỉnh nếu cần */
</style>

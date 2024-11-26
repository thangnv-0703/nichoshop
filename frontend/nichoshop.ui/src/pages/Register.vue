<template>
  <auth-layout>
    <p class="text-2xl text-center py-6">Nhanh chóng và miễn phí để bắt đầu</p>
    <div
      class="tabs bg-gray-100 flex justify-between p-[6px] mb-[32px] rounded gap-2"
    >
      <div
        @click="onSwitchTab(tabs.personal)"
        class="cursor-pointer rounded tab-item py-[6px] px-[36px]"
        :class="[
          currentTab === tabs.personal
            ? 'bg-white text-[#0B80CC] shadow-md'
            : 'text-[#B2B2C2]',
        ]"
      >
        Cá nhân
      </div>
      <div
        @click="onSwitchTab(tabs.business)"
        class="cursor-pointer rounded tab-item py-[6px] px-[36px]"
        :class="[
          currentTab === tabs.business
            ? 'bg-white text-[#0B80CC] shadow-md'
            : 'text-[#B2B2C2]',
        ]"
      >
        Doanh nghiệp
      </div>
    </div>
    <Form
      v-slot="$form"
      :resolver="resolver"
      @submit="onFormSubmit"
      class="flex flex-col gap-4 w-full"
    >
      <div class="flex flex-col gap-4">
        <div class="flex flex-col gap-1">
          <InputText name="fullname" type="text" placeholder="Họ và tên" />
          <Message
            v-if="$form.fullname?.invalid"
            severity="error"
            size="small"
            variant="simple"
            >{{ $form.fullname.error?.message }}</Message
          >
        </div>
        <div class="flex flex-col gap-1">
          <InputText name="email" type="text" placeholder="Email" />
          <Message
            v-if="$form.email?.invalid"
            severity="error"
            size="small"
            variant="simple"
            >{{ $form.email.error?.message }}</Message
          >
        </div>

        <div class="flex flex-col gap-1">
          <Password
            name="password"
            placeholder="Nhập mật khẩu"
            :feedback="false"
            fluid
            toggleMask
          />
          <template v-if="$form.password?.invalid">
            <Message
              v-for="(error, index) of $form.password.errors"
              :key="index"
              severity="error"
              size="small"
              variant="simple"
              >{{ error.message }}</Message
            >
          </template>
        </div>
      </div>
      <Button type="submit" label="Tạo tài khoản" />
      <div class="flex items-center justify-center">
        <p class="text-[#81818F]">Đã có tài khoản?</p>
        <p
          class="text-[#0B80CC] ml-[4px] cursor-pointer"
          @click="onClickGoToLoginPage"
        >
          Đăng nhập
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
const tabs = ref({
  personal: 0,
  bussiness: 1,
});
const currentTab = ref(tabs.value.personal);
const router = useRouter();
const resolver = ref(
  zodResolver(
    z.object({
      fullname: z.string({ required_error: "Không được để trống" }),
      email: z
        .string({ required_error: "Không được để trống" })
        .email("Email không đúng định dạng"),
      password: z
        .string({ required_error: "Không được để trống" })
        .min(3, { message: "Ít nhất chứa 3 ký tự." })
        .refine((value) => /[a-z]/.test(value), {
          message: "Phải chứa chữ cái in thường.",
        })
        .refine((value) => /[A-Z]/.test(value), {
          message: "Phải chứa chữ cái in hoa.",
        }),
    })
  )
);
const onFormSubmit = ({ valid }) => {
  if (valid) {
    router.push("/");
  }
};
const onClickGoToLoginPage = () => {
  router.push("/login");
};
const onSwitchTab = (newValue) => {
  debugger;
  currentTab.value = newValue;
};
</script>

<style scoped lang="scss">
.tabs {
}
/* Thêm CSS tùy chỉnh nếu cần */
</style>

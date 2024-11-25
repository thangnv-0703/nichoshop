<template>
  <auth-layout>
    <Form
      v-slot="$form"
      :resolver="resolver"
      :initialValues="initialValues"
      @submit="onFormSubmit"
      class="flex flex-col gap-4"
    >
      <div class="flex flex-col gap-3">
        <div class="flex flex-col gap-1">
          <InputText name="fullname" type="text" placeholder="Họ và tên" />
          <!-- <Message
            v-if="$form.email?.invalid"
            severity="error"
            size="small"
            variant="simple"
            >{{ $form.email.error?.message }}</Message
          > -->
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

        <Password
          name="password"
          placeholder="Password"
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
      <Button type="submit" severity="secondary" label="Tạo tài khoản" />
      <div class="flex items-center justify-center">
        <p class="text-[#81818F]">Đã có tài khoản?</p>
        <Button
          class="font-bold"
          label="Đăng nhập"
          @click="onClickGoToLoginPage"
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
const resolver = ref(
  zodResolver(
    z.object({
      password: z
        .string()
        .min(3, { message: "Minimum 3 characters." })
        .max(8, { message: "Maximum 8 characters." })
        .refine((value) => /[a-z]/.test(value), {
          message: "Must have a lowercase letter.",
        })
        .refine((value) => /[A-Z]/.test(value), {
          message: "Must have an uppercase letter.",
        }),
      // .refine((value) => /d/.test(value), {
      //   message: "Must have a number.",
      // }),
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
</script>

<style scoped lang="scss">
/* Thêm CSS tùy chỉnh nếu cần */
</style>

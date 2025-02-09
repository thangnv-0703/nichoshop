<template>
  <auth-layout title="Đăng ký">
    <p class="text-2xl py-6 w-full">Đăng ký</p>
    <Form
      v-slot="$form"
      :resolver="resolver"
      @submit="onFormSubmit"
      class="flex flex-col gap-4 w-full"
    >
      <div class="flex flex-col gap-4">
        <div class="flex flex-col gap-1">
          <InputText
            name="UserName"
            type="text"
            v-model="model.UserName"
            placeholder="Tên đăng nhập"
          />
          <Message
            v-if="$form.userName?.invalid"
            severity="error"
            size="small"
            variant="simple"
            >{{ $form.userName.error?.message }}</Message
          >
        </div>
        <div class="flex flex-col gap-1">
          <InputText
            name="phoneNumber"
            v-model="model.PhoneNumber"
            type="text"
            placeholder="Số điện thoại"
          />
          <Message
            v-if="$form.phoneNumber?.invalid"
            severity="error"
            size="small"
            variant="simple"
            >{{ $form.phoneNumber.error?.message }}</Message
          >
        </div>

        <div class="flex flex-col gap-1">
          <Password
            name="password"
            v-model="model.Password"
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
      <Button type="submit" severity="danger" label="Tạo tài khoản" />
      <div class="flex items-center justify-center">
        <p class="text-[#81818F]">Đã có tài khoản?</p>
        <p
          class="text-[#ee4d2d] ml-[4px] cursor-pointer"
          @click="onClickGoToLoginPage"
        >
          {{ $t("i18nAuth.Login") }}
        </p>
      </div>
    </Form>
  </auth-layout>
</template>
<script lang="ts">
import { ref, getCurrentInstance } from "vue";
import { zodResolver } from "@primevue/forms/resolvers/zod";
import AuthLayout from "@/layouts/AuthLayout.vue";
import { z } from "zod";
import { useRouter } from "vue-router";
import baseDetail from "@/views/base/baseDetail.js";

export default {
  extends: baseDetail,
  components: { AuthLayout },

  setup() {
    const { proxy } = getCurrentInstance();
    const router = useRouter();
    const tabs = ref({
      personal: 0,
      bussiness: 1,
    });
    const currentTab = ref(tabs.value.personal);
    const model = ref({
      UserName: null,
      PhoneNumber: null,
      Password: null,
    });
    const module = "moduleUser";
    const resolver = ref(
      zodResolver(
        z.object({
          userName: z.string({ required_error: "Không được để trống" }),
          phoneNumber: z
            .string({ required_error: "Không được để trống" })
            .regex(/^84(?:3[2-9]|5[689]|7[06-9]|8[1-9]|9[0-9])\d{7}$/, {
              message: "Số điện thoại không đúng dịnh dạng",
            }),
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
    const onFormSubmit = async ({ valid }) => {
      if (!valid) {
        return;
      }
      const res = await proxy.$store.dispatch("moduleUser/signup", {
        UserName: model.value.UserName,
        PhoneNumber: model.value.PhoneNumber,
        Password: model.value.Password,
      });
      if (res) {
        router.push("/login");
      }
    };
    const onClickGoToLoginPage = () => {
      router.push("/login");
    };
    const onSwitchTab = (newValue) => {
      currentTab.value = newValue;
    };
    return {
      resolver,
      onClickGoToLoginPage,
      onFormSubmit,
      model,
      module,
    };
  },
};
</script>

<style scoped lang="scss"></style>

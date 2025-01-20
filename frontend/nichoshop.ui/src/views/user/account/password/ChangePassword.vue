<template>
  <div class="">
    <p class="text-xl">Đổi mật khẩu</p>
    <p class="mb-2">
      Để bảo mật tài khoản, vui lòng không chia sẻ mật khẩu cho người khác
    </p>
    <hr />
    <div class="grid grid-cols-4 gap-4">
      <div class="col-span-3">
        <Form
          ref="formRef"
          v-slot="$form"
          :resolver="resolver"
          @submit="onSubmit"
          class="flex flex-col gap-4 w-full"
        >
          <table class="mt-4">
            <tbody>
              <tr>
                <td class="text-gray-400 text-right">Mật khẩu hiện tại</td>
                <td class="pl-4 min-w-[500px]">
                  <div class="flex flex-col gap-1">
                    <Password
                      name="password"
                      v-model="model.password"
                      class="w-full"
                      :feedback="false"
                      fluid
                      toggleMask
                    />
                    <Message
                      v-if="$form.password?.invalid"
                      severity="error"
                      size="small"
                      variant="simple"
                      >{{ $form.password.error?.message }}</Message
                    >
                  </div>
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Mật khẩu mới</td>
                <td class="pl-4 min-w-[500px]">
                  <div class="flex flex-col gap-1">
                    <Password
                      name="newPassword"
                      v-model="model.newPassword"
                      class="w-full"
                      :feedback="false"
                      fluid
                      toggleMask
                    />
                    <Message
                      :ref="'newPasswordMessage'"
                      v-if="$form.newPassword?.invalid"
                      severity="error"
                      size="small"
                      variant="simple"
                      >{{ $form.newPassword.error?.message }}</Message
                    >
                  </div>
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Xác nhận mật khẩu</td>
                <td class="pl-4 min-w-[500px]">
                  <div class="flex flex-col gap-1">
                    <Password
                      name="confirmedNewPassword"
                      v-model="model.confirmedNewPassword"
                      class="w-full"
                      :feedback="false"
                      fluid
                      toggleMask
                    />

                    <Message
                      ref="confirmedNewPasswordMessage"
                      v-if="$form.confirmedNewPassword?.invalid"
                      severity="error"
                      size="small"
                      variant="simple"
                      >{{ $form.confirmedNewPassword.error?.message }}</Message
                    >
                  </div>
                </td>
              </tr>

              <tr>
                <td></td>
                <td class="pl-4 min-w-[500px]">
                  <Button label="Xác nhận" type="submit" severity="warn" />
                </td>
              </tr>
            </tbody>
          </table>
        </Form>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, onMounted, getCurrentInstance } from "vue";
import { zodResolver } from "@primevue/forms/resolvers/zod";
import { z } from "zod";
import { useRouter } from "vue-router";
import { showToast } from "@/utils/toastUtil";

import baseDetail from "@/views/base/baseDetail.js";
export default {
  extends: baseDetail,
  setup() {
    const { proxy } = getCurrentInstance();
    const model = ref({
      password: "",
      newPassword: "",
      confirmedNewPassword: "",
    });
    const module = "moduleUser";
    const router = useRouter();
    const formRef = ref(null);
    const formContext = ref(null); // Lưu trữ $form từ scoped slot
    const resolver = ref(
      zodResolver(
        z
          .object({
            newPassword: z
              .string({ required_error: "Không được để trống" })
              .min(3, { message: "Ít nhất chứa 3 ký tự." })
              .refine((value) => /[a-z]/.test(value), {
                message: "Phải chứa chữ cái in thường.",
              })
              .refine((value) => /[A-Z]/.test(value), {
                message: "Phải chứa chữ cái in hoa.",
              }),
            confirmedNewPassword: z.string({
              required_error: "Không được để trống",
            }),
            password: z.string({
              required_error: "Không được để trống",
            }),
          })
          .refine(
            (data) => {
              return data.newPassword === data.confirmedNewPassword;
            },
            {
              message: "Xác nhận mật khẩu không khớp.",
              path: ["confirmedNewPassword"],
            }
          )
      )
    );

    const onSubmit = async ({ valid }) => {
      // if (!valid) {
      //   return;
      // }

      const res = await proxy.$store.dispatch("moduleUser/changePassword", {
        password: model.value.password,
        newPassword: model.value.newPassword,
      });
      if (res?.data) {
        showToast({
          severity: "success",
          summary: "Thành công",
          detail: "Đổi mật khẩu thành công",
          group: "tc",
          life: 3000,
        });
        router.push("/user/account/profile");
      }
    };

    return {
      model,
      module,
      onSubmit,
      resolver,
      formRef,
    };
  },
};
</script>

<style scoped>
td {
  font-size: 14px;
  padding-bottom: 30px;
}
</style>

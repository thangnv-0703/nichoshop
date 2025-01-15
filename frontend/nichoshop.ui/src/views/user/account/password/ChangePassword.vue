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
                  <InputText
                    v-model="model.password"
                    name="password"
                    class="w-full"
                    type="password"
                  />
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Mật khẩu mới</td>
                <td class="pl-4 min-w-[500px]">
                  <InputText
                    v-model="model.newPassword"
                    name="newPassword"
                    class="w-full"
                    type="password"
                  />
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Xác nhận mật khẩu</td>
                <td class="pl-4 min-w-[500px]">
                  <InputText
                    v-model="model.confirmedNewPassword"
                    name="confirmedNewPassword"
                    class="w-full"
                    type="password"
                  />
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
    const loadEditData = true;
    const module = "moduleUser";

    return {
      model,
      module,
      loadEditData,
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

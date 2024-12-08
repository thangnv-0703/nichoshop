<template>
  <div class="">
    <p class="text-xl">Hồ sơ của tôi</p>
    <p class="mb-2">Quản lý thông tin hồ sơ để bảo mật tài khoản</p>
    <hr />
    <div class="grid grid-cols-3 gap-4">
      <div class="col-span-2">
        <Form
          v-slot="$form"
          :resolver="resolver"
          @submit="onSubmit"
          class="flex flex-col gap-4 w-full"
        >
          <table class="mt-4">
            <tbody>
              <tr>
                <td class="text-gray-400 text-right">Tên đăng nhập</td>
                <td class="pl-4 min-w-[500px]">
                  <InputText
                    v-model="model.userName"
                    name="userName"
                    class="w-full"
                    type="text"
                  />
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Tên</td>
                <td class="pl-4 min-w-[500px]">
                  <InputText
                    v-model="model.fullName"
                    name="fullname"
                    class="w-full"
                    type="text"
                  />
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Email</td>
                <td class="pl-4 min-w-[500px]">
                  <InputText
                    v-model="model.email"
                    name="email"
                    class="w-full"
                    type="text"
                  />
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Số điện thoại</td>
                <td class="pl-4 min-w-[500px]">
                  <InputText
                    v-model="model.phoneNumber"
                    name="phoneNumber"
                    class="w-full"
                    type="text"
                  />
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Giới tính</td>
                <td class="pl-4 min-w-[500px]">
                  <div class="flex flex-wrap gap-4">
                    <RadioButtonGroup
                      v-model="model.gender"
                      name="gender"
                      class="flex flex-wrap gap-4"
                    >
                      <div class="flex items-center gap-2">
                        <RadioButton inputId="male" name="gender" value="0" />
                        <label for="male">Nam</label>
                      </div>
                      <div class="flex items-center gap-2">
                        <RadioButton inputId="female" name="gender" value="1" />
                        <label for="female">Nữ</label>
                      </div>
                      <div class="flex items-center gap-2">
                        <RadioButton inputId="others" name="gender" value="2" />
                        <label for="others">Khác</label>
                      </div>
                    </RadioButtonGroup>
                  </div>
                </td>
              </tr>
              <tr>
                <td class="text-gray-400 text-right">Ngày sinh</td>
                <td class="pl-4 min-w-[500px]">
                  <DatePicker
                    v-model="icondisplay"
                    showIcon
                    fluid
                    iconDisplay="input"
                  />
                </td>
              </tr>
              <tr>
                <td></td>
                <td class="pl-4 min-w-[500px]">
                  <Button label="Lưu" type="submit" severity="warn" />
                </td>
              </tr>
            </tbody>
          </table>
        </Form>
      </div>
      <div class="flex flex-col mt-5">
        <img
          src="https://down-vn.img.susercontent.com/file/36b878bafc795dd0ad8c0b142270d8b9"
          class="w-[100px] rounded-full"
        />

        <Button label="Chọn ảnh" severity="secondary" class="w-[100px] mt-2" />
        <!-- <FileUpload
          mode="basic"
          name="demo[]"
          url="/api/upload"
          accept="image/*"
          :maxFileSize="1000000"
          @upload="onUpload"
          :auto="true"
          chooseLabel="Chọn ảnh"
        /> -->
        <span class="text-gray-500"
          >Dụng lượng file tối đa 1 MB <br />
          Định dạng:.JPEG, .PNG</span
        >
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
      fullName: null,
      userName: null,
      email: null,
      phoneNumber: null,
      gender: null,
    });
    const loadEditData = true;
    const module = "moduleUser";
    const editMode = proxy.$nicho.enumeration.editMode.Edit;
    const customParam = () => {
      debugger;
      return { ...proxy.model, gender: 1 };
    };
    return { model, module, loadEditData, editMode, customParam };
  },
};
</script>

<style scoped>
td {
  font-size: 14px;
  padding-bottom: 30px;
}
</style>

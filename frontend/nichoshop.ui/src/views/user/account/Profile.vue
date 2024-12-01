<template>
  <div class="">
    <p class="text-xl">Hồ sơ của tôi</p>
    <p class="mb-2">Quản lý thông tin hồ sơ để bảo mật tài khoản</p>
    <hr />
    <table class="mt-4">
      <tbody>
        <tr>
          <td class="text-gray-400 text-right">Tên đăng nhập</td>
          <td class="pl-4 min-w-[500px]">Tên đăng nhập</td>
        </tr>
        <tr>
          <td class="text-gray-400 text-right">Tên</td>
          <td class="pl-4 min-w-[500px]">
            <InputText name="fullname" class="w-full" type="text" />
          </td>
        </tr>
        <tr>
          <td class="text-gray-400 text-right">Email</td>
          <td class="pl-4 min-w-[500px]">ph*************@gmail.com</td>
        </tr>
        <tr>
          <td class="text-gray-400 text-right">Số điện thoại</td>
          <td class="pl-4 min-w-[500px]">*********27</td>
        </tr>
        <tr>
          <td class="text-gray-400 text-right">Giới tính</td>
          <td class="pl-4 min-w-[500px]">
            <div class="flex flex-wrap gap-4">
              <div class="flex items-center gap-2">
                <RadioButton
                  v-model="ingredient"
                  inputId="male"
                  name="gender"
                  value="male"
                />
                <label for="male">Nam</label>
              </div>
              <div class="flex items-center gap-2">
                <RadioButton
                  v-model="ingredient"
                  inputId="female"
                  name="gender"
                  value="female"
                />
                <label for="female">Nữ</label>
              </div>
              <div class="flex items-center gap-2">
                <RadioButton
                  v-model="ingredient"
                  inputId="others"
                  name="gender"
                  value="others"
                />
                <label for="others">Khác</label>
              </div>
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
            <Button label="Lưu" severity="warn" />
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
td {
  font-size: 14px;
  padding-bottom: 30px;
}
</style>

<script setup lang="ts">
import { ref } from "vue";
import { VueFinalModal } from "vue-final-modal";
import { zodResolver } from "@primevue/forms/resolvers/zod";
import { GoogleMap, Marker } from "vue3-google-map";

import { z } from "zod";
const selectedCountry = ref();
const countries = ref([
  { name: "Australia", code: "AU" },
  { name: "Brazil", code: "BR" },
  { name: "China", code: "CN" },
  { name: "Egypt", code: "EG" },
  { name: "France", code: "FR" },
  { name: "Germany", code: "DE" },
  { name: "India", code: "IN" },
  { name: "Japan", code: "JP" },
  { name: "Spain", code: "ES" },
  { name: "United States", code: "US" },
]);

const center = { lat: 21.028511, lng: 105.804817 };
// const toast = useToast();
const initialValues = ref({
  password: "",
});

const resolver = ref(
  zodResolver(
    z.object({
      fullName: z.string({ required_error: "Không được để trống" }),
    })
  )
);
</script>

<template>
  <VueFinalModal
    :hide-overlay="false"
    :overlay-transition="'vfm-fade'"
    :content-transition="'vfm-fade'"
    :click-to-close="true"
    :esc-to-close="true"
    :background="'non-interactive'"
    :lock-scroll="true"
    :reserve-scroll-bar-gap="true"
    :swipe-to-close="none"
    class="flex justify-center items-center"
    content-class="w-[500px] mx-4 p-5 bg-white dark:bg-gray-900 border dark:border-gray-700 rounded-lg space-y-2"
  >
    <template #default="{ close }">
      <span class="text-xl">Cập nhật địa chỉ</span>
      <Form
        v-slot="$form"
        :resolver="resolver"
        :initialValues="initialValues"
        @submit="onFormSubmit"
        class="flex flex-col gap-4 w-full"
      >
        <div class="flex flex-col gap-4">
          <div class="grid grid-cols-2 gap-1">
            <div class="flex flex-col gap-1">
              <FloatLabel variant="on">
                <InputText id="fullName" />
                <label for="fullName">Họ và tên</label>
              </FloatLabel>
              <template v-if="$form.fullName?.invalid">
                <Message
                  v-for="(error, index) of $form.fullName.errors"
                  :key="index"
                  severity="error"
                  size="small"
                  variant="simple"
                  >{{ error.message }}</Message
                >
              </template>
            </div>
            <div class="flex flex-col gap-1">
              <div class="flex flex-col gap-1">
                <FloatLabel variant="on">
                  <InputMask id="phonenumber" mask="(999) 999-9999" fluid />
                  <label for="phonenumber">Số điện thoại</label>
                </FloatLabel>
              </div>
            </div>
          </div>

          <div class="grid grid-cols-3 gap-1">
            <Select
              filter
              name="city"
              :options="countries"
              optionLabel="name"
              placeholder="Tỉnh/Thành phố"
            />
            <Select
              filter
              name="city"
              :options="countries"
              optionLabel="name"
              placeholder="Quận/huyện"
            />
            <Select
              filter
              name="city"
              :options="countries"
              optionLabel="name"
              placeholder="Phường/xã"
            />
          </div>

          <div class="flex flex-col gap-1">
            <InputText
              name="specificAdress"
              type="text"
              placeholder="Địa chỉ cụ thể"
            />
            <template v-if="$form.specificAddress?.invalid">
              <Message
                v-for="(error, index) of $form.specificAddress.errors"
                :key="index"
                severity="error"
                size="small"
                variant="simple"
                >{{ error.message }}</Message
              >
            </template>
          </div>
          <GoogleMap
            :api-key="process?.env?.VUE_APP_API_KEY"
            style="width: 100%; height: 200px"
            :center="center"
            :zoom="15"
          >
            <Marker :options="{ position: center }" />
          </GoogleMap>
        </div>
        <div class="flex justify-end gap-2">
          <Button
            @click="() => close()"
            class="w-[150px]"
            severity="secondary"
            label="Trở lại"
          />
          <Button
            type="submit"
            class="w-[150px]"
            severity="warn"
            label="Hoàn thành"
          />
        </div>
      </Form>
    </template>
    <!-- <LoginFormVorms @submit="(formData) => emit('submit', formData)" /> -->
  </VueFinalModal>
</template>
<style scoped></style>

<script>
import { ref, onMounted, getCurrentInstance } from "vue";
import { VueFinalModal } from "vue-final-modal";
import { zodResolver } from "@primevue/forms/resolvers/zod";
import { GoogleMap, Marker } from "vue3-google-map";
import baseDetail from "@/views/base/baseDetail.js";
import { z } from "zod";
export default {
  extends: baseDetail,
  components: { VueFinalModal, GoogleMap, Marker },
  setup() {
    const model = ref({
      fullName: null,
      phoneNumber: null,
      street: null,
      province: null,
      district: null,
      ward: null,
    });
    const { proxy } = getCurrentInstance();
    const module = "moduleUserAddress";
    const provinces = ref([]);
    const districts = ref([]);
    const wards = ref([]);
    const center = { lat: 21.028511, lng: 105.804817 };
    const resolver = ref(
      zodResolver(
        z.object({
          fullName: z.string({ required_error: "Không được để trống" }),
        })
      )
    );
    onMounted(async () => {
      const res = await proxy.$store.dispatch("moduleLocation/getLocation", {
        type: 1, //enum
      });
      provinces.value = res.data;
    });

    const onChangeProvince = async (data) => {
      debugger;
      const res = await proxy.$store.dispatch("moduleLocation/getLocation", {
        type: 2, //enum
        parentCode: provinces.value.find((item) => item.name === data.value)
          ?.code,
      });
      districts.value = res.data;
    };

    const onChangeDistrict = async (data) => {
      const res = await proxy.$store.dispatch("moduleLocation/getLocation", {
        type: 3, //enum
        parentCode: districts.value.find((item) => item.name === data.value)
          ?.code,
      });
      wards.value = res.data;
    };
    return {
      model,
      module,
      resolver,
      center,
      provinces,
      districts,
      wards,
      onChangeProvince,
      onChangeDistrict,
    };
  },
};
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
      <span class="text-xl">{{ $attrs.popupTitle }}</span>
      <Form
        v-slot="$form"
        :resolver="resolver"
        @submit="onSubmit"
        class="flex flex-col gap-4 w-full"
      >
        <div class="flex flex-col gap-4">
          <div class="grid grid-cols-2 gap-1">
            <div class="flex flex-col gap-1">
              <FloatLabel variant="on">
                <InputText v-model="model.fullName" id="fullName" />
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
                  <InputText v-model="model.phoneNumber" id="phoneNumber" />
                  <!-- <InputMask
                    v-model="model.PhoneNumber"
                    id="phonenumber"
                    mask="(99)999 999 999"
                    fluid
                  /> -->
                  <label for="phonenumber">Số điện thoại</label>
                </FloatLabel>
              </div>
            </div>
          </div>

          <div class="grid grid-cols-3 gap-1">
            <Select
              @change="onChangeProvince"
              v-model="model.province"
              optionValue="name"
              filter
              name="provinces"
              :options="provinces"
              optionLabel="name"
              placeholder="Tỉnh/Thành phố"
            />
            <Select
              filter
              @change="onChangeDistrict"
              v-model="model.district"
              optionValue="name"
              name="districts"
              :options="districts"
              optionLabel="name"
              placeholder="Quận/huyện"
            />
            <Select
              filter
              v-model="model.ward"
              name="wards"
              optionValue="name"
              :options="wards"
              optionLabel="name"
              placeholder="Phường/xã"
            />
          </div>

          <div class="flex flex-col gap-1">
            <InputText
              v-model="model.street"
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
          <div class="flex items-center gap-2">
            <Checkbox
              v-model="model.isDefault"
              inputId="staySignedIn"
              name="staySignedIn"
              binary
            />
            <label for="staySignedIn">Đặt làm địa chỉ mặc định</label>
          </div>
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

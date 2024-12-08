<template>
  <div>
    <div class="card">
      <div class="flex justify-end">
        <Button
          @click="add"
          label="Thêm địa chỉ mới"
          severity="warn"
          icon="pi pi-plus"
        />
      </div>

      <DataTable
        :ref="baseGrid"
        v-model:selection="selectedProducts"
        :value="items"
        dataKey="id"
        :paginator="true"
        :rows="10"
        :filters="filters"
        paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
        :rowsPerPageOptions="[5, 10, 25]"
        currentPageReportTemplate=""
      >
        <Column field="price" header="Địa chỉ" style="min-width: 8rem">
          <template #body="slotProps">
            <div class="flex">
              <div>
                <b>{{ slotProps.data["fullName"] }}</b>
              </div>
              <Divider layout="vertical" />
              <div>
                {{ slotProps.data["phoneNumber"]["value"] }}
              </div>
            </div>
            <div>
              {{ slotProps.data["street"] }}
            </div>
            <div>
              {{
                `${slotProps.data["ward"]}, ${slotProps.data["district"]}, ${slotProps.data["province"]}`
              }}
            </div>
            <Tag severity="warn" value="Mặc định"></Tag>
          </template>
        </Column>

        <Column :exportable="false" style="width: 140px">
          <template #body="slotProps">
            <div class="flex justify-end">
              <span
                @click="edit(slotProps.data)"
                class="text-[#0B80CC] cursor-pointer"
                >Cập nhật</span
              >
              <span
                @click="deleteOne(slotProps.data)"
                class="text-[#0B80CC] cursor-pointer ml-3"
                >Xóa</span
              >
            </div>
            <Button
              :disabled="slotProps.data['isDefault']"
              class="w-[160px] set-default-btn"
              label="Thiết lập mặc định"
              severity="secondary"
              variant="outlined"
            />
          </template>
        </Column>
      </DataTable>
    </div>
  </div>
</template>

<script>
import { ref, onMounted, getCurrentInstance } from "vue";
import { FilterMatchMode } from "@primevue/core/api";
import baseList from "@/views/base/baseList.js";
import DetailModal from "@/views/user/account/address/UserAddressPopup.vue";
export default {
  extends: baseList,
  setup() {
    const detailModal = DetailModal;
    const autoLoadGrid = true;
    const { proxy } = getCurrentInstance();
    const module = "moduleUserAddress";
    onMounted(() => {
      //   ProductService.getProducts().then((data) => (products.value = data));
    });
    const dt = ref();
    const products = ref([{}, {}]);
    const selectedProducts = ref();
    const filters = ref({
      global: { value: null, matchMode: FilterMatchMode.CONTAINS },
    });
    return {
      products,
      detailModal,
      module,
      autoLoadGrid,
    };
  },
};
</script>
<style scoped>
.set-default-btn {
  line-height: 13px;
}
</style>

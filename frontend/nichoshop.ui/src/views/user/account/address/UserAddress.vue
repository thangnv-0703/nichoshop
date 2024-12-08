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
        :value="products"
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
            <div>
              <div>
                <div>
                  <span><div>Nguyễn Phúc Tĩnh</div></span>
                  <div>(+84) 948 314 827</div>
                </div>
              </div>
              <div>
                <div>
                  <div>
                    <div>Toà Nhà N03-T1, khu Ngoại Giao Đoàn</div>
                    <div>Phường Xuân Tảo, Quận Bắc Từ Liêm, Hà Nội</div>
                  </div>
                </div>
                <div>
                  <button class="FIxzOe H6ESfz U4E1nT" disabled="">
                    Thiết lập mặc định
                  </button>
                </div>
              </div>
              <div>
                <Tag severity="warn" value="Mặc định"></Tag>
                <Tag severity="secondary" value="Địa chỉ lấy hàng"></Tag>
              </div>
            </div>
          </template>
        </Column>

        <Column :exportable="false" style="width: 140px">
          <template #body="slotProps">
            <Button
              icon="pi pi-pencil"
              outlined
              rounded
              class="mr-2"
              @click="edit(slotProps.data)"
            />
            <Button
              icon="pi pi-trash"
              outlined
              rounded
              severity="danger"
              @click="confirmDeleteProduct(slotProps.data)"
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
    const autoLoad = true;
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
    };
  },
};
</script>

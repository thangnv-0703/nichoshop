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
            <div class="Ln8BPM">
              <div role="heading" class="ZP_sH4 EhiHrl">
                <div
                  id="address-card_56bc40f8-6982-4d02-9d97-ba28faa66de9_header"
                  class="PvQ82w Bo_fXH"
                >
                  <span class="WZoJQT sHEV0u"
                    ><div class="xwB4_Q">Nguyễn Phúc Tĩnh</div></span
                  >
                  <div class="qhS2mB"></div>
                  <div role="row" class="urSLUA SDYBn1 PoI6l8">
                    (+84) 948 314 827
                  </div>
                </div>
                <div class="oQEeks">
                  <button class="JHMWU8">Cập nhật</button>
                </div>
              </div>
              <div
                id="address-card_56bc40f8-6982-4d02-9d97-ba28faa66de9_content"
                role="heading"
                class="ZP_sH4 EhiHrl"
              >
                <div class="PvQ82w Bo_fXH">
                  <div class="W_MyuV">
                    <div role="row" class="PoI6l8">
                      Toà Nhà N03-T1, khu Ngoại Giao Đoàn
                    </div>
                    <div role="row" class="PoI6l8">
                      Phường Xuân Tảo, Quận Bắc Từ Liêm, Hà Nội
                    </div>
                  </div>
                </div>
                <div class="JwDIHs oQEeks">
                  <button class="FIxzOe H6ESfz U4E1nT" disabled="">
                    Thiết lập mặc định
                  </button>
                </div>
              </div>
              <div
                id="address-card_56bc40f8-6982-4d02-9d97-ba28faa66de9_badge"
                role="row"
                class="Xx6fjH PoI6l8"
              >
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
// import { useToast } from "primevue/usetoast";
// import { ProductService } from "@/service/ProductService";
import DetailModal from "@/views/user/account/address/AccountAddressPopup.vue";
export default {
  extends: baseList,
  setup() {
    const detailModal = DetailModal;
    const { proxy } = getCurrentInstance();
    onMounted(() => {
      //   ProductService.getProducts().then((data) => (products.value = data));
    });

    // const toast = useToast();
    const dt = ref();
    const products = ref([{}, {}]);
    const selectedProducts = ref();
    const filters = ref({
      global: { value: null, matchMode: FilterMatchMode.CONTAINS },
    });
    return {
      products,
      detailModal,
    };
  },
};
</script>

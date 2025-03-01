<template>
  <Header />
  <div class="card nicho-container">
    <div v-if="items.length > 0">
      <DataTable v-model:selection="selectedProducts" :value="items" rowGroupMode="subheader"
        groupRowsBy="representative.name" sortMode="single" sortField="representative.name" :sortOrder="1">
        <Column field="isSelected" selectionMode="multiple" headerStyle="width: 3rem">
          <!-- <template #body="slotProps">
            <Checkbox :value="slotProps.data.isSelected" />
          </template> -->
        </Column>
        <!-- <Column field="representative.name" header="Representative"></Column> -->
        <Column field="name" header="Sản phẩm" style="min-width: 520px">
          <template #body="slotProps">
            <div class="flex gap-3">
              <div class="flex gap-3 w-[350px]">
                <img src="https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-m045ss3gh8y750" width="80"
                  style="vertical-align: middle" />
                <span>
                  {{ slotProps.data.productName }}
                </span>
              </div>
              <div>
                <div>Phân loại hàng</div>
                <div>{{ slotProps.data.productVariantName }}</div>
              </div>
            </div>
          </template>
        </Column>

        <Column field="amount" header="Đơn giá" style="min-width: 170px">
          <template #body="slotProps">
            ₫ {{ slotProps.data.amount.toLocaleString("vi-VN") }}
          </template>
        </Column>
        <Column field="quantity" header="Số lượng" style="min-width: 160px">
          <template #body="slotProps">
            <div class="flex">
              <button @click="updateQuantity(slotProps.data, true)" class="w-[32px] decrease div-center cursor-pointer">
                <svg class="icon">
                  <polygon points="4.5 4.5 3.5 4.5 0 4.5 0 5.5 3.5 5.5 4.5 5.5 10 5.5 10 4.5"></polygon>
                </svg>
              </button>
              <div class="quantity">{{ slotProps.data.quantity }}</div>
              <button @click="updateQuantity(slotProps.data, false)"
                class="w-[32px] increase div-center cursor-pointer">
                <svg class="icon">
                  <polygon points="10 4.5 5.5 4.5 5.5 0 4.5 0 4.5 4.5 0 4.5 0 5.5 4.5 5.5 4.5 10 5.5 10 5.5 5.5 10 5.5">
                  </polygon>
                </svg>
              </button>
            </div>
          </template>
        </Column>
        <Column field="price" header="Số tiền" style="min-width: 120px" bodyStyle=" color: #ee4d2d">
          <template #body="slotProps">
            ₫
            {{
              (slotProps.data.quantity * slotProps.data.amount).toLocaleString(
                "vi-VN"
              )
            }}
          </template>
        </Column>
        <Column :exportable="false" style="width: 50px">
          <template #body="slotProps">
            <div class="flex justify-end">
              <span @click="deleteOne(slotProps.data)" class="text-[#0B80CC] cursor-pointer ml-3">Xóa</span>
            </div>
          </template>
        </Column>
        <template v-if="false" #groupheader="slotProps">
          <div class="flex items-center gap-2">
            <Checkbox @update:modelValue="
              (value) => selectProductsInGroup(value, slotProps.data)
            " :modelValue="isGroupChecked(slotProps.data)" binary />
            <img :alt="slotProps.data.representative.name"
              :src="`https://primefaces.org/cdn/primevue/images/avatar/${slotProps.data.representative.image}`"
              width="32" style="vertical-align: middle" />
            <span>{{ slotProps.data.representative.name }}</span>
          </div>
        </template>
        <!-- <template #groupfooter="slotProps">
        <div class="flex justify-end font-bold w-full">
          Total items:
          {{ calculateCustomerTotal(slotProps.data.representative.name) }}
        </div>
      </template> -->
      </DataTable>

      <div class="cart-footer">
        <div class="flex justify-between">
          <div class="flex items-center gap-4">
            <Checkbox @update:modelValue="(value) => selectAllProducts(value)"
              :modelValue="selectedProducts.length == items.length" binary />
            <button>Chọn tất cả</button>
            <button>Xóa</button>
          </div>
          <div class="flex items-center gap-4">
            <span>Tổng thanh toán ({{ selectedProducts.length }} sản phẩm)</span>
            <span> đ {{ getTotalPrice() }}</span>
            <Button label="Mua hàng" class="w-[210px]" severity="warn" @click="checkOut" />
          </div>
        </div>
      </div>
    </div>
    <div class="list-empty" v-else>Không có dữ liệu</div>
  </div>
</template>

<script>
import baseList from "@/views/base/baseList.js";
import { ref, onMounted, getCurrentInstance, watch } from "vue";
import _ from "lodash";
import { useRoute, useRouter } from 'vue-router';

export default {
  extends: baseList,
  setup() {
    const route = useRoute();
    const router = useRouter();

    onMounted(async () => {
      const res = await proxy.$store.dispatch("moduleCart/getItem");
      cartId.value = res?.data?.id;
      selectedProducts.value = proxy.items.filter((x) => x.isSelected);
    });
    const { proxy } = getCurrentInstance();
    const cartId = ref(null);
    const module = "moduleCartItem";
    const selectedProducts = ref([]);

    watch(selectedProducts, (newValue, oldValue) => {

      updateSelection(
        newValue.filter((item) => !oldValue.some((x) => x.id == item.id)),
        true
      );
      updateSelection(
        oldValue.filter((item) => !newValue.some((x) => x.id == item.id)),
        false
      );
    });

    const selectAllProducts = (isChecked) => {
      if (isChecked) {
        selectedProducts.value = _.unionBy(
          selectedProducts.value,
          proxy.items,
          "id"
        );
      } else {
        selectedProducts.value = [];
      }
    };
    const selectProductsInGroup = (isChecked, data) => {
      if (isChecked) {
        let productInGroup = proxy.items.filter((item) => {
          return item.representative.name === data.representative.name;
        });
        selectedProducts.value = _.unionBy(
          selectedProducts.value,
          productInGroup,
          "id"
        );
      } else {
        selectedProducts.value = selectedProducts.value.filter((item) => {
          return item.representative.name !== data.representative.name;
        });
      }
    };
    const isGroupChecked = (data) => {
      return (
        selectedProducts.value.filter((item) => {
          return item.representative.name === data.representative.name;
        }).length ===
        proxy.items.filter((item) => {
          return item.representative.name === data.representative.name;
        }).length
      );
    };

    const updateSelection = (items, isSelected) => {
      if (items.length === 0) return;
      proxy.$store.dispatch("moduleCartItem/updateCartItemMultiSelection", {
        SkuIds: items.map((x) => x.skuId),
        CartId: cartId.value,
        IsSelected: isSelected,
      });
    };

    const updateQuantity = (item, isDecrease) => {
      const product = proxy.items.find((product) => product.id === item.id);

      proxy.$store.dispatch("moduleCartItem/updateItem", {
        Id: product?.skuId,
        CartId: cartId.value,
        Quantity: isDecrease ? --product.quantity : ++product.quantity,
      });
    };

    const getTotalPrice = () => {
      return selectedProducts.value
        .reduce((acc, item) => {
          return acc + item.amount * item.quantity;
        }, 0)
        .toLocaleString("vi-VN");
    };

    const checkOut = () => {
      router.push({ name: 'checkout' });
    }

    return {
      selectedProducts,
      updateQuantity,
      module,
      isGroupChecked,
      selectProductsInGroup,
      selectAllProducts,
      getTotalPrice,
      updateSelection,
      checkOut
    };
  },
};
</script>
<style scoped>
.card.nicho-container {
  color: black;
}

.quantity,
.decrease,
.increase {
  border: 1px solid rgba(0, 0, 0, 0.09);
}

.quantity {
  text-align: center;
  width: 50px;
}

.increase .icon,
.decrease .icon {
  flex-shrink: 0;
  font-size: 10px;
  height: 10px;
  width: 10px;
}

.cart-footer {
  z-index: 1;
  position: sticky;
  padding: 12px 0;
  width: 100%;
  bottom: 0;
  background-color: #fff;
}

.cart-footer:before {
  background: linear-gradient(transparent, rgba(0, 0, 0, 0.06));
  content: "";
  height: 1.25rem;
  left: 0;
  position: absolute;
  top: -1.25rem;
  width: 100%;
}

:deep(.p-datatable-tbody > tr) {
  background: white;
}

:deep(.p-datatable-header-cell) {
  background: white;
  color: black;
}

:deep(.p-datatable-tbody tr) {
  color: black;
}

:deep(.p-checkbox-box) {
  background: white;
}
</style>

<template>
  <Header />
  <div class="card nicho-container">
    <DataTable
      v-model:selection="selectedProducts"
      :value="products"
      rowGroupMode="subheader"
      groupRowsBy="representative.name"
      sortMode="single"
      sortField="representative.name"
      :sortOrder="1"
    >
      <Column selectionMode="multiple" headerStyle="width: 3rem"></Column>
      <Column field="representative.name" header="Representative"></Column>
      <Column field="name" header="Sản phẩm" style="min-width: 520px">
        <template #body="slotProps">
          <div class="flex gap-3">
            <div class="flex gap-3 w-[350px]">
              <img
                src="https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-m045ss3gh8y750"
                width="80"
                style="vertical-align: middle"
              />
              <span>
                {{ slotProps.data.productName }}
              </span>
            </div>
            <div>
              <div>Phân loại hàng</div>
              <div>{{ slotProps.data.productVariantName }}</div>
            </div>
          </div>
        </template></Column
      >

      <Column field="amount" header="Đơn giá" style="min-width: 170px">
        <template #body="slotProps">
          ₫ {{ slotProps.data.amount.toLocaleString("vi-VN") }}
        </template>
      </Column>
      <Column field="quantity" header="Số lượng" style="min-width: 160px">
        <template #body="slotProps">
          <div class="flex">
            <button
              @click="decreaseQuantity(slotProps.data)"
              class="w-[32px] decrease div-center cursor-pointer"
            >
              <svg class="icon">
                <polygon
                  points="4.5 4.5 3.5 4.5 0 4.5 0 5.5 3.5 5.5 4.5 5.5 10 5.5 10 4.5"
                ></polygon>
              </svg>
            </button>
            <div class="quantity">{{ slotProps.data.quantity }}</div>
            <button
              @click="increaseQuantity(slotProps.data)"
              class="w-[32px] increase div-center cursor-pointer"
            >
              <svg class="icon">
                <polygon
                  points="10 4.5 5.5 4.5 5.5 0 4.5 0 4.5 4.5 0 4.5 0 5.5 4.5 5.5 4.5 10 5.5 10 5.5 5.5 10 5.5"
                ></polygon>
              </svg>
            </button>
          </div>
        </template>
      </Column>
      <Column
        field="price"
        header="Số tiền"
        style="min-width: 120px"
        bodyStyle=" color: #ee4d2d"
      >
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
            <span
              @click="deleteOne(slotProps.data)"
              class="text-[#0B80CC] cursor-pointer ml-3"
              >Xóa</span
            >
          </div>
        </template>
      </Column>
      <template v-if="false" #groupheader="slotProps">
        <div class="flex items-center gap-2">
          <Checkbox
            @update:modelValue="
              (value) => selectProductsInGroup(value, slotProps.data)
            "
            :modelValue="isGroupChecked(slotProps.data)"
            binary
          />
          <img
            :alt="slotProps.data.representative.name"
            :src="`https://primefaces.org/cdn/primevue/images/avatar/${slotProps.data.representative.image}`"
            width="32"
            style="vertical-align: middle"
          />
          <span>{{ slotProps.data.representative.name }}</span>
        </div>
      </template>
      <!-- <template #groupfooter="slotProps">
        <div class="flex justify-end font-bold w-full">
          Total products:
          {{ calculateCustomerTotal(slotProps.data.representative.name) }}
        </div>
      </template> -->
    </DataTable>

    <div class="cart-footer">
      <div class="flex justify-between">
        <div class="flex items-center gap-4">
          <Checkbox
            @update:modelValue="(value) => selectAllProducts(value)"
            :modelValue="selectedProducts.length == products.length"
            binary
          />
          <button>Chọn tất cả</button>
          <button>Xóa</button>
        </div>
        <div class="flex items-center gap-4">
          <span>Tổng thanh toán (0 sản phẩm)</span>
          <span> đ 0</span>
          <Button label="Mua hàng" class="w-[210px]" severity="warn" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import baseList from "@/views/base/baseList.js";
import { ref, onMounted, getCurrentInstance } from "vue";
import _ from "lodash";

export default {
  extends: baseList,
  setup() {
    onMounted(async () => {
      const res = await proxy.$store.dispatch("moduleCart/getItem");
      products.value = res?.data?.items || [];
      // products.value = [
      //   {
      //     id: 1033,
      //     name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      //     price: 99999,
      //     quantity: 1,
      //     verified: true,
      //     activity: 85,
      //     representative: {
      //       name: "Bernardo Dominic",
      //       image: "bernardodominic.png",
      //     },
      //   },
      //   {
      //     id: 1034,
      //     name: "Alishia Sergi",
      //     price: 99999,
      //     quantity: 1,
      //     verified: false,
      //     activity: 46,
      //     representative: {
      //       name: "Ivan Magalhaes",
      //       image: "ivanmagalhaes.png",
      //     },
      //   },
      //   {
      //     id: 1035,
      //     name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      //     price: 99999,
      //     quantity: 1,
      //     verified: true,
      //     activity: 32,
      //     representative: {
      //       name: "Onyama Limba",
      //       image: "onyamalimba.png",
      //     },
      //   },
      //   {
      //     id: 1038,
      //     name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      //     price: 99999,
      //     quantity: 1,
      //     verified: true,
      //     activity: 25,
      //     representative: {
      //       name: "Bernardo Dominic",
      //       image: "bernardodominic.png",
      //     },
      //   },
      //   {
      //     id: 1039,
      //     name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      //     price: 99999,
      //     quantity: 1,
      //     verified: true,
      //     activity: 25,
      //     representative: {
      //       name: "Bernardo Dominic",
      //       image: "bernardodominic.png",
      //     },
      //   },
      // ];
    });
    const { proxy } = getCurrentInstance();

    const module = "moduleCart";
    const products = ref([]);
    const selectedProducts = ref([]);
    const selectAllProducts = (isChecked) => {
      if (isChecked) {
        selectedProducts.value = _.unionBy(
          selectedProducts.value,
          products.value,
          "id"
        );
      } else {
        selectedProducts.value = [];
      }
    };
    const selectProductsInGroup = (isChecked, data) => {
      if (isChecked) {
        let productInGroup = products.value.filter((item) => {
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
        products.value.filter((item) => {
          return item.representative.name === data.representative.name;
        }).length
      );
    };
    const decreaseQuantity = (item) => {
      const product = products.value.find((product) => product.id === item.id);
      if (product) {
        product.quantity--;
      }
      proxy.$store.dispatch("moduleCart/updateItem", product);
    };
    const increaseQuantity = (item) => {
      const product = products.value.find((product) => product.id === item.id);
      if (product) {
        product.quantity++;
      }
    };
    return {
      products,
      selectedProducts,
      decreaseQuantity,
      increaseQuantity,
      module,
      isGroupChecked,
      selectProductsInGroup,
      selectAllProducts,
    };
  },
};
</script>
<style scoped>
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
</style>

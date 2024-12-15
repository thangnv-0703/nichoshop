<template>
  <Header />
  <div class="card nicho-container">
    <DataTable
      v-model:selection="selectedProduct"
      :value="customers"
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
                {{ slotProps.data.name }}
              </span>
            </div>
            <div>
              <div>Phân loại hàng</div>
              <div>Đen, L</div>
            </div>
          </div>
        </template></Column
      >

      <Column
        field="company"
        header="Đơn giá"
        style="min-width: 170px"
      ></Column>
      <Column field="status" header="Số lượng" style="min-width: 160px">
        <template #body="slotProps">
          <div class="flex">
            <button class="w-[32px] decrease grid cursor-pointer">
              <svg class="icon">
                <polygon
                  points="4.5 4.5 3.5 4.5 0 4.5 0 5.5 3.5 5.5 4.5 5.5 10 5.5 10 4.5"
                ></polygon>
              </svg>
            </button>
            <div class="quantity">1</div>
            <button class="w-[32px] increase grid cursor-pointer">
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
        field="company"
        header="Số tiền"
        style="min-width: 100px"
        bodyStyle=" color: #ee4d2d"
      ></Column>
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
      <template #groupheader="slotProps">
        <div class="flex items-center gap-2">
          <Checkbox v-model="checked" binary />
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
          Total Customers:
          {{ calculateCustomerTotal(slotProps.data.representative.name) }}
        </div>
      </template> -->
    </DataTable>

    <div class="cart-footer">
      <div class="flex justify-between">
        <div class="flex items-center gap-4">
          <Checkbox v-model="checked" binary />
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

<script setup>
import { ref, onMounted } from "vue";

onMounted(() => {
  customers.value = [
    {
      id: 1033,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Ukraine",
        code: "ua",
      },
      company: 99999,
      date: "2019-08-08",
      status: "proposal",
      verified: true,
      activity: 85,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 91201,
    },
    {
      id: 1034,
      name: "Alishia Sergi",
      country: {
        name: "Qatar",
        code: "qa",
      },
      company: 99999,
      date: "2018-05-19",
      status: "negotiation",
      verified: false,
      activity: 46,
      representative: {
        name: "Ivan Magalhaes",
        image: "ivanmagalhaes.png",
      },
      balance: 12237,
    },
    {
      id: 1035,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Cameroon",
        code: "cm",
      },
      company: 99999,
      date: "2015-02-12",
      status: "qualified",
      verified: true,
      activity: 32,
      representative: {
        name: "Onyama Limba",
        image: "onyamalimba.png",
      },
      balance: 34072,
    },

    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
    {
      id: 1038,
      name: "Áo khoác nam ROWAY chất liệu kaki cao cấp | Jacket Kaki",
      country: {
        name: "Paraguay",
        code: "py",
      },
      company: 99999,
      date: "2019-09-17",
      status: "qualified",
      verified: true,
      activity: 25,
      representative: {
        name: "Bernardo Dominic",
        image: "bernardodominic.png",
      },
      balance: 75502,
    },
  ];
});

const customers = ref();
const selectedProduct = ref([]);
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

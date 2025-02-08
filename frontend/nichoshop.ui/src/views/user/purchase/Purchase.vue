<template>
  <div class="card">
    <Tabs @update:value="onChangeTab" :value="-1">
      <TabList>
        <Tab v-for="tab in tabs" :key="tab.title" :value="tab.value">{{
          tab.title
        }}</Tab>
      </TabList>
      <TabPanels>
        <TabPanel v-for="tab in tabs" :key="tab.value" :value="tab.value">
          <order-card v-for="item in items" :order="item" />
          <div class="text-center">
            <button @click="loadMore" class="button-primary button m-auto">
              Load more
            </button>
          </div>
        </TabPanel>
      </TabPanels>
    </Tabs>
  </div>
</template>

<script>
import OrderCard from "./OrderCard.vue";
import { ref, onMounted, getCurrentInstance } from "vue";
import baseList from "@/views/base/baseList.js";
export default {
  extends: baseList,

  components: {
    OrderCard,
  },
  setup() {
    const autoLoadGrid = true;
    const { proxy } = getCurrentInstance();
    const module = "moduleOrder";
    const tabs = ref([
      {
        title: "Tất cả",
        value: -1,
      },
      {
        title: "Chờ xác nhận",
        value: proxy.$nicho.enumeration.OrderStatus.PendingApproval,
      },
      {
        title: "Chờ lấy hàng",
        value: proxy.$nicho.enumeration.OrderStatus.Approved,
      },
      {
        title: " Chờ giao hàng",
        value: proxy.$nicho.enumeration.OrderStatus.AwaitingShipment,
      },
      {
        title: "Đã giao",
        value: proxy.$nicho.enumeration.OrderStatus.Shipped,
      },
      {
        title: " Đã hủy",
        value: proxy.$nicho.enumeration.OrderStatus.Canceled,
      },
      { title: " Trả hàng/hoàn tiền", value: 6 },
    ]);

    const onChangeTab = (value) => {
      proxy.gridInfo.filters = proxy.gridInfo.filters || {};
      proxy.gridInfo.filters = {
        ...proxy.gridInfo.filters,
        status: { value, Comparison: 0 },
      };
      proxy.reload();
    };
    return { module, autoLoadGrid, tabs, onChangeTab };
  },
};
</script>
